using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Graphs_1
{
    public class Graph<T> : IEnumerable
    {
        private Stack<Node<T>> _nodes;

        public Stack<Node<T>> Nodes { get => _nodes; set => _nodes = value; }

        public Graph()
        {
            Nodes = new Stack<Node<T>>();
        }

        public void AddNode(Node<T> node) => _nodes.Push(node);

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
    }
}
