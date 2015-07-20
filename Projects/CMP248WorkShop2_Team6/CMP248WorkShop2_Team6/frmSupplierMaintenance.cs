/*
 * Author : Sunny Xie
 * Date: July 20, 2015
 * Usage: File to add/modify/delete/get supplier details, and add new Products to specific supplier.
 * 
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelData;

namespace CMP248WorkShop2_Team6
{
    public partial class frmSupplierMaintenance : Form
    {
        // variables for drag and drop
        private int indexOfItemUnderMouseToDrag;
        private int indexOfItemUnderMouseToDrop;

        private Rectangle dragBoxFromMouseDown;
        private Point screenOffset;

        private Cursor MyNoDropCursor;
        private Cursor MyNormalCursor;

        public frmSupplierMaintenance()
        {
            InitializeComponent();
        }
        private Supplier supplier;
        
        //Method to get the supplier details by passing supplierid
        private void btnGetSupplier_Click(object sender, EventArgs e)
        {
            if (Validator.IsPresent(txtSupplierId) &&
                Validator.IsInt32(txtSupplierId) &&
                Validator.IsPositiveOverZero(txtSupplierId))
            {
                //get supplier id
                int supplierId = Convert.ToInt32(txtSupplierId.Text);
                //Method to get the supplier details by passing supplier id
                this.GetSupplier(supplierId);
                if (supplier == null)
                {
                    MessageBox.Show("No Supplier found with this ID. Try again.", "SupplierId not found");

                    this.ClearControls();
                }
                else
                {
                    this.DisplaySupplier();
                    DisplaySupplierProducts(supplierId);

                    btnModifyProd.Enabled = true;
                }
                lsbProducts.AllowDrop = true;
                lsbAllProducts.AllowDrop = true;

                // hide all the products list.
                lsbAllProducts.Visible = false;
                btnSave.Enabled = false;
                lblMsg.Visible = false;
            }
        }

        //Method to connect with dabase layer to get the supplier details
        private void GetSupplier(int supplierId)
        {
            supplier = SupplierDB.GetSupplier(supplierId);
        }

        //Method to clear all supplier fields
        private void ClearControls()
        {
            txtSupplierId.Text = "";
            txtSupName.Text = "";
            btnSave.Enabled = false;
            btnModifyProd.Enabled = false;

            lsbProducts.Items.Clear();
        }

        //Method to display supplier details
        private void DisplaySupplier()
        {
            txtSupplierId.Text = supplier.SupplierId.ToString(); ;
            txtSupName.Text = supplier.SupName;
            btnModify.Enabled = true;
            btnDelete.Enabled = true;
            btnModifyProd.Enabled = true;
        }     

        // display all the products that this supplier supply. 
        private void DisplaySupplierProducts(int supplierId)
        {
            lsbProducts.Items.Clear();
            List<Product> products = SupplierDB.GetProductsBySupplierId(supplierId);
            foreach (Product p in products)
            {
                lsbProducts.Items.Add(p.ProductId.ToString() + "   " + p.ProdName);
            }
        }

        // display all the possible products. 
        private void DisplayAllTheProducts()
        {
            lsbAllProducts.Items.Clear();
            List<Product> products = ProductDB.GetAllProducts();
            foreach (Product p in products)
            {
                lsbAllProducts.Items.Add(p.ProductId.ToString() + "   " + p.ProdName);
            }
        }

        //Method to add supplier
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifySupplier addSupplierForm = new frmAddModifySupplier();
            addSupplierForm.addSupplier = true;
            DialogResult result = addSupplierForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                supplier = addSupplierForm.supplier;
                txtSupplierId.Text = supplier.SupplierId.ToString();
                this.DisplaySupplier();
            }
        }

        //Method to modify the existing supplier details
        private void btnModify_Click(object sender, EventArgs e)
        {
            // if no supplier found, return.
            if (supplier == null)
            {
                return;
            }

            frmAddModifySupplier modifySupplierForm = new frmAddModifySupplier();
            modifySupplierForm.addSupplier = false;
            modifySupplierForm.supplier = supplier;
            DialogResult result = modifySupplierForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                supplier = modifySupplierForm.supplier;
                if (supplier != null)
                {
                    this.DisplaySupplier();
                }
            }
            else if (result == DialogResult.Retry)
            {
                this.GetSupplier(supplier.SupplierId);
                if (supplier != null)
                    this.DisplaySupplier();
                else
                    this.ClearControls();
            }
        }

        //Method to delete the supplier
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // if no supplier found, return.
            if (supplier == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Delete " + supplier.SupplierId+"?" ,
                                "Confirm Delete", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (!SupplierDB.DeleteSupplier(supplier))
                    {
                        MessageBox.Show("Another user has updated that supplier", "Database Error");
                        this.GetSupplier(supplier.SupplierId);
                        if (supplier != null)
                            this.DisplaySupplier();
                        else
                            this.ClearControls();
                    }
                    else
                        this.ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,ex.GetType().ToString());
                }
            }
        }

        //Method to close the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModifyProd_Click(object sender, EventArgs e)
        {
            lsbAllProducts.Visible = true;
            lblMsg.Visible = true;
            btnSave.Enabled = true ;
            DisplayAllTheProducts();
        }

        private void lsbAllProducts_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {

                // If the mouse moves outside the rectangle, start the drag. 
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Create custom cursors for the drag-and-drop operation. 
                    try
                    {
                        MyNormalCursor = new Cursor("3dwarro.cur");
                        MyNoDropCursor = new Cursor("3dwno.cur");

                    }
                    catch
                    {
                        // An error occurred while attempting to load the cursors, so use 
                        // standard cursors.
                        // UseCustomCursorsCheck.Checked = false;
                    }
                    finally
                    {

                        // The screenOffset is used to account for any desktop bands  
                        // that may be at the top or left side of the screen when  
                        // determining when to cancel the drag drop operation.
                        screenOffset = SystemInformation.WorkingArea.Location;

                        // Proceed with the drag-and-drop, passing in the list item.                    
                        DragDropEffects dropEffect = lsbAllProducts.DoDragDrop(lsbAllProducts.Items[indexOfItemUnderMouseToDrag].ToString(), DragDropEffects.All | DragDropEffects.Link);

                        // If the drag operation was a move then remove the item. 
                        if (dropEffect == DragDropEffects.Move)
                        {
                            lsbAllProducts.Items.RemoveAt(indexOfItemUnderMouseToDrag);

                            // Selects the previous item in the list as long as the list has an item. 
                            if (indexOfItemUnderMouseToDrag > 0)
                                lsbAllProducts.SelectedIndex = indexOfItemUnderMouseToDrag - 1;

                            else if (lsbAllProducts.Items.Count > 0)
                                // Selects the first item.
                                lsbAllProducts.SelectedIndex = 0;
                        }

                      
                    }
                }
            }
        }

        private void lsbProducts_DragDrop(object sender, DragEventArgs e)
        {
            // Ensure that the list item index is contained in the data. 
            if (e.Data.GetDataPresent(typeof(System.String)))
            {

                Object item = (object)e.Data.GetData(typeof(System.String));

                // Perform drag-and-drop, depending upon the effect. 
                if (e.Effect == DragDropEffects.Copy ||
                    e.Effect == DragDropEffects.Move)
                {
                    if (IsItemsDuplicated(lsbProducts, item))
                    {
                        return;
                    }

                    // Insert the item. 
                    if (indexOfItemUnderMouseToDrop != ListBox.NoMatches)
                        lsbProducts.Items.Insert(indexOfItemUnderMouseToDrop, item);
                    else
                        lsbProducts.Items.Add(item);

                }
            }
            // Reset the label text.
            //DropLocationLabel.Text = "None";
        }

        private void lsbAllProducts_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            // Cancel the drag if the mouse moves off the form.
            ListBox lb = sender as ListBox;

            if (lb != null)
            {

                Form f = lb.FindForm();

                // Cancel the drag if the mouse moves off the form. The screenOffset 
                // takes into account any desktop bands that may be at the top or left 
                // side of the screen. 
                if (((Control.MousePosition.X - screenOffset.X) < f.DesktopBounds.Left) ||
                    ((Control.MousePosition.X - screenOffset.X) > f.DesktopBounds.Right) ||
                    ((Control.MousePosition.Y - screenOffset.Y) < f.DesktopBounds.Top) ||
                    ((Control.MousePosition.Y - screenOffset.Y) > f.DesktopBounds.Bottom))
                {

                    e.Action = DragAction.Cancel;
                }
            }
        }

        private void lsbAllProducts_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            indexOfItemUnderMouseToDrag = lsbAllProducts.IndexFromPoint(e.X, e.Y);

            if (indexOfItemUnderMouseToDrag != ListBox.NoMatches)
            {

                // Remember the point where the mouse down occurred. The DragSize indicates 
                // the size that the mouse can move before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being 
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)), dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void lsbProducts_DragEnter(object sender, DragEventArgs e)
        {
            // Reset the label text.
            DropLocationLabel.Text = "None";
        }

        private void lsbProducts_DragOver(object sender, DragEventArgs e)
        {
            // Determine whether string data exists in the drop data. If not, then 
            // the drop effect reflects that the drop cannot occur. 
            if (!e.Data.GetDataPresent(typeof(System.String)))
            {

                e.Effect = DragDropEffects.None;
               // DropLocationLabel.Text = "None - no string data.";
                return;
            }

            // Set the effect based upon the KeyState. 
            if ((e.KeyState & (8 + 32)) == (8 + 32) &&
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
            {
                // KeyState 8 + 32 = CTL + ALT 

                // Link drag-and-drop effect.
                e.Effect = DragDropEffects.Link;

            }
            else if ((e.KeyState & 32) == 32 &&
              (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
            {

                // ALT KeyState for link.
                e.Effect = DragDropEffects.Link;

            }
            else if ((e.KeyState & 4) == 4 &&
              (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {

                // SHIFT KeyState for move.
                e.Effect = DragDropEffects.Move;

            }
            else if ((e.KeyState & 8) == 8 &&
              (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {

                // CTL KeyState for copy.
                e.Effect = DragDropEffects.Copy;

            }
            else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {

                // By default, the drop action should be move, if allowed.
                e.Effect = DragDropEffects.Move;

            }
            else
                e.Effect = DragDropEffects.None;

            // Get the index of the item the mouse is below.  

            // The mouse locations are relative to the screen, so they must be  
            // converted to client coordinates.

            indexOfItemUnderMouseToDrop =
                lsbProducts.IndexFromPoint(lsbProducts.PointToClient(new Point(e.X, e.Y)));

            // Updates the label text. 
          
        }

        private void frmSupplierMaintenance_Load(object sender, EventArgs e)
        {
            // for testing
            // txtSupplierId.Text = "80";
            // btnGetSupplier.PerformClick();
            lblMsg.Visible = false;
        }

        private void lsbAllProducts_MouseUp(object sender, MouseEventArgs e)
        {
            // Reset the drag rectangle when the mouse button is raised.
            dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void lsbProducts_DragLeave(object sender, EventArgs e)
        {
            DropLocationLabel.Text = "None";
        }

        private void lsbAllProducts_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void lsbProducts_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {

                // If the mouse moves outside the rectangle, start the drag. 
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Create custom cursors for the drag-and-drop operation. 
                    try
                    {
                        MyNormalCursor = new Cursor("3dwarro.cur");
                        MyNoDropCursor = new Cursor("3dwno.cur");

                    }
                    catch
                    {
                        // An error occurred while attempting to load the cursors, so use 
                    }
                    finally
                    {

                        // The screenOffset is used to account for any desktop bands  
                        // that may be at the top or left side of the screen when  
                        // determining when to cancel the drag drop operation.
                        screenOffset = SystemInformation.WorkingArea.Location;

                        // Proceed with the drag-and-drop, passing in the list item.                    
                        DragDropEffects dropEffect = lsbProducts.DoDragDrop(lsbProducts.Items[indexOfItemUnderMouseToDrag].ToString(), DragDropEffects.All | DragDropEffects.Link);

                        // If the drag operation was a move then remove the item. 
                        if (dropEffect == DragDropEffects.Move)
                        {
                            lsbProducts.Items.RemoveAt(indexOfItemUnderMouseToDrag);

                            // Selects the previous item in the list as long as the list has an item. 
                            if (indexOfItemUnderMouseToDrag > 0)
                                lsbProducts.SelectedIndex = indexOfItemUnderMouseToDrag - 1;

                            else if (lsbProducts.Items.Count > 0)
                                // Selects the first item.
                                lsbProducts.SelectedIndex = 0;
                        }


                    }
                }
            }
        }

        private void lsbProducts_MouseUp(object sender, MouseEventArgs e)
        {
            dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void lsbAllProducts_DragOver(object sender, DragEventArgs e)
        {
              // Determine whether string data exists in the drop data. If not, then 
            // the drop effect reflects that the drop cannot occur. 
            if (!e.Data.GetDataPresent(typeof(System.String))) {

                e.Effect = DragDropEffects.None;
                DropLocationLabel.Text = "None - no string data.";
                return;
            }

            // Set the effect based upon the KeyState. 
            if ((e.KeyState & (8+32)) == (8+32) && 
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link) {
                // KeyState 8 + 32 = CTL + ALT 

                // Link drag-and-drop effect.
                e.Effect = DragDropEffects.Link;

            } else if ((e.KeyState & 32) == 32 && 
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link) {

                // ALT KeyState for link.
                e.Effect = DragDropEffects.Link;

            } else if ((e.KeyState & 4) == 4 && 
                (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move) {

                // SHIFT KeyState for move.
                e.Effect = DragDropEffects.Move;

            } else if ((e.KeyState & 8) == 8 && 
                (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) {

                // CTL KeyState for copy.
                e.Effect = DragDropEffects.Copy;

            } else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)  {

                // By default, the drop action should be move, if allowed.
                e.Effect = DragDropEffects.Move;

            } else
                e.Effect = DragDropEffects.None;

            // Get the index of the item the mouse is below.  

            // The mouse locations are relative to the screen, so they must be  
            // converted to client coordinates.

            indexOfItemUnderMouseToDrop =
                lsbAllProducts.IndexFromPoint(lsbAllProducts.PointToClient(new Point(e.X, e.Y)));

           
        }

        private void lsbAllProducts_DragDrop(object sender, DragEventArgs e)
        {
            // Ensure that the list item index is contained in the data. 
            if (e.Data.GetDataPresent(typeof(System.String)))
            {

                Object item = (object)e.Data.GetData(typeof(System.String));

                // Perform drag-and-drop, depending upon the effect. 
                if (e.Effect == DragDropEffects.Copy ||
                    e.Effect == DragDropEffects.Move)
                {
                    if (IsItemsDuplicated(lsbAllProducts, item))
                    {
                        return;
                    }

                    // Insert the item. 
                    if (indexOfItemUnderMouseToDrop != ListBox.NoMatches)
                        lsbAllProducts.Items.Insert(indexOfItemUnderMouseToDrop, item);
                    else
                        lsbAllProducts.Items.Add(item);

                }
            }
            // Reset the label text.
            DropLocationLabel.Text = "None";

        }

        // check for duplicated items
        private bool IsItemsDuplicated(ListBox lsbProducts, Object item) 
        {
            foreach (Object oo in lsbProducts.Items)
            {
                if (oo.ToString() == item.ToString())
                {
                    return true;
                }
            }

            return false;
        }

        private void lsbProducts_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            // Cancel the drag if the mouse moves off the form.
            ListBox lb = sender as ListBox;

            if (lb != null)
            {

                Form f = lb.FindForm();

                // Cancel the drag if the mouse moves off the form. The screenOffset 
                // takes into account any desktop bands that may be at the top or left 
                // side of the screen. 
                if (((Control.MousePosition.X - screenOffset.X) < f.DesktopBounds.Left) ||
                    ((Control.MousePosition.X - screenOffset.X) > f.DesktopBounds.Right) ||
                    ((Control.MousePosition.Y - screenOffset.Y) < f.DesktopBounds.Top) ||
                    ((Control.MousePosition.Y - screenOffset.Y) > f.DesktopBounds.Bottom))
                {

                    e.Action = DragAction.Cancel;
                }
            }
        }

        private void lsbProducts_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            indexOfItemUnderMouseToDrag = lsbProducts.IndexFromPoint(e.X, e.Y);

            if (indexOfItemUnderMouseToDrag != ListBox.NoMatches)
            {

                // Remember the point where the mouse down occurred. The DragSize indicates 
                // the size that the mouse can move before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being 
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)), dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void lsbAllProducts_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                List<int> new_products = new List<int>();
                foreach (Object oo in lsbProducts.Items)
                {
                    string f = oo.ToString();
                    string[] cc = f.Split(' ');
                    foreach (string s in cc)
                    {
                        if (s.Trim() != "")
                            new_products.Add(Convert.ToInt32(s));
                        break;
                    }
                }

                //get supplier id
                int supplierId = Convert.ToInt32(txtSupplierId.Text);
                SupplierDB.UpdateSupplierProductList(supplierId, new_products);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("A Format exception occurs " + ex.Message, ex.GetType().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            
        }
    }
}
