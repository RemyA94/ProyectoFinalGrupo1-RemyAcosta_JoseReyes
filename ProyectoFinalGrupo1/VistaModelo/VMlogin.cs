using Firebase.Auth;
using ProyectoFinalGrupo1.Conexion;
using ProyectoFinalGrupo1.Modelo;
using ProyectoFinalGrupo1.Vistas.MenuPrincipal;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoFinalGrupo1.VistaModelo
{
   public class VMlogin : BaseViewModel
   {
      private string email;
      private string clave;

      public string txtemail
      {
         get { return email; }
         set { SetValue(ref email, value); }
      }

      public string txtclave
      {
         get { return clave; }
         set { SetValue(ref clave, value); }
      }

      public Command LogearUsuarioCommand { get; }

      public VMlogin(INavigation navigation)
      {
         Navigation = navigation;
         LogearUsuarioCommand = new Command(async () => await LoginUsuario());
      }

      private async Task LoginUsuario()
      {
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

         var objusuario = new MUsuarios()
         {
            Email = email.Trim(),
            Clave = clave
         };

         try
         {
            var autenticacion = new FirebaseAuthProvider(new FirebaseConfig(FireBaseDBConn.WepApyAuthentication));
            var authuser = await autenticacion.SignInWithEmailAndPasswordAsync(objusuario.Email, objusuario.Clave);
            string obternertoken = authuser.FirebaseToken;

            var Propiedades_NavigationPage = new NavigationPage(new MenuPrincipal(objusuario.Email));
            Propiedades_NavigationPage.BarBackgroundColor = Color.RoyalBlue;
            App.Current.MainPage = Propiedades_NavigationPage;
         }
         catch (Exception)
         {
            await App.Current.MainPage.DisplayAlert("Error", "Usuario o clave incorrecto.", "Intentar de nuevo");
         }
      }
   }
}
