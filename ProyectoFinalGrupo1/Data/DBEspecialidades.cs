using Firebase.Database.Query;
using ProyectoFinalGrupo1.Conexion;
using ProyectoFinalGrupo1.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo1.Data
{
    public class DBEspecialidades
    {
        #region CRUD
        /// <summary>
        /// Consultar todos los proveedores
        /// </summary>
        /// <returns>Retorna una lista con todas las Especialidades</returns>
        
        public async Task<List<Mespecialidad>> ListarEspecialidades()
        {
            try
            {
                return (await FireBaseDBConn.FireBase_Connect
                    .Child("Especialidad")
                    .OrderByKey()
                    .OnceAsync<Mespecialidad>())
                    .Select(datos => new Mespecialidad
                    {
                        Id_EspecialidadFirebase = datos.Key,
                        Id_Especialidad = datos.Object.Id_Especialidad,
                        Especialidad = datos.Object.Especialidad,
                        Estado = datos.Object.Estado,
                        FechaRegistro = datos.Object.FechaRegistro
                    }).ToList();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                await App.Current.MainPage.DisplayAlert("Error", "Compruebe la conexión a intenet he intentelo nuevamente.", "Aceptar");
                return null;
            }
        }

        /// <summary>
        /// Insertar Especialidades
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retorna True si el registro fue insertado correctamente.</returns>
        public async Task<bool> InsertarEspecialidad(Mespecialidad obj)
        {
            try
            {
                await FireBaseDBConn.FireBase_Connect
                .Child("Especialidad")
                .PostAsync(new Mespecialidad()
                {
                    Id_Especialidad = obj.Id_Especialidad,
                    Especialidad = obj.Especialidad,
                    Estado = obj.Estado,
                    FechaRegistro = obj.FechaRegistro
                });
                return true;
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                await App.Current.MainPage.DisplayAlert("Error", mensaje, "Aceptar");
                return false;
            }
        }

        /// <summary>
        /// Modificar Especialidades
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retorna True si el registro fue modificado correctamente.</returns>

        public async Task<bool> ModificarDatosEspecialidades(Mespecialidad obj)
        {
            try
            {
                var modprov = (await FireBaseDBConn.FireBase_Connect
                    .Child("Especialidad")
                    .OnceAsync<Mespecialidad>()).Where(p => p.Object.Id_Especialidad == obj.Id_Especialidad).FirstOrDefault();
                await FireBaseDBConn.FireBase_Connect
                    .Child("Especialidad")
                    .Child(modprov.Key)
                    .PutAsync(new Mespecialidad()
                    {
                        Id_Especialidad = obj.Id_Especialidad,
                        Especialidad = obj.Especialidad,
                        Estado = obj.Estado,
                        FechaRegistro = obj.FechaRegistro
                    });
                return true;
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                await App.Current.MainPage.DisplayAlert("Error", mensaje, "Aceptar");
                return false;
            }
        }

        /// <summary>
        /// Borrar Especialidad
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retorna True si el registro fue borrado correctamente.</returns>

        public async Task<bool> BorrarEspecialidad(Mespecialidad obj)
        {
            try
            {
                var borrar = (await FireBaseDBConn.FireBase_Connect
                    .Child("Especialidad")
                    .OnceAsync<Mespecialidad>()).Where(p => p.Object.Id_Especialidad == obj.Id_Especialidad).FirstOrDefault();
                await FireBaseDBConn.FireBase_Connect.Child("Especialidad").Child(borrar.Key).DeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
                return false;
            }
        }

        #endregion

    }
}
