using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalGrupo1.Modelo
{
    public class Mcitas
    {
        public string ID_CitaFirebase { get; set; }
        public string ID_Cita { get; set; }
        public Mpacientes paciente { get; set; }
        public Mmedicos medico { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }

    }
}
