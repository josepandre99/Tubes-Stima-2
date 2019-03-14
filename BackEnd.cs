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

        public Graph(int n)
        {
            n_vertex = n;
            edges = new List<int>[n + 1];
            depth = new int[n + 1];
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
            DFS(v, visited);
        }

        void DFS(int v, bool[] visited)
        {
            visited[v] = true;
            for (int i = 0; i < edges[v].Count; i++)
            {
                int nextr = edges[v][i];
                if (edges[nextr] != null && !visited[nextr])
                {
                    depth[nextr] = depth[v] + 1;
                    Console.WriteLine("dalam[" + nextr + "] : " + depth[nextr]);
                    DFS(nextr, visited);
                }
            }
        }

        void checkPosition(int n, int X, int Y)
        {
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
                for (int i = 0; i < edges[Y].Count; i++)
                {
                    int nextr = edges[Y][i];
                    if (edges[nextr] != null && !visited[nextr] && depth[nextr] < depth[Y])
                    {
                        if (nextr == X)
                        {
                            return true;
                        }
                        else
                        {
                            cek = cek || isApproaching(nextr, X, visited);
                        }
                    }
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

                for (int i = 0; i < edges[Y].Count; i++)
                {
                    int nextr = edges[Y][i];
                    if (edges[nextr] != null && !visited[nextr] && depth[nextr] > depth[Y])
                    {
                        if (nextr == X)
                        {
                            return true;
                        }
                        else
                        {
                            cek = cek || isDistant(nextr, X, visited);
                        }
                    }
                }
                return cek;
            }
        }

        static void Main()
        {
            Graph graph = new Graph(9);
            graph.addEgde(1, 2);
            graph.addEgde(1, 7);
            graph.addEgde(1, 3);
            graph.addEgde(2, 9);
            graph.addEgde(5, 4);
            graph.addEgde(5, 6);
            graph.addEgde(7, 8);
            graph.addEgde(3, 5);
            graph.depthNumbering(1);

            graph.checkPosition(1,9,1);

            int a = Console.Read();
        }
    }
}
