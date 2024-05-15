using ProyectoFinalGrupo1.Modelo;
using ProyectoFinalGrupo1.VistaModelo;
using ProyectoFinalGrupo1.Vistas.Maestras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalGrupo1.Vistas.Listas_de_Maestras
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaMedicos : ContentPage
    {
        public ListaMedicos()
        {
            InitializeComponent();
            BindingContext = new VMMaestra_Medicos(Navigation);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var buscarmed = BindingContext as VMMaestra_Medicos;
            ListaDatosMedicos.BeginRefresh();
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ListaDatosMedicos.ItemsSource = buscarmed.ColeccionMed;
            }
            else
            {
                ListaDatosMedicos.ItemsSource = buscarmed.ColeccionMed.Where(a => a.Nombre.Contains(e.NewTextValue) || a.Apellido.Contains(e.NewTextValue) || a.Especialidad.Especialidad.Contains(e.NewTextValue));
            }
            ListaDatosMedicos.EndRefresh();

        }

        private void ListaDatosMedicos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new MaestraMedicos(e.SelectedItem as Mmedicos));
        }
    }
}