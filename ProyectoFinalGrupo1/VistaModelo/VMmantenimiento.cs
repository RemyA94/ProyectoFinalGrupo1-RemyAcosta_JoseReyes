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
   //internal class VMmantenimiento

   internal class VMmantenimiento : BaseViewModel
   {
      public VMmantenimiento(INavigation navigation)
      {
         Navigation = navigation;
         NavegarEspecialidadesCommand = new Command(async () => await NavegarEspecialidades());
         NavegarMedicosCommand = new Command(async () => await NavegarMedicos());
      }

      private async Task Volver()
      {
         //await Navigation.PushAsync(new MenuPrincipal());
         await Navigation.PopAsync();
      }

      private async Task NavegarEspecialidades()
      {
         await Navigation.PushAsync(new AgregarModificar_EspecialidadesPage());
      }

      private async Task NavegarMedicos()
      {
         await Navigation.PushAsync(new ListaMedicos());
         //await Navigation.PushAsync(new MaestraMedicos());
      }


      #region COMANDOS
      public INavigation Navigation { get; }
      public Command Volvercomand { get; }
      public Command NavegarEspecialidadesCommand { get; }
      public Command NavegarMedicosCommand { get; }

      #endregion

   }


}
