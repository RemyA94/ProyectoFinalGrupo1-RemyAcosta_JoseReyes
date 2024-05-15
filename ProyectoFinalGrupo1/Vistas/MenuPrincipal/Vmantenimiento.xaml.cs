using ProyFinalSeccion707.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyFinalSeccion707.Vistas.MenuPrincipal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vmantenimiento : ContentPage
    {
        public Vmantenimiento()
        {
            InitializeComponent();
            BindingContext = new VMmantenimiento(Navigation);
        }
    }
}