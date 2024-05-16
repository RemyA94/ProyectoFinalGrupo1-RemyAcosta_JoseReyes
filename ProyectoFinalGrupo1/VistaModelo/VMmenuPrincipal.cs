using ProyectoFinalGrupo1.Vistas.MenuPrincipal;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoFinalGrupo1.VistaModelo
{
   internal class VMmenuPrincipal : BaseViewModel
   {
      private string _usuario;
      public string Usuario
      {
         get => _usuario;
         set
         {
            _usuario = value;
            OnPropertyChanged();
         }
      }

      public INavigation Navigation { get; }

      public VMmenuPrincipal(INavigation navigation)
      {
         Navigation = navigation;
         InitializeCommands();
      }

      public VMmenuPrincipal(INavigation navigation, string usuario) : this(navigation)
      {
         Usuario = usuario;
      }

      private void InitializeCommands()
      {
         VolverCommand = new Command(async () => await Volver());
         NavegarMantenimientoCommand = new Command(async () => await NavegarMenuMantenimiento());
         NavegarReportesCommand = new Command(async () => await NavegarMenuReportes());
      }

      private async Task Volver()
      {
         await Navigation.PopAsync();
      }

      private async Task NavegarMenuMantenimiento()
      {
         await Navigation.PushAsync(new MenuMantenimiento());
      }

      private async Task NavegarMenuReportes()
      {
         await Navigation.PushAsync(new MenuReportes());
      }

      public Command VolverCommand { get; private set; }
      public Command NavegarMantenimientoCommand { get; private set; }
      public Command NavegarReportesCommand { get; private set; }
   }
}
