using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TechTaskWG.DTO;

namespace TechTaskWG.DAL
{
    class ComponentDAL : IBaseDAL<Component>
    {
        private MySqlConnection connection;
        private MySqlCommand command;

        public ComponentDAL()
        {
            connection = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            connection.Open();
        }

        public string Create(Component obj)
        {
            try
            {
                command = new MySqlCommand("INSERT INTO component(nome, descricao, quantidade, preco) VALUES (?, ?, ?, ?)", connection);
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
                command = new MySqlCommand("DELETE FROM component WHERE id = ?", connection);
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

        public List<Component> ReadAll()
        {
            try
            {
                command = new MySqlCommand("SELECT * FROM component", connection);
                command.CommandType = CommandType.Text;

                MySqlDataReader dataReader = command.ExecuteReader();

                List<Component> components = new List<Component>();
                Component component;
                while (dataReader.Read())
                {
                    component = new Component()
                    {
                        Id = dataReader.GetInt32(0),
                        Name = dataReader.GetString(1),
                        Description = dataReader.GetString(2),
                        Amount = dataReader.GetInt32(3),
                        Price = dataReader.GetDouble(4)
                    };

                    components.Add(component);
                }

                return components;
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

        public Component ReadById(int id)
        {
            try
            {
                command = new MySqlCommand("SELECT * FROM component WHERE id = ?", connection);
                command.Parameters.Clear();
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.CommandType = CommandType.Text; 

                MySqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();

                Component component = new Component()
                {
                    Id = dataReader.GetInt32(0),
                    Name = dataReader.GetString(1),
                    Description = dataReader.GetString(2),
                    Amount = dataReader.GetInt32(3),
                    Price = dataReader.GetDouble(4)
                };

                command = null;
                connection.Close();
                return component;
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

        public string Update(Component obj)
        {
            try
            {
                command = new MySqlCommand("UPDATE component SET nome = ?, descricao = ?, quantidade = ?, preco = ? WHERE id = ?", connection);
                command.Parameters.Clear();
                command.Parameters.Add("@name", MySqlDbType.VarChar, 50).Value = obj.Name;
                command.Parameters.Add("@description", MySqlDbType.VarChar, 100).Value = obj.Description;
                command.Parameters.Add("@amount", MySqlDbType.Int32).Value = obj.Amount;
                command.Parameters.Add("@price", MySqlDbType.Float).Value = obj.Price;
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = obj.Id;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                command = null;
                connection.Close();
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
