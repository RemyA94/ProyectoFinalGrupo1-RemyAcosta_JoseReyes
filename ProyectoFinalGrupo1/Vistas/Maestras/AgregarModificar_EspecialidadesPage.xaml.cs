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
    public partial class AgregarModificar_EspecialidadesPage : ContentPage
    {
        public AgregarModificar_EspecialidadesPage()
        {
            InitializeComponent();
            BindingContext = new VMMaestra_Especialidades(Navigation);
        }
        public AgregarModificar_EspecialidadesPage(Mespecialidad cliente)
        {
            InitializeComponent();
            this.BindingContext = new VMMaestra_Especialidades(Navigation, cliente);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as VMMaestra_Especialidades;
            ListViewEspecialidades.BeginRefresh();
            if (string.IsNullOrWhiteSpace(e.NewTextValue.ToUpper()))
            {
                ListViewEspecialidades.ItemsSource = _container.especialidadcollection;
            }
            else
            {
                ListViewEspecialidades.ItemsSource = _container.especialidadcollection.Where(i => i.idsocio.ToUpper().Contains(e.NewTextValue.ToUpper()));
            }
            ListViewEspecialidades.EndRefresh();
        }

        private async void ListViewEspecialidades_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new MaestraEspecialidades(e.SelectedItem as Mespecialidad));
        }

    }
}