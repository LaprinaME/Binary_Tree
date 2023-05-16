using System;
using System.Collections;
using System.Collections.Generic;

namespace Binary_Tree
{
    /* Класс Node<T> представляет узел дерева и хранит данные типа T (условно предполагается, 
     * что T реализует интерфейс IComparable<T> для сравнения данных в узлах), 
     * а также ссылки на левое и правое поддеревья.*/
    public class Node<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public object Value { get; internal set; }

        public Node(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        internal void Insert<T>(T value) where T : IComparable<T>
        {
            throw new NotImplementedException();
        }

        internal void InOrderTraversal<T>(Action<T> action) where T : IComparable<T>
        {
            throw new NotImplementedException();
        }
    }
    /*Класс Tree<T> реализует само дерево и содержит методы для добавления нового узла, 
     * поиска узла по заданным данным, итерации по дереву (инфиксный обход) и обхода в ширину (BFS). 
     * Кроме того, он реализует интерфейс IEnumerable<T>, что позволяет использовать объекты этого класса в циклах foreach.*/
    public class Tree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node<T> root;
        /*Метод Add добавляет новый узел с заданными данными в дерево. Если дерево пустое, создается корневой узел. 
         * В противном случае, выполняется поиск места для вставки нового узла в дерево, 
         * и это место находится с помощью последовательного сравнения данных в узлах и перехода к соответствующему поддереву.*/
        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node<T> current = root;

                while (true)
                {
                    if (data.CompareTo(current.Data) < 0)
                    {
                        if (current.Left == null)
                        {
                            current.Left = newNode;
                            break;
                        }
                        current = current.Left;
                    }
                    else
                    {
                        if (current.Right == null)
                        {
                            current.Right = newNode;
                            break;
                        }
                        current = current.Right;
                    }
                }
            }
        }
        /*Метод Search осуществляет поиск узла с заданными данными в дереве. Для этого выполняется поиск по дереву, 
         * начиная с корня и продолжая до тех пор, пока не будет найден узел с заданными данными или пока не будет 
         * достигнут конец дерева.*/
        public Node<T> Search(T data)
        {
            Node<T> current = root;

            while (current != null)
            {
                if (data.CompareTo(current.Data) == 0)
                {
                    return current;
                }
                else if (data.CompareTo(current.Data) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return null;
        }
        /*Метод GetEnumerator реализует итерацию по дереву в инфиксном порядке (сначала левое поддерево, 
         * затем текущий узел, затем правое поддерево) с помощью стека. 
         * Метод BreadthFirstTraversal реализует обход в ширину дерева (BFS) с помощью очереди.*/
        public IEnumerator<T> GetEnumerator()
        {
            if (root != null)
            {
                Stack<Node<T>> stack = new Stack<Node<T>>();
                Node<T> current = root;

                while (stack.Count > 0 || current != null)
                {
                    if (current != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                    else
                    {
                        current = stack.Pop();
                        yield return current.Data;
                        current = current.Right;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /*Оба метода возвращают последовательность данных в узлах дерева типа T при помощи оператора yield return, 
         * который позволяет создать ленивую последовательность без выделения лишней памяти.*/
        public IEnumerable<T> BreadthFirstTraversal()
        {
            if (root == null)
            {
                yield break;
            }

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node<T> node = queue.Dequeue();
                yield return node.Data;

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }
    }
}
