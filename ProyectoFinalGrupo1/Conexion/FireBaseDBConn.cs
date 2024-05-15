//using Firebase.Database;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalGrupo1.Conexion
{
    public class FireBaseDBConn
    {
        public static FirebaseClient FireBase_Connect = new FirebaseClient("https://login707-1be7a-default-rtdb.firebaseio.com/");
        public const string WepApyAuthentication = "AIzaSyCg0aITetykHp-WPEPX5W4TKt2BClWUgT8";
    }

}
