using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TechTaskWG.DTO;
using System.Linq;

namespace TechTaskWG.DAL
{
    public class ProductDAL : IBaseDAL<Product>
    {
        private MySqlConnection connection;
        private MySqlCommand command;

        public ProductDAL()
        {
            try
            {
                connection = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public string Create(Product obj)
        {
            MySqlTransaction transaction = connection.BeginTransaction();

            try
            {
                command = connection.CreateCommand();
                command.Connection = connection;
                command.Transaction = transaction;

                command.CommandText = "INSERT INTO product(name, description, amount, price, ip) VALUES (?, ?, ?, ?, ?)";
                command.Parameters.Add("@name", MySqlDbType.VarChar, 50).Value = obj.Name;
                command.Parameters.Add("@description", MySqlDbType.VarChar, 100).Value = obj.Description;
                command.Parameters.Add("@amount", MySqlDbType.Int32).Value = obj.Amount;
                command.Parameters.Add("@price", MySqlDbType.Float).Value = obj.Price;
                command.Parameters.Add("@ip", MySqlDbType.VarChar, 40).Value = obj.Ip;
                command.ExecuteNonQuery();
                                
                int lastInsertedId = (int) command.LastInsertedId;

                if (obj.Components.Count > 0)
                {
                    string sql = "INSERT INTO product_component(product_id, component_id) VALUES ";
                    foreach (Component component in obj.Components)
                    {
                        sql += "(" + lastInsertedId + ", " + component.Id + "),";
                    }
                    command.CommandText = sql.Substring(0, sql.Length - 1);
                    command.ExecuteNonQuery();
                }                
                transaction.Commit();

                return "Successful registration!";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return "Registration failed: " + ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
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
                    connection.Dispose();
                }
            }
        }

        public List<Product> ReadAll()
        {
            try
            {
                command = new MySqlCommand("SELECT * FROM product", connection);
                command.CommandType = CommandType.Text;

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
                        Price = dataReader.GetDouble(4), 
                        CreationDate = dataReader.GetDateTime(5),
                        Ip = dataReader.GetString(6)
                    };

                    products.Add(product);
                }

                return products;
            }
            catch (MySqlException ex)
            {
                throw new Exception("SQL problem: " + ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Operation failed: " + ex);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public Product ReadById(int id)
        {
            try
            {
                command = new MySqlCommand("SELECT p.id, p.name, p.description, p.amount, p.price, " +
                    "c.id c_id, c.name c_name, c.description c_description, c.amount c_amount, c.price c_price " +
                    "FROM product p " +
                    "LEFT JOIN product_component pc ON p.id = pc.product_id " +
                    "LEFT JOIN component c ON pc.component_id = c.id " +
                    "WHERE p.id = @id", connection);
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
                    Price = dataReader.GetDouble(4),
                    Components = new List<Component>()
                };

                if (!dataReader.IsDBNull(5))
                {
                    Component component;
                    do
                    {
                        component = new Component()
                        {
                            Id = dataReader.GetInt32(5),
                            Name = dataReader.GetString(6),
                            Description = dataReader.GetString(7),
                            Amount = dataReader.GetInt32(8),
                            Price = dataReader.GetDouble(9)
                        };
                        product.Components.Add(component);
                    } while (dataReader.Read());
                }
                
                return product;
            }
            catch (MySqlException ex)
            {
                throw new Exception("SQL problem: " + ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Operation failed: " + ex);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public string Update(Product obj)
        {
            MySqlTransaction transaction = connection.BeginTransaction();

            try
            {
                command = connection.CreateCommand();
                command.Connection = connection;
                command.Transaction = transaction;

                command.CommandText = "UPDATE product SET name = ?, description = ?, amount = ?, price = ? WHERE id = ?";
                command.Parameters.Clear();
                command.Parameters.Add("@name", MySqlDbType.VarChar, 50).Value = obj.Name;
                command.Parameters.Add("@description", MySqlDbType.VarChar, 100).Value = obj.Description;
                command.Parameters.Add("@amount", MySqlDbType.Int32).Value = obj.Amount;
                command.Parameters.Add("@price", MySqlDbType.Float).Value = obj.Price;
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = obj.Id;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                //Obter componentes do produto após atualização
                List<int> componentsAfterSaving = (from component in obj.Components select component.Id).ToList();

                //Obter componentes do produto antes da atualização
                List<int> componentsBeforeSaving = new List<int>();

                command.CommandText = "SELECT component_id FROM product_component WHERE product_id = " + obj.Id;
                command.CommandType = CommandType.Text;
                MySqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    componentsBeforeSaving.Add(dataReader.GetInt32(0));
                }
                dataReader.Close();
                //Obter componentes do produto antes da atualização - Fim

                //Obter componentes a serem excluídos 
                List<int> componentsToExclude = componentsBeforeSaving.Except(componentsAfterSaving).ToList();

                if (componentsToExclude.Count > 0)
                {
                    command.CommandText = "DELETE FROM product_component WHERE component_id IN (" + string.Join(", ", componentsToExclude.ToArray()) + ")";
                    command.ExecuteNonQuery();
                }                

                //Obter os componentes novos
                List<int> componentsToInsert = componentsAfterSaving.Except(componentsBeforeSaving).ToList();

                if (componentsToInsert.Count > 0)
                {
                    string sql = "INSERT INTO product_component(product_id, component_id) VALUES ";
                    foreach (int componentId in componentsToInsert)
                    {
                        sql += "(" + obj.Id + ", " + componentId + "),";
                    }
                    command.CommandText = sql.Substring(0, sql.Length - 1);
                    command.ExecuteNonQuery();
                }
                
                transaction.Commit();

                return "Successful registration!";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return "Registration failed: " + ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
    }
}
