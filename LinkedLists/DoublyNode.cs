using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class DoublyNode<T>
    {
        public T Data { get; set; }
        public DoublyNode<T> Next {get; set;}
        public DoublyNode<T> Previus {get; set;}
        public DoublyNode(T data)
        {
            Data = data;
        }
    }
}
