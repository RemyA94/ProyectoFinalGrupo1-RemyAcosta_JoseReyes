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
    public class DBmedicos
    {
        #region CRUD
        /// <summary>
        /// Consultar todos los medicos
        /// </summary>
        /// <returns>Retorna una lista con todos los medicos.</returns>
        public async Task<List<Mmedicos>> ListarMedicos()
        {
            try
            {
                return (await FireBaseDBConn.FireBase_Connect
                    .Child("libros")
                    .OrderByKey()
                    .OnceAsync<Mmedicos>())
                    .Select(datos => new Mmedicos
                    {
                        idLibroFirebase = datos.Key,
                        idLibro = datos.Object.idLibro,
                        nombre = datos.Object.nombre,
                        status = datos.Object.status,


                    }).ToList();
            }
            catch (Exception)
            {
                return null;
                await App.Current.MainPage.DisplayAlert("Error", "Compruebe la conexión a intenet he intentelo nuevamente.", "Aceptar");

            }
        }

        /// <summary>
        /// Insertar Medicos
        /// </summary>
        /// <param name="objmedico"></param>
        /// <returns>Retorna True si el registro fue insertado correctamente.</returns>
        public async Task<bool> InsertarMedicos(Mmedicos objmedico)
        {
            try
            {
                await FireBaseDBConn.FireBase_Connect
                .Child("libros")
                .PostAsync(new Mmedicos()
                {   
                    
                     idLibro = objmedico.idLibro,
                    nombre = objmedico.nombre,
                    status = objmedico.status,

                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        /// <summary>
        /// Modificar Medicos
        /// </summary>
        /// <param name="objmedico"></param>
        /// <returns>Retorna True si el registro fue modificado correctamente.</returns>
        public async Task<bool> ModificarDatosMedico(Mmedicos objmedico)
        {
            try
            {
                var modalm = (await FireBaseDBConn.FireBase_Connect
                    .Child("libros")
                    .OnceAsync<Mmedicos>()).Where(p => p.Object.nombre == objmedico.nombre).FirstOrDefault();
                await FireBaseDBConn.FireBase_Connect
                    .Child("Medicos")
                    .Child(modalm.Key)
                    .PutAsync(new Mmedicos()
                    {
                        idLibro = objmedico.idLibro,
                        nombre = objmedico.nombre,
                        status = objmedico.status

                    });
                return true;
            }
            catch (Exception ex)
            {
                return false;
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        /// <summary>
        /// Borrar Medicos
        /// </summary>
        /// <param name="objmedico"></param>
        /// <returns>Retorna True si el registro fue borrado correctamente.</returns>
        public async Task<bool> BorrarMedico(Mmedicos objmedico)
        {
            try
            {
                var borrar = (await FireBaseDBConn.FireBase_Connect
                    .Child("libros")
                    .OnceAsync<Mmedicos>()).Where(p => p.Object.idLibro == objmedico.idLibro).FirstOrDefault();
                await FireBaseDBConn.FireBase_Connect.Child("Medicos").Child(borrar.Key).DeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        #endregion

    }
}
