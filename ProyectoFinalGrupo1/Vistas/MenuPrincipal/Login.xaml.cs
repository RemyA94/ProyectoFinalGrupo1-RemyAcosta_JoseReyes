using ProyectoFinalGrupo1.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalGrupo1.Vistas.MenuPrincipal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            BindingContext = new VMlogin(Navigation);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new PageRegistrar());
            Navigation.PushAsync(new RegistroUsuario());
        }
    }
}