using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalGrupo1.Modelo
{
    public class Mtratamiento
    {
        public string ID_TratamientoFirebase { get; set; }
        public string ID_Tratamiento { get; set; }
        public Mpacientes paciente { get; set; }
        public Mmedicos medico { get; set; }
        public string Descripcion { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
        public string Costo { get; set; }

    }
}
