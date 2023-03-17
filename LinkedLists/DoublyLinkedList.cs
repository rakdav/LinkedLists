using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    internal class DoublyLinkedList<T>:IEnumerable<T>
    {
        DoublyNode<T> head;
        DoublyNode<T> tail;
        int count;
        public int Count { get; set; }
        public bool IsEmpty 
        { 
            get { return count == 0; } 
        }

        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            if(head == null) 
                head = node;
            else
            {
                tail.Next = node.Next;
                node.Previus = tail;
            }
            tail=node;
            count++;
        }
        public void AddFirst(T data)
        {
            DoublyNode<T> node=new DoublyNode<T>(data);
            DoublyNode<T> temp=head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = node;
            else
                temp.Previus = node;
            count++;
        }
        public bool Remove(T data) 
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data)) break;
                current = current.Next;
            }
            if(current!=null)
            {
                //если узел не последний и последний
                if (current.Next != null)
                    current.Next.Previus = current.Previus;
                else
                    tail = current.Previus;
                //если узел не первый
                if (current.Previus != null)
                    current.Previus.Next = current.Next;
                else
                    head = current.Next;
                count--;
                return true;
            }
            return false;
        }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public bool Contains(T data) 
        {
            DoublyNode<T> current=head;
            while (current != null)
            {
                if(current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current=head;
            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public IEnumerator<T> BackEnumerator()
        {
            DoublyNode<T> current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previus;
            }
        }

    }
}
