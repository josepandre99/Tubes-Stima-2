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
        static List<string> visitedNode;
        int count, nNode, nQuery;
        string queryLine, q;
        StreamReader fq;
        bool graphLoaded = false;

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

            //Clear listBox1
            listBox1.Items.Clear();
            //Setting Font in listBox1
            listBox1.Font = new Font(Font.FontFamily, 20);

            // Show file dialog
            DialogResult result = openFileGraph.ShowDialog();

            if (result == DialogResult.OK) // If the file dialog retrieves a file
            {
                graph = new Microsoft.Msagl.Drawing.Graph("graph"); // Initialize new MSAGL graph                
                // Read input file

                using (StreamReader sr = new StreamReader(openFileGraph.OpenFile()))
                {
                    string line = sr.ReadLine();
                    if (line == null || line == "0")
                    {
                        MessageBox.Show("File Kosong", "Warning!!!");
                    }
                    else
                    {
                        graphLoaded = true;
                        nNode = Int32.Parse(line);
                        for (int i = 0; i < nNode; i++) graph.AddNode((i + 1).ToString());
                        virtualGraph = new Graph(nNode);

                        while (sr.Peek() >= 0)
                        {
                            line = sr.ReadLine(); // Read file line by line
                            string[] cur_line = line.Split(' ');
                            virtualGraph.addEdge(Int32.Parse(cur_line[0]), Int32.Parse(cur_line[1]));
                            if (!(Int32.Parse(cur_line[0]) > nNode || Int32.Parse(cur_line[1]) > nNode))
                                graph.AddEdge(cur_line[0], cur_line[1]);
                        }

                        try
                        {
                            virtualGraph.depthNumbering(1);
                            DrawGraph();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("CIRCULAR CUY");
                            MessageBox.Show("Graf Siklik", "Warning!!!");
                        }
                    }
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

        public void button_loadQuery_Click(object sender, EventArgs e)
        {
            // Setting up the file dialog
            openFileQuery.Filter = "*.txt|*.txt|All files (*.*)|*.*";
            openFileQuery.InitialDirectory = Directory.GetCurrentDirectory();
            openFileQuery.Title = "Masukkan file eksternal";

            // Show file dialog
            DialogResult result_loadQuery = openFileQuery.ShowDialog();

            if (result_loadQuery == DialogResult.OK)
            {// If the file dialog retrieves a file
                fq = new StreamReader(openFileQuery.OpenFile());
                queryLine = fq.ReadLine();
                nQuery = Int32.Parse(queryLine);
                count = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!graphLoaded)
            {
                MessageBox.Show("Graf Kosong", "Warning!!!");
            }
            else
            {
                for (int i = 0; i < nNode; i++) graph.FindNode((i + 1).ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
                
                string[] cur_queryLine = q.Split(' ');
                visitedNode = new List<string>();

                //Show Query
                //listBox3.Items.Clear();
                //listBox3.Items.Add(queryLine);

                //virtualGraph.depthNumbering(1);
                try
                {
                    if (virtualGraph.checkPosition(Int32.Parse(cur_queryLine[0]), Int32.Parse(cur_queryLine[1]), Int32.Parse(cur_queryLine[2])))
                    {
                        foreach (string visited in visitedNode)
                            graph.FindNode(visited).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                        Console.WriteLine("YA");
                        listBox3.Items.Clear();
                        listBox3.Items.Add("YA");
                    }
                    else
                    {
                        Console.WriteLine("TIDAK");
                        listBox3.Items.Clear();
                        listBox3.Items.Add("TIDAK");
                    }
                    DrawGraph();
                }
                catch(Exception)
                {
                    MessageBox.Show("Query salah", "Warning!!!");
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            q = textBox1.Text;
            Console.WriteLine(q);
        }

        private void panel_DrawGraph_Paint(object sender, PaintEventArgs e)
        {

        }

        public void button_nextQuery_Click(object sender, EventArgs e)
        {
            if (!graphLoaded)
            {
                MessageBox.Show("Graf Kosong", "Warning!!!");
            }
            else if(count < nQuery)
            {
                    for (int i = 0; i < nNode; i++) graph.FindNode((i + 1).ToString()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
                    queryLine = fq.ReadLine(); // Read file line by line
                    string[] cur_queryLine = queryLine.Split(' ');
                    visitedNode = new List<string>();

                    //Show Query
                    listBox2.Items.Clear();
                    listBox2.Items.Add(queryLine);

                    //virtualGraph.depthNumbering(1);
                    if (virtualGraph.checkPosition(Int32.Parse(cur_queryLine[0]), Int32.Parse(cur_queryLine[1]), Int32.Parse(cur_queryLine[2])))
                    {
                        foreach (string visited in visitedNode)
                            graph.FindNode(visited).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                        Console.WriteLine("YA");
                        listBox1.Items.Clear();
                        listBox1.Items.Add("YA");
                    }
                    else
                    {
                        Console.WriteLine("TIDAK");
                        listBox1.Items.Clear();
                        listBox1.Items.Add("TIDAK");
                    }
                    DrawGraph();

            }
            else
            {
                MessageBox.Show("Query Kosong", "Warning!!!");
            }
            count++;
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

            public bool checkPosition(int n, int x, int y)
            {
                visitedNode.Clear();
                visitedNode.Add(y.ToString());
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
                    int i = 0;
                    while (i < edges[Y].Count && !cek)
                    {
                        int nextr = edges[Y][i];
                        if (edges[nextr] != null && !visited[nextr] && depth[nextr] < depth[Y])
                        {
                            visitedNode.Add(nextr.ToString());
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
                                visitedNode.Remove(nextr.ToString());
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
                    while (i < edges[Y].Count && !cek)
                    {
                        int nextr = edges[Y][i];
                        if (edges[nextr] != null && !visited[nextr] && depth[nextr] > depth[Y])
                        {
                            visitedNode.Add(nextr.ToString());
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
                                visitedNode.Remove(nextr.ToString());
                            }
                        }
                        i++;
                    }
                    return cek;
                }
            }    
        }
    }

}