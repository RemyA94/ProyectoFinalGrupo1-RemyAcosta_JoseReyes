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
    public partial class MenuMantenimiento : ContentPage
    {
        public MenuMantenimiento()
        {
            InitializeComponent();
            BindingContext = new VMmantenimiento(Navigation);
        }

      public MenuMantenimiento(string usuario)
      {
         InitializeComponent();
         BindingContext = new VMmenuPrincipal(Navigation, usuario);
      }
   }
}