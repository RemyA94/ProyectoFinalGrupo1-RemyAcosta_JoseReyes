using ProyectoFinalGrupo1.Vistas.MenuPrincipal;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalGrupo1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new Empezar();
            MainPage = new NavigationPage(new Empezar())
            {
               BarBackgroundColor = Color.White,
               BarTextColor = Color.Black
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
