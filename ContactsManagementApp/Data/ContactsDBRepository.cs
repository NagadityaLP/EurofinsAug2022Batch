using ContactsManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ContactsManagementApp.Data
{
    public class ContactsDBRepository : IContactsRepository
    {
        private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            return conn;
        }


        public void Delete(int id)
        {
            using(SqlConnection conn = GetConnection())
            {
                string sqlDelete = "delete from contacts where contactid = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sqlDelete;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(int id, Contact modifiedContact)
        {
            using (SqlConnection conn = GetConnection())
            {
                string sqlUpdate = "update contacts set name=@name,mobile=@mobile,email=@email,location=@loc where contactid=@id";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sqlUpdate;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", modifiedContact.Name);
                cmd.Parameters.AddWithValue("@mobile", modifiedContact.Mobile);
                cmd.Parameters.AddWithValue("@email", modifiedContact.Email);
                cmd.Parameters.AddWithValue("@loc", modifiedContact.Location);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Contact GetContactById(int id)
        {
            Contact c = new Contact();
            using (SqlConnection conn = GetConnection())
            {
                string sqlSelect = "select * from contacts where contactid=@id";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = conn;
                cmd.CommandText = sqlSelect;
                conn.Open();
               // cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();//reader points to buffer containing data obtained by select statement. it will be pointing to the 
                // beginning of buffer. But actual data will be present from the next row
                reader.Read();//Now reader actually points to data

                // each data stored in the buffer will be of type object
                c.ContactID = (int)reader[0];
                c.Name = reader[1].ToString();
                c.Mobile = reader[2].ToString();
                c.Email = reader.GetString(3);
                c.Location = reader["Location"].ToString();
                
            }
            return c;
        }

        public List<Contact> GetContacts()
        {
            List<Contact> contacts = new List<Contact>();
            using(SqlConnection conn = GetConnection())
            {
                string sqlSelect = "Select * from contacts";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sqlSelect;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                //reader.Read();
                while (reader.Read())
                {
                    Contact c = new Contact();
                    c.ContactID =(int)reader[0];
                    c.Name = (string)reader[1];
                    c.Mobile = (string)reader[2];
                    c.Email = (string)reader[3];
                    c.Location = (string)reader[4];

                    contacts.Add(c);
                }
            }
            return contacts;
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            List<Contact> contacts = new List<Contact>();
            using (SqlConnection conn = GetConnection())
            {
                string sqlSelect = "Select * from contacts where location=@location";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@location", location);
                cmd.CommandText = sqlSelect;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                //reader.Read();
                while (reader.Read())
                {
                    Contact c = new Contact();
                    c.ContactID = (int)reader[0];
                    c.Name = (string)reader[1];
                    c.Mobile = (string)reader[2];
                    c.Email = (string)reader[3];
                    c.Location = (string)reader[4];

                    contacts.Add(c);
                }
            }
            return contacts;   
        }

        public void Save(Contact contact)
        {
            //Step 1 : Connect to the database
            using (SqlConnection conn = GetConnection())
            {
                //Connection string - copy from properties of database created by right clicking on it. It consists of 3 parts(mandatory)
                //1. Database server  2. Database name   3. UserID Password


                //Step 2 : Prepare sql insert cmd
                //SQL Injection
                /*string sqlInsert = $"insert into contacts values" +
                    $"('{contact.Name}','{contact.Mobile}','{contact.Email}','{contact.Location}')";*/

                string sqlInsert = "insert into contacts values (@name,@mobile,@email,@loc)";
                SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                cmd.Parameters.AddWithValue("@name", contact.Name);

                SqlParameter p2 = new SqlParameter();
                p2.ParameterName = "@mobile";
                p2.Value = contact.Mobile;
                cmd.Parameters.Add(p2);

                cmd.Parameters.AddWithValue("@email", contact.Email);
                cmd.Parameters.AddWithValue("@loc", contact.Location);


                conn.Open();
                cmd.ExecuteNonQuery();

                //Step 3 : close
                //conn.Close();
            }
        }
    }
}
