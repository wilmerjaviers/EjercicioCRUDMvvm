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
                
                Console.WriteLine($"Error al obtener proveedores: {ex.Message}");
                return new List<Proveedor>();
            }
        }

        public bool AgregarProveedor(Proveedor proveedor)
        {
            try
            {
               
                if (string.IsNullOrWhiteSpace(proveedor.Nombre))
                {
                    return false;
                }

                
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
                
                if (proveedor.Id == 0 || string.IsNullOrWhiteSpace(proveedor.Nombre))
                {
                    return false;
                }

                
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
                
                if (id <= 0)
                {
                    return false;
                }

                
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