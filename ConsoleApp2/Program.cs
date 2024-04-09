using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedListString list = new LinkedListString();

            
            list.Add("Zadoian");
            list.Add("Dmytro");
            list.Add("!");

         
            int size = list.Size();
            Console.WriteLine("Size: " + size); 

            
            string element = list.Get(1);
            Console.WriteLine("Element at index 1: " + element); 

            
            list.Set(0, "Hi");

           
            list.Delete(2);

            
            for (int i = 0; i < list.Size(); i++)
            {
                Console.WriteLine(list.Get(i));
            }
            Console.ReadLine(); 
        }
    }
    public class LinkedListString
    {
        private Node head; 
        private Node tail;
        private int size; 

      
        public void Add(string data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }

            size++;
        }

        
        public string Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }

            return current.data;
        }

        
        public void Set(int index, string data)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }

            current.data = data;
        }

        
        public void Delete(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }

            if (size == 1)
            {
                head = tail = null;
            }
            else if (index == 0)
            {
                head = head.next;
            }
            else
            {
                Node previous = head;
                for (int i = 0; i < index - 1; i++)
                {
                    previous = previous.next;
                }

                previous.next = previous.next.next;

                if (index == size - 1)
                {
                    tail = previous;
                }
            }

            size--;
        }

        
        public int Size()
        {
            return size;
        }

        
        private class Node
        {
            public string data;
            public Node next;

            public Node(string data)
            {
                this.data = data;
                next = null;
            }
        }
    }

}
