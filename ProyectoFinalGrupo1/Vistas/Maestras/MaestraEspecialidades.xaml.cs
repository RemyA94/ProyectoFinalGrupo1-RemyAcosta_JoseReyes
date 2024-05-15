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
    public partial class MaestraEspecialidades : ContentPage
    {
        public MaestraEspecialidades()
        {
            InitializeComponent();
            BindingContext = new VMMaestra_Especialidades(Navigation);
        }

        public MaestraEspecialidades(Mespecialidad objespecialidad)
        {
            InitializeComponent();
            BindingContext = new VMMaestra_Especialidades(objespecialidad);
        }

        private void ListaEspecialidades_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var espseleccionada = e.SelectedItem as Mespecialidad;
            //txtidespecialidad.Text = espseleccionada.Id_Especialidad;
            //txtespecialidad.Text = espseleccionada.Especialidad;

        }
    }
}