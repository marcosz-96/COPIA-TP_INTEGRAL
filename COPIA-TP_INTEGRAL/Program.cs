using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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
        static int opcion, cantidadAIngresar;
        static string productoBuscado, productoAEliminar;
        

        public struct Datos
        {
            public string Estilo;
            public string Presentacion;
            public int Stock;
            public double Precio;


            public Datos(string estilo, string presentacion, int stock, double precio)
            {
                Estilo = estilo;
                Presentacion = presentacion;
                Stock = stock;
                Precio = precio;
            }
        }
        
        static void Main(string[] args)
        {
            /*La idea principal de programa es trabajar con datos ya cargados
             pero a la vez poder modificarlos, ya sea para eliminar o añadir productos*/

            
            List<Datos[]> cervezas = new List<Datos[]>();

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
        static void IngresoAlMenu(int opcion, string productoAEliminar, string productoBuscado, int cantidadAIngresar, List<Datos[]> cervezas)
        {
            switch (opcion)
            {
                case 1:
                    BuscarProducto(cervezas, productoBuscado);
                    break;
                case 2:
                    VerInformacionDeProductos(cervezas);
                    break;
                case 3:
                    IngresarNuevoProducto(cervezas, cantidadAIngresar);
                    break;
                case 4:
                    EliminarProducto(cervezas, productoAEliminar);
                    break;
                case 5:
                    Ventas(cervezas);
                    RealizarPresupuesto(cervezas);
                    break;
                case 6:
                    Console.WriteLine("Fin del programa");
                    break;
                default: Console.WriteLine("Opcion invalida. Ingrese una opción válida");
                    break;
            }
        }
        static void BuscarProducto(List<Datos[]> cervezas, string productoBuscado)
        {
            bool continuarBuscando = true;

            while (continuarBuscando)
            {
                Console.Write("\nIngrese el estilo del producto (o 'menu' para volver al menú): ");
                productoBuscado = Console.ReadLine();

                if (productoBuscado == "menu")
                {
                    continuarBuscando = false;//SALE DE BUCLE Y VUELVE AL MENÚ
                    continue;
                }

                bool existe = false;

                for (int i = 0; i < cervezas.Count; i++)
                {
                    //VERIFICAMOS QUE EL INDICE QUE BUSCAMOS ESTÉ DENTRO DE LA LISTA
                    var cerveza = cervezas[i][0];

                    if (cerveza.Estilo.ToLower().Contains(productoBuscado.ToLower()))
                    {
                        Console.WriteLine($"\nEl producto {productoBuscado} se encuentra disponible");
                        Console.WriteLine($"Estilo:        {cerveza.Estilo}");
                        Console.WriteLine($"Presentación:  {cerveza.Presentacion}");
                        Console.WriteLine($"Stock:         {cerveza.Stock}");
                        Console.WriteLine($"Precio:        {cerveza.Precio} $");
                        existe = true;
                        break;
                    }
                }
                if (!existe)
                {
                    Console.WriteLine("El producto no se encuentra disponible");
                }
            }
        }
        static void VerInformacionDeProductos(List<Datos[]> cervezas)
        {
            bool continuarViendo = true;

            while (continuarViendo)
            {
                //COMPARA SI HAY DATOS DENTRO DE LA LISTA
                if (cervezas.Count == 0)
                {
                    //SI NO ES ASÍ NOS MUESTRA EL SIGUIENTE MENSAJE
                    Console.WriteLine("No hay productos ingresados.");
                    return;
                }
                //CASO CONTRARIO NOS MUESTRA LOS PRODUCTOS DISPONIBLES
                Console.WriteLine("\nLos Productos disponibles son:\n");

                List<Datos[]> cerveza = new List<Datos[]>();
                for (int c = 0; c < cervezas.Count; c++)
                {
                    Console.WriteLine("Producto {0}:", c + 1);
                    foreach (var datosDeCerveza in cervezas[c])
                    {
                        Console.WriteLine($"Estilo:        {datosDeCerveza.Estilo}");
                        Console.WriteLine($"Presentación:  {datosDeCerveza.Presentacion}");
                        Console.WriteLine($"Stock:         {datosDeCerveza.Stock}");
                        Console.WriteLine($"Precio:        {datosDeCerveza.Precio} $");
                    }
                }
                //LUEGO SOLICITA AL USUARIO QUE PRESIONE UNA TECLA PARA CONTINUAR AL MENU 
                Console.WriteLine("\nPresione 'Enter' para volver al menú.");
                Console.ReadLine();
                continuarViendo = false;
            }
        }
        static void EliminarProducto(List<Datos[]> cervezas, string productoAEliminar)
        {
            bool continuarEliminando = true;

            while (continuarEliminando)
            {
                //SOLICITAMOS AL USURARIO EL NOMBRE DEL PRODUCTO
                Console.WriteLine("\nIngrese el estilo del producto que desea eliminar (o 'menu' para volver al menú): ");
                productoAEliminar = Console.ReadLine();

                if (productoAEliminar == "menu")
                {
                    continuarEliminando = false;//SALE DEL BUCLE Y VUELVE AL MENÚ
                    continue;
                }
                //RECORREMOS LA LISTA Y BUSCAMOS EL ARREGLO QUE COINCIDA CON LO QUE INGRESE EL USUARIO
                bool encontrado = false;

                for (int c = 0; c < cervezas.Count; c++)
                {
                    //LUEGO VERIFICAMOS SI EXISTE EL ARREGLO CON EL NOMBRE QUE INGRESO EL USUARIO
                    foreach (var nombre in cervezas[c])
                    {
                        //LO QUE HACE ES COMPARAR LOS ELEMENTOS DEL ARREGLO IGNORANDO LA FORMA DE ESCRITURA (camelCase) EN ESTE CASO
                        if (nombre.Estilo.Equals(productoAEliminar, StringComparison.OrdinalIgnoreCase))
                        {
                            cervezas.RemoveAt(c);
                            Console.WriteLine($"\nEl producto {productoAEliminar} fue eliminado exitosamente de la lista");
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
        }
        static void IngresarNuevoProducto(List<Datos[]> cervezas, int cantidadAIngresar)
        {
            bool continuarIngresando = true;

            while (continuarIngresando)
            {
                //SOLICITAMOS Y VERIFICAMOS QUE EL USUARIO INGRESE CORRECTAMENTE LA CANTIDAD DE PRODUCTOS QUE VA A AGREGAR AL LA LISTA
                Console.Write("\nCuantos productos desea ingresar a la lista? (o 'menu' para volver al menú): ");
                string ingresa = Console.ReadLine();

                if (ingresa == "menu")
                {
                    continuarIngresando = false;
                    continue;
                }

                if (int.TryParse(ingresa, out cantidadAIngresar) && cantidadAIngresar > 0)
                {
                    //CREAMOS UN NUEVO ARREGLO PARA LOS DATOS DEL NUEVO PRODUCTO
                    Datos[] nuevoProducto = new Datos[cantidadAIngresar];
                    bool existe = false;
                    //SOLICITAMOS LA INFORMACION NECESARIA
                    for (int n = 0; n < cantidadAIngresar; n++)// n = nuevo
                    {
                        Console.WriteLine($"\nIngrese los datos del Producto:");
                        Console.Write("\nEstilo: ");
                        string estilo = Console.ReadLine();

                        Console.Write("Presentación: ");
                        string presentacion = Console.ReadLine();

                        Console.Write("Stock: ");
                        if (!int.TryParse(Console.ReadLine(), out int stock))
                        {
                            Console.WriteLine("Valor inválido. Se ingresará 0.");
                            stock = 0; //EN CASO DE NO SER UN VALOR DEL TIPO DESEADO SE COMPLETA CON 0
                        }

                        Console.Write("Precio: ");
                        if (!double.TryParse(Console.ReadLine(), out double precio))
                        {
                            Console.WriteLine("Valor inválido. Se ingresará 0.");
                            precio = 0.0;//EN CASO DE NO SER UN VALOR DEL TIPO DESEADO SE COMPLETA CON 0.0
                        }
                        nuevoProducto[n] = new Datos(estilo, presentacion, stock, precio);
                        existe = true;
                    }
                    if (existe == true)
                    {
                        cervezas.Add(nuevoProducto);
                        Console.WriteLine("Producto ingresado exitosamente!");
                    }
                }
                else if (existe != true)
                {
                    Console.WriteLine("Valor inválido. Ingrese un número mayor que 0");
                }
            }
        }
        static void StockActualizado(List<Datos[]> cervezas, int cantidadAIngresar, string productoAEliminar)
        {
            Console.WriteLine("\nLa lista actualizada es:");
            for (int c = 0; c < cervezas.Count; c++)
            {
                Console.WriteLine("Producto {0}:", c + 1);
                foreach (var productos in cervezas[c])
                {
                    Console.WriteLine($"Estilo:        {productos.Estilo}");
                    Console.WriteLine($"Presentación:  {productos.Presentacion}");
                    Console.WriteLine($"Stock:         {productos.Stock}");
                    Console.WriteLine($"Precio:        {productos.Precio} $");
                }
            }
        }
        static void RealizarPresupuesto(List<Datos[]> cervezas)
        {
            bool continuarPresupuestando = true;

            while (continuarPresupuestando)
            {
                Console.Write("\nIngrese el estilo del producto para calcular el presupuesto (o 'menu' para volver al menú): ");
                string estiloPresupuesto = Console.ReadLine();

                if (estiloPresupuesto == "menu")
                {
                    continuarPresupuestando = false; // Salir del bucle y volver al menú
                    continue;
                }

                double total = 0.0;
                bool existe = false;

                for (int i = 0; i < cervezas.Count; i++)
                {
                    var cerveza = cervezas[i][0];

                    if (cerveza.Estilo.ToLower().Contains(estiloPresupuesto.ToLower()))
                    {
                        total += cerveza.Precio * cerveza.Stock;
                        existe = true;
                    }
                }

                if (existe)
                {
                    Console.WriteLine($"El total del presupuesto para {estiloPresupuesto} es: {total} $");
                }
                else
                {
                    Console.WriteLine("No se encontraron productos para el estilo ingresado.");
                }
            }
        }

        static void Ventas(List<Datos[]> cervezas)
        {

            Console.WriteLine("Seleccione el número del producto que desea vender:", cervezas.Count);

            for (int i = 0; i < cervezas.Count; i++)
            {
                // [0] se usa porque en este caso los productos están dentro de un arreglo(de tipo Cerveza[]),
                // y estamos accediendo al primer(y único) elemento de ese arreglo, donde con el for recorro los indices de la lista 
                // para ingresar en dichos arreglos y asi mostrarlo.
                Console.WriteLine($"Producto {i + 1}: {cervezas[i][0].Estilo}, Presentación: {cervezas[i][0].Presentacion}, Stock: {cervezas[i][0].Stock}");
            }
            int productoSeleccionado = int.Parse(Console.ReadLine());

            if (productoSeleccionado > 0 && productoSeleccionado <= cervezas.Count)
            {
                productoSeleccionado--; //  se hace productoSeleccionado-- para ajustar el número del producto a su índice real en la lista.

                // Muestra información del producto seleccionado
                Console.WriteLine($"Producto seleccionado: {cervezas[productoSeleccionado][0].Estilo}, Presentación: {cervezas[productoSeleccionado][0].Presentacion}, Stock: {cervezas[productoSeleccionado][0].Stock}");


                Console.WriteLine("Ingrese la cantidad que desea vender:");
                int cantidadVendida = int.Parse(Console.ReadLine());

                // si la cantidad que desea vender es meyor a  0 entro en el if...
                if (cantidadVendida > 0)
                {
                    // Verifica el indice 0 del arreglo seleccionado, si la cantidad vendida es inferior o igual al stock de dicho indice del arreglo dentro de la lista.
                    if (cantidadVendida <= cervezas[productoSeleccionado][0].Stock)
                    {
                        // Llama a la función que actualiza el stock
                        StockConProductoVendido(cervezas, productoSeleccionado, cantidadVendida);
                    }
                    else
                    {
                        Console.WriteLine("No hay suficiente stock para realizar la venta.");
                    }
                }
                else
                {
                    Console.WriteLine("Cantidad inválida. Ingrese un número mayor a 0.");
                }
            }
            else
            {
                Console.WriteLine("Producto seleccionado inválido.");
            }
        }

        // Función que actualiza el stock después de la venta
        static void StockConProductoVendido(List<Datos[]> cervezas, int productoSeleccionado, int cantidadVendida)
        {
            // Restar la cantidad vendida del stock
            cervezas[productoSeleccionado][0].Stock -= cantidadVendida;

            // Mostrar el stock actualizado
            Console.WriteLine($"Venta realizada. Nuevo stock del producto {cervezas[productoSeleccionado][0].Estilo}: {cervezas[productoSeleccionado][0].Stock}\n");

            // Mostrar la lista actualizada de productos
            Console.WriteLine(" Lista con productos actualizada");
            for (int i = 0; i < cervezas.Count; i++)
            {
                Console.WriteLine(" Producto {0} : ", i + 1);
                foreach (Datos listaCerveza in cervezas[i])
                {
                    Console.WriteLine($"Estilo:        {listaCerveza.Estilo}");
                    Console.WriteLine($"Presentación:  {listaCerveza.Presentacion}");
                    Console.WriteLine($"Stock:         {listaCerveza.Stock}");
                    Console.WriteLine($"Precio:        {listaCerveza.Precio} $");
                }
            }
        }
    }

}