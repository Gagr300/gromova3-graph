using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	public class Node
	{

		private int from;
		private int cnt;
		private List<KeyValuePair<int, int>> to;

		public int From { get { return from; } }
		public int Cnt { get { return cnt; } }

		public List<KeyValuePair<int, int>> To { get { return to; } }

		//конструктор, инициализирует список смежности и вспомогательный массив
		public Node(int u, List<KeyValuePair<int, int>> a)
		{
			from = u;
			to = a;
			to.Sort(delegate (KeyValuePair<int, int> x, KeyValuePair<int, int> y)
			{ if (x.Key == y.Key) return x.Value.CompareTo(y.Value); else return x.Key.CompareTo(y.Key); });
			cnt = a.Count;
		}

		public Node(Node n)
		{
			from = n.from;
			to = new List<KeyValuePair<int, int>>(n.to);
			cnt = n.cnt;
		}

		public bool AddEdge(int v, int w)
		{
			if (!to.Contains(new KeyValuePair<int, int>(v, w)))
			{
				to.Add(new KeyValuePair<int, int>(v, w));
				to.Sort(delegate (KeyValuePair<int, int> x , KeyValuePair<int, int> y) 
					{ if (x.Key == y.Key) return x.Value.CompareTo(y.Value); else return x.Key.CompareTo(y.Key); } );
				cnt++;
				return true;
			}
			else
            {
				Console.WriteLine("The edge (u,v) len - w has already been");
				return false;
            }
		}

		public bool RemoveEdge(int v, int w)
		{
			if (to.Contains(new KeyValuePair<int, int>(v, w)))
			{
				to.Remove(new KeyValuePair<int, int>(v, w));
				cnt--;
				return true;
			}
			else
			{
				return false;
			}
		}

		//выводит в консоль список смежных вершин
		public void ShowLine(bool weigted)
		{
			if (weigted)
			{
				if (cnt < 1) Console.Write("--"); 
				foreach (KeyValuePair<int, int> l in to)
				{
					Console.Write("{0,4} - {1,4} ;  ", l.Key, l.Value);
				}
			}
			else
            {
				if (cnt < 1) Console.Write("--"); ;
				foreach (KeyValuePair<int, int> l in to)
				{
					Console.Write("{0,4}", l.Key);
				}
			}
		}

	}
}
