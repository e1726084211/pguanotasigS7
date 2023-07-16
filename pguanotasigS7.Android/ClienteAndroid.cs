using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using pguanotasigS7.Droid;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(ClienteAndroid))]
namespace pguanotasigS7.Droid
{
    public class ClienteAndroid : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var rutaBase = Path.Combine(ruta, "uisrael.db3");
            return new SQLiteAsyncConnection(rutaBase);
        }
    }
}