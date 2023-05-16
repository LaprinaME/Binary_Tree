﻿// Подключаем необходимые пространства имен
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

// Объявляем пространство имен для бинарного дерева
namespace Binary_Tree
{
    // Объявляем класс для бинарного дерева с дженериками, где T должен быть типа IComparable<T>
    class BinaryTree<T> where T : IComparable<T>
    {
        // Объявляем приватную переменную для корневого узла дерева
        private Node<T> _root;

        // Метод для вставки нового значения в дерево
        public void Insert(T value)
        {
            // Если дерево пустое, создаем новый узел и делаем его корневым
            if (_root == null)
            {
                _root = new Node<T>(value);
            }
            // Иначе вызываем метод вставки для корневого узла
            else
            {
                _root.Insert(value);
            }
        }

        // Метод для обхода дерева в порядке in-order и выполнения переданного действия для каждого узла
        public void InOrderTraversal(Action<T> action)
        {
            // Если дерево не пустое, вызываем метод обхода узлов
            if (_root != null)
            {
                _root.InOrderTraversal(action);
            }
        }

        // Реализуем интерфейс IEnumerator<T> для возможности итерирования по дереву с помощью foreach
        public IEnumerator<T> GetEnumerator()
        {
            return new BinaryTreeEnumerator<T>(_root);
        }

        // Вложенный класс для реализации интерфейса IEnumerator<U> для итерирования по дереву
        class BinaryTreeEnumerator<U> : IEnumerator<U> where U : IComparable<U>
        {
            // Очередь для обхода дерева в порядке breadth-first
            // Очередь(queue) в C# является коллекцией объектов, которая работает по принципу "первым пришёл — первым вышел" (FIFO - First In, First Out).
            // То есть, элементы добавляются в конец очереди и удаляются из начала очереди.
            private Queue<Node<U>> _queue;

            // Конструктор для создания нового итератора, начиная с корневого узла дерева
            public BinaryTreeEnumerator(Node<U> root)
            {
                // Инициализируем очередь и добавляем в нее корневой узел, если он есть
                // Очереди осуществляется через класс Queue<T>.
                // Этот класс предоставляет набор методов для добавления и удаления элементов из очереди, а также для получения информации о её состоянии.
                _queue = new Queue<Node<U>>();
                if (root != null)
                {
                    _queue.Enqueue(root);
                }
            }

            // Текущий элемент итератора
            public U Current
            {
                get { return (U)_queue.Peek().Value; }
            }

            // Текущий элемент итератора (для интерфейса IEnumerator)
            object IEnumerator.Current
            {
                get { return Current; }
            }


            // Метод для освобождения ресурсов, используемых итератором
            public void Dispose()
            {
            }

            // Метод для перехода к следующему элементу итератора
            public bool MoveNext()
            {
                // Если очередь пустая, значит, элементы закончились
                if (_queue.Count == 0)
                {
                    return false;
                }

                // Объявление переменной node типа Node<U> и присваивание ей значения, извлеченного из головы очереди _queue
                Node<U> node = _queue.Dequeue();

                // Если узел node имеет левого потомка, то добавить его в очередь _queue
                if (node.Left != null)
                {
                    _queue.Enqueue(node.Left);
                }

                // Если узел node имеет правого потомка, то добавить его в очередь _queue
                if (node.Right != null)
                {
                    _queue.Enqueue(node.Right);
                }

                // Возвращение значения true, если очередь не пуста и обход продолжается
                return true;
            }
            // метод Reset возвращает указатель на начало коллекции
            public void Reset()
            {
                throw new NotSupportedException(); // исключение 
            }
        }
    }
}
