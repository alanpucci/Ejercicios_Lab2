using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class ConnectionHandler
    {
        public static void InsertPerson(Person persona)
        {
            String connectionStr = @"Data Source=.; Initial Catalog = productos; Integrated Security = True";
            int columnasAfectadas = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = "INSERT INTO [persona] ([Nombre], [Apellido])" + "Values (@nombre, @apellido)";

                    command.Parameters.AddWithValue("@nombre", persona.GetNombre);
                    command.Parameters.AddWithValue("@apellido", persona.GetApellido);

                    columnasAfectadas = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EditPerson(Person persona)
        {
            String connectionStr = @"Data Source=.; Initial Catalog = productos; Integrated Security = True";
            int columnasAfectadas = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = $"UPDATE [persona] SET Nombre = @nombre, Apellido = @apellido WHERE Id = {persona.GetId}";

                    command.Parameters.AddWithValue("@nombre", persona.GetNombre);
                    command.Parameters.AddWithValue("@apellido", persona.GetApellido);

                    columnasAfectadas = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Person GetById(int id)
        {
            Person persona = null;
            String connectionStr = @"Data Source=.; Initial Catalog = productos; Integrated Security = True";

            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            command.CommandText = string.Format($"SELECT * FROM persona WHERE id = {id}");

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read() == false)
            {
                throw new Exception("Persona no encontrada");
            }
            persona = new Person(Convert.ToInt32(dataReader["id"]), dataReader["nombre"].ToString(), dataReader["apellido"].ToString());
            dataReader.Close();
            connection.Close();
            return persona;
        }

        public static List<Person> GetPersons()
        {
            try
            {
                List<Person> personas = new List<Person>();
                String connectionStr = @"Data Source=.; Initial Catalog = productos; Integrated Security = True";

                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = string.Format($"SELECT * FROM persona");

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read() != false)
                { 
                    personas.Add(new Person(Convert.ToInt32(dataReader["id"]), dataReader["nombre"].ToString(), dataReader["apellido"].ToString()));
                }
                dataReader.Close();
                connection.Close();
                return personas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete(int id)
        {
            try
            {
                List<Person> personas = new List<Person>();
                String connectionStr = @"Data Source=.; Initial Catalog = productos; Integrated Security = True";

                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = string.Format($"DELETE persona WHERE id = {id}");

                int rows = command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
