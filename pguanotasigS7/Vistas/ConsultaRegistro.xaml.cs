using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pguanotasigS7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tabla;
        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            Obtener();
        }

        public async void Obtener()
        {
            var resultado = await con.Table<Estudiante>().ToListAsync();
            tabla = new ObservableCollection<Estudiante>(resultado);
            listaEstudiantes.ItemsSource = tabla;
        }

        private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Estudiante)e.SelectedItem;
            var item = Obj.Id.ToString();
            int ID = Convert.ToInt32(item);

            try
            {
                Navigation.PushAsync(new Elemento(ID));
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}