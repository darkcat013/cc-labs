using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Graph
    {
        public Dictionary<string, List<string>> Vertices { get; set; }
        public int VerticesCount => Vertices.Count;
        public int EdgeCount { get; set; }
        public string FirstVertice => Vertices.Keys.FirstOrDefault() ?? "";
        public Graph(string filePath)
        {
            Vertices = new Dictionary<string, List<string>>();
            IEnumerable<string[]> edges = File.ReadAllLines(filePath).Select(x => x.Split(' '));
            foreach(string[] edge in edges)
            {
                if(!Vertices.ContainsKey(edge[0]))
                {
                    Vertices.Add(edge[0], new List<string>());
                }
                if(!Vertices.ContainsKey(edge[1]))
                {
                    Vertices.Add(edge[1], new List<string>());
                }    
                Vertices[edge[0]].Add(edge[1]);
                Vertices[edge[1]].Add(edge[0]);
                EdgeCount++;
            }
            
        }

        public bool BFS(string toFind)
        {
            Stopwatch stopwatch = new();

            stopwatch.Start();
            Dictionary<string, bool> visited = new();

            Queue<string> nextVertices = new();
            nextVertices.Enqueue(FirstVertice);

            while(nextVertices.Count > 0)
            {
                string current = nextVertices.Dequeue();
                if (toFind.Equals(current))
                {
                    Console.Write($"{current} ");
                    stopwatch.Stop();
                    Console.WriteLine();
                    Console.WriteLine($"{(stopwatch.Elapsed.Minutes * 60000) + (stopwatch.Elapsed.Seconds * 1000) + stopwatch.Elapsed.Milliseconds}");
                    return true;
                }
                if (!visited.ContainsKey(current))
                {
                    visited.Add(current, true);
                    Console.Write($"{current} ");
                }

                foreach (string vertice in Vertices[current])
                {
                    if(!visited.ContainsKey(vertice))
                    {
                        nextVertices.Enqueue(vertice);
                    }
                }
            }
            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"{(stopwatch.Elapsed.Minutes * 60000) + (stopwatch.Elapsed.Seconds * 1000) + stopwatch.Elapsed.Milliseconds}");
            return false;
        }

        public bool DFS(string toFind)
        {
            Stopwatch stopwatch = new();

            stopwatch.Start();

            Dictionary<string, bool> visited = new();

            Stack<string> nextVertices = new();
            nextVertices.Push(FirstVertice);

            while (nextVertices.Count > 0)
            {
                string current = nextVertices.Pop();
                if (toFind.Equals(current))
                {
                    Console.Write($"{current} ");
                    stopwatch.Stop();
                    Console.WriteLine();
                    Console.WriteLine($"{(stopwatch.Elapsed.Minutes * 60000) + (stopwatch.Elapsed.Seconds * 1000) + stopwatch.Elapsed.Milliseconds}");
                    return true;
                }
                if (!visited.ContainsKey(current))
                {
                    visited.Add(current, true);
                    Console.Write($"{current} ");
                }

                foreach (string vertice in Vertices[current])
                {
                    if (!visited.ContainsKey(vertice))
                    {
                        nextVertices.Push(vertice);
                    }
                }
            }
            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"{(stopwatch.Elapsed.Minutes * 60000) + (stopwatch.Elapsed.Seconds * 1000) + stopwatch.Elapsed.Milliseconds}");
            return false;
        }
    }
}
