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
            // Crear un nuevo proveedor si no hay uno seleccionado
            if (ProveedorSeleccionado == null)
            {
                ProveedorSeleccionado = new Proveedor();
            }

            // Validaciones
            if (string.IsNullOrWhiteSpace(ProveedorSeleccionado.Nombre))
            {
                // Aquí podrías mostrar un mensaje de error
                return;
            }

            // Intentar agregar
            if (_proveedorService.AgregarProveedor(ProveedorSeleccionado))
            {
                // Recargar la lista
                CargarProveedores();
                // Limpiar selección
                ProveedorSeleccionado = null;
            }
        }

        [RelayCommand]
        private void EditarProveedor()
        {
            // Validaciones
            if (ProveedorSeleccionado == null || ProveedorSeleccionado.Id == 0)
            {
                // Aquí podrías mostrar un mensaje de error
                return;
            }

            // Intentar editar
            if (_proveedorService.EditarProveedor(ProveedorSeleccionado))
            {
                // Recargar la lista
                CargarProveedores();
                // Limpiar selección
                ProveedorSeleccionado = null;
            }
        }

        [RelayCommand]
        private void EliminarProveedor()
        {
            // Validaciones
            if (ProveedorSeleccionado == null || ProveedorSeleccionado.Id == 0)
            {
                // Aquí podrías mostrar un mensaje de error
                return;
            }

            // Intentar eliminar
            if (_proveedorService.EliminarProveedor(ProveedorSeleccionado.Id))
            {
                // Recargar la lista
                CargarProveedores();
                // Limpiar selección
                ProveedorSeleccionado = null;
            }
        }
    }
}