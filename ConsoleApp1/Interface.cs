using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Interface
    {

        private const string CreateGraph = "CREATE_GRAPH";
        private static readonly string[] CreateGraphArgs = {"(WAY IF YOU NEED)",  "DIRECTED (TRUE/FALSE)", "WEIGHTED (TRUE/FALSE)" };
        
        private const string DeleteGraph = "DELETE_GRAPH";
        private static readonly string[] DeleteGraphArgs = { "ID"};

        private const string GetGRAPH = "PRINT_GRAPH";
        private static readonly string[] GetGRAPHArgs = { "ID" };

        private const string AddEDGE = "ADD_EDGE";
        private static readonly string[] AddEDGEArgs = { "ID", "NODE_FROM", "NODE_TO", "(WEIGHT IF THE GRAPH IF WEIGHTED)" };

        private const string AddNODE = "ADD_NODE";
        private static readonly string[] AddNODEArgs = { "ID", "NODE" };

        private const string DeleteEDGE = "DELETE_EDGE";
        private static readonly string[] DeleteEDGEArgs = { "ID", "NODE_FROM", "NODE_TO", "(WEIGHT IF THE GRAPH IF WEIGHTED)" };

        private const string DeleteNODE = "DELETE_NODE";
        private static readonly string[] DeleteNODEArgs = { "ID", "NODE" };

        private const string ToUndirected = "TURN_THE_GRAPH_TO_UNDIRECTED";
        private static readonly string[] ToUndirectedArgs = { "ID"};

        private const string BFS = "BFS";
        private static readonly string[] BFSArgs = { "ID", "NODE_FROM", "(NODE_TO IF YOU NEED)" };

        private const string DFS = "DFS";
        private static readonly string[] DFSArgs = { "ID", "NODE_FROM" };

        private const string Dijkstr = "SHORTEST_WAY";
        private static readonly string[] DijkstrArgs = { "ID", "NODE_FROM", "NODE_TO" };

        private const string PrintAll = "PRINT_ALL";

        private const string Read_Adjacency_List = "READ_ADJACENCY_LIST";
        private static readonly string[] ReadALArgs = {"ID", "WAY" };

        private const string Write_Adjacency_List = "WRITE_ADJACENCY_LIST";
        private static readonly string[] WriteALArgs = { "ID", "WAY" };

        private const string Hint = "HINT";
        private const string Exit = "EXIT";

        private readonly Logic _logic;

        public Interface(Logic logic)
        {
            this._logic = logic;
        }

        public void Start()
        {
            Console.WriteLine(GetHint());
            for (;;)
            {
                try
                {
                    Console.Write(">>> ");
                    List<String> arguments = new List<String>(Console.ReadLine().Split(" "));
                    string command = arguments[0].ToUpper();
                    arguments.RemoveAt(0);
                    switch (command)
                    {
                        case CreateGraph:
                            if (arguments.Count == CreateGraphArgs.Length)
                            {
                                bool direc = (arguments[1].ToUpper() == "TRUE");
                                bool weig = (arguments[2].ToUpper() == "TRUE");
                                
                                Console.WriteLine(_logic.AddGraph(
                                    arguments[0], direc, weig));
                            }
                            else if (arguments.Count == CreateGraphArgs.Length - 1) { 

                                bool direc = (arguments[0] == "TRUE");
                                bool weig = (arguments[1] == "TRUE");
                                
                                Console.WriteLine(_logic.AddGraph(direc, weig));

                            }
                            else throw new Exception("Wrong Arguments");
                            break;

                        case DeleteGraph:
                            if (arguments.Count == DeleteGraphArgs.Length)
                            {
                                _logic.DeleteGraph(int.Parse(arguments[0]));
                            }
                            else throw new Exception("Wrong Arguments");
                            break;

                        case AddEDGE:
                            if (arguments.Count == AddEDGEArgs.Length)
                            {
                                Console.WriteLine(_logic.AddEdge(
                                    int.Parse(arguments[0]),
                                    int.Parse(arguments[1]),
                                    int.Parse(arguments[2]),
                                    int.Parse(arguments[3])));
                            }
                            else if (arguments.Count == AddEDGEArgs.Length - 1)
                            {
                                Console.WriteLine(_logic.AddEdge(
                                    int.Parse(arguments[0]),
                                    int.Parse(arguments[1]),
                                    int.Parse(arguments[2]), 0));
                            }
                            else throw new Exception("Wrong Arguments");
                            break;

                        case AddNODE:
                            if (arguments.Count == AddNODEArgs.Length)
                            {
                                Console.WriteLine(_logic.AddNode(
                                    int.Parse(arguments[0]),
                                    int.Parse(arguments[1])));
                            }
                            else throw new Exception("Wrong Arguments");
                            break;

                        case DeleteEDGE:
                            if (arguments.Count == DeleteEDGEArgs.Length)
                            {
                                Console.WriteLine(_logic.RemoveEdge(
                                       int.Parse(arguments[0]),
                                       int.Parse(arguments[1]),
                                       int.Parse(arguments[2]),
                                       int.Parse(arguments[3])));
                            }
                            else if (arguments.Count == DeleteEDGEArgs.Length - 1)
                            {
                                Console.WriteLine(_logic.RemoveEdge(
                                    int.Parse(arguments[0]),
                                    int.Parse(arguments[1]),
                                    int.Parse(arguments[2]), 0));
                            }
                            else throw new Exception("Wrong Arguments");

                            break;

                        case DeleteNODE:
                            if (arguments.Count != DeleteNODEArgs.Length)
                                throw new Exception("Wrong Arguments");
                            else
                            {
                                Console.WriteLine(_logic.RemoveNode(
                                    int.Parse(arguments[0]),
                                    int.Parse(arguments[1])));
                            }
                            break;

                        case GetGRAPH:
                            if (arguments.Count == GetGRAPHArgs.Length)
                            {
                                _logic.Show(int.Parse(arguments[0]));
                            }
                            else throw new Exception("Wrong Arguments");
                            break;

                        case ToUndirected:
                            if (arguments.Count == ToUndirectedArgs.Length)
                            {
                                Console.WriteLine(_logic.ToUndirected(int.Parse(arguments[0])));
                            }
                            else throw new Exception("Wrong Arguments");
                            break;

                        case BFS:
                            if (arguments.Count == BFSArgs.Length)
                            {
                                _logic.BFS(int.Parse(arguments[0]), int.Parse(arguments[1]), int.Parse(arguments[2]));
                            }
                            else if (arguments.Count == BFSArgs.Length - 1)
                            {
                                _logic.BFS(int.Parse(arguments[0]), int.Parse(arguments[1]));
                            }
                            else throw new Exception("Wrong Arguments");
                            break;

                        case DFS:
                            if (arguments.Count == DFSArgs.Length)
                            {
                                _logic.DFS(int.Parse(arguments[0]), int.Parse(arguments[1]));
                            }
                            else throw new Exception("Wrong Arguments");
                            break;

                        case Dijkstr:
                            if (arguments.Count == DijkstrArgs.Length)
                            {
                                _logic.Dijkstr(int.Parse(arguments[0]),
                                    int.Parse(arguments[1]),
                                    int.Parse(arguments[2]));
                            }
                            else throw new Exception("Wrong Arguments");
                            break;

                        case Read_Adjacency_List:
                            if (arguments.Count == ReadALArgs.Length)
                            {
                                _logic.ReadAdjacencyList(
                                    int.Parse(arguments[0]), arguments[1]);
                            }
                            else throw new Exception("Wrong Arguments");
                            break;

                        case Write_Adjacency_List:
                            if (arguments.Count == WriteALArgs.Length)
                            {
                                _logic.WriteAdjacencyList(
                                    int.Parse(arguments[0]), arguments[1]);
                            }
                            else throw new Exception("Wrong Arguments");
                            break;

                        case PrintAll:
                            if (arguments.Count == 0)
                            {
                                _logic.PrintAll();
                            }
                            else throw new Exception("Wrong Arguments");
                            break;

                        case Hint:
                            Console.WriteLine(GetHint());
                            break;

                        case Exit:
                            return;

                        default:
                            throw new Exception("ERROR: Unknown Command");
                            break;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }



        private static String GetHint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(CreateGraph).Append(": ").Append(String.Join(", ", CreateGraphArgs)).Append('\n');
            sb.Append(Read_Adjacency_List).Append(": ").Append(String.Join(", ", ReadALArgs)).Append('\n');
            sb.Append(Write_Adjacency_List).Append(": ").Append(String.Join(", ", WriteALArgs)).Append('\n');
            sb.Append(AddEDGE).Append(": ").Append(String.Join(", ", AddEDGEArgs)).Append('\n');
            sb.Append(AddNODE).Append(": ").Append(String.Join(", ", AddNODEArgs)).Append('\n');
            sb.Append(DeleteEDGE).Append(": ").Append(String.Join(", ", DeleteEDGEArgs)).Append('\n');
            sb.Append(DeleteNODE).Append(": ").Append(String.Join(", ", DeleteNODEArgs)).Append('\n');
            sb.Append(GetGRAPH).Append(": ").Append(String.Join(", ", GetGRAPHArgs)).Append('\n');
            sb.Append(ToUndirected).Append(": ").Append(String.Join(", ", ToUndirectedArgs)).Append('\n');
            sb.Append(BFS).Append(": ").Append(String.Join(", ", BFSArgs)).Append('\n');
            sb.Append(DFS).Append(": ").Append(String.Join(", ", DFSArgs)).Append('\n');
            sb.Append(Dijkstr).Append(": ").Append(String.Join(", ", DijkstrArgs)).Append('\n');
            sb.Append(PrintAll).Append('\n');
            sb.Append(Hint).Append('\n');
            sb.Append(Exit).Append('\n');

            return sb.ToString();
        }
    }
}
