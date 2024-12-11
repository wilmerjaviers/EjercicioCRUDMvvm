using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EjercicioCRUDMvvm
{
    public partial class ProveedorViewModel : ObservableObject
    {
        private readonly ProveedorService _proveedorService;

        [ObservableProperty]
        private ObservableCollection<Proveedor> proveedores;

        [ObservableProperty]
        private Proveedor proveedorSeleccionado;

        public ProveedorViewModel(string dbPath)
        {
            _proveedorService = new ProveedorService(dbPath);
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            Proveedores = new ObservableCollection<Proveedor>(_proveedorService.GetProveedores());
        }

        [RelayCommand]
        private void AgregarProveedor()
        {
            
            if (ProveedorSeleccionado == null)
            {
                ProveedorSeleccionado = new Proveedor();
            }

            
            if (string.IsNullOrWhiteSpace(ProveedorSeleccionado.Nombre))
            {
                
                return;
            }

            
            if (_proveedorService.AgregarProveedor(ProveedorSeleccionado))
            {
                
                CargarProveedores();
                
                ProveedorSeleccionado = null;
            }
        }

        [RelayCommand]
        private void EditarProveedor()
        {
            
            if (ProveedorSeleccionado == null || ProveedorSeleccionado.Id == 0)
            {
                
                return;
            }

            
            if (_proveedorService.EditarProveedor(ProveedorSeleccionado))
            {
                
                CargarProveedores();
                
                ProveedorSeleccionado = null;
            }
        }

        [RelayCommand]
        private void EliminarProveedor()
        {
            
            if (ProveedorSeleccionado == null || ProveedorSeleccionado.Id == 0)
            {
                
                return;
            }

            
            if (_proveedorService.EliminarProveedor(ProveedorSeleccionado.Id))
            {
                
                CargarProveedores();
                
                ProveedorSeleccionado = null;
            }
        }
    }
}