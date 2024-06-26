﻿using ProyectoFinalGrupo1.Vistas;
using ProyectoFinalGrupo1.Vistas.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalGrupo1.VistaModelo
{
    public class VMempezar : BaseViewModel
    {
        #region VARIABLES

        #endregion

        #region CONSTRUCTOR
        public VMempezar(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJETOS

        #endregion

        #region PROCESOS
        private async void NavegarMenuprincipal()
        {
            //await Navigation.PushAsync(new MenuPrincipal());
            await Navigation.PushAsync(new Login());
        }
        private async void NavegarMenumantenimiento()
        {
            //await Navigation.PushAsync(new MenuPrincipal());
            await Navigation.PushAsync(new Configuracion());
        }

        #endregion

        #region COMANDOS
        public ICommand Navegarmenuprincipalcommand => new Command(NavegarMenuprincipal);
        public ICommand Navegarmenumantenimientocommand => new Command(NavegarMenumantenimiento);
        #endregion
    }

}

