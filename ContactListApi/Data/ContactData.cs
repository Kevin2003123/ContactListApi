using ContactListApi.Db;
using ContactListApi.Models;
using System.Data.SqlClient;

namespace ContactListApi.Data
{
    public class ContactData
    {
        public static List<Contact> GetAllContacts()
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection connection = new SqlConnection(Connection.connRute))
            {
                SqlCommand cmd = new SqlCommand("GetAllContacts", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            contacts.Add(new Contact()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = dr["Name"].ToString(),
                                LastName = dr["LastName"].ToString(),
                                Cellphone = dr["Cellphone"].ToString(),
                                Email = dr["Email"].ToString(),
                                dateOfRegistration = Convert.ToDateTime(dr["dateOfRegistration"].ToString())
                            });
                        }
                    }

                    return contacts;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return contacts;
                }
            }
        }


        public static List<Contact> GetContactsPerPage(int PageNumber, string Order, string OrderBy)
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection connection = new SqlConnection(Connection.connRute))
            {
                SqlCommand cmd = new SqlCommand("GetContactsPerPage", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                cmd.Parameters.AddWithValue("@Order", Order);
                cmd.Parameters.AddWithValue("@OrderBy", OrderBy);
                try
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            contacts.Add(new Contact()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = dr["Name"].ToString(),
                                LastName = dr["LastName"].ToString(),
                                Cellphone = dr["Cellphone"].ToString(),
                                Email = dr["Email"].ToString(),
                                dateOfRegistration = Convert.ToDateTime(dr["dateOfRegistration"].ToString())
                            });
                        }
                    }

                    return contacts;
                }
                catch (Exception ex)
                {
                    return contacts;
                }
            }
        }


        public static List<Contact> SearchContactsPerPage(int PageNumber,string SearchTerm ,string Order, string OrderBy)
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection connection = new SqlConnection(Connection.connRute))
            {
                SqlCommand cmd = new SqlCommand("SearchContactsPerPage", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                cmd.Parameters.AddWithValue("@Order", Order);
                cmd.Parameters.AddWithValue("@SearchTerm", SearchTerm);
                cmd.Parameters.AddWithValue("@OrderBy", OrderBy);

                try
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            contacts.Add(new Contact()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = dr["Name"].ToString(),
                                LastName = dr["LastName"].ToString(),
                                Cellphone = dr["Cellphone"].ToString(),
                                Email = dr["Email"].ToString(),
                                dateOfRegistration = Convert.ToDateTime(dr["dateOfRegistration"].ToString())
                            });
                        }
                    }

                    return contacts;
                }
                catch (Exception ex)
                {
                    return contacts;
                }
            }
        }

        public static Contact GetContactById(int id)
        {
            Contact contact = new Contact();

            using (SqlConnection connection = new SqlConnection(Connection.connRute))
            {
                SqlCommand cmd = new SqlCommand("GetContactById", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            contact = new Contact()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = dr["Name"].ToString(),
                                LastName = dr["LastName"].ToString(),
                                Cellphone = dr["Cellphone"].ToString(),
                                Email = dr["Email"].ToString(),
                                dateOfRegistration = Convert.ToDateTime(dr["dateOfRegistration"].ToString())
                            };
                        }
                    }

                    return contact;
                }
                catch (Exception ex)
                {
                    return contact;
                }
            }
        }

        public static bool DeleteContact(int id)
        {
            using (SqlConnection connection = new SqlConnection(Connection.connRute))
            {
                SqlCommand cmd = new SqlCommand("DeleteContact", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool InsertContact(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(Connection.connRute))
            {
                SqlCommand cmd = new SqlCommand("InsertContact", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", contact.Name);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@Cellphone", contact.Cellphone);
                cmd.Parameters.AddWithValue("@Email", contact.Email);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool UpdateContact(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(Connection.connRute))
            {
                SqlCommand cmd = new SqlCommand("UpdateContact", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", contact.Id);
                cmd.Parameters.AddWithValue("@Name", contact.Name);
                cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                cmd.Parameters.AddWithValue("@Cellphone", contact.Cellphone);
                cmd.Parameters.AddWithValue("@Email", contact.Email);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}