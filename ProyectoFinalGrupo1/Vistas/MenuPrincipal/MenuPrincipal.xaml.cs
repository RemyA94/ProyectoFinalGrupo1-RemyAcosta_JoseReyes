using ProyectoFinalGrupo1.VistaModelo;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalGrupo1.Vistas.MenuPrincipal
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class MenuPrincipal : ContentPage
   {
      public static string usuariologueado;
      public MenuPrincipal(string usuario)
      {
         InitializeComponent();
         BindingContext = new VMmenuPrincipal(Navigation, usuario);
         MessagingCenter.Subscribe<VMmenuPrincipal>(this, "MostrarPopup", (sender) =>
         {
            popupCreadopor.IsVisible = true;
         });
      }

      private void btnCerrarPopup_Clicked(object sender, EventArgs e)
      {
         popupCreadopor.IsVisible = false;
      }
   }
}
