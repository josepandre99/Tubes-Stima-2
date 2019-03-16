using System;
using System.IO;
using System.Collections.Generic;

namespace BackEnd
{
    class Graph
    {
        private List<int>[] edges;
        private int[] depth;
        private int n_vertex;
        public List<int> path;

        public Graph(int n)
        {
            n_vertex = n;
            edges = new List<int>[n + 1];
            depth = new int[n + 1];
            path = new List<int>();
            for (int i = 0; i <= n; i++)
            {
                edges[i] = new List<int>();
                depth[i] = 0;
            }
        }
        ~Graph()
        {
            for (int i = 0; i <= n_vertex; i++)
            {
                edges[i] = null;
            }
            edges = null;
            depth = null;
            path = null;
        }

        void addEgde(int origin, int end)
        {
            edges[origin].Add(end);
            edges[end].Add(origin);
        }

        public void depthNumbering(int v)
        {
            bool[] visited = new bool[n_vertex + 1];
            for (int i = 0; i <= n_vertex; i++)
            {
                visited[i] = false;
            }
            DFS(v, 0, visited);
        }

        void DFS(int v, int prevr, bool[] visited)
        {
            visited[v] = true;
            for (int i = 0; i < edges[v].Count; i++)
            {
                int nextr = edges[v][i];
                if (nextr != prevr && visited[nextr])
                {
                    throw new Exception();
                }
            if (edges[nextr] != null && !visited[nextr])
                {
                    depth[nextr] = depth[v] + 1;
                    Console.WriteLine("dalam[" + nextr + "] : " + depth[nextr]);
                    DFS(nextr, v, visited);
                }
            }
        }

        void checkPosition(int n, int X, int Y)
        {
            path.Clear();
            path.Add(Y);
            bool[] visited = new bool[n_vertex + 1];
            for (int i = 0; i <= n_vertex; i++)
            {
                visited[i] = false;
            }
            if (n == 1)
            {
                if (isDistant(Y, X, visited))
                {
                    Console.WriteLine("YA");
                }
                else
                {
                    Console.WriteLine("TIDAK");
                }
            }
            else if (n == 0)
            {
                if (isApproaching(Y, X, visited))
                {
                    Console.WriteLine("YA");
                }
                else
                {
                    Console.WriteLine("TIDAK");
                }
            }
        }

       bool isApproaching(int Y, int X, bool[] visited)
        {

            visited[Y] = true;
            if (Y == 1)
            {
                return false;
            }
            else
            {
                bool cek = false;
                int i = 0;
                while (i < edges[Y].Count && !cek)
                {
                    int nextr = edges[Y][i];
                    if (edges[nextr] != null && !visited[nextr] && depth[nextr] < depth[Y])
                    {
                        path.Add(nextr);
                        if (nextr == X)
                        {
                            return true;
                        }
                        else
                        {
                            cek = cek || isApproaching(nextr, X, visited);
                        }
                        if (!cek)
                        {
                            path.Remove(nextr);
                        }
                    }
                    
                    i++;                    
                }
                return cek;
            }
        }

        bool isDistant(int Y, int X, bool[] visited)
        {
            visited[Y] = true;
            if (edges[Y].Count == 1)
            {
                return false;
            }
            else
            {
                bool cek = false;
                int i = 0;
                while(i < edges[Y].Count && !cek)
                {
                    int nextr = edges[Y][i];                    
                    if (edges[nextr] != null && !visited[nextr] && depth[nextr] > depth[Y])
                    {
                        path.Add(nextr);
                        if (nextr == X)
                        {
                            return true;
                        }
                        else
                        {
                            cek = cek || isDistant(nextr, X, visited);
                        }
                        if (!cek)
                        {
                            path.Remove(nextr);
                        }
                    }
                    i++;
                }                
                return cek;
            }
        }

        static void Main()
        {
            Graph graph = new Graph(3);
            graph.addEgde(1, 2);
            graph.addEgde(1, 7);
            graph.addEgde(1, 3);
            graph.addEgde(4, 9);
            graph.addEgde(5, 4);
            graph.addEgde(5, 6);
            graph.addEgde(7, 8);
            graph.addEgde(3, 5);
            try
            {
                graph.depthNumbering(1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            graph.checkPosition(1,9, 3);
            foreach(int n in graph.path)
            {
                Console.WriteLine(n);
            }

            int a = Console.Read();
        }
    }
}
