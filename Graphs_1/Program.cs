using System;
using System.Collections;
using System.Collections.Generic;

namespace Graphs_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = Graph<int>.CreateGraph(new int[,] 
            {
                { 0, 1, 1, 1 },
                { 1, 0, 1, 0 },
                { 1, 1, 1, 1 },
                { 1, 0, 1, 0 }
            });

            GraphWalker<int>.WalkGraph(graph);
        }
    }
}
