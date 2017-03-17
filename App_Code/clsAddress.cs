using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsAnAddress
/// </summary>
public class clsAddress
{

    //houseNo private member variable
    private string houseNo;
    //street private member variable
    private string street;
    //town private member variable
    private string town;
    //postCode private member variable
    private string postCode;
    //countyCode private member variable
    private Int32 countyCode;
    //dateAdded private member variable
    private DateTime dateAdded;
    //active private member variable
    private Boolean active;
    //data member for data connection
    private clsDataConnection dBConnection = new clsDataConnection();

    //addressNo private member variable
    private Int32 addressNo;

    //AddressNo public property
    public Int32 AddressNo
    {
        get
        {
            //this line of code sends data out of the property
            return addressNo;
        }
        set
        {
            //this line of code allows data into the property
            addressNo = value;
        }
    }

    //HouseNo public property
    public string HouseNo
    {
        get
        {
            return houseNo;
        }
        set
        {
            houseNo = value;
        }
    }

    //Town public property
    public string Town
    {
        get
        {
            return town;
        }
        set
        {
            town = value;
        }
    }

    //Street public property
    public string Street
    {
        get
        {
            return street;
        }
        set
        {
            street = value;
        }
    }

    //PostCode public property
    public string PostCode
    {
        get
        {
            return postCode;
        }
        set
        {
            postCode = value;
        }
    }

    //CountyCode public property
    public Int32 CountyCode
    {
        get
        {
            return countyCode;
        }
        set
        {
            countyCode = value;
        }
    }

    //DateAdded public property
    public DateTime DateAdded
    {
        get
        {
            return dateAdded;
        }
        set
        {
            dateAdded = value;
        }
    }

    //Active public property
    public Boolean Active
    {
        get
        {
            return active;
        }
        set
        {
            active = value;
        }
    }

    //function for the public validation method
    public string Valid(string houseNo,
                        string street,
                        string town,
                        string postCode,
                        string dateAdded)
    ///this function accepts 5 parameters for validation
    ///the function returns a string containing any error message
    ///if no errors found then a blank string is returned
    {
        //var to store the error message
        string ErrMsg = "";
        //check the min length of the house no
        if (houseNo.Length == 0)
        {
            //set the error messsage
            ErrMsg = ErrMsg + "House no is blank. ";
        }
        //check the max length of the house no
        if (houseNo.Length > 6)
        {
            //set the error messsage
            ErrMsg = ErrMsg + "House no must be less than 6 characters. ";
        }
        //check the min length of the street
        if (street.Length == 0)
        {
            //set the error messsage
            ErrMsg = ErrMsg + "Street is blank. ";
        }
        //check the max length of the street
        if (street.Length > 50)
        {
            //set the error messsage
            ErrMsg = ErrMsg + "Street must be less than 50 characters. ";
        }
        //check the min length for the town
        if (town.Length == 0)
        {
            //set the error messsage
            ErrMsg = ErrMsg + "Town is blank. ";
        }
        //check the max length for the town
        if (town.Length > 50)
        {
            //set the error messsage
            ErrMsg = ErrMsg + "Town must be less than 50 characters. ";
        }
        //check the min length for the post code
        if (postCode.Length == 0)
        {
            //set the error messsage
            ErrMsg = ErrMsg + "Post Code is blank. ";
        }
        //check the max length for the post code
        if (postCode.Length > 9)
        {
            //set the error messsage
            ErrMsg = ErrMsg + "Post Code must be less than 9 characters. ";
        }
        //test if the date is valid
        try//try the operation
        {
            //var to store the date
            DateTime Temp;
            //assign the date to the temporary var
            Temp = Convert.ToDateTime(dateAdded);
        }
        catch//if it failed report an error
        {
            //set the error messsage
            ErrMsg = ErrMsg + "Date added is not valid. ";
        }
        //if there were no errors
        if (ErrMsg == "")
        {
            //return a blank string
            return "";
        }
        else//otherwise
        {
            //return the errors string value
            return "There were the following errors : " + ErrMsg;
        }
    }

    //function for the find public method
    public Boolean Find(Int32 AddressNo)
    {
        //initialise the DBConnection
        dBConnection = new clsDataConnection();
        //add the address no parameter
        dBConnection.AddParameter("@AddressNo", AddressNo);
        //execute the query
        dBConnection.Execute("sproc_tblAddress_FilterByAddressNo");
        //if the record was found
        if (dBConnection.Count == 1)
        {
            //get the address no
            addressNo = Convert.ToInt32(dBConnection.DataTable.Rows[0]["AddressNo"]);
            //get the house no
            houseNo = Convert.ToString(dBConnection.DataTable.Rows[0]["HouseNo"]);
            //get the street
            street = Convert.ToString(dBConnection.DataTable.Rows[0]["Street"]);
            //get the town
            town = Convert.ToString(dBConnection.DataTable.Rows[0]["Town"]);
            //get the post code
            postCode = Convert.ToString(dBConnection.DataTable.Rows[0]["PostCode"]);
            //get the county code
            countyCode = Convert.ToInt32(dBConnection.DataTable.Rows[0]["CountyCode"]);
            //get the date added
            dateAdded = Convert.ToDateTime(dBConnection.DataTable.Rows[0]["DateAdded"]);
            //get the acive state
            try
            {
                active = Convert.ToBoolean(dBConnection.DataTable.Rows[0]["Active"]);
            }
            catch
            {
                active = true;
            }
            //return success
            return true;
        }
        else
        {
            //return failure
            return false;
        }
    }

}