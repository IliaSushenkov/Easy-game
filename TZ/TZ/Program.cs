using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TZ
{
    struct QueueNode
    {
        public int i;
        public int j;
        public int idx;

        public QueueNode(int i, int j, int idx = 0)
        {
            this.i = i;
            this.j = j;
            this.idx = idx;
        }
    }

    struct Node
    {
        public int i;
        public int j;

        public Node(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
    }

    class Program
    {
        private static readonly int[] i_d = { 1, -1, 0, 0 };
        private static readonly int[] j_d = { 0, 0, 1, -1 };

        private static void Fill<T>(ref T[,] arr, T value)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = value;
        }

        private static Node Bfs(ref char[,] ar, int n, ref string word, int start_i, int start_j, ref bool[,] used, ref Node[,] path)
        {
            Fill<bool>(ref used, false);

            Queue<QueueNode> q = new Queue<QueueNode>();
            q.Enqueue(new QueueNode(start_i, start_j, 0));
            used[start_i, start_j] = true;

            while (q.Any())
            {
                QueueNode cur_node = q.Dequeue();

                // We need this when word.Length = 1
                if (cur_node.idx == word.Length - 1)
                    return new Node(cur_node.i, cur_node.j);

                for (int ch = 0; ch < i_d.Length; ch++)
                {
                    int next_i = cur_node.i + i_d[ch];
                    int next_j = cur_node.j + j_d[ch];
                    if (0 <= next_i && next_i < n && 0 <= next_j && next_j < n)  
                        if (!used[next_i, next_j] && ar[next_i, next_j] == word[cur_node.idx + 1])
                        {
                            used[next_i, next_j] = true;
                            path[next_i, next_j] = new Node(cur_node.i, cur_node.j);

                            if (cur_node.idx + 1 == word.Length - 1)
                                return new Node(next_i, next_j);

                            q.Enqueue(new QueueNode(next_i, next_j, cur_node.idx + 1));
                        }
                }
            }
            return new Node(-1, -1);
        }

        private static void PrintAns(ref string word, Node ans, ref Node[,] path)
        {
            List<Node> ans_n = new List<Node>();
            int word_len = word.Length;
            while (word_len-- > 0)
            {
                ans_n.Add(ans);
                ans = path[ans.i, ans.j];
            }

            ans_n.Reverse();
            for (int i = 0; i < word.Length; i++)
                Console.WriteLine("{0} - [{1},{2}]", word[i], ans_n[i].i, ans_n[i].j);
        }

        static void Main(string[] args)
        {
            string m_str = Console.ReadLine();

            int n = (int)Math.Sqrt(m_str.Length);
            char[,] ar = new char[n, n];

            int cnt = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    ar[i, j] = m_str[cnt++];

            string word = Console.ReadLine();

            Node[,] path = new Node[n, n];
            bool[,] used = new bool[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (ar[i, j] == word[0])
                    {
                        Node ans = Bfs(ref ar, n, ref word, i, j, ref used, ref path);
                        if (ans.i != -1)
                        {
                            PrintAns(ref word, ans, ref path);
                            return;
                        }
                    }
            Console.WriteLine("There is no right answer!");
            Console.ReadKey();
        }
    }
}


