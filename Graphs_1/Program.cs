using System;
using System.Collections;
using System.Collections.Generic;

namespace Graphs_1
{
    class GraphWalker<T>
    {
        enum State
        {
            Visited,
            Unvisted
        }

        static Dictionary<int, State> visitedNodes = new Dictionary<int, State>();

        public static void WalkGraph<T>(Graph<T> graph)
        {
            visitedNodes.Clear();
            foreach (Node<T> node in graph)
                visitedNodes.Add(node.Number, State.Unvisted);

            WalkThroughNode(graph.Nodes.Pop());
        }

        static void WalkThroughNode<T>(Node<T> node)
        {
            if (node.HasConnections())
            {
                visitedNodes[node.Number] = State.Visited;
                Console.WriteLine(node.Number);

                foreach (var n in node.ConnectedNodes)
                {
                    if (visitedNodes[n.Number] == State.Unvisted)
                        WalkThroughNode(n);
                }
            }
            else
            {
                visitedNodes[node.Number] = State.Visited;
                Console.WriteLine(node.Number);

                return;
            }
            return;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>();

            var _1 = new Node<int>(graph);
            var _2 = new Node<int>(graph);
            var _3 = new Node<int>(graph);
            var _4 = new Node<int>(graph);
            var _5 = new Node<int>(graph);
            var _6 = new Node<int>(graph);
            var _7 = new Node<int>(graph);
            var _8 = new Node<int>(graph);

            _1.ConnectNode(_2);
            _1.ConnectNode(_3);
            _1.ConnectNode(_4);

            _3.ConnectNode(_7);

            _4.ConnectNode(_5);
            _4.ConnectNode(_6);

            _8.ConnectNode(_7);
            _8.ConnectNode(_3);
            _8.ConnectNode(_6);

            GraphWalker<int>.WalkGraph(graph);
        }
    }
}
