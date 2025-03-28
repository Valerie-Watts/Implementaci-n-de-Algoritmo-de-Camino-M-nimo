using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementación_de_Algoritmo_de_Camino_Mínimo
{
    class Graph
    {
        private Dictionary<int, List<int>> adgList; // Diccionario para almacenar los nodos y sus conexiones
        public bool Directed; // Indica si el grafo es dirigido o no

        public Graph(bool Directed)
        {
            adgList = new Dictionary<int, List<int>>(); // Inicializamos la lista de adyacencia
            this.Directed = Directed; // Guardamos si el grafo es dirigido o no
        }

        // Agrega un vértice al grafo (si no existe)
        public void InsertVertix(int vertix)
        {
            if (adgList.ContainsKey(vertix))
            {
                return; // Ya existe, así que no hacemos nada
            }
            else
            {
                adgList.Add(vertix, new List<int>()); // Se agrega con una lista vacía de conexiones
            }
        }

        // Agrega un arco entre dos vértices (conexión)
        public void InsertArcs(int vert1, int vert2)
        {
            if (adgList.ContainsKey(vert1) && adgList.ContainsKey(vert2))
            {
                if (Directed)
                {
                    adgList[vert1].Add(vert2); // Solo de vert1 a vert2 si es dirigido
                }
                else
                {
                    adgList[vert1].Add(vert2);
                    adgList[vert2].Add(vert1); // Si es no dirigido, se conecta en ambos sentidos
                }
            }
            else
            {
                Console.WriteLine("One or both of the vertices does not exist");
            }
        }

        // Imprime la lista de adyacencia para ver las conexiones
        public void IMprint()
        {
            foreach (var item in adgList)
            {
                Console.Write(item.Key + " --> [ ");
                foreach (var dato in item.Value)
                {
                    Console.Write(dato + " ");
                }
                Console.WriteLine("]");
            }
        }

        // Borra un arco entre dos vértices
        public void eraseArcs(int vert1, int vert2)
        {
            if (adgList.ContainsKey(vert1))
            {
                adgList[vert1].Remove(vert2);
            }
            else
            {
                Console.WriteLine("The vertix does not exist");
            }

            if (!Directed && adgList.ContainsKey(vert2))
            {
                adgList[vert2].Remove(vert1); // También eliminamos la conexión inversa si el grafo no es dirigido
            }
        }

        // Borra un vértice y todas sus conexiones
        public void eraseVertix(int vertix)
        {
            if (adgList.ContainsKey(vertix))
            {
                Console.WriteLine("The vertix has been erased");
                adgList.Remove(vertix);

                // Eliminamos el vértice de todas las listas de adyacencia
                foreach (var arcs in adgList.Keys.ToList())
                {
                    adgList[arcs].Remove(vertix);
                }
            }
            else
            {
                Console.WriteLine("The vertix does not exist");
            }
        }

        // Búsqueda en anchura (BFS) desde un vértice inicial
        public void BFS(int start)
        {
            if (adgList.ContainsKey(start))
            {
                HashSet<int> visited = new HashSet<int>(); // Para no visitar nodos repetidos
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(start);
                visited.Add(start);

                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    Console.Write(node + " ");

                    // Agregamos los vecinos que no han sido visitados
                    foreach (var neighbor in adgList[node].OrderBy(n => n))
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                        }
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The vertix does not exist");
            }
        }

        // Búsqueda en profundidad (DFS) desde un vértice inicial
        public void DFS(int start)
        {
            if (adgList.ContainsKey(start))
            {
                HashSet<int> visited = new HashSet<int>();
                Stack<int> stack = new Stack<int>();
                stack.Push(start);

                while (stack.Count > 0)
                {
                    int node = stack.Pop();
                    if (!visited.Contains(node))
                    {
                        Console.Write(node + " ");
                        visited.Add(node);

                        // Agregamos los vecinos en orden inverso para respetar el comportamiento de la pila
                        foreach (var neighbor in adgList[node].OrderByDescending(n => n))
                        {
                            if (!visited.Contains(neighbor))
                            {
                                stack.Push(neighbor);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The vertix does not exist");
            }
        }
    }
}
