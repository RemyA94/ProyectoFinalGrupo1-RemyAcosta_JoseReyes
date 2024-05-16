using ProyectoFinalGrupo1.VistaModelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalGrupo1.Vistas.MenuPrincipal
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class MenuPrincipal : ContentPage
   {
      public static string usuariologueado;

      public MenuPrincipal()
      {
         InitializeComponent();
         BindingContext = new VMmenuPrincipal(Navigation);
      }

      public MenuPrincipal(string usuario)
      {
         InitializeComponent();
         //usuariologueado = usuario;
         BindingContext = new VMmenuPrincipal(Navigation, usuario);
      }
   }
}
