using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementación_de_Algoritmo_de_Camino_Mínimo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese la cantidad de vértices del grafo: ");
            int v = int.Parse(Console.ReadLine());
            Grafo grafo = new Grafo(v);

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n--- Menú ---");
                Console.WriteLine("1. Agregar arista");
                Console.WriteLine("2. Mostrar matriz de adyacencia");
                Console.WriteLine("3. Ejecutar Dijkstra");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Write("Origen: ");
                        int origen = int.Parse(Console.ReadLine());
                        Console.Write("Destino: ");
                        int destino = int.Parse(Console.ReadLine());
                        Console.Write("Costo: ");
                        int costo = int.Parse(Console.ReadLine());
                        grafo.CrearArista(origen, destino, costo);
                        break;
                    case 2:
                        grafo.MostrarMatrizAdyacencia();
                        break;
                    case 3:
                        Console.Write("Nodo de origen para Dijkstra: ");
                        int nodoOrigen = int.Parse(Console.ReadLine());
                        grafo.Dijkstra(nodoOrigen);
                        break;
                    case 4:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
    
}
