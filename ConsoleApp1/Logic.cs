using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Logic
    {
        private readonly GraphRepo _graphRepo;

        public Logic(GraphRepo graphRepo)
        {
            this._graphRepo = graphRepo;
        }
        public int AddGraph(bool dir, bool weig)
        {
            Graph graph = new Graph(dir, weig);
            return _graphRepo.AddGraph(graph);

        }
        public int AddGraph(string name, bool dir, bool weig)
        {
            Graph graph = new Graph( name, dir, weig);
            return _graphRepo.AddGraph(graph);
        }
        public List<Graph> GetAll()
        {
            return _graphRepo.GetAll();
        }
        public void PrintAll()
        {
           _graphRepo.PrintAll();
        }
        public bool DeleteGraph(int id)
        {
            return _graphRepo.DeleteGraph(id);
        }
        public Graph Find(int id)
        {
            List<Graph> graphs = _graphRepo.GetAll();
            foreach (Graph b in graphs)
            {
                if (b.GetID == id)
                {
                    return b;
                }
            }
            return null;
        }
        public bool AddEdge(int id, int u, int v, int w)
        {
            return _graphRepo.AddEdge(id, u, v, w);
        }
        public bool RemoveEdge(int id, int u, int v, int w)
        {
            return _graphRepo.RemoveEdge(id, u, v, w);
        }
        public bool AddNode(int id, int u)
        {
            return _graphRepo.AddNode(id, u);
        }
        public bool RemoveNode(int id, int u)
        {
            return _graphRepo.RemoveNode(id, u);
        }
        public void Show(int id)
        {
            _graphRepo.Show(id);
        }

        public bool ToUndirected(int id)
        {
            return _graphRepo.ToUndirected(id);
        }
        public void BFS(int id, int v)
        {
            _graphRepo.BFS(id, v);
        }
        public void BFS(int id, int v, int u)
        {
            _graphRepo.BFS(id, v, u);
        }
        public void DFS(int id, int v)
        {
            _graphRepo.DFS(id, v);
        }
        public void Dijkstr(int id, int v, int u)
        {
            _graphRepo.Dijkstr(id, v, u);
        }

        public void ReadAdjacencyList(int id, string name)
        {
            _graphRepo.ReadAdjacencyList(id, name);
        }
        public void WriteAdjacencyList(int id, string name)
        {
            _graphRepo.WriteAdjacencyList(id, name);
        }
    }

}
