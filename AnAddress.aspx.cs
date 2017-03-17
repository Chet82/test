using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AnAddress : System.Web.UI.Page
{
    //var to store the address number
    Int32 AddressNo;

    //event handler for the page load event
    protected void Page_Load(object sender, EventArgs e)
    {
        //get the address no from the session object
        AddressNo = Convert.ToInt32(Session["AddressNo"]);
        //if this is the first time the page has loaded
        if (IsPostBack == false)
        {
            //populate the counties drop down
            DisplayCounties();
            //if we are not adding a new record
            if (AddressNo != -1)
            {
                //update the fields on the page with the data from the record
                DisplayAddress();
            }
            else//this is a new record
            {
                //set the date to todays date
                txtDateAdded.Text = DateTime.Today.Date.ToString("dd/MM/yyyy"); ;
            }
        }
    }

    //this is the event handler for the cancel button
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //redirect to the main page
        Response.Redirect("Default.aspx");
    }

    //event handler for the ok button
    protected void btnOK_Click(object sender, EventArgs e)
    {
        //var to store any error messages
        string ErrorMsg;
        //create an instance of the address class
        clsAddressCollection AddressBook = new clsAddressCollection();
        //use the objects validation method to test the data
        ErrorMsg = AddressBook.ThisAddress.Valid(txtHouseNo.Text, txtStreet.Text, txtTown.Text, txtPostCode.Text, txtDateAdded.Text);
        //if there is no error message
        if (ErrorMsg == "")
        {
            //if we are adding a new record
            if (AddressNo == -1)
            {
                //set the house number property of the object
                AddressBook.ThisAddress.HouseNo = txtHouseNo.Text;
                //set the street property
                AddressBook.ThisAddress.Street = txtStreet.Text;
                //set the town property
                AddressBook.ThisAddress.Town = txtTown.Text;
                //set the post code property
                AddressBook.ThisAddress.PostCode = txtPostCode.Text;
                //set the data added
                AddressBook.ThisAddress.DateAdded = Convert.ToDateTime(txtDateAdded.Text);
                //set the county code
                AddressBook.ThisAddress.CountyCode = Convert.ToInt32(ddlCounty.SelectedValue);
                //set the active property
                AddressBook.ThisAddress.Active = chkActive.Checked;
                //invoke the add method
                AddressBook.Add();
            }
            else//this is an existing record to update
            {
                //find the record to be updated
                AddressBook.ThisAddress.Find(AddressNo);
                //set the house no property
                AddressBook.ThisAddress.HouseNo = txtHouseNo.Text;
                //set the street property
                AddressBook.ThisAddress.Street = txtStreet.Text;
                //set the town property
                AddressBook.ThisAddress.Town = txtTown.Text;
                //set the post code property
                AddressBook.ThisAddress.PostCode = txtPostCode.Text;
                //set the date added property
                AddressBook.ThisAddress.DateAdded = Convert.ToDateTime(txtDateAdded.Text);
                //set the county code property
                AddressBook.ThisAddress.CountyCode = Convert.ToInt32(ddlCounty.SelectedValue);
                //set the active property
                AddressBook.ThisAddress.Active = chkActive.Checked;
                //update the record with the new data
                AddressBook.Update();
            }
            //all done so redirect back to the main page
            Response.Redirect("Default.aspx");
        }
        else//there are errors
        {
            //display the error message
            lblError.Text = ErrorMsg;
        }
    }

    //this function is used to populate the counties drop down list
    Int32 DisplayCounties()
    {
        //create an instance of the county class
        clsCountyCollection Counties = new clsCountyCollection();
        //var to store the county number primary key
        string CountyNo;
        //var to store the name of the county
        string County;
        //var to store the index for the loop
        Int32 Index = 0;
        //while the index is less that the number of records to process
        while (Index < Counties.Count)
        {
            //get the county number from the database
            CountyNo = Convert.ToString(Counties.AllCounties[Index].CountyNo);
            //get teh county name from the database
            County = Counties.AllCounties[Index].County;
            //set up the new row to be added to the list
            ListItem NewCounty = new ListItem(County, CountyNo);
            //add the new row to the list
            ddlCounty.Items.Add(NewCounty);
            //increment the index to the next record
            Index++;
        }
        //return the number of records found
        return Counties.Count;
    }

    //this function displays the data for an address on the web form
    void DisplayAddress()
    {
        //create an instance of the addresses class
        clsAddressCollection MyAddressBook = new clsAddressCollection();
        //find the record we want to display
        MyAddressBook.ThisAddress.Find(AddressNo);
        //display the house no
        txtHouseNo.Text = MyAddressBook.ThisAddress.HouseNo;
        //diaplay the street
        txtStreet.Text = MyAddressBook.ThisAddress.Street;
        //display the town
        txtTown.Text = MyAddressBook.ThisAddress.Town;
        //display the post code
        txtPostCode.Text = MyAddressBook.ThisAddress.PostCode;
        //diaply the data added
        txtDateAdded.Text = MyAddressBook.ThisAddress.DateAdded.ToString("dd/MM/yyyy");
        //set the drop down list to display the county
        ddlCounty.SelectedValue = Convert.ToString(MyAddressBook.ThisAddress.CountyCode);
        //display the active state
        chkActive.Checked = MyAddressBook.ThisAddress.Active;
    }
}