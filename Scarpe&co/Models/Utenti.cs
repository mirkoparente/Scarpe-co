using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Scarpe_co.Models
{
    public class Utenti
    {
        public int IdUtente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        [Required(ErrorMessage ="Inserisci Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Inserisci Password")]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }





        public static List<Utenti> AllUser()
        {
            List<Utenti> utenti = new List<Utenti>();
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Utenti", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Utenti u = new Utenti();
                    u.IdUtente = Convert.ToInt32(reader["IdUtente"].ToString());
                    u.Nome = reader["Nome"].ToString();
                    u.Cognome = reader["Cognome"].ToString();
                    u.Username = reader["Username"].ToString();
                    u.Password = reader["Password"].ToString();
                    u.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                    utenti.Add(u);
                }


            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return utenti;
        }


        public static void AddUser(Utenti u)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Utenti values (@Nome,@Cognome,@Username,@Password,@IsAdmin)", conn);

                    cmd.Parameters.AddWithValue("Nome", u.Nome);
                    cmd.Parameters.AddWithValue("Cognome", u.Cognome);
                    cmd.Parameters.AddWithValue("Username", u.Username);
                    cmd.Parameters.AddWithValue("Password", u.Password);
                    cmd.Parameters.AddWithValue("IsAdmin", "False");
                

                if (cmd.ExecuteNonQuery() >0)
                {
                    
                };


            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            
        }
    }
}


