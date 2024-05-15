using ProyectoFinalGrupo1.Modelo;
using ProyectoFinalGrupo1.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalGrupo1.Vistas.Maestras
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaestraMedicos : ContentPage
    {
        public MaestraMedicos()
        {
            InitializeComponent();
            BindingContext = new VMMaestra_Medicos(Navigation);
        }
        public MaestraMedicos(Mmedicos objmedicos)
        {
            InitializeComponent();
            BindingContext = new VMMaestra_Medicos(objmedicos);

        }

    }
}