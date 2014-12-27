using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess;
using Oracle.DataAccess.Types;
using System.Data;
using System.Windows;
using System.Configuration;

namespace AnimeList_Project
{
    class Databaseconnection
    {
        private OracleConnection conn;

        public void AddUser(string email, string password)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();

                cmd.CommandText = "INSERT INTO DB21_ACCOUNT(Mailaddress,password) VALUES( :MAILADDRESS,PASSWORD)";

                cmd.Parameters.Add("Mailaddress", email);
                cmd.Parameters.Add("password", password);


                this.conn.Open();
                cmd.ExecuteReader();
            }
            catch
            {
            }
            finally
            {
                this.conn.Close();
            }
}
        public int GetPlaces()
        {
         
            int uitkomst=0;
            int id;

            OracleDataReader Reader;
            this.conn = new OracleConnection();
            this.conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand("SELECT * from Plek", conn);
            cmd.CommandType = CommandType.Text;
            conn.Open();

            Reader = cmd.ExecuteReader();
            
            try
            {
                while (Reader.Read())
                {
                    uitkomst = Convert.ToInt16(Reader.GetValue(3));
                }
            }
            catch(OracleException OE)
            {
                
            }
            finally
            {
                conn.Close();

            }
            return uitkomst;
            
        }



       /* public string GetAccountInfo(int barcode)
        {
            string uitkomst;

            OracleDataReader Reader = new OracleDataReader();
            OracleConnection conn = new OracleConnection(connectionstring);
            OracleCommand cmd = new OracleCommand("SELECT * from Getaccountinfo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("rfid", "varchar2").Value = barcode;
            conn.Open();

            Reader = cmd.ExecuteReader();
            
            try
            {
                while (Reader.Read())
                {
                    if (!Reader.IsDBNull(0))
                    {
                        uitkomst = Reader.GetString(0);   
                    }
                }
            }
            catch(OracleException OE)
            {

            }
            finally
            {
                conn.Close();

            }
            return uitkomst;
            
        }*/

        /*public void FillDataGrid(DataGridView d)
        {

            string cmdstr = "";
            OracleConnection conn = new OracleConnection(connectionstring);
            conn.Open();
            OracleCommand cmd = new OracleCommand(cmdstr, conn);
            DataSet ds = new DataSet();
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);
            d.DataSource = ds.Tables[0];
            conn.Dispose();
        }*/
       

     
    }
}
