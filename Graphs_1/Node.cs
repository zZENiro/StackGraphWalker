using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs_1
{
    public class Node<T>
    {
        private static int _counter = 1;

        private T _value;
        private Stack<Node<T>> _incedentEdges;
        private Graph<T> _parentGraph;
        public readonly int Number;

        public T Value
        {
            get => _value;
            set => SetValue(ref _value, value);
        }

        public Stack<Node<T>> ConnectedNodes
        {
            get => _incedentEdges;
            set => SetValue(ref _incedentEdges, value);
        }

        public Node(Graph<T> ParentGraph)
        {
            _parentGraph = ParentGraph;
            ParentGraph.AddNode(this);

            Number = _counter++;
            _incedentEdges = new Stack<Node<T>>();
        }

        public void ConnectNode(Node<T>? node)
        {
            if (node == null || IsConnected(node) || this == node)
                return;

            _incedentEdges.Push(node);
            node.ConnectNode(this);
        }

        public void DisconnectWithNode(Node<T> node)
        {
            
        }

        public void DisconnectNode()
        {
                        
        }

        public bool HasConnections() => _incedentEdges.Count > 0;

        private bool IsConnected(Node<T> node)
        {
            foreach (var n in _incedentEdges)
                if (n == node)
                    return true;

            return false;
        }

        protected bool SetValue<T>(ref T target, T value)
        {
            if (object.Equals(target, value))
                return false;

            target = value;
            return true;
        }

        public override bool Equals(object obj) => (this.Number == (obj as Node<T>).Number);

        public override string ToString() => $"Number: {Number}\tValue: {Value}";
    }
}
