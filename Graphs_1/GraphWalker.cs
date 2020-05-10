using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs_1
{
    public class GraphWalker<T>
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

            WalkThroughNode(graph.Nodes[0]);
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
}
