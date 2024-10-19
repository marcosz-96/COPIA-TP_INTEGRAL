using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static TP_INTEGRAL_PROGRAMACION.Program;

namespace TP_INTEGRAL_PROGRAMACION
{

    internal class Program
    {
        static bool existe = false;
        static int opcion;
        static string productoBuscado, productoAEliminar;

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
                IngresoAlMenu(opcion, infoDeCerveza, productoAEliminar, infoDeCerveza);
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
        static void IngresoAlMenu(int opcion, Cerveza[] infoDeCerveza, string productoAEliminar, Cerveza[] agregaInfoDeCerveza)
        {
            switch (opcion)
            {
                case 1:
                    BuscarProducto(infoDeCerveza);
                    break;
                case 2:
                    VerInformacionDeProductos(infoDeCerveza);
                    //StockConProductoIngresado(infoDeCerveza, agregaInfoDeCerveza);
                    break;
                case 3:
                    //IngresarNuevoProducto(infoDeCerveza);
                    
                    break;
                case 4:
                    //EliminarProducto(infoDeCerveza, productoAEliminar);
                    //StockConProductoEliminado(infoDeCerveza);
                    break;
                case 5:
                case 6:
                    Console.WriteLine("Fin del programa");
                    break;
                default: Console.WriteLine("Opcion invalida"); break;
            }
        }
        static void BuscarProducto(Cerveza[] cerveza)
        {
            Console.Write("\nIngrese el nombre del producto: ");
            productoBuscado = Console.ReadLine().ToUpper();
            bool existe = false;

            for (int i = 0; i < cerveza.Length; i++)
            {
                if (productoBuscado == cerveza[i].NombreCerveza.ToUpper())
                {
                    Console.WriteLine($"\nEl producto {productoBuscado} se encuentra disponible");
                    existe = true;
                    break;
                }
            }
            if (!existe)
            {
                Console.WriteLine("El producto no se encuentra disponible");
            }

        }
        static void VerInformacionDeProductos(Cerveza[] cerveza)
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
            List<Cerveza[]> cervezas = new List<Cerveza[]> { Cerveza1, Cerveza2, Cerveza3, Cerveza4, Cerveza5 };
            foreach (Cerveza[] datos in cervezas)
            {
                foreach (Cerveza datosDeCerveza in datos)
                {
                    Console.WriteLine($"Estilo: {datosDeCerveza.NombreCerveza}, " +
                        $"Presentación: {datosDeCerveza.PresentacionCerveza}" +
                        $" Stock: {datosDeCerveza.StockCerveza}, " +
                        $"Precio: {datosDeCerveza.PreciosCerveza}");
                }
            }
        }
        static bool EliminarProducto(List<Cerveza[]> cervezas, Cerveza[] arregloAEliminar)
        {
            //BUSCAMOS Y ELIMINAMOS EL ARREGLO
            for (int c = 0; c < cervezas.Count; c++)
            {
                //COMPARAMOS LOS ARREGLOS DENTRO DE LA LISTA. CON EL MÉTODO SequenceEqual SE COMPARAN LOS ARREGLOS
                if (cervezas[c].Length == arregloAEliminar.Length && cervezas[c].SequenceEqual(arregloAEliminar))
                {
                    cervezas.RemoveAt(c);
                    return true; //SI SE ELIMINA EL ARREGLO
                }
            }
            return false; //EL ARREGLO NO ESTÁ EN LA LISTA
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
            */
        

    }

}