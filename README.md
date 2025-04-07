```markdown
# 📊 Algoritmo de Dijkstra en C#

Este proyecto implementa el **algoritmo de Dijkstra** para encontrar el camino más corto desde un vértice origen a todos los demás vértices en un grafo ponderado, utilizando el lenguaje **C#**. La aplicación permite al usuario interactuar mediante consola para construir el grafo y ejecutar el algoritmo.

## 🎯 Objetivos

- Implementar el algoritmo de Dijkstra de manera clara e interactiva.
- Permitir la creación dinámica de grafos dirigidos con pesos.
- Mostrar las distancias mínimas desde un nodo origen a todos los demás nodos.
- Facilitar la visualización de la matriz de adyacencia.

---

## ⚙️ Instalación y Uso

### Requisitos:
- .NET SDK (versión 6.0 o superior recomendada)
- Visual Studio o cualquier editor compatible con C#

### Pasos:
1. Clona este repositorio o copia los archivos `Grafo.cs` y `Program.cs`.
2. Abre el proyecto en Visual Studio o ejecuta desde la terminal.
3. Compila y ejecuta el programa:

```bash
dotnet build
dotnet run
```

4. Sigue el menú interactivo para:
   - Agregar aristas
   - Ver la matriz de adyacencia
   - Ejecutar el algoritmo de Dijkstra

---

## 🧪 Ejemplo de Uso

```
Ingrese la cantidad de vértices del grafo: 5

--- Menú ---
1. Agregar arista
2. Mostrar matriz de adyacencia
3. Ejecutar Dijkstra
4. Salir
Seleccione una opción: 1
Origen: 0
Destino: 1
Costo: 10

Seleccione una opción: 1
Origen: 0
Destino: 4
Costo: 5

...

Seleccione una opción: 3
Nodo de origen para Dijkstra: 0

Vertice 	 Distancia desde origen
0		         0
1		        8
2		        9
3		        7
4		        5
```

---

## 🧠 Explicación del Algoritmo

El algoritmo de **Dijkstra** encuentra la ruta más corta desde un vértice origen a todos los demás en un grafo con pesos no negativos.

### ¿Cómo funciona?
1. Inicializa todas las distancias como infinitas, excepto la del nodo origen (0).
2. Recorre los nodos no visitados, eligiendo el de menor distancia actual.
3. Actualiza las distancias de sus vecinos si se encuentra un camino más corto.
4. Repite hasta visitar todos los nodos.

### Complejidad Temporal:
- El programa utiliza una **matriz de adyacencia**, con una complejidad de **O(V²)**, siendo `V` el número de vértices.
- Con optimizaciones (listas de adyacencia + heap), puede reducirse a **O((V + E) log V)**.

---

## 📁 Estructura del Proyecto

```
Dijkstra/
│
├── Grafo.cs        # Clase Grafo con implementación del algoritmo
└── Program.cs      # Programa principal con menú interactivo
```

---

## ✅ Funcionalidades Adicionales

- Menú de texto interactivo.
- Creación dinámica de grafos por consola.
- Visualización de la matriz de adyacencia.
- Soporte para múltiples ejecuciones del algoritmo sin reiniciar el programa.

---
