using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class clsAddressCollection
{
    ///this class contains code allowing us to manipulate address

    //private data members
    //create a null instance of the class clsDataConnection with class level scope
    clsDataConnection dBConnection;
    //private data member for the current address
    clsAddress thisAddress = new clsAddress();



    public clsAddress ThisAddress
    {
        get
        {
            return thisAddress;
        }
        set
        {
            thisAddress = value;
        }
    }

    //function for the public Add method
    public Int32 Add()
    {
        //this function adds a new record to the database returning the primary key value of the new record

        //var to store the primary key value of the new record
        Int32 PrimaryKey;
        //create a connection to the database
        clsDataConnection NewAddress = new clsDataConnection();
        //add the house number parameter
        NewAddress.AddParameter("@HouseNo", thisAddress.HouseNo);
        //add the street parameter
        NewAddress.AddParameter("@Street", thisAddress.Street);
        //add the town parameter
        NewAddress.AddParameter("@Town", thisAddress.Town);
        //add the post code parameter
        NewAddress.AddParameter("@PostCode", thisAddress.PostCode);
        //add the county code parameter
        NewAddress.AddParameter("@CountyCode", thisAddress.CountyCode);
        //add the data added parameter
        NewAddress.AddParameter("@DateAdded", thisAddress.DateAdded);
        //add the active parameter
        NewAddress.AddParameter("@Active", thisAddress.Active);
        //execute the query to add the record - it will return the primary key value of the new record
        PrimaryKey = NewAddress.Execute("sproc_tblAddress_Insert");
        //return the primary key value of the new record
        return PrimaryKey;
    }

    //function for the public Update method
    public void Update()
    {
        //this function updates an existing record specified by the class level variable addressNo
        //it returns no value

        //create a connection to the database
        clsDataConnection NewAddress = new clsDataConnection();
        //add the address no parameter
        NewAddress.AddParameter("@AddressNo", thisAddress.AddressNo);
        //add the house no parameter
        NewAddress.AddParameter("@HouseNo", thisAddress.HouseNo);
        //add the street parameter
        NewAddress.AddParameter("@Street", thisAddress.Street);
        //add the town parameter
        NewAddress.AddParameter("@Town", thisAddress.Town);
        //add the post code parameter
        NewAddress.AddParameter("@PostCode", thisAddress.PostCode);
        //add the county code parameter
        NewAddress.AddParameter("@CountyCode", thisAddress.CountyCode);
        //add the date added parameter
        NewAddress.AddParameter("@DateAdded", thisAddress.DateAdded);
        //add the active parameter
        NewAddress.AddParameter("@Active", thisAddress.Active);
        //execute the query
        NewAddress.Execute("sproc_tblAddress_Update");
    }

    ///this function deletes a record in the database based on the value of the addressNo var
    public void Delete()
    ///it is a void function and returns no value
    {
        //initialise the DBConnection
        dBConnection = new clsDataConnection();
        //add the parameter data used by the stored procedure
        dBConnection.AddParameter("@AddressNo", thisAddress.AddressNo);
        //execute the stored procedure to delete the address
        dBConnection.Execute("sproc_tblAddress_Delete");
    }


    ///this function defines the FilterByPostCode method
    public void FilterByPostCode(string PostCode)
        ///it accepts a single parameter PostCode and returns no value
    {
        //initialise the DBConnection
        dBConnection = new clsDataConnection();
        //add the parameter data used by the stored procedure
        dBConnection.AddParameter("@PostCode", PostCode);
        //execute the stored procedure to delete the address
        dBConnection.Execute("sproc_tblAddress_FilterByPostCode");
    }

    ///this function defines the public property Count
    public Int32 Count
        ///it returns the count of records currently in QueryResults
    {   
        get
        {
            //return the count of records
            return dBConnection.Count;
        }
    }

    ///this function exposes the DataTable via the public collection AllAddresses
    public List<clsAddress> AddressList
    {
        get
        {
            List<clsAddress> addressList = new List<clsAddress>();
            Int32 Index=0;
            while (Index < dBConnection.Count)
            {
                clsAddress NewAddress = new clsAddress();
                //get the house no from the query results
                NewAddress.HouseNo = Convert.ToString(dBConnection.DataTable.Rows[Index]["HouseNo"]);
                //get the street from the query results
                NewAddress.Street = Convert.ToString(dBConnection.DataTable.Rows[Index]["Street"]);
                //get the post code from the query results
                NewAddress.PostCode = Convert.ToString(dBConnection.DataTable.Rows[Index]["PostCode"]);
                //get the address no from the query results
                NewAddress.AddressNo = Convert.ToInt32(dBConnection.DataTable.Rows[Index]["AddressNo"]);
                //increment the index
                Index++;
                //add the address to the list
                addressList.Add(NewAddress);
            }
            //return the list of addresses
            return addressList;
        }
    }

}