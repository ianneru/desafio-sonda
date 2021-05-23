using DesafioSonda.Domain.Core;
using DesafioSonda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DesafioSonda.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly string _connectionString;

        public ClientesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ICollection<Clientes> GetAll()
        {
            var listaClientes = new List<Clientes>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Clientes", connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = (Guid)reader["Identificador"];
                        var nome = (string)reader["Nome"];
                        var cpf = (string)reader["Cpf"];
                        var sexo = (Byte)reader["Sexo"];
                        var dataNascimento = (DateTime)reader["DataNascimento"];

                        listaClientes.Add(
                            new Clientes
                            {
                                Identificador = id,
                                Nome = nome,
                                Cpf = cpf,
                                Sexo = (Sexo)sexo,
                                DataNascimento = dataNascimento
                            });
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    command.Dispose();
                }
            }

            return listaClientes;
        }

        public Clientes GetById(Guid Id)
        {
            var cliente = new Clientes();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Clientes WHERE Identificador = '" + Id + "'", connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var nome = (string)reader["Nome"];
                        var cpf = (string)reader["Cpf"];
                        var sexo = (Byte)reader["Sexo"];
                        var dataNascimento = (DateTime)reader["DataNascimento"];

                        cliente = new Clientes
                        {
                            Identificador = Id,
                            Nome = nome,
                            Cpf = cpf,
                            Sexo = (Sexo)sexo,
                            DataNascimento = dataNascimento
                        };
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    command.Dispose();
                }
            }

            return cliente;
        }

        public void Add(Clientes cliente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(@"INSERT INTO Clientes(Identificador,Nome,Cpf,DataNascimento,Sexo)
                                                      VALUES (@Identificador,@Nome,@Cpf,@DataNascimento,@Sexo)", connection);

                try
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@Identificador", Guid.NewGuid());
                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                    command.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
                    command.Parameters.AddWithValue("@Sexo", cliente.Sexo);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    command.Dispose();
                }
            }
        }

        public void Update(Clientes cliente)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(@"UPDATE Clientes SET Nome = @Nome, Cpf = @Cpf,
                                                      DataNascimento = @DataNascimento, @Sexo = @Sexo 
                                                      WHERE Identificador = @Identificador", connection);

                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Identificador", cliente.Identificador);
                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                    command.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
                    command.Parameters.AddWithValue("@Sexo", cliente.Sexo);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    command.Dispose();
                }
            }
        }

        public void Remove(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(@"DELETE FROM  Clientes
                                                      WHERE Identificador = @Identificador", connection);

                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Identificador", Id);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    command.Dispose();
                }
            }
        }
    }
}
