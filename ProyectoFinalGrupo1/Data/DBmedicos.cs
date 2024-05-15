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
                    .Child("Medicos")
                    .OrderByKey()
                    .OnceAsync<Mmedicos>())
                    .Select(datos => new Mmedicos
                    {
                        ID_MedicoFirebase = datos.Key,
                        ID_Medico = datos.Object.ID_Medico,
                        Nombre = datos.Object.Nombre,
                        Apellido = datos.Object.Apellido,

                        Especialidad = new Mespecialidad
                        {
                            Id_Especialidad = datos.Object.Especialidad.Id_Especialidad,
                            Especialidad = datos.Object.Especialidad.Especialidad,
                        },
                        Genero = datos.Object.Genero,
                        Telefono = datos.Object.Telefono,
                        Email = datos.Object.Email,
                        Estado = datos.Object.Estado,
                        FechaRegistro = datos.Object.FechaRegistro

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
                .Child("Medicos")
                .PostAsync(new Mmedicos()
                {
                     ID_Medico = objmedico.ID_Medico,
                    Nombre = objmedico.Nombre,
                    Apellido = objmedico.Apellido,

                    Especialidad = new Mespecialidad
                    {
                        Id_Especialidad = objmedico.Especialidad.Id_Especialidad,
                        Especialidad = objmedico.Especialidad.Especialidad
                    },
                    Genero = objmedico.Genero,
                    Telefono = objmedico.Telefono,
                    Email = objmedico.Email,
                    Estado = objmedico.Estado,
                    FechaRegistro = objmedico.FechaRegistro

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
                    .Child("Medicos")
                    .OnceAsync<Mmedicos>()).Where(p => p.Object.ID_Medico == objmedico.ID_Medico).FirstOrDefault();
                await FireBaseDBConn.FireBase_Connect
                    .Child("Medicos")
                    .Child(modalm.Key)
                    .PutAsync(new Mmedicos()
                    {
                        ID_Medico = objmedico.ID_Medico,
                        Nombre = objmedico.Nombre,
                        Apellido = objmedico.Apellido,

                        Especialidad = new Mespecialidad
                        {
                            Id_Especialidad = objmedico.Especialidad.Id_Especialidad,
                            Especialidad = objmedico.Especialidad.Especialidad
                        },
                        Genero = objmedico.Genero,
                        Telefono = objmedico.Telefono,
                        Email = objmedico.Email,
                        Estado = objmedico.Estado,
                        FechaRegistro = objmedico.FechaRegistro
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
                    .Child("Medicos")
                    .OnceAsync<Mmedicos>()).Where(p => p.Object.ID_Medico == objmedico.ID_Medico).FirstOrDefault();
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
