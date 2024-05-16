//using Firebase.Database;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalGrupo1.Conexion
{
    public class FireBaseDBConn
    {
        public static FirebaseClient FireBase_Connect = new FirebaseClient("https://grupo-1-v1-default-rtdb.firebaseio.com/");
        public const string WepApyAuthentication = "AIzaSyDv1FNNKN3dY4oEHTefIlnMAOBSLmpntkw";
    }

}
