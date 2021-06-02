using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ConnectionHandler conexion = new ConnectionHandler();
                List<Person> personas = new List<Person>();
                //Persona persona = conexion.LeerPersonaPorId(2);
                //conexion.Eliminar(2);
                Person newPersona = new Person("Juan", "Pepe");
                conexion.InsertarPersona(newPersona);
                //Console.WriteLine(persona.Mostrar());
                personas = conexion.LeerPersonas();
                foreach (Person item in personas)
                {
                    Console.WriteLine(item.Mostrar());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
