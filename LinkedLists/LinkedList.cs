using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    internal class LinkedList<T>:IEnumerable<T> 
    {
        Node<T>? head;
        Node<T>? tail;
        int count;
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        public void Add(T data)
        {
            Node<T> node=new Node<T>(data);
            if(head==null) 
                head = node;
            else
                tail!.Next=node;
            tail = node;
            count++;
        }
        public bool Remove(T data)
        {
            Node<T>? current=head;
            Node<T>? previus=null;
            while(current!=null&&current.Data!=null)
            {
                if (current.Data.Equals(data))
                {
                    if (previus != null)
                    {
                        previus.Next = current.Next;
                        if (current.Next == null)
                            tail = previus;
                    }
                    else
                    {
                        head = head?.Next;
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
                previus = current;
                current = current.Next; 
            }
            return false;
        }
        public void Clear()
        {
            head=null;
            tail=null;
            count=0;
        }
        public bool Contains(T data)
        {
            Node<T> current=head;
            while(current!=null && current.Data!=null)
            {
                if(current.Data.Equals(data)) 
                    return true;
                current = current.Next;
            }
            return false;
        }
        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;    
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = head;
            while(current!=null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
