using Firebase.Auth;
using ProyectoFinalGrupo1.Conexion;
using ProyectoFinalGrupo1.Modelo;
using ProyectoFinalGrupo1.Vistas.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoFinalGrupo1.VistaModelo
{
    public class VMlogin : BaseViewModel
    {
        #region Atributos
        private string email;
        private string clave;
        #endregion

        #region Propiedades
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
        #endregion

        #region Command
        public Command LogearUsuarioCommand { get; }
        #endregion

        #region Metodo
        public async Task LoginUsuario()
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
                var authuser = await autenticacion.SignInWithEmailAndPasswordAsync(objusuario.Email.ToString(), objusuario.Clave.ToString());
                string obternertoken = authuser.FirebaseToken;

                var Propiedades_NavigationPage = new NavigationPage(new MenuPrincipal(objusuario.Email.ToString()));

                //var Propiedades_NavigationPage = new NavigationPage(new MenuPrincipal());

                Propiedades_NavigationPage.BarBackgroundColor = Color.RoyalBlue;
                App.Current.MainPage = Propiedades_NavigationPage;
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Las credenciales introducidas son incorrectos o el usuario se encuentra inactivo.", "Aceptar");
            }
        }
        #endregion

        #region Constructor
        public VMlogin(INavigation navegar)
        {
            Navigation = navegar;
            LogearUsuarioCommand = new Command(async () => await LoginUsuario());
        }
        #endregion
    }
}
