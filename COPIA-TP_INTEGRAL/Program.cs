using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static TP_INTEGRAL_PROGRAMACION.Program;

namespace TP_INTEGRAL_PROGRAMACION
{

    internal class Program
    {
        static bool existe = false;
        static int opcion, productoBuscado;
        static string productoAEliminar;

        public struct Cerveza
        {
            public string NombreCerveza;
            public string PresentacionCerveza;
            public int StockCerveza;
            public double PreciosCerveza;


            public Cerveza(string nombreCerveza, string presentacionCerveza, int stockCerveza, double preciosCerveza)
            {
                NombreCerveza = nombreCerveza;
                PresentacionCerveza = presentacionCerveza;
                StockCerveza = stockCerveza;
                PreciosCerveza = preciosCerveza;
            }
        }
        static void Main(string[] args)
        {
            /*La idea principal de programa es trabajar con datos ya cargados
             pero a la vez poder modificalos, ya sea para eliminar o añadir productos*/

            Cerveza[] infoDeCerveza = new Cerveza[]
            {
                new Cerveza("IPA", "BARRILES", 10, 100000.00),
                new Cerveza("APA", "BARRILES", 25, 112000.00),
                new Cerveza("SCOTTISH", "BARRILES", 13, 114000.00),
                new Cerveza("OLD ALE", "BARRILES", 16, 85000.00),
                new Cerveza("PORTER", "BARRILES", 32, 112000.00),
                new Cerveza("GLADSTONE", "BARRILES", 28, 112000.00),
                new Cerveza("BLONDE", "BARRILES", 15, 112000.00),
                new Cerveza("HONEY", "BARRILES", 29, 112000.00),
            };
            
            //ARREGLOS PARA CADA PRODUCTO:
            Cerveza[] Cerveza1 = new Cerveza[]
            {
                new Cerveza("Apa", "Botellas", 450, 3850.00)
            };

            Cerveza[] Cerveza2 = new Cerveza[]
            {
                new Cerveza("Blonde", "Latas", 1500, 1200.00)
            };

            Cerveza[] Cerveza3 = new Cerveza[]
            {
                new Cerveza("Honey", "Botellas", 150, 2890.50)
            };

            Cerveza[] Cerveza4 = new Cerveza[]
            {
                new Cerveza("Porter", "Latas", 1680, 1560.70)
            };

            Cerveza[] Cerveza5 = new Cerveza[]
            {
                new Cerveza("Gladstone", "Botellas", 200, 3790.15)
            };
            //LISTAS CON LOS ARREGLOS ANTERIORES:
            List<Cerveza[]>cervezas = new List<Cerveza[]> { Cerveza1, Cerveza2, Cerveza3, Cerveza4, Cerveza5 };
            //MOSTRAMOS LOS DATOS EN LA LISTA:
            /*
            Console.WriteLine("Lista actual:");
            foreach (Cerveza[] datos in cervezas) 
            {
                foreach (Cerveza cerveza in datos)
                {
                    Console.WriteLine($"Estilo: {cerveza.NombreCerveza}, Presentación: {cerveza.PresentacionCerveza}" +
                        $" Stock: {cerveza.StockCerveza}, Precio: {cerveza.PreciosCerveza}");
                }
            }*/


            /*
            Cerveza[] infoDeCerveza2 = {new Cerveza { NombreCerveza = "California", PresentacionCerveza = "Botellas",
            StockCerveza = 50, PreciosCerveza = 898.56 } };

            Cerveza[] infoDeCerveza3 = {new Cerveza { NombreCerveza = "Algebra", PresentacionCerveza = "Latas",
            StockCerveza = 150, PreciosCerveza = 89.36 } };

            Cerveza[] infoDeCerveza4 = {new Cerveza { NombreCerveza = "Ipa", PresentacionCerveza = "Latas",
            StockCerveza = 250, PreciosCerveza = 98.86 } };

            Cerveza[] infoDeCerveza5 = {new Cerveza { NombreCerveza = "California", PresentacionCerveza = "Latas",
            StockCerveza = 90, PreciosCerveza = 88.76 } };

            Cerveza[] infoDeCerveza6 = {new Cerveza { NombreCerveza = "Scottish", PresentacionCerveza = "Botellas",
            StockCerveza = 70, PreciosCerveza = 658.77 } };
            */

            Console.WriteLine("\nBienvenido al programa de Gestión de Inventario!");
            do
            {
                MensajeYMenu();
                opcion = int.Parse(Console.ReadLine());
                IngresoAlMenu(opcion, productoAEliminar, infoDeCerveza, cervezas, productoBuscado);
            } while (opcion != 6);
        }
        static void MensajeYMenu()
        {
            Console.WriteLine("\nElija una opción del siguiente menú :");
            Console.WriteLine("Opcion 1: buscar productos");
            Console.WriteLine("Opcion 2: ver información productos");
            Console.WriteLine("Opcion 3: agregar producto");
            Console.WriteLine("Opcion 4: eliminar producto");
            Console.WriteLine("Opcion 5: realizar presupuesto");
            Console.WriteLine("Opcion 6: salir\n");
        }
        static void IngresoAlMenu(int opcion, string productoAEliminar, Cerveza[] agregaInfoDeCerveza, List<Cerveza[]> cervezas, int productoBuscado)
        {
            switch (opcion)
            {
                case 1:
                    BuscarProducto(cervezas, productoBuscado);
                    MostrarProductoBuscado(cervezas);
                    break;
                case 2:
                    VerInformacionDeProductos(cervezas);
                    //StockConProductoIngresado(infoDeCerveza, agregaInfoDeCerveza);
                    break;
                case 3:
                    //IngresarNuevoProducto(infoDeCerveza);
                    
                    break;
                case 4:
                    EliminarProducto(cervezas, productoAEliminar);
                    StockConProductoEliminado(cervezas);
                    break;
                case 5:
                case 6:
                    Console.WriteLine("Fin del programa");
                    break;
                default: Console.WriteLine("Opcion invalida"); break;
            }
        }
        static void BuscarProducto(List<Cerveza[]> cervezas, int productoBuscado)
        {
            //VERIFICAMOS QUE EL INDICE QUE BUSCAMOS ESTÉ DENTRO DE LA LISTA
            if (productoBuscado >= 0 && productoBuscado < cervezas.Count)
            {
                Console.WriteLine("Producto {0}:", productoBuscado + 1);
                //EN CASO DE SER ASI MOSTRAMOS LA INFORMACION QUE BUSCAMOS
                foreach (var buscado in cervezas[productoBuscado])
                {
                    Console.WriteLine($"Estilo: {buscado.NombreCerveza},",
                        $"Presentación: {buscado.PresentacionCerveza},",
                        $"Stock: {buscado.StockCerveza},", $"Precio: {buscado.PreciosCerveza}.");
                }
            }
            else
            {
                Console.WriteLine("Número de producto inválido. Ingrese el número de producto correctamente");
            }
        }
        static void MostrarProductoBuscado(List<Cerveza[]> cervezas)
        {
            Console.Write("Ingrese el número del producto que desea ver la información (entre 1 y {0}): ", cervezas.Count);
            if (int.TryParse(Console.ReadLine(), out int productoBuscado) && productoBuscado >= 1 && productoBuscado <= cervezas.Count)
            {
                BuscarProducto(cervezas, productoBuscado -1);
            }
            else
            {
                Console.WriteLine("Número inválido. Intente de nuevo");
            }
        }
        static void VerInformacionDeProductos(List<Cerveza[]> cervezas)
        {
            Cerveza[] Cerveza1 = new Cerveza[]
            {
                new Cerveza("Apa", "Botellas", 450, 3850.00)
            };

            Cerveza[] Cerveza2 = new Cerveza[]
            {
                new Cerveza("Blonde", "Latas", 1500, 1200.00)
            };

            Cerveza[] Cerveza3 = new Cerveza[]
            {
                new Cerveza("Honey", "Botellas", 150, 2890.50)
            };

            Cerveza[] Cerveza4 = new Cerveza[]
            {
                new Cerveza("Porter", "Latas", 1680, 1560.70)
            };

            Cerveza[] Cerveza5 = new Cerveza[]
            {
                new Cerveza("Gladstone", "Botellas", 200, 3790.15)
            };

            Console.WriteLine("\nLos Productos disponibles son:\n");
            List<Cerveza[]> cerveza = new List<Cerveza[]> { Cerveza1, Cerveza2, Cerveza3, Cerveza4, Cerveza5 };
            for (int c = 0; c < cervezas.Count; c++)
            {
                Console.WriteLine("Producto {0}:", c + 1);
                foreach (var datosDeCerveza in cervezas[c])
                {
                    Console.WriteLine($"Estilo: {datosDeCerveza.NombreCerveza}, " +
                        $"Presentación: {datosDeCerveza.PresentacionCerveza}" +
                        $" Stock: {datosDeCerveza.StockCerveza}, " +
                        $"Precio: {datosDeCerveza.PreciosCerveza}");
                }
            }
        }
        static void EliminarProducto(List<Cerveza[]> cervezas, string productoAEliminar)
        {
            //SOLICITAMOS AL USURARIO EL NOMBRE DEL PRODUCTO
            Console.WriteLine("\nIngrese el nombre del produto que desea eliminar: ");
            productoAEliminar = Console.ReadLine();

            //RECORREMOS LA LISTA Y BUSCAMOS EL ARREGLO QUE COINCIDA CON LO QUE INGRESE EL USUARIO
            bool encontrado = false;
            for (int c = 0; c < cervezas.Count; c++)
            {
                //LUEGO VERIFICAMOS SI EXISTE EL ARREGLO CON EL NOMBRE QUE INGRESO EL USUARIO
                foreach (var nombre in cervezas[c])
                {
                    //LO QUE HACE ES COMPARAR LOS ELEMENTOS DEL ARREGLO IGNORANDO LA FORMA DE ESCRITURA (camelCase) EN ESTE CASO
                    if (nombre.NombreCerveza.Equals(productoAEliminar, StringComparison.OrdinalIgnoreCase))
                    {
                        cervezas.RemoveAt(c);
                        Console.WriteLine("\nEl producto fue eliminado exitosamente de la lista");
                        encontrado = true;
                        break;
                    }
                }
                //SALIMOS EL BUCLE SI SE ENCONTRÓ Y ELIMININÓ EL ARREGLO
                if (encontrado)
                    break;
            }
            //EN CASO DE QUE NO SE ENCUENTRE LO QUE BUSCA EL USUARIO
            if (!encontrado)
            {
                Console.WriteLine("\nNo se encontró el producto. Asegurate de ingresar bien el nombre");
            }
        }
        static void StockConProductoEliminado(List<Cerveza[]> cervezas)
        {
            Console.WriteLine("La lista actualizada es:");
            for (int c = 0; c < cervezas.Count; c++) 
            {
                Console.WriteLine("Producto {0}:", c + 1);
                foreach (var productos in cervezas[c])
                {
                    Console.WriteLine($"Estilo: {productos.NombreCerveza}, " +
                        $"Presentación: {productos.PresentacionCerveza}" +
                        $" Stock: {productos.StockCerveza}, " +
                        $"Precio: {productos.PreciosCerveza}");
                }
            }
        }
        static Cerveza[] IngresarNuevoProducto(Cerveza[] infoDeCerveza)
        {
            Console.WriteLine("\nA continuación ingrese los datos necesarios:");
            Cerveza[] agregaInfoDeCerveza = new Cerveza[+1];
            bool existe = false;

            for (int mas = 0; mas < agregaInfoDeCerveza.Length; mas++)
            {
                Console.Write("\nIngrese el nombre del nuevo producto: ");
                infoDeCerveza[mas].NombreCerveza = Console.ReadLine().ToUpper();
                Console.Write("Ingrese la presentacion del nuevo producto: ");
                infoDeCerveza[mas].PresentacionCerveza = Console.ReadLine().ToUpper();
                Console.Write("Ingrese la cantidad en el stock del nuevo producto: ");
                infoDeCerveza[mas].StockCerveza = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el precio del nuevo producto: ");
                infoDeCerveza[mas].PreciosCerveza = double.Parse(Console.ReadLine());
                existe = true;
            }
            Console.WriteLine("\nLos datos del nuevo producto son:");

            if (existe == true)
            {
                for (int mas = 0; mas < agregaInfoDeCerveza.Length; mas++)
                {
                    Console.WriteLine($"Nombre: {infoDeCerveza[mas].NombreCerveza}");
                    Console.WriteLine($"Presentacion: {infoDeCerveza[mas].PresentacionCerveza}");
                    Console.WriteLine($"Stock: {infoDeCerveza[mas].StockCerveza}");
                    Console.WriteLine($"Precio: {infoDeCerveza[mas].PreciosCerveza}");
                }
            }
            else
            {
                Console.WriteLine("Datos inválidos. Ingrese correctamente los datos");
            }
            return infoDeCerveza;
        }

        static void StockConProductoIngresado(Cerveza[] infoDeCerveza, Cerveza[] agregaInfoDeCerveza)
        {

            Console.WriteLine("\nEl stock actualizado es:");
            foreach (Cerveza nuevaLista in infoDeCerveza)
            {
                Console.WriteLine($"Nombre: {nuevaLista.NombreCerveza}, " +
                    $"Presentación: {nuevaLista.PresentacionCerveza}, " +
                    $"Stock: {nuevaLista.StockCerveza}, " +
                    $"Precio: {nuevaLista.PreciosCerveza}");
            }
            foreach (Cerveza nuevaLista in agregaInfoDeCerveza)
            {
                Console.WriteLine($"Nombre: {nuevaLista.NombreCerveza}, " +
                    $"Presentación: {nuevaLista.PresentacionCerveza}, " +
                    $"Stock: {nuevaLista.StockCerveza}, " +
                    $"Precio: {nuevaLista.PreciosCerveza}");
            }
            
        }

    }

}