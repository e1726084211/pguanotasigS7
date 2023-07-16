using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pguanotasigS7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {

        public int IdSeleccionado;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> ResultadoDelete;
        IEnumerable<Estudiante> ResultadoUpdate;
        public Elemento(int Id)
        {
            con = DependencyService.Get<DataBase>().GetConnection();
            IdSeleccionado = Id;
            InitializeComponent();
        }
        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int Id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where Id = ?", Id);
        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string Nombre, string Usuario, string Contrasena, int Id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET Nombre = ?, Usuario = ?, " +
        "Contrasena = ? where Id = ?", Nombre, Usuario, Contrasena, Id);
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoUpdate = Update(db,txtNombre.Text , txtUsuario.Text, txtContrasena.Text, IdSeleccionado);
                DisplayAlert("Alerta", "Se actualizo correctamente", "ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR" + ex.Message, "ok");

            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {

                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3"); 
                var db = new SQLiteConnection(databasePath);
                ResultadoDelete = Delete(db, IdSeleccionado);
                DisplayAlert("Alerta", "Se elimino correctamente", "ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR" + ex.Message, "ok");
            }
        }
    }
}