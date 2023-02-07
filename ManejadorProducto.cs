using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Preentrega1
{
    internal static class ManejadorProducto
    {
        //Cadena de conexion
        private static string connectionString = "Data Source=DESKTOP-K1HOTLS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Traer Usuario (recibe un int)
        public static Usuario ObtenerUsuario(int id)
        {
            Usuario usuarioSeleccionado = new Usuario();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"SELECT * FROM Usuario WHERE Usuario.Id = @Id", conn);
                SqlParameter parametro = new SqlParameter();

                parametro.SqlValue = SqlDbType.BigInt;
                parametro.Value = id;
                parametro.ParameterName = "Id";

                comando.Parameters.Add(parametro);

                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        usuarioSeleccionado.Id1 = Convert.ToInt32(reader["ID"]);
                        usuarioSeleccionado.Nombre1 = reader["Nombre"].ToString();
                        usuarioSeleccionado.Apellido1 = reader["Apellido"].ToString();
                        usuarioSeleccionado.NombreUsuario1 = reader["NombreUsuario"].ToString();
                        usuarioSeleccionado.Contraseña1 = reader["Contraseña"].ToString();
                        usuarioSeleccionado.Mail1 = reader["Mail"].ToString();
                    }
                }
            }
            return usuarioSeleccionado;
        }

        //Traer Productos (recibe un id de usuario y, devuelve una lista con todos los productos cargado
        //por ese usuario)
        public static List<Producto> ObtenerProductos(long idUsuario)
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT Producto.Id, Producto.Descripciones FROM Producto INNER JOIN " +
                    "Usuario ON Producto.IdUsuario = Usuario.Id WHERE Usuario.Id = @IdUsuario", conn);

                SqlParameter parametro = new SqlParameter();
                parametro.SqlValue = SqlDbType.BigInt;
                parametro.Value = idUsuario;
                parametro.ParameterName = "IdUsuario";

                comando.Parameters.Add(parametro);
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto temporal = new Producto();
                        temporal.Id1 = Convert.ToInt64(reader["Id"]);
                        temporal.Descripciones1 = reader["Descripciones"].ToString();
                        
                        productos.Add(temporal);
                    }
                }
            }
            return productos;
        }

        //Traer ProductosVendidos (recibe el id del usario y devuelve una lista de productos
        //vendidos por ese usuario)
        public static List<Producto> ObtenerProductosVendidos(long idUsuario)
        {
            List<Producto> productos = new List<Producto>();
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT Producto.Id, Producto.Descripciones FROM dbo.Producto " +
                    "INNER JOIN ProductoVendido ON Producto.Id = ProductoVendido.IdProducto " +
                    "WHERE Producto.IdUsuario = @IdUsuario", conn);
                SqlParameter parametro = new SqlParameter();

                parametro.Value = idUsuario;
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.ParameterName = "IdUsuario";

                comando.Parameters.Add(parametro);

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto temporal= new Producto();
                        temporal.Id1 = Convert.ToInt64(reader["Id"]);
                        temporal.Descripciones1 = reader["Descripciones"].ToString();
                        
                        productos.Add(temporal);
                    }
                }
            }
            return productos;
        }

        //Traer Ventas (recibe el id del usuario y devuelve un a lista de Ventas realizadas por ese usuario)
        public static List<Venta> ObtenerVentas(long idUsuario)
        {
            List<Venta> ventas = new List<Venta>();
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT Venta.id, Venta.Comentarios, Venta.IdUsuario " +
                    "FROM Venta INNER JOIN ProductoVendido ON ProductoVendido.IdVenta = Venta.Id " +
                    "WHERE IdUsuario = @IdUsuario", conn);

                SqlParameter parametro = new SqlParameter();
                parametro.Value = idUsuario;
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.ParameterName = "IdUsuario";

                comando.Parameters.Add(parametro);

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venta temporal = new Venta();
                        temporal.Id1 = Convert.ToInt64(reader["Id"]);
                        temporal.Comentarios1 = reader["Comentarios"].ToString();
                        temporal.IdUsuario1 = Convert.ToInt64(reader["IdUsuario"]);
                        
                        ventas.Add(temporal);
                    }
                }
            }
            return ventas;
        }

        //Inicio de sesión(recibe un usuario y contraseña y devuelve un objeto Usuario)
        public static Usuario Login(string nombreUsuario, string contraseña)
        {
            Usuario usuarioLogin = new Usuario();
            using(SqlConnection conn = new SqlConnection(connectionString)) 
            {
                SqlCommand comando = new SqlCommand($"SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña", conn);

                comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                comando.Parameters.AddWithValue("@Contraseña", contraseña);

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        usuarioLogin.Id1 = Convert.ToInt64(reader["Id"]);
                        usuarioLogin.Nombre1 = reader["Nombre"].ToString();
                        usuarioLogin.Apellido1 = reader["Apellido"].ToString();
                        usuarioLogin.NombreUsuario1 = reader["NombreUsuario"].ToString();
                        usuarioLogin.Contraseña1 = reader["Contraseña"].ToString();
                        usuarioLogin.Mail1 = reader["Mail"].ToString();
                    }
                }
            }
            return usuarioLogin;
        }
    }
}
