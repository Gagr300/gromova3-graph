using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{

	public class Graph
	{
		private int ID;
		private int size;
		private List<int> nodes;
		private List<Node> graph;

		private bool directed;
		private bool weighted;

		public int GetID { get {return ID; } set { ID = value; } }
		public bool Directed { get { return directed; } }
		public List<int> Nodes { get { return nodes; } }
		
		public char[] splitChars = { ' ', '\n', '\t', '\r' };

		public Graph()
		{
			ID = 0;
			size = 0;
			directed = false;
			weighted = false;
			nodes = new List<int>();
			graph = new List<Node>();
		}
		public Graph(bool dir, bool weig)
		{
			ID = 0;
			size = 0;
			directed = dir;
			weighted = weig;
			nodes = new List<int>();
			graph = new List<Node>();
		}
		public Graph(string name, bool dir, bool weig)
		{
			directed =  dir;
			weighted = weig;
			nodes = new List<int>();
			graph = new List<Node>();
			nov = new bool[size];
			ReadList(name);
		}
		public Graph(int id, string name, bool dir, bool weig)
		{
			ID = id;
			directed = dir;
			weighted = weig;
			nodes = new List<int>();
			graph = new List<Node>();
			nov = new bool[size];
			ReadList(name);
		}
		public Graph(Graph g)
		{
			ID = g.ID;
			directed = g.directed;
			weighted = g.weighted;
			nodes = new List<int>(g.nodes);
			for (int i = 0; i < size; i++)
			{
				graph.Add(new Node(g.graph[i]));
			}

		}

		public void ReadList(string name)
        {
			using (StreamReader file = new StreamReader(name))
			{
				string[] n = file.ReadLine().Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
				size = int.Parse(n[0]);
				List<KeyValuePair<int, int>>[] a = new List<KeyValuePair<int, int>>[size];
				for (int i = 0; i < size; i++) a[i] = new List<KeyValuePair<int, int>>();

				nov = new bool[size];

				if (weighted==true)
				{
					if (directed==true)
					{
						for (int i = 0; i < int.Parse(n[1]); i++)
						{
							string[] mas = file.ReadLine().Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
							a[int.Parse(mas[0])].Add(new KeyValuePair<int, int>(int.Parse(mas[1]), int.Parse(mas[2])));
						}
					}
					else
					{
						for (int i = 0; i < int.Parse(n[1]); i++)
						{
							string[] mas = file.ReadLine().Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
							a[int.Parse(mas[0])].Add(new KeyValuePair<int, int>(int.Parse(mas[1]), int.Parse(mas[2])));
							a[int.Parse(mas[1])].Add(new KeyValuePair<int, int>(int.Parse(mas[0]), int.Parse(mas[2])));
						}
					}
				}
				else
				{
					if (directed==true)
					{
						for (int i = 0; i < int.Parse(n[1]); i++)
						{
							string[] mas = file.ReadLine().Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
							a[int.Parse(mas[0])].Add(new KeyValuePair<int, int>(int.Parse(mas[1]), 1));
						}
					}
					else
					{
						for (int i = 0; i < int.Parse(n[1]); i++)
						{
							string[] mas = file.ReadLine().Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
							a[int.Parse(mas[0])].Add(new KeyValuePair<int, int>(int.Parse(mas[1]), 1));
							a[int.Parse(mas[1])].Add(new KeyValuePair<int, int>(int.Parse(mas[0]), 1));
						}
					}
				}
				for (int i = 0; i < size; i++)
				{
					nodes.Add(i);
					graph.Add(new Node(i, a[i]));
				}
			}
		}

		public void ReadAdjacencyList(string name)
		{

			using (StreamReader file = new StreamReader(name))
			{
				string[] n = file.ReadLine().Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
				size = int.Parse(n[0]);
				Dictionary<int,List<KeyValuePair<int, int>>> a = new Dictionary<int,List<KeyValuePair<int, int>>>();
				
				for (int i = 0; i < size; i++)
				{
					string[] mas = file.ReadLine().Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
					a.Add( int.Parse(mas[0]), new List<KeyValuePair<int, int>>());
					for (int j = 1; j < mas.Length; j+=2)
					a[int.Parse(mas[0])].Add(new KeyValuePair<int, int>(int.Parse(mas[j]), int.Parse(mas[j+1])));
				}
				foreach ( var i in a)
                {
					nodes.Add(i.Key);
					graph.Add(new Node(i.Key, i.Value));
                }
			}
		}

		public void WriteAdjacencyList(string name)
		{
			using (StreamWriter file = new StreamWriter(name))
			{
				file.WriteLine(size);
				for (int i = 0; i < size; i++)
				{
					file.Write("{0} ", i);
					for (int j = 0; j < graph[i].To.Count; j++)
					{
						file.Write("{0} {1} ", graph[i].To[j].Key, graph[i].To[j].Value);
					}
					file.WriteLine();
				}
			}
		}

		//делает ненаправленым
		public void ToUndirected()
		{
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < graph[i].Cnt; j++)
				{
					if (!graph[j].To.Contains(new KeyValuePair<int, int>(i, graph[i].To[j].Value)))
					{
						graph[j].To.Add(new KeyValuePair<int, int>(i, graph[i].To[j].Value));

					}
				}
			}
			directed = false;
		}

		//добавляет ребро
		public bool AddEdge(int u, int v, int w)
		{
			if (nodes.Contains(u) && nodes.Contains(v))
			{
				return (graph[nodes.IndexOf(u)].AddEdge(v, w));
			}
			else if (nodes.Contains(v))
				throw new Exception("ERROR: Wrong NODE_FROM");
			else if (nodes.Contains(u))
				throw new Exception("ERROR: Wrong NODE_TO");
			else throw new Exception("ERROR: Wrong NODE_FROM and NODE_TO");
		}

		//удаляет ребро
		public bool RemoveEdge(int u, int v, int w)
		{
			return (graph[nodes.IndexOf(u)].RemoveEdge(v, w));
		}

		//добавляет вершину
		public bool AddNode(int u)
		{

			if (!nodes.Contains(u))
			{
				graph.Add(new Node(u, new List<KeyValuePair<int, int>>()));
				graph.Sort(delegate (Node n, Node m) { return n.From.CompareTo(m.From); });
				nodes.Add(u);
				nodes.Sort();
				size++;
				nov = new bool[size];
				return true;
			}
			else throw new Exception ("ERROR: The node already exists");
		}

		//удаляет вершину
		public bool RemoveNode(int u)
		{

			if (nodes.Contains(u))
			{
				graph.Remove(new Node(u, new List<KeyValuePair<int, int>>()));
				nodes.Remove(u);
				size--;
				nov = new bool[size];
				return true;
			}
			else return false;
		}

		//вывод списка смежности
		public void Show()
		{
			for (int i = 0; i < size; i++)
			{
				Console.Write("{0} : ", nodes[i]);
				graph[i].ShowLine(weighted);
				Console.WriteLine();
			}
		}

		public void Show(int v)
		{
			graph[v].ShowLine(weighted);
		}

		private bool[] nov;
		// помечает все вершины графа как непросмотреные
		public void NovSet()
		{
			for (int i = 0; i < size; i++)
			{
				nov[i] = false;
			}
		}

		public void DFS(int v)
		{
			Console.Write("DFS from {0}:  ", v);
			NovSet();
			dfs(v);
            Console.WriteLine();
		}

		public void dfs(int v)
		{
			if (!nov[v])
			{
				nov[v] = true;
				foreach (var i in graph[v].To)
				{
					if (!nov[i.Key])
					{
						dfs(i.Key);
						Console.Write("{0} ", i.Key);
					}
				}
			}
		}

		public int[] d;
		public int[] p;

		public void BFS(int v)
		{
			NovSet();

			Queue<int> q = new Queue<int>();
			d = new int[size];
			p = new int[size];
			q.Enqueue(v);
			nov[v] = true;
			p[v] = -1;
			while (q.Count != 0)
			{
				int u = q.Peek();
				q.Dequeue();
				for (var i = 0; i < graph[u].To.Count; i++)
				{
					int to = graph[u].To[i].Key;
					if (!nov[to])
					{
						nov[to] = true;
						q.Enqueue(to);
						d[to] = d[u] + 1;
						p[to] = u;
					}

				}
			}
		}

		public void BFSPrint(int v)
		{
			NovSet();

			Queue<int> q = new Queue<int>();
			d = new int[size];
			p = new int[size];
			q.Enqueue(v);
            Console.Write("{0} ", v);
			nov[v] = true;
			p[v] = -1;
			while (q.Count != 0)
			{
				int u = q.Peek();
				q.Dequeue();
				for (var i = 0; i < graph[u].To.Count; i++)
				{
					int to = graph[u].To[i].Key;
					if (!nov[to])
					{
						nov[to] = true;
						q.Enqueue(to);
                        Console.Write("{0} ",to);
						d[to] = d[u] + 1;
						p[to] = u;
					}

				}
			}
		}

		public bool BFSPrint(int from, int to)
		{
			if (!nov[to])
			{
				Console.WriteLine("No path!");
				return false;
			}
			else
			{
				List<int> path = new List<int>();
				for (int v = to; v != -1; v = p[v]) path.Add(v);
				path.Reverse();
				Console.Write("BFS from {0} to {1}:  ", from, to);
				for (int i = 0; i < path.Count; i++) Console.Write("{0} ", path[i]);
				return true;
			}
            Console.WriteLine();
		}

		public void DIJ(int s, int find) {
			//List<bool> used = new List<bool>(size);
			List<int> d = Enumerable.Repeat(int.MaxValue, size).ToList(); ;
			d[s] = 0;
			SortedSet<KeyValuePair<int, int>> q = new SortedSet<KeyValuePair<int, int>>();
			q.Add(new KeyValuePair<int, int>(d[s], s));
            while (q.Count != 0)
            {
				int v = q.First().Value;
				q.Remove(q.First());
				foreach (var i in graph[v].To)
                {
					if (d[i.Key] > d[v] + i.Value)
                    {
						q.Remove(new KeyValuePair<int, int>(d[i.Key], i.Key));
						d[i.Key] = d[v] + i.Value;
						p[i.Key] = v;
						q.Add(new KeyValuePair<int, int>(d[i.Key], i.Key));
                    }
                }
            }
			int j = s;
			while(j != find)
            {
                Console.Write("{0} ", j);
				j = d[j];
            }
		}

		public void Floyd()
		{
			int[,] p;
			long[,] a = Floyd(out p); //запускаем алгоритм Флойда
			int i, j;
			//анализируем полученные данные и выводим их на экран
			for (i = 0; i < size; i++)
			{
				for (j = 0; j < size; j++)
				{
					if (i != j)
					{
						if (a[i, j] == int.MaxValue)
						{
							Console.WriteLine("Пути из вершины {0} в вершину {1} не существует", i, j);
						}
						else
						{
							Console.Write("Кратчайший путь  от вершины {0} до вершины {1} равен ", i, j);
							Console.Write(a[i, j]);
							Console.Write(" путь ");
							Queue<int> items = new Queue<int>();
							items.Enqueue(i);
							WayFloyd(i, j, p, ref items);
							items.Enqueue(j);
							while (items.Count != 0)
							{
								Console.Write("{0} ", items.Dequeue());
							}
							Console.WriteLine();
						}
					}
				}
			}
		}

		//алгоритм Флойда
		public long[,] Floyd(out int[,] p)
		{
			int i, j, k;
			//создаем массивы р и а
			long[,] a = new long[size, size];
			p = new int[size, size];
			for (i = 0; i < size; i++)
			{
				for (j = 0; j < size; j++)
				{
					if (i == j) a[i, j] = 0;
					else a[i, j] = int.MaxValue;
					p[i, j] = -1;
				}
				foreach (KeyValuePair<int, int> l in graph[i].To) a[i, l.Key] = l.Value;
			}

			//осуществляем поиск кратчайших путей
			for (k = 0; k < size; k++)
			{
				for (i = 0; i < size; i++)
				{
					for (j = 0; j < size; j++)
					{
						long distance = a[i, k] + a[k, j];
						if (a[i, j] > distance)
						{
							a[i, j] = distance;
							p[i, j] = k;
						}
					}
				}
			}
			return a;
		}

		//восстановление пути от вершины a до вершины в для алгоритма Флойда
		public void WayFloyd(int a, int b, int[,] p, ref Queue<int> items)
		{
			int k = p[a, b];
			//если k<> -1, то путь состоит более чем из двух вершин а и b, и проходит  через  
			//вершину k, поэтому
			if (k != -1)
			{
				// рекурсивно восстанавливаем путь между вершинами а и k
				WayFloyd(a, k, p, ref items);
				items.Enqueue(k);   //помещаем вершину к в очередь
									// рекурсивно восстанавливаем путь между вершинами  k и b
				WayFloyd(k, b, p, ref items);
			}
		}

		//Дейкстра
		/*
		public void Dijkstr(int v)
		{
			NovSet(); //помечаем все вершины графа как непросмотренные
			int[] p;
			long[] d = Dijkstr(v, out p); //запускаем алгоритм Дейкстры
										  //анализируем полученные данные и выводим их на экран
			Console.WriteLine("Длина кратчайшие пути от вершины {0} до вершины", v);
			for (int i = 0; i < size; i++)
			{
				if (i != v)
				{
					Console.Write("{0} равна  {1}, ", i, d[i]);
					Console.Write("путь ");
					if (d[i] != int.MaxValue)
					{
						Stack<int> items = new Stack<int>();
						WayDijkstr(v, i, p, ref items);
						while (items.Count != 0)
						{
							Console.Write("{0} ", items.Pop());
						}
					}
				}
				Console.WriteLine();
			}
		}

		//алгоритм Дейкстры 
		public long[] Dijkstr(int v, out int[] p)
		{
			nov[v] = false;     // помечаем вершину v как просмотренную
								//создаем матрицу с
			int[,] c = new int[size, size];

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++) c[i, j] = int.MaxValue;
				foreach (KeyValuePair<int, int> l in graph[i].To) c[i, l.Key] = l.Value;
			}

			//создаем матрицы d и p
			long[] d = new long[size];
			p = new int[size];
			for (int u = 0; u < size; u++)
			{
				if (u != v)
				{
					d[u] = c[v, u];
					p[u] = v;
				}
			}

			for (int i = 0; i < size - 1; i++)  // на каждом шаге цикла
			{
				// выбираем из множества V\S такую вершину w, что D[w] минимально
				long min = int.MaxValue;
				int w = 0;
				for (int u = 0; u < size; u++)
				{
					if (nov[u] && min > d[u])
					{
						min = d[u];
						w = u;
					}
				}
				nov[w] = false; //помещаем w в множество S
								//для каждой вершины из множества V\S определяем кратчайший путь от
								// источника до этой вершины
				for (int u = 0; u < size; u++)
				{
					long distance = d[w] + c[w, u];
					if (nov[u] && d[u] > distance)
					{
						d[u] = distance;
						p[u] = w;
					}
				}
			}
			return d;   //в качестве результата возвращаем массив кратчайших путей для 
		}

		//восстановление пути от вершины a до вершины b для алгоритма Дейкстры
		public void WayDijkstr(int a, int b, int[] p, ref Stack<int> items)
		{
			items.Push(b);   //помещаем вершину b в стек
			if (a == p[b])  //если предыдущей для вершины b является вершина а, то
			{
				items.Push(a);  //помещаем а в стек и завершаем восстановление пути
			}
			else        //иначе метод рекурсивно вызывает сам себя для поиска пути
			{               //от вершины а до вершины, предшествующей вершине b
				WayDijkstr(a, p[b], p, ref items);
			}
		}
		*/
	}
}
