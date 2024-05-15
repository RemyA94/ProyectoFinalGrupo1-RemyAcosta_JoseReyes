using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalGrupo1.Modelo
{
    public class Mmedicos
    {
        public string ID_MedicoFirebase { get; set; }
        public string ID_Medico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Mespecialidad Especialidad { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string FechaRegistro { get; set; }
    }
}
