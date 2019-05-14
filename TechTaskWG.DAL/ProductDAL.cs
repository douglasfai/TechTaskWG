using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TechTaskWG.DTO;

namespace TechTaskWG.DAL
{
    public class ProductDAL : IBaseDAL<Product>
    {
        private MySqlConnection connection;
        private MySqlCommand command;

        public ProductDAL()
        {
            connection = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            connection.Open();
        }

        public string Create(Product obj)
        {
            try
            {
                command = new MySqlCommand("INSERT INTO product(nome, descricao, quantidade, preco) VALUES (?, ?, ?, ?)", connection);
                command.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = obj.Name;
                command.Parameters.Add("@descricao", MySqlDbType.VarChar, 100).Value = obj.Description;
                command.Parameters.Add("@quantidade", MySqlDbType.Int32).Value = obj.Amount;
                command.Parameters.Add("@preco", MySqlDbType.Float).Value = obj.Price;
                command.ExecuteNonQuery();

                return "Successful registration!";
            }
            catch (Exception ex)
            {
                return "Registration failed: " + ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public string Delete(int id)
        {
            try
            {
                command = new MySqlCommand("DELETE FROM product WHERE id = ?", connection);
                command.Parameters.Clear();
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                return "Successful exclusion!";
            }
            catch (Exception ex)
            {
                return "Exclusion failed: " + ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public List<Product> ReadAll()
        {
            try
            {
                command = new MySqlCommand("SELECT * FROM product", connection);
                command.CommandType = CommandType.Text;

                //using (command = new MySqlCommand("SELECT * FROM products", connection))
                //{
                //    using (MySqlDataReader dataReader = command.ExecuteReader())
                //    {
                //        while (dataReader.Read())
                //        {
                //            columnData.Add(dataReader.GetString(0));
                //        }
                //    }
                //}


                MySqlDataReader dataReader = command.ExecuteReader();

                List<Product> products = new List<Product>();
                Product product;
                while (dataReader.Read())
                {
                    product = new Product()
                    {
                        Id = dataReader.GetInt32(0),
                        Name = dataReader.GetString(1),
                        Description = dataReader.GetString(2),
                        Amount = dataReader.GetInt32(3),
                        Price = dataReader.GetDouble(4)
                    };

                    products.Add(product);
                }

                return products;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public Product ReadById(int id)
        {
            try
            {
                command = new MySqlCommand("SELECT * FROM product WHERE id = ?", connection);
                command.Parameters.Clear();
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.CommandType = CommandType.Text; 

                MySqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();

                Product product = new Product()
                {
                    Id = dataReader.GetInt32(0),
                    Name = dataReader.GetString(1),
                    Description = dataReader.GetString(2),
                    Amount = dataReader.GetInt32(3),
                    Price = dataReader.GetDouble(4)
                };

                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public string Update(Product obj)
        {
            try
            {
                command = new MySqlCommand("UPDATE product SET nome = ?, descricao = ?, quantidade = ?, preco = ? WHERE id = ?", connection);
                command.Parameters.Clear();
                command.Parameters.Add("@name", MySqlDbType.VarChar, 50).Value = obj.Name;
                command.Parameters.Add("@description", MySqlDbType.VarChar, 100).Value = obj.Description;
                command.Parameters.Add("@amount", MySqlDbType.Int32).Value = obj.Amount;
                command.Parameters.Add("@price", MySqlDbType.Float).Value = obj.Price;
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = obj.Id;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                return "Successful registration!";
            }
            catch (Exception ex)
            {
                return "Registration failed: " + ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
