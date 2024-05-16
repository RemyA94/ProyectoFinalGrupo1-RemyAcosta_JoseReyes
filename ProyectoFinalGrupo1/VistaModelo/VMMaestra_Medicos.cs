using ProyectoFinalGrupo1.Data;
using ProyectoFinalGrupo1.Modelo;
using ProyectoFinalGrupo1.Vistas.Listas_de_Maestras;
using ProyectoFinalGrupo1.Vistas.Maestras;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoFinalGrupo1.VistaModelo
{
    public class VMMaestra_Medicos : BaseViewModel
    {
        #region Atributos
        //Campos Modelo
        Mespecialidad selectEspecialidad;
        public List<Mespecialidad> listaespecialidad = new List<Mespecialidad>();
        public string idmedico;
        public string nombremedico;
        public string apellidomedico;
        public string genero;
        public string telefono;
        public string email;
        public string estado;
        public string fecharegistro;
        public string idespecialidad;
        public string especialidad;

        //Botones
        public bool isenebledcrear;
        public bool isenebledmodificar;
        public bool isenebledguardar;
        public bool isenebledcancelar;
        public bool isenebledborrar;
        public bool isvisiblelistaespecialidades = false;
        public bool isvisiblebuscarespecialidades = false;

        //Otros
        public bool chkestado;
        public System.Drawing.Color colorfondoid;
        public bool isrefrescar = false;
        public object listamedicos;
        public object listaespecialidades;
        //public bool correrbarra;
        public bool isvisible = false;
        #endregion

        #region Propiedades


        #region Campos Modelo

        public List<Mespecialidad> Listaespecialidad
        {
            get { return listaespecialidad; }
            set { SetValue(ref listaespecialidad, value); }
        }

        public Mespecialidad SelectEspecialidad
        {
            get { return selectEspecialidad; }
            set
            {
                SetProperty(ref selectEspecialidad, value);
                txtidespecialidad = selectEspecialidad.idsocio;
                txtnombreespecialidad = selectEspecialidad.idsocio;
            }
        }


        public string txtidmedico
        {
            get { return idmedico; }
            set { SetValue(ref idmedico, value); }
        }
        public string txtnombremedico
        {
            get { return nombremedico; }
            set { SetValue(ref nombremedico, value); }
        }
                      
        public string txtapellidomedico
        {
            get { return apellidomedico; }
            set { SetValue(ref apellidomedico, value); }
        }

        public string txtgenero
        {
            get { return genero; }
            set { SetValue(ref genero, value); }
        }
        public string txttelefono
        {
            get { return telefono; }
            set { SetValue(ref telefono, value); }
        }
        public string txtemail
        {
            get { return email; }
            set { SetValue(ref email, value); }
        }
        public string txtidespecialidad
        {
            get { return idespecialidad; }
            set { SetValue(ref idespecialidad, value); }
        }
        public string txtnombreespecialidad
        {
            get { return especialidad; }
            set { SetValue(ref especialidad, value); }
        }

        public string txtfecharegistro
        {
            get { return fecharegistro; }
            set { SetValue(ref fecharegistro, value); }
        }

        public string txtestado
        {
            get { return estado; }
            set { SetValue(ref estado, value); }
        }

        #endregion

        #region Botones
        public bool IsEnebledCrear
        {
            get { return isenebledcrear; }
            set { SetValue(ref isenebledcrear, value); }
        }
        public bool IsEnebledModificar
        {
            get { return isenebledmodificar; }
            set { SetValue(ref isenebledmodificar, value); }
        }
        public bool IsEnebledGuardar
        {
            get { return isenebledguardar; }
            set { SetValue(ref isenebledguardar, value); }
        }
        public bool IsEnebledCancelar
        {
            get { return isenebledcancelar; }
            set { SetValue(ref isenebledcancelar, value); }
        }
        public bool IsEnebledBorrar
        {
            get { return isenebledborrar; }
            set { SetValue(ref isenebledborrar, value); }
        }
        public bool IsVisibleListaMedicos
        {
            get { return isvisiblelistaespecialidades; }
            set { SetValue(ref isvisiblelistaespecialidades, value); }
        }
        public bool IsVisibleBuscarEspecialidades
        {
            get { return isvisiblebuscarespecialidades; }
            set { SetValue(ref isvisiblebuscarespecialidades, value); }
        }
        #endregion

        #region Otros
        public bool ChkEstadoValidar
        {
            get { return chkestado; }
            set { SetValue(ref chkestado, value); }
        }
        public System.Drawing.Color ColorFondoId
        {
            get { return colorfondoid; }
            set { SetValue(ref colorfondoid, value); }
        }
        public bool IsRefrescar
        {
            get { return isrefrescar; }
            set { SetValue(ref isrefrescar, value); }
        }
        public object ListaMedicos
        {
            get { return listamedicos; }
            set { SetValue(ref listamedicos, value); }
        }
        public object ListaEspecialidades
        {
            get { return listaespecialidades; }
            set { SetValue(ref listaespecialidades, value); }
        }

        public bool IsVisible
        {
            get { return isvisible; }
            set { SetValue(ref isvisible, value); }
        }
        #endregion

        #endregion

        #region Command
        public Command RefrescarCommand { get; }
        public Command RefrescarListMedCommand { get; }
        public Command CrearCommand { get; }
        public Command ModificarCommand { get; }
        public Command GuardarCambiosCommand { get; }
        public Command CancelarCommand { get; }
        public Command BorrarCommand { get; }
        public Command Ir_CrearMedicoCommand { get; }
        public Command BuscarEspecialidadCommand { get; }
        public Command CerrarListaEspecialidadesCommand { get; }
        public Command VolverCommand { get; }
        #endregion

        #region Métodos
        //Creamos una instancia de:
        DBmedicos dbmedicos = new DBmedicos();
        DBEspecialidades dbespecialidades = new DBEspecialidades();
        public ObservableCollection<Mmedicos> ColeccionMed = new ObservableCollection<Mmedicos>();
        private string idsocio;
        private string nombre;

        private async Task Mostrarespecialidades()
        {
            //var funcion = new DBEspecialidades();
            Listaespecialidad = await dbespecialidades.ListarEspecialidades();
        }

        public async Task Listar_Medicos()
        {
            IsRefrescar = true;
            await Task.Delay(100);
            ListaMedicos = await dbmedicos.ListarMedicos();
            IsRefrescar = false;
        }

        public async Task Listar_Especialidades()
        {
            IsRefrescar = true;
            await Task.Delay(100);
            //ListaEspecialidades = await dbespecialidades.ListarEspecialidades();
            Listaespecialidad = await dbespecialidades.ListarEspecialidades();
            IsRefrescar = false;
        }

        public async Task Buscar_En_DBMedicos()
        {
            List<Mmedicos> ListMed = await dbmedicos.ListarMedicos();
            foreach (var encontrado in ListMed)
            {
                ColeccionMed.Add(encontrado);
            }
        }
        public async Task Crear()
        {
            List<Mmedicos> registros = await dbmedicos.ListarMedicos();
            int cant_registros = registros.Count();
            int IdGenerado;
            if (cant_registros == 0)
                IdGenerado = 1;
            else
                IdGenerado = cant_registros + 1;

            txtidmedico = string.Format("MED-{0:000}", IdGenerado);
            txtnombremedico = "";
            txtapellidomedico = "";
            txtgenero = "";
            txttelefono = "";
            txtemail = "";
            txtestado = "";
            txtfecharegistro = DateTime.Now.Date.ToString("dd-MMM-yyy");
            txtnombreespecialidad = "";
            txtidespecialidad = "";

            ColorFondoId = System.Drawing.Color.LightGreen;
            IsEnebledModificar = false;
            IsEnebledCrear = false;
            IsEnebledCancelar = true;
            IsEnebledGuardar = true;
            IsEnebledBorrar = false;
            IsVisibleBuscarEspecialidades = true;
        }
        public async Task GuardarCambios()
        {
            try
            {
                if (ColorFondoId == System.Drawing.Color.Transparent)
                {
                    await App.Current.MainPage.DisplayAlert("Información", "No existen datos que guardar.", "Aceptar");
                    return;
                }
                #region Reglas para la insercion de los datos
                if (string.IsNullOrEmpty(txtnombremedico))
                {
                    await App.Current.MainPage.DisplayAlert("Advertencia", "Debe de indicar un nombre.", "Aceptar");
                    return;
                }
                if (string.IsNullOrEmpty(txtapellidomedico))
                {
                    await App.Current.MainPage.DisplayAlert("Advertencia", "Debe de indicar un apellido", "Aceptar");
                    return;
                }
                if (string.IsNullOrEmpty(txttelefono))
                {
                    await App.Current.MainPage.DisplayAlert("Advertencia", "Debe de colocar un número de contacto.", "Aceptar");
                    return;
                }
                if (txtnombreespecialidad == "")
                {
                    await App.Current.MainPage.DisplayAlert("Advertencia", "Debe de colocar el nombre de la especialidad", "Aceptar");
                    return;
                }
                //Validar estado
                if (ChkEstadoValidar == true)
                    estado = "Inactivo";
                else
                    estado = "Activo";
                #endregion

                //Instanciamos el modelo para obtener los datos introducidos por el usuario
                var objmedicos = new Mmedicos
                {
                    ID_Medico = idmedico,
                    Nombre = nombremedico,
                    Apellido = apellidomedico,
                    Genero = genero,
                    Telefono = telefono,
                    Email = email,

                    Especialidad = new Mespecialidad
                    {
                        idsocio = idsocio,
                        nombre = nombre
                    },

                    Estado = estado,
                    FechaRegistro = fecharegistro
                };

                if (ColorFondoId == System.Drawing.Color.LightGreen)
                {
                    if (objmedicos.Estado == "Inactivo")
                    {
                        await App.Current.MainPage.DisplayAlert("Advertencia", "No se puede insertar un medico como inactivo.", "Aceptar");
                    }
                    else
                    {
                        IsVisible = true;
                        await Task.Delay(1000);
                        await dbmedicos.InsertarMedicos(objmedicos);
                        IsVisible = false;
                        ColorFondoId = System.Drawing.Color.Transparent;
                        IsEnebledCancelar = false;
                        IsEnebledGuardar = false;
                        IsEnebledCrear = true;
                        IsEnebledModificar = true;
                        IsEnebledBorrar = true;
                        await App.Current.MainPage.DisplayAlert("Información", "Datos registrados exitosamente.", "Aceptar");
                        await Navigation.PushAsync(new ListaMedicos());
                    }
                }
                else
                {
                    IsVisible = true;
                    await Task.Delay(1000);
                    bool respuesta = await dbmedicos.ModificarDatosMedico(objmedicos);
                    IsVisible = false;
                    if (respuesta == true)
                    {
                        ColorFondoId = System.Drawing.Color.Transparent;
                        IsEnebledCancelar = false;
                        IsEnebledGuardar = false;
                        IsEnebledCrear = true;
                        IsEnebledModificar = true;
                        IsEnebledBorrar = true;
                        await App.Current.MainPage.DisplayAlert("Información", "Datos modificados exitosamente.", "Aceptar");
                        await Navigation.PushAsync(new ListaMedicos());
                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
        public async Task Modificar()
        {
            try
            {
                List<Mmedicos> cargardatos = await dbmedicos.ListarMedicos();
                var objmedicos = new Mmedicos
                {
                    ID_Medico = idmedico
                };
                var datosencontrados = cargardatos.Where(buscar => buscar.ID_Medico == objmedicos.ID_Medico).FirstOrDefault();
                if (datosencontrados != null)
                {

                    txtidmedico = datosencontrados.ID_Medico;
                    txtnombremedico = datosencontrados.Nombre;
                    txtapellidomedico = datosencontrados.Apellido;
                    txtgenero = datosencontrados.Genero;
                    txttelefono = datosencontrados.Telefono;
                    txtemail = datosencontrados.Email;
                    txtestado = datosencontrados.Estado;
                    txtidespecialidad = datosencontrados.Especialidad.idsocio;
                    txtnombreespecialidad = datosencontrados.Especialidad.idsocio;
                    
                    txtfecharegistro = datosencontrados.FechaRegistro;
                    ColorFondoId = System.Drawing.Color.Khaki;
                    IsEnebledModificar = false;
                    IsEnebledCrear = false;
                    IsEnebledCancelar = true;
                    IsEnebledGuardar = true;
                    IsEnebledBorrar = false;
                    IsVisibleBuscarEspecialidades = true;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Información", "Debe seleccionar un medico", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
        public async Task Borrar()
        {
            try
            {
                var objmedico = new Mmedicos()
                {
                    ID_Medico = idmedico
                };

                if (string.IsNullOrEmpty(txtidmedico))
                {
                    await App.Current.MainPage.DisplayAlert("Información", "Debe de seleccionar un medico.", "Aceptar");
                }
                else
                {
                    string respuesta = await App.Current.MainPage.DisplayActionSheet("¿Seguro que desea borrar el medico?", "Cancelar", null, "Si", "No");
                    if (respuesta == "Si")
                    {
                        IsVisible = true;
                        await Task.Delay(1000);
                        await dbmedicos.BorrarMedico(objmedico);
                        IsVisible = false;

                        txtidmedico = "";
                        txtnombremedico = "";
                        txtapellidomedico = "";
                        txtgenero = "";
                        txttelefono = "";
                        txtemail = "";
                        txtestado = "";
                        txtfecharegistro = "";
                        txtidespecialidad = "";
                        txtnombreespecialidad = "";

                        ChkEstadoValidar = false;
                        IsEnebledCancelar = false;
                        IsEnebledGuardar = false;
                        ColorFondoId = System.Drawing.Color.Transparent;
                        await App.Current.MainPage.DisplayAlert("Información", "Datos borrados exitosamente.", "Aceptar");
                        await Navigation.PushAsync(new ListaMedicos());

                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        public async Task Cancelar()
        {
            if (ColorFondoId == System.Drawing.Color.LightGreen)
            {
                txtidmedico = "";
                txtnombremedico = "";
                txtapellidomedico = "";
                txtgenero = "";
                txttelefono = "";
                txtemail = "";
                txtestado = "";
                txtfecharegistro = "";
                txtidespecialidad = "";
                txtnombreespecialidad = "";

                ColorFondoId = System.Drawing.Color.Transparent;
                IsEnebledCancelar = false;
                IsEnebledGuardar = false;
                IsVisibleBuscarEspecialidades = false;
                IsEnebledModificar = true;
                IsEnebledCrear = true;
                IsEnebledBorrar = true;
            }
            else
                {
                ColorFondoId = System.Drawing.Color.Transparent;
                IsEnebledCancelar = false;
                IsEnebledGuardar = false;
                IsVisibleBuscarEspecialidades = false;
                IsEnebledModificar = true;
                IsEnebledCrear = true;
                IsEnebledBorrar = true;
            }
        }


        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        
        public async Task CerrarListaEspecialidades()
        {
            isvisiblelistaespecialidades = false;
        }

        async public Task BuscarEspecialidades()
        {
            isvisiblelistaespecialidades = true;
            _ = Listar_Especialidades();
            //return Task.CompletedTask;
        }

        public async Task Ir_CrearMedicos()
        {
            await Navigation.PushAsync(new MaestraMedicos());
        }
        #endregion

        #region Constructor
        //Principal
        public VMMaestra_Medicos(INavigation navegar)
        {
            Navigation = navegar;

            //Controlar estados de los botones al iniciar el componente
            ColorFondoId = System.Drawing.Color.Transparent;
            IsEnebledGuardar = false;
            IsEnebledCrear = true;
            IsEnebledModificar = true;
            IsEnebledBorrar = true;
            IsEnebledCancelar = false;
            //egerman
            IsVisibleBuscarEspecialidades = false;
            isvisiblelistaespecialidades = false;

            RefrescarCommand = new Command(async () => await Listar_Medicos());
            RefrescarListMedCommand = new Command(async () => await Listar_Especialidades());
            CrearCommand = new Command(async () => await Crear());
            GuardarCambiosCommand = new Command(async () => await GuardarCambios());
            ModificarCommand = new Command(async () => await Modificar());
            BorrarCommand = new Command(async () => await Borrar());
            CancelarCommand = new Command(async () => await Cancelar());
            BuscarEspecialidadCommand = new Command(async () => await BuscarEspecialidades());
            Ir_CrearMedicoCommand = new Command(async () => await Ir_CrearMedicos());
            CerrarListaEspecialidadesCommand = new Command(async () => await CerrarListaEspecialidades());
            VolverCommand = new Command(async () => await Volver());
            _= Listar_Medicos();
            _ = Listar_Especialidades();
            _= Mostrarespecialidades();
        }


        public VMMaestra_Medicos(Mmedicos objmedicos)
        {
            //Controlar estados de los botones al iniciar el componente
            //ColorFondoId = Color.Transparent;
            IsEnebledGuardar = false;
            IsEnebledCrear = true;
            IsEnebledModificar = true;
            IsEnebledBorrar = true;
            IsEnebledCancelar = false;
            IsVisibleBuscarEspecialidades = false;
            isvisiblelistaespecialidades = false;


            // Cargar datos del id seleccionado
            txtidmedico = objmedicos.ID_Medico;
            txtnombremedico = objmedicos.Nombre;
            txtapellidomedico = objmedicos.Apellido;
            txtgenero = objmedicos.Genero;
            txttelefono = objmedicos.Telefono;
            txtemail = objmedicos.Email;
            txtfecharegistro = objmedicos.FechaRegistro;
            txtidespecialidad = objmedicos.Especialidad.idsocio;
            txtnombreespecialidad = objmedicos.Especialidad.idsocio;
            if (objmedicos.Estado == "Inactivo")
                ChkEstadoValidar = true;
            else
                ChkEstadoValidar = false;

            BuscarEspecialidadCommand = new Command(async () => await BuscarEspecialidades());
            RefrescarCommand = new Command(async () => await Listar_Medicos());
            CrearCommand = new Command(async () => await Crear());
            ModificarCommand = new Command(async () => await Modificar());
            CancelarCommand = new Command(async () => await Cancelar());
            BorrarCommand = new Command(async () => await Borrar());
            GuardarCambiosCommand = new Command(async () => await GuardarCambios());
            CerrarListaEspecialidadesCommand = new Command(async () => await CerrarListaEspecialidades());
            VolverCommand = new Command(async () => await Volver());
            //_ = Listar_Medicos();
            _ = Listar_Especialidades();
        }
        #endregion

    }
}
