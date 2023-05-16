using System;

namespace Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();

            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);
            tree.Add(9);

            Console.WriteLine("Обход по прямому порядку:");
            foreach (int i in tree)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Обход в ширину:");
            foreach (int i in tree.BreadthFirstTraversal())
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Поиск 3:");
            Node<int> node = tree.Search(3);
            if (node != null)
            {
                Console.WriteLine("Найден узел со значением 3.");
            }
            else
            {
                Console.WriteLine("Узел со значением 3 не найден.");
            }
            Console.WriteLine("Поиск 6:");
            node = tree.Search(6);
            if (node != null)
            {
                Console.WriteLine("Найден узел со значением 6.");
            }
            else
            {
                Console.WriteLine("Узел со значением 6 не найден.");
            }

            Console.ReadLine();
        }
    }
}