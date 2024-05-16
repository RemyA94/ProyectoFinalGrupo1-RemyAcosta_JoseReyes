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
                    .Child("socios")
                    .OnceAsync<Mespecialidad>())
                    .Select(datos => new Mespecialidad
                    {
                        idsocio = datos.Object.idsocio,
                        nombre = datos.Object.nombre,
                        status = datos.Object.status,
                        fechaRegistro = datos.Object.fechaRegistro
                    }).ToList();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                // await App.Current.MainPage.DisplayAlert("Error", "Compruebe la conexión a intenet he intentelo nuevamente.", "Aceptar");
                await App.Current.MainPage.DisplayAlert("Error", mensaje, "Aceptar");
                return null;
            }
        }

        /// <summary>
        /// Insertar socios
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retorna True si el registro fue insertado correctamente.</returns>
        public async Task<bool> InsertarEspecialidad(Mespecialidad obj)
        {
            try
            {
                await FireBaseDBConn.FireBase_Connect
                .Child("socios")
                .PostAsync(new Mespecialidad()
                {
                    fechaRegistro = obj.fechaRegistro,
                    status = obj.status,
                    nombre = obj.nombre,
                    idsocio = obj.idsocio
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
        /// Modificar socios
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retorna True si el registro fue modificado correctamente.</returns>

        public async Task<bool> ModificarDatosEspecialidades(Mespecialidad obj)
        {
            try
            {
                var modprov = (await FireBaseDBConn.FireBase_Connect
                    .Child("socios")
                    .OnceAsync<Mespecialidad>()).Where(p => p.Object.idsocio == obj.idsocio).FirstOrDefault();
                await FireBaseDBConn.FireBase_Connect
                    .Child("socios")
                    .Child(modprov.Key)
                    .PutAsync(new Mespecialidad()
                    {
                        idsocio = obj.idsocio,
                        nombre = obj.nombre,
                        status = obj.status,
                        fechaRegistro = obj.fechaRegistro
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
        /// Borrar socios
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retorna True si el registro fue borrado correctamente.</returns>

        public async Task<bool> BorrarEspecialidad(Mespecialidad obj)
        {
            try
            {
                var borrar = (await FireBaseDBConn.FireBase_Connect
                    .Child("Especialidad")
                    .OnceAsync<Mespecialidad>()).Where(p => p.Object.idsocio == obj.idsocio).FirstOrDefault();
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
