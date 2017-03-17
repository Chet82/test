using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //this function handles the load event for the page
    protected void Page_Load(object sender, EventArgs e)
    {
        //clear any existing error messages
        lblError.Text = "";
        //if this is the first time the page has been displayed
        if (IsPostBack == false)
        {
            //populate the list and display the number of records found
            lblError.Text = DisplayAddresses("") + " records in the database";
        }
    }

    //event handler for the add button
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //store -1 into the session object to indicate this is a new record
        Session["AddressNo"] = -1;
        //redirect to the data entry page
        Response.Redirect("AnAddress.aspx");
    }

    //event handler for the edit button
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //var to store the primary key value of the record to be edited
        Int32 AddressNo;
        //if a record has been selected from the list
        if (lstAddresses.SelectedIndex != -1)
        {
            //get the primary key value of the record to edit
            AddressNo = Convert.ToInt32(lstAddresses.SelectedValue);
            //store the data in the session object
            Session["AddressNo"] = AddressNo;
            //redirect to the edit page
            Response.Redirect("AnAddress.aspx");
        }
        else//if no record has been selected
        {
            //display an error
            lblError.Text = "Please select a record to delete from the list";
        }
    }

    //event handler for the delete button
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //var to store the primary key value of the record to be deleted
        Int32 AddressNo;
        //if a record has been selected from the list
        if (lstAddresses.SelectedIndex != -1)
        {
            //get the primary key value of the record to delete
            AddressNo = Convert.ToInt32(lstAddresses.SelectedValue);
            //store the data in the session object
            Session["AddressNo"] = AddressNo;
            //redirect to the delete page
            Response.Redirect("Delete.aspx");
        }
        else //if no record has been selected
        {
            //display an error
            lblError.Text = "Please select a record to delete from the list";
        }
    }

    //event handler for the apply button
    protected void btnApply_Click(object sender, EventArgs e)
    {
        //declare var to store the record count
        Int32 RecordCount;
        //assign the results of the DisplayAddresses function to the record count var
        RecordCount = DisplayAddresses(txtPostCode.Text);
        //display the number of records found
        lblError.Text = RecordCount + " records found";
    }

    //event hanlder for the display all button
    protected void btnDisplayAll_Click(object sender, EventArgs e)
    {
        //var to store the record count
        Int32 RecordCount;
        //assign the results of the DisplayAddresses function to the record count var
        RecordCount = DisplayAddresses("");
        //display the number of records found
        lblError.Text = RecordCount + " records in the database";
        //clear the post code filter text box
        txtPostCode.Text = "";
    }

    //function use to populate the list box
    Int32 DisplayAddresses(string PostCodeFilter)
    {
        ///this function accepts one parameter - the post code to filter the list on
        ///it populates the list box with data from the middle layer class
        ///it returns a single value, the number of records found

        //create a new instance of the clsAddress
        clsAddressCollection MyAddressBook = new clsAddressCollection();
        //var to store the count of records
        Int32 RecordCount;
        //var to store the house no
        string HouseNo;
        //var to store the street name
        string Street;
        //var to store the post code
        string PostCode;
        //var to store the primary key value
        string AddressNo;
        //var to store the index
        Int32 Index = 0;
        //clear the list of any existing items
        lstAddresses.Items.Clear();
        //call the filter by post code method
        MyAddressBook.FilterByPostCode(PostCodeFilter);
        //get the count of records found
        RecordCount = MyAddressBook.Count;
        //loop through each record found using the index to point to each record in the data table
        while (Index < RecordCount)
        {
            //get the house no from the query results
            HouseNo = Convert.ToString(MyAddressBook.AddressList[Index].HouseNo);
            //get the street from the query results
            Street = Convert.ToString(MyAddressBook.AddressList[Index].Street);
            //get the post code from the query results
            PostCode = Convert.ToString(MyAddressBook.AddressList[Index].PostCode);
            //get the address no from the query results
            AddressNo = Convert.ToString(MyAddressBook.AddressList[Index].AddressNo);
            //set up a new object of class list item 
            ListItem NewItem = new ListItem(HouseNo + " " + Street + " " + PostCode, AddressNo);
            //add the new item to the list
            lstAddresses.Items.Add(NewItem);
            //increment the index
            Index++;
        }
        //return the number of records found
        return RecordCount;
    } 

}