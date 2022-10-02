using System;

namespace ConsoleApp1
{
    class Program
    {

        static void Main()
        {
            /*
            Graph graph1 = new Graph();
            Graph graph2 = new Graph(-1, @"input.txt", false, false);
            graph2.Bfs(0);
            graph2.BfsPrint(0, 2);

            Console.WriteLine();
            graph2.BfsPrint(0);
            Console.WriteLine();
            graph2.Dfs(0);
            */

            GraphRepo graphRepo = new GraphRepo();
            Logic graphLogic = new Logic(graphRepo);
            Interface consoleInterface = new Interface(graphLogic);
            consoleInterface.Start();

        }
    }
}
