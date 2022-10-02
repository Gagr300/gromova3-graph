using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class GraphRepo
    {

        private readonly List<Graph> _graphs;
        private int counter;
        public GraphRepo()
        {
            _graphs = new List<Graph>(0);
            counter = 0;
        }

        public int AddGraph(Graph graph)
        {
            if (graph.GetID.Equals(0))
            {
                graph.GetID = ++counter;
                _graphs.Add(graph);
                return graph.GetID;
            }
            throw new Exception("Graph already exists");
        }

        public List<Graph> GetAll()
        {
            return _graphs;
        }
        public void PrintAll()
        {
            if (counter == 0) throw new Exception("No Graphs Yet");
            foreach (Graph graph in _graphs)
            {
                Console.WriteLine(graph.GetID);
                if (graph.Nodes.Count == 0)
                {
                    Console.WriteLine("The graph is empty");
                    continue;
                }
                graph.Show();
            }
            
        }
        
        public bool DeleteGraph(int id)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].GetID == id)
                {
                    _graphs.RemoveAt(i);
                    return true;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public bool AddEdge(int id, int u, int v, int w)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].GetID == id)
                {
                    return _graphs[i].AddEdge(u, v, w); ;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public bool RemoveEdge(int id, int u, int v, int w)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].GetID == id)
                {
                    return _graphs[i].RemoveEdge(u, v, w); ;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public bool AddNode(int id, int u)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].GetID == id)
                {
                    _graphs[i].AddNode(u);
                    return true;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public bool RemoveNode(int id, int u)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].GetID == id)
                {
                    return _graphs[i].RemoveNode(u);
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void Show(int id)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                _graphs[i].Show();
                return;
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public bool ToUndirected(int id)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].GetID == id)
                {
                    if (!_graphs[i].Directed)
                        throw new Exception("WARNING: The graph is already undirected");
                    _graphs[i].ToUndirected();
                    return true;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public bool BFS(int id, int v)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].GetID == id)
                {
                    _graphs[i].BFSPrint(v);
                    return true;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public bool BFS(int id, int v, int u)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].GetID == id)
                {
                    _graphs[i].BFSPrint(v, u);
                    return true;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public bool DFS(int id, int v)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].GetID == id)
                {
                    _graphs[i].DFS(v);
                    return true;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void Dijkstr(int id, int v, int u)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].GetID == id)
                {

                    if (!(_graphs[i].Nodes.Contains(v) && _graphs[i].Nodes.Contains(u)))
                        throw new Exception("ERROR: Wrong nodes");
                    _graphs[i].DIJ(v, u);
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }

        public bool ReadAdjacencyList(int id, string name)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].GetID == id)
                {
                    _graphs[i].ReadAdjacencyList(name);
                    return true;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public bool WriteAdjacencyList(int id, string name)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].GetID == id)
                {
                    _graphs[i].WriteAdjacencyList(name);
                    return true;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
    }
}
