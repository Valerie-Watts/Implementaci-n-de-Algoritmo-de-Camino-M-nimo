using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementación_de_Algoritmo_de_Camino_Mínimo
{
    class Grafo
    {
        private int vertices; // Número total de vértices en el grafo
        private int[,] matriz; // Matriz de adyacencia para representar el grafo

        // Constructor que inicializa el número de vértices y la matriz
        public Grafo(int vertices)
        {
            this.vertices = vertices;
            this.matriz = new int[vertices, vertices];
        }

        // Método para agregar una arista al grafo (nodos numerados desde 1)
        public void CrearArista(int origen, int destino, int costo)
        {
            matriz[origen - 1, destino - 1] = costo;
        }

        // Muestra la matriz de adyacencia con "INF" para valores 0 (sin conexión)
        public void MostrarMatrizAdyacencia()
        {
            Console.WriteLine("\nMatriz de Adyacencia:");
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    Console.Write((matriz[i, j] == 0 ? "INF" : matriz[i, j].ToString()) + "\t");
                }
                Console.WriteLine();
            }
        }

        // Encuentra el índice del vértice con la menor distancia que aún no ha sido procesado
        private int distanciaMin(int[] distancia, bool[] nodos)
        {
            int min = int.MaxValue, min_index = -1;

            for (int i = 0; i < vertices; i++)
                if (!nodos[i] && distancia[i] <= min)
                {
                    min = distancia[i];
                    min_index = i;
                }

            return min_index;
        }

        // Algoritmo de Dijkstra para encontrar las distancias más cortas desde un nodo origen
        public void Dijkstra(int origen)
        {
            origen--; // Ajustar índice para trabajar desde 0 internamente
            bool[] nodos = new bool[vertices]; // Para marcar nodos ya procesados
            int[] distancia = new int[vertices]; // Distancias mínimas desde el nodo origen

            // Inicialización de distancias y visitados
            for (int i = 0; i < vertices; i++)
            {
                distancia[i] = int.MaxValue;
                nodos[i] = false;
            }

            distancia[origen] = 0;

            // Recorremos todos los vértices
            for (int count = 0; count < vertices - 1; count++)
            {
                int u = distanciaMin(distancia, nodos); // Vértice con menor distancia
                nodos[u] = true;

                // Actualizar distancias a los vecinos del vértice seleccionado
                for (int v = 0; v < vertices; v++)
                {
                    if (!nodos[v] && matriz[u, v] != 0 && distancia[u] != int.MaxValue && distancia[u] + matriz[u, v] < distancia[v])
                    {
                        distancia[v] = distancia[u] + matriz[u, v];
                    }
                }
            }

            // Mostrar resultados
            Console.WriteLine("\nDistancia mínima desde el nodo " + (origen + 1) + ":");
            for (int i = 0; i < vertices; i++)
            { 
                Console.WriteLine("A nodo " + (i + 1) + " => " + distancia[i]);
            }
        }
    }
}
