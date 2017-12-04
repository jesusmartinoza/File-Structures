using CSharpTest.Net.Collections;
using CSharpTest.Net.Serialization;
using Shields.GraphViz.Components;
using Shields.GraphViz.Models;
using Shields.GraphViz.Services;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Structures
{
    /**
    *  +--- Name ---+--- Type ---+--- Length ----+---- Address ----+--- Index Address ----+--- Index Type ----+--- Next Address ----+
    *        30           1              4                8                  8                      4                  8            
    *        
    * 63 bytes in file per attribute
    **/
    public class Attribute
    {
        public enum IndexType
        {
            nonType = 0,
            searchKey = 1,
            primaryKey = 2,
            foreignKey = 3,
            bPlusTree = 4,
            dynamicHash = 5
        }

        string name;
        long fileAddress;
        char type;
        int length;
        long indexAddress;
        IndexType indexType;
        long nexAttributeAddress;
        string entityName;
        SortedList<object, string> indexData;

        // Tree
        BPlusTree<int, long> tree;
        IRenderer renderer;

        public string Name { get => name; set => name = value.PadRight(30); }
        public long FileAddress { get => fileAddress; set => fileAddress = value; }
        public char Type { get => type; set => type = value; }
        public int Length { get => length; set => length = value; }
        public long IndexAddress { get => indexAddress; set => indexAddress = value; }
        public IndexType IndexTypeV { get => indexType; set => indexType = value; }
        public long NexAttributeAddress { get => nexAttributeAddress; set => nexAttributeAddress = value; }
        public string EntityName { get => entityName; set => entityName = value; }
        public SortedList<object, string> IndexData { get => indexData; set => indexData = value; }
        public BPlusTree<int, long> Tree { get => tree; set => tree = value; }

        /**
         *  Constructor used to create an attribute in memory.
         *  By default all addresses are -1
         */
        public Attribute(string name, char type, int length, IndexType indexType, string entityName)
        {
            Name = name;
            Type = type;
            Length = length;
            IndexTypeV = indexType;
            EntityName = entityName.Trim();
            FileAddress = -1;
            IndexAddress = -1;
            NexAttributeAddress = -1;
            IndexData = new SortedList<object, string>();
        }

        /**
         * Constructor used when read from file
         * */
        public Attribute(string name, long fileAddress, char type, int length, long indexAddress, IndexType indexType, long nexAttributeAddress, string entityName)
        {
            this.name = name;
            this.fileAddress = fileAddress;
            this.type = type;
            this.length = length;
            this.indexAddress = indexAddress;
            this.indexType = indexType;
            this.nexAttributeAddress = nexAttributeAddress;
            this.entityName = entityName;
            this.IndexData = new SortedList<object, string>();

            if(indexType == IndexType.bPlusTree)
            {
                BPlusTree<int, long>.Options optionsTree = new BPlusTree<int, long>.Options(
                                    PrimitiveSerializer.Int32, PrimitiveSerializer.Int64, Comparer<int>.Default)
                {
                    CreateFile = CreatePolicy.IfNeeded,
                    FileName = @"C:\Users\hongo\Documents\File-Structures\File Structures\bin\Debug\Tree\" + name.Trim() + ".dat"
                };

                renderer = new Renderer(@"C:\Program Files (x86)\Graphviz2.38\bin");

                //optionsTree.BTreeOrder = 5;
                optionsTree.MaximumValueNodes = 4;
                Tree = new BPlusTree<int, long>(optionsTree);
            }
        }

        /**
         * Generate B+ Tree Log and print on a TextBox
         * @param textBoxTreeLog - TextBox to print log.
         * @param pictureBox - PictureBox to show de graph
         */
        public void SetBPlusTreeLog(TextBox textBoxTreeLog, PictureBox pictureBox)
        {
            var path = @"C:\Users\hongo\Documents\File-Structures\File Structures\bin\Debug\Tree\TreeLog.txt";
            String log = "";
            String root = "[   ";
            List<String> nodes = new List<String>();

            // Write log in file
            using (var writer = System.IO.File.CreateText(path))
            {
                tree.Print(writer, BPlusTree<int, long>.DebugFormat.Formatted);
                writer.Close();
            }

            // Remove duplicated info
            var newNode = false;
            var node = "[   ";
            foreach (var str in System.IO.File.ReadAllLines(path))
            {
                log += "\r\n";
                if (str.Contains("="))
                {
                    log += str.Substring(0, str.LastIndexOf("="));
                    node += str.Substring(0, str.LastIndexOf("=")).Trim() + "   ";
                    newNode = false;
                }
                else
                {
                    log += str;
                    newNode = true;
                }

                if (newNode && node.Length > 8)
                {
                    nodes.Add(node + "]");
                    node = "[   ";
                }
            }
            textBoxTreeLog.Text = log;

            // Extract Root
            Regex reg = new Regex(@"}.*?{");
            MatchCollection matches = reg.Matches(log.Replace("\r\n", ""));

            textBoxTreeLog.Text += "\r\n\r\n ROOT: ";

            foreach (Match m in matches)
                root += Regex.Match(m.Value, @"\d+").Value + "   ";
            root += "]";
            textBoxTreeLog.Text += root;

            GenerateBPlusTreeImage(root, nodes, pictureBox);
        }

        /**
         * Iterate over nodes list and create Graph representation using GraphViz
         * @param root - String that shows root nodes
         * @param nodes - Leafs of the tree
         * @param pictureBox - PictureBox instance to show the generated image
         */
        private async Task GenerateBPlusTreeImage(String root, List<String> nodes, PictureBox pictureBox)
        {
            Graph graph;
            List<EdgeStatement> edges = new List<EdgeStatement>();

            foreach (String node in nodes)
            {
                var label = ImmutableDictionary.CreateBuilder<Id, Id>();
                label.Add("label", "");

                edges.Add(new EdgeStatement(root, node, label.ToImmutable()));
            }

            // Note: Double assign because Shields.Graphviz doesn't 
            //       allow to add Statements after instance creation.
            if (nodes.Count == 1)
            {
                graph = Graph.Directed
                        .Add(AttributeStatement.Graph.Set("labelloc", "t"))
                        .Add(AttributeStatement.Node.Set("style", "filled"))
                        .Add(AttributeStatement.Node.Set("shape", "box"))
                        .Add(AttributeStatement.Node.Set("fillcolor", "#ECECEC"))
                        .Add(AttributeStatement.Edge.Set("color", "#0097A7"))
                        .Add(AttributeStatement.Node.Set("color", "#0097A7"))
                        .Add(NodeStatement.For(nodes[0]));
            }
            else
            {
                graph = Graph.Directed
                        .Add(AttributeStatement.Graph.Set("labelloc", "t"))
                        .Add(AttributeStatement.Node.Set("style", "filled"))
                        .Add(AttributeStatement.Node.Set("shape", "box"))
                        .Add(AttributeStatement.Node.Set("fillcolor", "#ECECEC"))
                        .Add(AttributeStatement.Edge.Set("color", "#0097A7"))
                        .Add(AttributeStatement.Node.Set("color", "#0097A7"))
                        .AddRange(edges);
            }

            using (Stream file = System.IO.File.Create(@"C:\Users\hongo\Documents\File-Structures\File Structures\bin\Debug\Tree\Tree_" + name.Trim() + ".png"))
            {
                await renderer.RunAsync(
                    graph, file,
                    RendererLayouts.Dot,
                    RendererFormats.Png,
                    CancellationToken.None);

                pictureBox.Image = Image.FromStream(file);
            }
        }
    }
}
