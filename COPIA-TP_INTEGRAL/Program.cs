using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        static int opcion, productoBuscado, cantidadAIngresar;
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
             pero a la vez poder modificarlos, ya sea para eliminar o añadir productos*/
            
            Console.WriteLine("\nBienvenido al programa de Gestión de Inventario!");
            do
            {
                MensajeYMenu();
                opcion = int.Parse(Console.ReadLine());
                IngresoAlMenu(opcion, productoAEliminar, productoBuscado, cantidadAIngresar, cervezas);
            } while (opcion != 6);
        }
        static void MensajeYMenu()
        {
            Console.WriteLine("\nElija una opción del siguiente menú:");
            Console.WriteLine("Opcion 1: buscar productos");
            Console.WriteLine("Opcion 2: ver información productos");
            Console.WriteLine("Opcion 3: agregar producto");
            Console.WriteLine("Opcion 4: eliminar producto");
            Console.WriteLine("Opcion 5: realizar presupuesto");
            Console.WriteLine("Opcion 6: salir\n");
        }
        static void IngresoAlMenu(int opcion, string productoAEliminar, List<Cerveza[]> cervezas, int productoBuscado, int cantidadAIngresar)
        {
            switch (opcion)
            {
                case 1:
                    MostrarProductoBuscado(cervezas, productoBuscado);
                    break;
                case 2:
                    VerInformacionDeProductos(cervezas);
                    //StockActualizado(cervezas);
                    break;
                case 3:
                    IngresarNuevoProducto(cervezas, cantidadAIngresar);
                    //StockActualizado(cervezas);
                    break;
                case 4:
                    EliminarProducto(cervezas, productoAEliminar);
                    //StockActualizado(cervezas);
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
                Console.WriteLine("\nProducto {0}:", productoBuscado + 1);
                //EN CASO DE SER ASI MOSTRAMOS LA INFORMACION QUE BUSCAMOS
                foreach (var buscado in cervezas[productoBuscado])
                {
                    Console.WriteLine($"Estilo: {buscado.NombreCerveza}, " +
                        $"Presentación: {buscado.PresentacionCerveza}, " +
                        $"Stock: {buscado.StockCerveza}, " + $"Precio: {buscado.PreciosCerveza}.");
                }
            }
            else
            {
                Console.WriteLine("\nNúmero inválido. Intente de nuevo");
            }
        }
        static void MostrarProductoBuscado(List<Cerveza[]> cervezas, int productoBuscado)
        {
            Console.Write("\nIngrese el número del producto que desea ver la información (entre 1 y {0}): ", cervezas.Count);
            if (int.TryParse(Console.ReadLine(), out productoBuscado) && productoBuscado >= 1 && productoBuscado <= cervezas.Count)
            {
                BuscarProducto(cervezas, productoBuscado -1);
            }
            else
            {
                Console.WriteLine("\nNúmero inválido. Intente de nuevo");
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
            Console.WriteLine("\nIngrese el nombre del producto que desea eliminar: ");
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
        static void IngresarNuevoProducto(List<Cerveza[]> cervezas, int cantidadAIngresar)
        {
            //SOLICITAMOS Y VERIFICAMOS QUE EL USUARIO INGRESE CORRECTAMENTE LA CANTIDAD DE PRODUCTOS QUE VA A AGREGAR AL LA LISTA
            Console.Write("\nCuantos productos desea ingresar a la lista?: ");
            if (int.TryParse(Console.ReadLine(), out cantidadAIngresar) && cantidadAIngresar > 0) 
            {
                //CREAMOS UN NUEVO ARREGLO PARA LOS DATOS DEL NUEVO PRODUCTO
                Cerveza[] nuevoProducto = new Cerveza[cantidadAIngresar];
                bool existe = false;
                //SOLICITAMOS LA INFORMACION NECESARIA
                for (int n = 0; n < cantidadAIngresar; n++)// n = nuevo
                {
                    Console.WriteLine($"\nIngrese los datos del Producto:");
                    Console.Write("\nNombre: ");
                    string nombreCerveza = Console.ReadLine();

                    Console.Write("Presentación: ");
                    string presentacionCerveza = Console.ReadLine();

                    Console.Write("Stock: ");
                    if (!int.TryParse(Console.ReadLine(), out int stockCerveza))
                    {
                        Console.WriteLine("Valor inválido. Se ingresará 0.");
                        stockCerveza = 0; //EN CASO DE NO SER UN VALOR DEL TIPO DESEADO SE COMPLETA CON 0
                    }

                    Console.WriteLine("Precio: ");
                    if (!double.TryParse(Console.ReadLine(), out double precioCerveza))
                    {
                        Console.WriteLine("Valor inválido. Se ingresará 0.");
                        precioCerveza = 0.0;//EN CASO DE NO SER UN VALOR DEL TIPO DESEADO SE COMPLETA CON 0.0
                    }
                    nuevoProducto[n] = new Cerveza(nombreCerveza, presentacionCerveza, stockCerveza, precioCerveza);
                    existe = true;
                }
                if (existe == true)
                {
                    cervezas.Add(nuevoProducto);
                    //StockActualizado(cervezas);
                }
            }
            else if (existe != true)
            {
                Console.WriteLine("Valor inválido. Ingrese un número mayor que 0");
            }
        }
        static void StockActualizado(List<Cerveza[]> cervezas, int cantidadAIngresar, string productoAEliminar)
        {
            Console.WriteLine("\nLa lista actualizada es:");
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

    }

}