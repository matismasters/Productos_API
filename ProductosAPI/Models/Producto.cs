using System.Data;
using ProductosAPI.Data;

namespace ProductosAPI.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public static List<Producto> TodosLosProductos() { 
            List<Producto> listaProductos = new List<Producto>();
            DataTable data = SqlHelper.Instancia.EjecutarConsulta(
                ComoSQLSelectAll()
            );

            foreach (DataRow fila in data.Rows)
            {
                listaProductos.Add(new Producto(
                    (int) fila["Id"],
                    (string) fila["Nombre"],
                    (decimal) fila["Precio"]
                ));
            }

            return listaProductos;
        }

        public static Producto Buscar(int id)
        {
            // Producto.Buscar(10) (static)
            // Devolvemos el producto con ese id de la BD
        }

        public void Actualizar()
        {
            // producto.Nombre = "algoNuevo"
            // producto.Actualizar()
            // Hace un update de este producto
        }

        public Producto Crear()
        {
            // Producto producto = new Producto("Monitor", "2000");
            // producto.Crear()
            // Crea este producto en la base de datos, tienen que manejar los errores
        }
        
        public void Borrar()
        {
            // Producto producto = new Producto("Monitor", "2000");
            // producto.Crear()
            // producto.Borrar()
            // Borra este producto de la base de datos.
        }

        public Producto()
        {
        }
        public Producto(int id, string nombre, decimal precio)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
        }
        public Producto(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        public string ComoSQLInert()
        {
            // INSERT INTO Productos(Nombre,Precio) VALUES('teclado', 90);
            return $"INSERT INTO Productos(Nombre, Precio) VALUES('{Nombre}', {Precio});";
        }
        public string ComoSQLUpdate()
        {
            // UPDATE Productos SET ... WHERE Id = Id
            return $"UPDATE Productos SET Nombre = '{Nombre}', Precio = {Precio} WHERE Id = {Id};";
        }
        public string ComoSQLDelete()
        {
            // DELETE ...
            return $"DELETE FROM Productos WHERE Id = {Id};";
        }
        public string ComoSQLSelect()
        {
            // SELECT * FROM Productos WHERE Id = Id
            return $"SELECT * FROM Productos WHERE Id = {Id};";
        }
        public static string ComoSQLSelectAll()
        {
            // SELECT * FROM Productos
            return "SELECT * FROM Productos;";
        }

        public static string ComoSQLCreateTable()
        {
            // CREATE TABLE Productos
            return @"
                CREATE TABLE Productos (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Nombre NVARCHAR(100) NOT NULL,
                    Precio NUMERIC(18,2) NOT NULL   
                )
            ";
        }
    }
}
