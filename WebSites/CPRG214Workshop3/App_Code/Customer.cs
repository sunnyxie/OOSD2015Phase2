/*
 * Author : Geetha Muniswamy
 * Date : June 29, 2015
 * Description : File contains Customer details
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Customer
{
    public Customer() { }
        
    //added public variables for Customers
    public int CustomerId { set; get; }
    public string CustFirstName { set; get; }
    public string CustLastName { set; get; }
    public string CustName { set; get; }
    public string CustAddress { set; get; }
    public string CustCity { set; get; }
    public string CustProv { set; get; }
    public string CustPostal { set; get; }
    public string CustCountry { set; get; }
    public string CustHomePhone { set; get; }
    public string CustBusPhone { set; get; }
    public string CustEmail { set; get; }
    public int AgentId { set; get; }

    //Constructors having customers details
    /*
    public Customer(int cid,string fn, string ln, string addr, string city, string prov, 
        string postal, string country, string homeph, string busph, string email, int aid)
    {
        CustomerId = cid;
        CustFirstName = fn;
        CustLastName = ln;
        CustAddress = addr;
        CustCity = city;
        CustProv = prov;
        CustPostal = postal;
        CustCountry = country;
        CustHomePhone = homeph;
        CustBusPhone = busph;
        CustEmail = email;
        AgentId = aid;
    }
    */

    //ToString method to display the customer details
    public override string ToString()
    {
        return "customerId : " + CustomerId + "\n\t" +
            "CustomerFirstName : " + CustFirstName + "\n\t" +
            "CustomerLastName : " + CustLastName + "\n\t" +
            "CustomerAddress : " + CustAddress + "\n\t" +
            "CustCity : " + CustCity + "\n\t" +
            "CustProv : " + CustProv + "\n\t" +
            "CustPostal : " + CustPostal + "\n\t" +
            "CustCountry : " + CustCountry + "\n\t" +
            "CustHomePhone : " + CustHomePhone + "\n\t" +
            "CustBusPhone : " + CustBusPhone + "\n\t" +
            "CustEmail : " + CustEmail + "\n\t" +
            "AgentId : " + AgentId;
    }

    //display customer address
    /*
    public string CustomerAddress()
    {
        return CustAddress + ", " + CustCity + ", " + CustProv + ", " + CustPostal + ", " + CustCountry;
    }
    */
}

