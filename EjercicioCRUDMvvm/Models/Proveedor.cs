using SQLite;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EjercicioCRUDMvvm
{
    public partial class Proveedor : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Codigo { get; set; }
       

        [ObservableProperty]
        private string nombre;
        

        [ObservableProperty]
        private string direccion;
       

        [ObservableProperty]
        private string telefono;
        

        [ObservableProperty]
        private string email;
        
    }
}