using GalaSoft.MvvmLight.Command;
using ProyFinalSeccion707.Data;
using ProyFinalSeccion707.Modelo;
using ProyFinalSeccion707.Vistas.Maestras;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyFinalSeccion707.VistaModelo
{
    public class VMespecialidadAgregarpage: BaseViewModel
    {

        #region VARIABLES
        public int TotalClientes;
        List<Mespecialidad> listaEspecialidades;
        string txtidespecialidad;
        string txtespecialidad;
        string txtestado;

        #endregion

        public ObservableCollection<Mespecialidad> especialidadcollection = new ObservableCollection<Mespecialidad>();

        public Mespecialidad CurrentEspecialidad { get; set; }
        public Command AddEspecialidadCommand { get; set; }
        public Command ItemTappedCommand { get; }


        #region CONSTRUCTOR

        public VMespecialidadAgregarpage(INavigation navigation
            , Mespecialidad esp = null)
        {
            txtidespecialidad = esp.Id_Especialidad;
            txtespecialidad = esp.Especialidad;
            txtestado = esp.Estado;
        }

        public VMespecialidadAgregarpage(INavigation navigation)
        {
            Navigation = navigation;

            AddEspecialidadCommand = new Command(async () => await
            GoToClienteDetailPage());
            ItemTappedCommand = new Command(async () => await GoToClienteDetailPage(CurrentEspecialidad));

            _ = MostrarEspecialidades();
            _ = TestListViewBindingAsync();

            Volvercomamdatras = new Command(async () => await Volver());
        }
        #endregion


        private async Task TestListViewBindingAsync()
        {
            var lista = new List<Mespecialidad>();
            {
                var funcion = new DBEspecialidades();
                lista = await funcion.ListarEspecialidades();
            }
            foreach (var item in lista)
            {
                especialidadcollection.Add(item);
            }
        }

        public async Task GoToClienteDetailPage(Mespecialidad c = null)
        {
            if (c == null)
            {
                await Navigation.PushAsync(new MaestraEspecialidades());
            }
            else
            {
                await Navigation.PushAsync(new MaestraEspecialidades(CurrentEspecialidad));
            }
        }

        #region PROCESOS
        private async Task MostrarEspecialidades()
        {
            var funcion = new DBEspecialidades();
            ListaEspecialidades = await funcion.ListarEspecialidades();
            //TotalClientes = ListaClientes.Count(); //Using System.Linq
        }

        #endregion

        #region OBJETOS

        public List<Mespecialidad> ListaEspecialidades
        {
            get { return listaEspecialidades; }
            set { SetValue(ref listaEspecialidades, value); }
        }

        public string TxtIdespecialidad
        {
            get { return txtidespecialidad; }
            set { SetValue(ref txtidespecialidad, value); }
        }

        public string TxtEspecialidad
        {
            get { return txtespecialidad; }
            set { SetValue(ref txtespecialidad, value); }
        }

        public string Txtestado
        {
            get { return txtestado; }
            set { SetValue(ref txtestado, value); }
        }


        private async Task Volver()
        {
            //await App.Current.MainPage.Navigation.PushAsync(new AgregarCliente());
            await Navigation.PopAsync();
        }

        public ICommand updateespecialidadcommand
        {
            get
            {
                //MvvmLightLibs DESCARGAR EN MANAGENUGET
                return new RelayCommand(ActualizarEspecialidades);
            }
        }

        //public ICommand Eliminarclientecomamd
        //{
        //    get
        //    {
        //        //MvvmLightLibs DESCARGAR EN MANAGENUGET
        //        return new RelayCommand(EliminarCliente);
        //    }
        //}

        private async void ActualizarEspecialidades()
        {
            var para = new Mespecialidad
            {
                Id_Especialidad = TxtIdespecialidad,
                Especialidad = TxtEspecialidad,
                Estado = Txtestado
            };

            var funcion = new DBEspecialidades();
            await funcion.ModificarDatosEspecialidades(para);

            await App.Current.MainPage.Navigation.PushAsync(new AgregarModificar_EspecialidadesPage());
            //await Navigation.PopAsync();
        }

        //private async void EliminarCliente()
        //{
        //    //string idbolsaSeleccionado = (sender as Button).CommandParameter.ToString();
        //    var funcion = new Dclientes();

        //    var para = new Mclientes
        //    {
        //        Idcliente = TxtIdcliente,
        //        Identificacion = Txtidentificacion
        //    };

        //    var DisplayResultado = await Application.Current.MainPage
        //        .DisplayAlert("Mensaje", "Desea eliminar el cliente", "Si", "No");

        //    if (DisplayResultado)
        //    {
        //        //string codi = para.Modelo;
        //        bool respuesta = await funcion.EliminarCliente(para);
        //        if (respuesta)
        //        {
        //            await DisplayAlert("Mensaje", "Cliente Eliminado", "ok");

        //            await App.Current.MainPage.Navigation.PushAsync(new AgregarCliente());
        //            //await Navigation.PopAsync();
        //        }
        //        else
        //            await DisplayAlert("Mensaje", "Hubo un problema al retornar", "ok");
        //    }
        //}

        #endregion

        #region COMANDOS
        public Command Volvercomamdatras { get; }

        #endregion

    }
}
