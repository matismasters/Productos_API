using Microsoft.Data.SqlClient;
using System.Data;

namespace ProductosAPI.Data
{
    public class SqlHelper
    {
        // Instancia singleton ya inicializada
        private static readonly SqlHelper _instancia = new SqlHelper();

        // Cadena de conexión a tu base de datos
        private readonly string _connectionString = "Server=localhost;Database=ProductosAPI;Trusted_Connection=True;";

        // Constructor privado para que no se pueda crear desde fuera
        private SqlHelper() { }

        // Propiedad para acceder a la instancia única
        public static SqlHelper Instancia => _instancia;

        // Ejecuta una consulta SELECT y devuelve un DataTable
        public DataTable EjecutarConsulta(string sql)
        {
            using var conexion = new SqlConnection(_connectionString);
            using var comando = new SqlCommand(sql, conexion);
            using var adaptador = new SqlDataAdapter(comando);
            var tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        // Ejecuta un INSERT, UPDATE o DELETE
        public int EjecutarNoConsulta(string sql)
        {
            using var conexion = new SqlConnection(_connectionString);
            using var comando = new SqlCommand(sql, conexion);
            conexion.Open();
            return comando.ExecuteNonQuery();
        }
    }
}
