using System;
using System.Collections;

class Program
{

    public class MyLinkedList<T> : IEnumerable<T>
        where T : IEquatable<T>
    {
        class Node<T>
        {
            public T value;
            public Node<T> prev;
            public Node<T> next;
            public Node(T val, Node<T> prev, Node<T> next) {
                value = val;
                this.prev = prev;
                this.next = next;
            }
        }

        private Node<T> head;
        private Node<T> tail;

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            for (int i = 0; i < this.Count; i++)
            {
                yield return current.value;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public MyLinkedList(T[] data)
        {
            Node<T> prev = null;
            bool is_head_init = false;
            foreach (var item in data)
            {
                var current_node = new Node<T>(item, prev, null);
                if (!is_head_init)
                {
                    head = current_node;
                    is_head_init = true;
                }
                tail = current_node;
                if (prev != null)
                    prev.next = current_node;
                prev = current_node;
            }
        }

        public int Count
        {
            get {
                var cnt = 0;
                var current = head;
                while (current != null)
                {
                    cnt++;
                    current = current.next;
                }
                return cnt;
            }
        }

        public void AddToTail(T? value)
        {
            var new_node = new Node<T>(value, tail, null);
            tail.next = new_node;
            tail = new_node;
        }

        public bool Remove(T? val)
        {
            var current = head;
            while ((current != null)  && (! current.value.Equals(val)))
                current = current.next;
            if (current == null)
                return false;
            current.prev.next = current.next;
            if (tail == current)
                tail = current.prev;
            if (head == current)
                head = current.next;
            return true;
        }

    }

    public static void Main()
    {
        int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        MyLinkedList<int> myLst = new MyLinkedList<int>(data);
        foreach (int i in myLst)
            Console.Write(i.ToString() + ' ');
        Console.WriteLine("\n Count = " + myLst.Count.ToString());
        myLst.AddToTail(1);
        myLst.AddToTail(2);
        myLst.AddToTail(7);
        foreach (int i in myLst)
            Console.Write(i.ToString() + ' ');
        Console.WriteLine("\n Count = " + myLst.Count.ToString());
        myLst.Remove(5);
        myLst.Remove(7);
        foreach (int i in myLst)
            Console.Write(i.ToString() + ' ');
        Console.WriteLine("\n Count = " + myLst.Count.ToString());
    }
}