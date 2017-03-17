using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// this class exposes the count and query results of the county data
/// </summary>

public class clsCountyCollection
{
    //create a connection to the database with class level scope
    clsDataConnection Counties = new clsDataConnection();

    //constructor
    public clsCountyCollection()
	{
        //execute the select all query
        Counties.Execute("sproc_tblCounty_SelectAll");
    }

    //this read only function gives us the count property
    public Int32 Count
    {
        get
        {
            //return the count of the data from the database
            return Counties.Count;
        }
    }

    //this readonly function exposes the query results collection
    public List<clsCounty> AllCounties
    {
        
        get
        {
            //create a instance of a list called allCounties
            List<clsCounty> allCounties = new List<clsCounty>();
            //var to store the index for the loop
            Int32 Index = 0;
            //while the index is less that the number of records to process
            while (Index < Counties.Count)
            {
                //set up the new entry to be added to the list
                clsCounty NewCounty = new clsCounty();
                //get the county number from the database
                NewCounty.CountyNo = Convert.ToInt32(Counties.DataTable.Rows[Index]["CountyNo"]);
                //get teh county name from the database
                NewCounty.County = Convert.ToString(Counties.DataTable.Rows[Index]["County"]);
                //add the new entry to the list
                allCounties.Add(NewCounty);
                //increment the index to the next record
                Index++;
            }
            //return the query results from the database
            return allCounties;
        }
    }
}