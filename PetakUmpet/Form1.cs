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
    //ClassGraph declaration
    public class ClassGraph
    {
        static int banyakRumah()
        {
            try
            {
                int nRumah = 0;
                using (StreamReader sr = new StreamReader("coba.txt"))
                {
                    nRumah = int.Parse(sr.ReadLine());
                    return nRumah;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        // Inisialisai graf
        public static List<int>[] vertex = new List<int>[10];

        // Menambahkan edge pada graf
        static void addEgde(int asal, int tujuan)
        {
            ClassGraph.vertex[asal].Add(tujuan);
            ClassGraph.vertex[tujuan].Add(asal);
        }

        static void Telusuri(int rAwal, int nRumah)
        {
            bool[] visited = new bool[nRumah + 1];
            hasil(rAwal, visited, nRumah + 1);
        }

        static void hasil(int rumahAwal, bool[] visited, int nRumah)
        {
            visited[rumahAwal] = true;
            Console.WriteLine(rumahAwal + " ");
            for (int i = 0; i < vertex[rumahAwal].Count; i++)
            {
                int nextr = vertex[rumahAwal][i];
                if (vertex[nextr] != null)
                {
                    hasil(nextr, visited, nRumah);
                }
            }
        }

        static void ck(int nRumah, ref int[] dalam)
        {
            bool[] visited = new bool[nRumah + 1];
            kedalaman(1, visited, nRumah + 1, ref dalam);
        }

        // Menentukan level
        static void kedalaman(int rumahAwal, bool[] visited, int nRumah, ref int[] dalam)
        {
            visited[rumahAwal] = true;
            // Console.WriteLine(rumahAwal + " ");
            // Console.WriteLine("dalam[rumahAwal] : " + dalam[rumahAwal]);
            for (int i = 0; i < vertex[rumahAwal].Count; i++)
            {
                int nextr = vertex[rumahAwal][i];
                if (vertex[nextr] != null && visited[nextr] == false)
                {
                    dalam[nextr] = dalam[rumahAwal] + 1;
                    Console.WriteLine("dalam[" + nextr + "] : " + dalam[nextr]);
                    kedalaman(nextr, visited, nRumah, ref dalam);
                }
            }
        }

        static void cari(int rAwal, int nRumah, int rTujuan, ref bool cek, int[] dalam)
        {
            bool[] visited = new bool[nRumah + 1];
            dekati(rAwal, visited, nRumah + 1, ref cek, rTujuan, dalam);
        }

        static void dekati(int rumahAwal, bool[] visited, int nRumah, ref bool cek, int rTujuan, int[] dalam)
        {
            visited[rumahAwal] = true;
            // Console.WriteLine(rumahAwal + " ");
            if (rumahAwal == rTujuan)
            {
                cek = true;
                Console.WriteLine("Ketemu");
            }
            int i = 0;
            while (i < vertex[rumahAwal].Count && cek == false && rumahAwal != 1)
            {
                int nextr = vertex[rumahAwal][i];
                if (vertex[nextr] != null && dalam[nextr] < dalam[rumahAwal])
                {
                    dekati(nextr, visited, nRumah, ref cek, rTujuan, dalam);
                }
                i++;
            }
        }
        /*
        static void Main()
        {
            for (int i = 0; i < 10; i++)
            {
                vertex[i] = new List<int>();
            }

            int nRumah = banyakRumah();

            int[] dalam = new int[nRumah + 1];

            for (int i = 0; i < nRumah; i++)
            {
                dalam[i] = 0;
                //Console.WriteLine(dalam[i]);
            }


            addEgde(1, 2);
            addEgde(1, 7);
            addEgde(1, 3);
            addEgde(2, 9);
            addEgde(5, 4);
            addEgde(5, 6);
            addEgde(7, 8);
            addEgde(3, 5);



            bool cek = false;
            // Telusuri(1,nRumah);
            ck(nRumah, ref dalam);

            cari(9, nRumah, 2, ref cek, dalam);
            if (cek)
            {
                Console.WriteLine("dapat");
            }
            else
            {
                Console.WriteLine("skip");
            }
        }
        */
    }

    public partial class Form1 : Form
    {
        Microsoft.Msagl.Drawing.Graph visualGraph; // The graph that MSAGL accepts

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
                visualGraph = new Microsoft.Msagl.Drawing.Graph("graph"); // Initialize new MSAGL graph

                /*
                ClassGraph = new List<ClassGraph>(); // Clear leftover Course content
                // Read input file


                using (StreamReader sr = new StreamReader(openFileGraph.OpenFile()))
                {
                    while (sr.Peek() >= 0)
                    {
                        //construct ClassGraph & visualGraph from extern file
                    }
                }

                // Re-initialize graph viewer and animation
                DrawGraph();
                
                //check query
                //play animation
                
                */
            }
        }
    }
}
