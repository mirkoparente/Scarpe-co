using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;

namespace Scarpe_co.Models
{
    public class Prodotti
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name ="Nome Prodotto")]
        public string NomeProdotto { get; set; }

        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Descrizione Breve")]
        public string DescrizioneB { get; set; }

        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Descrizione Aggiuntiva")]
        public string DescrizioneL { get; set; }

        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Immagine Principale")]
        public string Copertina { get; set; }

        [Display(Name = "Immagine Secondaria")]
        public string Img1 { get; set; }

        [Display(Name = "Immagine Secondaria")]
        public string Img2 { get; set; }

        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Prezzo Prodotto")]
        public double Prezzo { get; set; }

        [Required(ErrorMessage = "Campo Obbligatorio")]
        [Display(Name = "Quantità")]
        public int Quantita { get; set; }


        public static List<Prodotti> SelectAllP()
        {
            List<Prodotti> prod = new List<Prodotti>();
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Prodotti ", conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Prodotti p = new Prodotti();
                    p.Id = Convert.ToInt32(reader["IdProdotto"].ToString());
                    p.NomeProdotto = reader["NomeProdotto"].ToString();
                    p.DescrizioneB = reader["DescrizioneB"].ToString();
                    p.DescrizioneL = reader["DescrizioneL"].ToString();
                    p.Copertina = reader["Copertina"].ToString();
                    p.Img1 = reader["Img1"].ToString();
                    p.Img2 = reader["Img2"].ToString();
                    p.Prezzo = Convert.ToDouble(reader["Prezzo"].ToString());
                    p.Quantita= Convert.ToInt32(reader["Quantita"].ToString());


                    prod.Add(p);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return prod;
        }

        public static Prodotti DettaglioP(int id)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            Prodotti p = new Prodotti();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select * from Prodotti where IdProdotto={id}", conn);

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    p.Id = Convert.ToInt32(reader["IdProdotto"].ToString());
                    p.NomeProdotto = reader["NomeProdotto"].ToString();
                    p.DescrizioneB = reader["DescrizioneB"].ToString();
                    p.DescrizioneL = reader["DescrizioneL"].ToString();
                    p.Copertina = reader["Copertina"].ToString();
                    p.Img1 = reader["Img1"].ToString();
                    p.Img2 = reader["Img2"].ToString();
                    p.Prezzo = Convert.ToDouble(reader["Prezzo"].ToString());
                    p.Quantita = Convert.ToInt32(reader["Quantita"].ToString());

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return p;
        }

        public static void NewProd(Prodotti p)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Prodotti values (@NomeProdotto,@DescrizioneB,@DescrizioneL,@Copertina,@Img1,@Img2,@Prezzo,@Quantita)", conn);

                cmd.Parameters.AddWithValue("NomeProdotto", p.NomeProdotto);
                cmd.Parameters.AddWithValue("DescrizioneB", p.DescrizioneB);
                cmd.Parameters.AddWithValue("DescrizioneL", p.DescrizioneL);
                cmd.Parameters.AddWithValue("Copertina", p.Copertina);
                cmd.Parameters.AddWithValue("Img1", p.Img1);
                cmd.Parameters.AddWithValue("Img2", p.Img2);
                cmd.Parameters.AddWithValue("Prezzo", p.Prezzo);
                cmd.Parameters.AddWithValue("Quantita", p.Quantita);



                cmd.ExecuteNonQuery();
               


            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }

        }


        public static void ModificaProd(Prodotti p)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"update Prodotti set NomeProdotto=@NomeProdotto,DescrizioneB=@DescrizioneB,DescrizioneL=@DescrizioneL,Copertina=@Copertina,Img1=@Img1,Img2=@Img2,Prezzo=@Prezzo,Quantita=@Quantita  where IdProdotto={p.Id}", conn);



                cmd.Parameters.AddWithValue("NomeProdotto", p.NomeProdotto);
                cmd.Parameters.AddWithValue("DescrizioneB", p.DescrizioneB);
                cmd.Parameters.AddWithValue("DescrizioneL", p.DescrizioneL);
                cmd.Parameters.AddWithValue("Copertina", p.Copertina);
                cmd.Parameters.AddWithValue("Img1", p.Img1);
                cmd.Parameters.AddWithValue("Img2", p.Img2);
                cmd.Parameters.AddWithValue("Prezzo", p.Prezzo);
                cmd.Parameters.AddWithValue("Quantita", p.Quantita);



                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
        }


        public static void Delete(int id)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"delete from Prodotti where IdProdotto={id}", conn);
                cmd.ExecuteNonQuery();
            }
            catch(Exception)
            {

            }
            finally
            {
                conn.Close ();
            }
        }

    }
}