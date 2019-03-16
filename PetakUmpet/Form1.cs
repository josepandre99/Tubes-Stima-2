using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PetakUmpet
{

    public partial class Form1 : Form
    {
        Microsoft.Msagl.Drawing.Graph graph; // The graph that MSAGL accepts
        Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer(); // Graph viewer engine
        Graph virtualGraph;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_LoadFile_Click(object sender, EventArgs e)
        {
            // Setting up the file dialog
            openFileGraph.Filter = "*.txt|*.txt|All files (*.*)|*.*";
            openFileGraph.InitialDirectory = Directory.GetCurrentDirectory();
            openFileGraph.Title = "Masukkan file eksternal";

            // Show file dialog
            DialogResult result = openFileGraph.ShowDialog();

            if (result == DialogResult.OK) // If the file dialog retrieves a file
            {
                graph = new Microsoft.Msagl.Drawing.Graph("graph"); // Initialize new MSAGL graph                
                // Read input file

                using (StreamReader sr = new StreamReader(openFileGraph.OpenFile()))
                {
                    string line = sr.ReadLine();
                    int nNode = Int32.Parse(line);
                    for (int i = 0; i < nNode; i++) graph.AddNode((i + 1).ToString());
                    Graph virtualGraph = new Graph(nNode);

                    while (sr.Peek() >= 0)
                    {
                        line = sr.ReadLine(); // Read file line by line
                        string[] cur_line = line.Split(' ');
                        virtualGraph.addEdge(Int32.Parse(cur_line[0]), Int32.Parse(cur_line[1]));
                        if (!(Int32.Parse(cur_line[0]) > nNode || Int32.Parse(cur_line[1]) > nNode))
                            graph.AddEdge(cur_line[0], cur_line[1]);               
                    }

                    //if (virtualGraph.isCyclic())
                    //{
                        DrawGraph();
                    //}
                    
                    //else tampilkan pesan kesalahan

                    //load file query
                    //check query dari GUI
                    
                }

                
            }
        }



        private void DrawGraph()
        {
            // Bind graph to viewer engine
            viewer.Graph = graph;
            // Bind viewer engine to the panel
            panel_DrawGraph.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_DrawGraph.Controls.Add(viewer);
            panel_DrawGraph.ResumeLayout();
        }

        private void button_loadQuery_Click(object sender, EventArgs e)
        {
            // Setting up the file dialog
            openFileQuery.Filter = "*.txt|*.txt|All files (*.*)|*.*";
            openFileQuery.InitialDirectory = Directory.GetCurrentDirectory();
            openFileQuery.Title = "Masukkan file eksternal";

            // Show file dialog
            DialogResult result_loadQuery = openFileQuery.ShowDialog();

            if (result_loadQuery == DialogResult.OK)
            {// If the file dialog retrieves a file

                using (StreamReader fq = new StreamReader(openFileQuery.OpenFile()))
                {
                    string queryLine = fq.ReadLine();
                    int nQuery = Int32.Parse(queryLine);
                    int count = 0;

                    while (count < nQuery)
                    {
                        queryLine = fq.ReadLine(); // Read file line by line
                        string[] cur_queryLine = queryLine.Split(' ');

                        virtualGraph.depthNumbering(1);
                        if (virtualGraph.checkPosition(Int32.Parse(cur_queryLine[0]), Int32.Parse(cur_queryLine[1]), Int32.Parse(cur_queryLine[2])))
                        {
                            //YA
                            //playAnimation
                        }
                        else
                        {
                            //TIDAK
                        }
                    }
                }
            }
        }
    }

    //Graph declaration

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

        public void addEdge(int origin, int end)
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

        public bool checkPosition(int n, int x, int y)
        {
            bool[] visited = new bool[n_vertex + 1];
            for (int i = 0; i <= n_vertex; i++)
            {
                visited[i] = false;
            }
            if (n == 1)
            {
                return (isDistant(y, x, visited));

            }
            else
            {
                return (isApproaching(y, x, visited));
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

        public bool isCyclicUtil(int i, bool[] visited, bool[] recStack)
        {
            if (recStack[i])
            {
                return true;
            }

            if (visited[i])
            {
                return false;
            }
                
            visited[i] = true;

            recStack[i] = true;
            List<int> children = edges[i];

            for (int j = 0; j < edges[i].Count; j++)
            {
                if (isCyclicUtil(edges[i][j], visited, recStack))
                    return true;
            }

            recStack[i] = false;

            return false;
        }

        public bool isCyclic()
        {
            bool[] visited = new bool[n_vertex + 1];
            bool[] recStack = new bool[n_vertex + 1];

            for (int i = 0; i < n_vertex; i++)
            {
                if (isCyclicUtil(i, visited, recStack))
                {
                    return true;
                }
            }

            return false;
        }

    }