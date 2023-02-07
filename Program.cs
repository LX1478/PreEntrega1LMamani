namespace Preentrega1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int id1 = 0;
            long id2 = 0, id3 = 0, id4 = 0;
            string nombreUsuario, contraseña;

            Usuario usuarioT = new Usuario();
            Console.Write("Método para obtener Usuario con IdUsuario: ");
            id1 = Convert.ToInt32(Console.ReadLine());
    
            usuarioT = ManejadorProducto.ObtenerUsuario(id1);

            Console.WriteLine("<Id>\t<Nombre>\t<Apellido\t<NombreUsuario\t<Contraseña>\t<Mail>");
            Console.WriteLine(usuarioT + "\t" + usuarioT.Nombre1 + "\t" + usuarioT.Apellido1 + "\t" + usuarioT.NombreUsuario1 + "\t" + usuarioT.Contraseña1 + "\t" + usuarioT.Mail1);
            Console.Write("\n");

            Console.WriteLine("***************************************************************************");

            Console.Write("Método para obtener Productos cargados por el IdUsuario: ");
            id2 = Convert.ToInt64(Console.ReadLine());

            List<Producto> p1 = new List<Producto>();
            p1 = ManejadorProducto.ObtenerProductos(id2);

            Console.WriteLine("<Id>\t<Descripciones>");
            foreach (Producto item in p1)
            {
                Console.WriteLine(item.Id1 + "\t" + item.Descripciones1 + "\t");
            }
            Console.WriteLine("\n");

            Console.WriteLine("***************************************************************************");

            Console.Write("Método para obtener Productos vendidos por el IdUsuario: ");
            id3 = Convert.ToInt32(Console.ReadLine());

            List<Producto> p2 = new List<Producto>();
            p2 = ManejadorProducto.ObtenerProductosVendidos(id3);

            Console.WriteLine("<Id>\t<Descripciones>");
            foreach (Producto item in p2)
            {
                Console.WriteLine(item.Id1 + "\t" + item.Descripciones1 + "\t");
            }
            Console.WriteLine("\n");

            Console.WriteLine("***************************************************************************");

            Console.Write("Método para obtener ventas por el IdUsuario: ");
            id4 = Convert.ToInt64(Console.ReadLine());

            List<Venta> v1 = new List<Venta>();
            v1 = ManejadorProducto.ObtenerVentas(id2);

            Console.WriteLine("<Id>\t<Comentarios>\t<IdUsuario>");
            foreach (Venta item in v1)
            {
                Console.WriteLine(item.Id1 + "\t" + item.Comentarios1 + "\t" + item.IdUsuario1 + "\t");
            }
            Console.WriteLine("\n");

            Console.WriteLine("***************************************************************************");

            Console.Write("Método para obtener Usuario con NombreUsuario: ");
            nombreUsuario = Console.ReadLine();
            Console.Write("Y la contraseña: ");
            contraseña = Console.ReadLine();
            
            Usuario usuarioLogin = new Usuario();

            usuarioLogin = ManejadorProducto.Login(nombreUsuario, contraseña);
            Console.WriteLine("Id: " + usuarioLogin.Id1);
            Console.WriteLine("Nombre: " + usuarioLogin.Nombre1);
            Console.WriteLine("Apellido: " + usuarioLogin.Apellido1);
            Console.WriteLine("Nombre de Usuario: " + usuarioLogin.NombreUsuario1);
            Console.WriteLine("Mail: " + usuarioLogin.Mail1);
            Console.WriteLine("Contraseña: " + usuarioLogin.Contraseña1);
        }
    }
}