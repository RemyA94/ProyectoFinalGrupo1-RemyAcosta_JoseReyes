using Firebase.Auth;
using ProyectoFinalGrupo1.Conexion;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalGrupo1.Vistas.MenuPrincipal
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class RegistroUsuario : ContentPage
   {
      public RegistroUsuario()
      {
         InitializeComponent();
      }

      private void TapLabelTerminosCondiciones_Tapped(object sender, EventArgs e)
      {
         popupTerminosCondiciones.IsVisible = true;
      }

      private void btnCerrarModal_Clicked(object sender, EventArgs e)
      {
         popupTerminosCondiciones.IsVisible = false;
      }

      private async void btnRegistrar_Clicked(object sender, EventArgs e)
      {
         string email = txtemail.Text;
         string clave = txtclave.Text;

         #region Reglas para la insercion de la información

         if (chkAceptaTerminos.IsChecked != true)
         {
            await DisplayAlert("Alerta", "Seleccione los terminos y condiciones", "Ok");
            return;
         }

         if (string.IsNullOrEmpty(email))
         {
            await DisplayAlert("Alerta", "Escriba su email", "Ok");
            return;
         }

         if (string.IsNullOrEmpty(clave))
         {
            await DisplayAlert("Alerta", "Escriba su contraseña", "Ok");
            return;
         }

         #endregion

         #region Logica para crear el usuario

         try
         {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(FireBaseDBConn.WepApyAuthentication));
            await authProvider.CreateUserWithEmailAndPasswordAsync(email, clave);

            MostrarRegistroExitoso();

            await Task.Delay(3000); // Espera la duración de la animación

            //await App.Current.MainPage.Navigation.PushModalAsync(new Login());
            await Navigation.PushModalAsync(new NavigationPage(new Login()));
         }
         catch (Exception ex)
         {
            await DisplayAlert("Error", ex.Message, "Ok");
         }

         #endregion
      }

      private void MostrarRegistroExitoso()
      {
         popupRegistroExitoso.IsVisible = true;
      }

      private void btnCerrarRegistroExitoso_Clicked(object sender, EventArgs e)
      {
         popupRegistroExitoso.IsVisible = false;
         Navigation.PopAsync();
      }
   }
}
