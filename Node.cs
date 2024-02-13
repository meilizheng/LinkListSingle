using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkListSingle
{
    public class Node<T>
    {
        private T? value;

        public Node(T? value)
        {
            this.value = value;
        }

        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public void DisplayNode()
        {
            Console.WriteLine(Value);
        }
    }
}
