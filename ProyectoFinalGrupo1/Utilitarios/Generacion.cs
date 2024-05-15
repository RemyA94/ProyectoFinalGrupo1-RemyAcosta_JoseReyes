using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoFinalGrupo1.Utilitarios
{
    public class Generacion
    {
        public class ValorUser
        {
            public int Valor { get; set; }
            public string TextoValor { get; set; }
            public string TextoValor2 { get; set; }
        }
        public class ListadeObtenerValor
        {
            public List<ValorUser> ValorObtenido { get; set; }
            public ListadeObtenerValor()
            {
                ValorObtenido = new List<ValorUser>();
            }
        }
        public int GenerarId(int Cant_Registros, List<int> Contar_Registros)
        {
            if (Contar_Registros.Count() < 0)
            {
                Contar_Registros.Add(Cant_Registros++);
            }
            return Contar_Registros.Count();
        }

    }
}
