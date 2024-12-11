using SQLite;

namespace EjercicioCRUDMvvm
{
    public class ProveedorService
    {
        private readonly SQLiteConnection _connection;

        public ProveedorService(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<Proveedor>();
        }

        public List<Proveedor> GetProveedores()
        {
            try
            {
                return _connection.Table<Proveedor>().ToList();
            }
            catch (Exception ex)
            {
                // Aquí podrías agregar logging
                Console.WriteLine($"Error al obtener proveedores: {ex.Message}");
                return new List<Proveedor>();
            }
        }

        public bool AgregarProveedor(Proveedor proveedor)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(proveedor.Nombre))
                {
                    return false;
                }

                // Insertar y retornar si fue exitoso
                return _connection.Insert(proveedor) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar proveedor: {ex.Message}");
                return false;
            }
        }

        public bool EditarProveedor(Proveedor proveedor)
        {
            try
            {
                // Validaciones básicas
                if (proveedor.Id == 0 || string.IsNullOrWhiteSpace(proveedor.Nombre))
                {
                    return false;
                }

                // Actualizar y retornar si fue exitoso
                return _connection.Update(proveedor) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar proveedor: {ex.Message}");
                return false;
            }
        }

        public bool EliminarProveedor(int id)
        {
            try
            {
                // Validar que el ID sea válido
                if (id <= 0)
                {
                    return false;
                }

                // Eliminar y retornar si fue exitoso
                return _connection.Delete<Proveedor>(id) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar proveedor: {ex.Message}");
                return false;
            }
        }
    }
}