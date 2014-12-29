using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.SessionState;
using Oracle.DataAccess.Client;
using Oracle.DataAccess;
using Oracle.DataAccess.Types;
using System.Data;
using System.Windows;
using System.Configuration;
using System.Web;


namespace AnimeList_Project
{
    class Databaseconnection
    {
        private OracleConnection conn;

        private int accountnr;
        public Databaseconnection()
        {
            conn = new OracleConnection();
            this.conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }
        public void AddUser(string email, string password)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();

                cmd.CommandText = "INSERT INTO DB21_ACCOUNT(Mailaddress,password) VALUES( :MAILADDRESS,:PASSWORD)";

                cmd.Parameters.Add("Mailaddress", email);
                cmd.Parameters.Add("password", password);
                this.conn.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException exc)
            {
            }
            finally
            {
                this.conn.Close();
            }
        }

        public void AddAnime(string status,string anime, string genre, double score, int rank, int popularity, int members, int favorites,string email)
        {
            try
            {
                accountnr = Getaccountnr(email);
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "INSERT INTO DB21_MYANIME(Status,Anime,Manga,Genre,Score,Rank, Popularity, Members,Favorites,Accountnr) VALUES(:Status,:Anime, :Manga, :Genre, :Score, :Rank, :Popularity,:Members, :Favorites, :Mailaddress)";

                cmd.Parameters.Add("Status", status);
                cmd.Parameters.Add("Anime", anime);
                cmd.Parameters.Add("Manga", anime);
                cmd.Parameters.Add("Genre", genre);
                cmd.Parameters.Add("Score", score);
                cmd.Parameters.Add("Rank", rank);
                cmd.Parameters.Add("Popularity", popularity);
                cmd.Parameters.Add("Members", members);
                cmd.Parameters.Add("Favorites", favorites);
                cmd.Parameters.Add("Mailaddress",accountnr);
                this.conn.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException exc)
            {
            }
            finally
            {
                this.conn.Close();
            }
        }

        public int Getaccountnr(string email)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "SELECT Accountnr FROM DB21_ACCOUNT WHERE (Mailaddress= :Mailaddress)";
                cmd.Parameters.Add("Mailaddress", email);
                this.conn.Open();
                cmd.ExecuteReader();
                accountnr = Convert.ToInt16(cmd.ExecuteScalar());
            }
            catch (OracleException exc)
            {
              
            }
            finally
            {
                this.conn.Close();
            }
            return accountnr;
        }

    }
}
