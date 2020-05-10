using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Graphs_1
{
    public class Graph<T> : IEnumerable
    {
        private List<Node<T>> _nodes;

        public List<Node<T>> Nodes { get => _nodes; }

        public Graph() => _nodes = new List<Node<T>>();

        public Graph(List<Node<T>> nodes) => _nodes = nodes;

        public static Graph<T> CreateGraph(int[,] graphTable)
        {
            if (!IsQuadratic(graphTable))
                throw new Exception("Table has to be quad.");

            var crLen = Math.Sqrt(graphTable.Length);

            List<Node<T>> _nodes = new List<Node<T>>();
            Graph<T> _graph = new Graph<T>(_nodes);

            for (int i = 0; i < graphTable.Length; ++i)
                _nodes.Add(new Node<T>());

            for (int i = 0; i < crLen; ++i)
            {
                for (int j = 0; j < crLen; ++j)
                {
                    if (graphTable[i, j] != 0)
                    {
                        _nodes[i].ConnectNode(_nodes[j]);
                    }
                }
            }

            return _graph;
        }

        public void AddNode(Node<T> node) => _nodes.Add(node);

        //public void AddNodesRange(params Node<T>[] nodes)
        //{
        //    foreach (var node in nodes)
        //        _nodes.Add(node);
        //}

        //public void RemoveNode(Node<T> node)
        //{
        //    node.DisconnectNode();
        //}

        public IEnumerator GetEnumerator() => ((IEnumerable)_nodes).GetEnumerator();
        
        private static bool IsQuadratic(int[,] graphTable) => (Math.Sqrt(graphTable.Length) % 1) == 0;
    }
}
