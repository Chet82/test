using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Delete : System.Web.UI.Page
{
    //var to store the primary key value of the record to be deleted
    Int32 AddressNo;

    //event handler for the load event
    protected void Page_Load(object sender, EventArgs e)
    {
        //get the number of the address to be deleted from the session object
        AddressNo = Convert.ToInt32(Session["AddressNo"]);
    }

    //event handler for the yes button
    protected void btnYes_Click(object sender, EventArgs e)
    {
        //create instance of clsAddress called AnAddress used to control addresses in the database
        clsAddressCollection MyAddressBook = new clsAddressCollection();
        //find the record to be deleted
        MyAddressBook.ThisAddress.Find(AddressNo);
        //call the delete method of the object
        MyAddressBook.Delete();
        //redirect back to the main page
        Response.Redirect("Default.aspx");
    }

    //event handler for the no button
    protected void btnNo_Click(object sender, EventArgs e)
    {
        //redirect back to the main page
        Response.Redirect("Default.aspx");
    }
    protected void txtAddressNo_TextChanged(object sender, EventArgs e)
    {

    }
}