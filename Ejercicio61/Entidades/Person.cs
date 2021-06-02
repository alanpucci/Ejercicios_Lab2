using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Person
    {
        private int id;
        private string nombre;
        private string apellido;

        public Person(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public Person(int id, string nombre, string apellido)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public int GetId
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string GetNombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string GetApellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {this.GetId}");
            sb.AppendLine($"Nombre: {this.GetNombre}");
            sb.AppendLine($"Apellido: {this.GetApellido}");
            return sb.ToString();
        }
    }
}
