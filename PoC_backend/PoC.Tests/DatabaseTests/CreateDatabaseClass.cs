using System.Data;
using System.Data.SqlClient;

namespace PoC.Tests.DatabaseTests
{
    public class CreateTestDataBaseClass
    {
        public static void CreateDataBase()
        {
            SqlConnection myConn =
                new SqlConnection(
                    @"Server=NXNPCHP1819\MSSQLSERVER001;Integrated security=true;database=master;Trusted_Connection=True;MultipleActiveResultSets=True");

            // var dropDatabaseStr = @"IF EXISTS(select * from sys.databases where name='TestHaromszogDbContext')
            //                     DROP DATABASE TestHaromszogDbContext";
            //
            
            
            var createDbStr = @"IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'TestHaromszogDbContext')
            BEGIN CREATE DATABASE [TestHaromszogDbContext] END";
        
            var createTableStr = @"USE [TestHaromszogDbContext] 
          
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Haromszog' and xtype='U')
        BEGIN CREATE TABLE Haromszog (
            Id INT PRIMARY KEY IDENTITY (1, 1),
            Guid VARCHAR(100),
        Pont1 VARCHAR(100),
        Pont2 VARCHAR(100),
        Pont3 VARCHAR(100),
        Irany VARCHAR(100),
        Color VARCHAR(100)) END";

            //SqlCommand dropCommand = new SqlCommand(dropDatabaseStr, myConn);
            SqlCommand dbCommand = new SqlCommand(createDbStr, myConn);
            SqlCommand tableCommand = new SqlCommand(createTableStr, myConn);
            try
            {
                myConn.Open();
                //dropCommand.ExecuteNonQuery();
                dbCommand.ExecuteNonQuery();
                tableCommand.ExecuteNonQuery();
           
            }
            catch (System.Exception ex)
            {
            
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
    }
}