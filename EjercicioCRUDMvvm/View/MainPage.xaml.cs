namespace EjercicioCRUDMvvm;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "proveedores.db3");
        BindingContext = new ProveedorViewModel(dbPath);
    }
}