using ProyectoFinalGrupo1.Vistas.Listas_de_Maestras;
using ProyectoFinalGrupo1.Vistas.Maestras;
using ProyectoFinalGrupo1.Vistas.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoFinalGrupo1.VistaModelo
{
    public class VMMenuReportes : BaseViewModel
    {
        #region VARIABLES

        #endregion

        #region CONSTRUCTOR

        public VMMenuReportes()
        {
        }
        public VMMenuReportes(INavigation navigation)
        {
            Navigation = navigation;
            Volvercomand = new Command(async () => await Volver());
            NavegarEspecialidadescommand = new Command(async () => await NavegarEspecialidades());
            NavegarMedicoscommand = new Command(async () => await NavegarMedicos());
        }

        public VMMenuReportes(INavigation navigation, string usu)
        {
            Navigation = navigation;
            Volvercomand = new Command(async () => await Volver());
            NavegarEspecialidadescommand = new Command(async () => await NavegarEspecialidades());
            NavegarMedicoscommand = new Command(async () => await NavegarMedicos());
        }

        #endregion

        #region OBJETOS

        #endregion

        #region PROCESOS

        private async Task Volver()
        {
            await Navigation.PopAsync();
        }

        private async Task NavegarEspecialidades()
        {
            await Navigation.PushAsync(new ListaEspecialidades());
        }

        private async Task NavegarMedicos()
        {
            await Navigation.PushAsync(new ListaMedicos());
        }

        #endregion

        #region COMANDOS

        public Command Volvercomand { get; }
        public Command NavegarEspecialidadescommand { get; }
        public Command NavegarMedicoscommand { get; }

        #endregion

    }
}
