using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkListSingle
{
    public class LinkListSingle<T>
    {
         // Inner class LinkedListNode<T> represents individual elements (nodes) in the linked list.
         class Node<T>
         {
            // Represents the data stored in the node.
            public T Value { get; set; }
            // Represents the reference to the next node in the linked list.
            public Node<T> Next { get; set; } 

             // Constructor to initialize a LinkedListNode with a given value.
             public Node(T value)
             {
                // Set the data value of the node.
                Value = value;
                // Initialize the reference to the next node as null.
                Next = null;    
             }
         }

         // Fields
         private Node<T> head;
         private int count;

         // Property
         public int Count
         {
             get { return count; }
         }

         // Constructor
         public LinkListSingle()
         {
             head = null;
             count = 0;
         }

         // Method to add an element to the end of the linked list
         public void Add(T value)
         {
             // Create a new node with the given value
             Node<T> newNode = new Node<T>(value);

             // Check if the linked list is empty by examining whether the 'head' reference is 'null'.
             if (head == null)
             {
                 // If the list is empty, make the new node ('newNode') the head of the list
                 head = newNode;
             }
             else
             {
                 // If the list is not empty, start at the head
                 Node<T> current = head;
                // Traverse the list to find the last node (one with no next node)
                 while (current.Next != null)
                 {
                     // Move to the next node in the list
                     current = current.Next;
                 }
                 // Connect the last node's 'Next' to the new node, adding it to the end
                 current.Next = newNode;
             }
             // Increase the count to keep track of the number of elements in the list
             count++;
         }

         // Method to display all elements in the linked list
         public void Display()
         {
             // Start at the head of the linked list
             Node<T> current = head;
             // Traverse the linked list and print each element
             while (current != null)
             {
                 // Print the current node's value followed by an arrow symbol
                 Console.Write($"{current.Value} => ");
                 // Move to the next node in the list
                 current = current.Next;
             }
             // Print "null" to indicate the end of the linked list
             Console.WriteLine("null");
         }

         // Method to remove an element by its value
         public bool Remove(T value)
         {
             // Check if the linked list is empty
             if (head == null)
             {
                 // If the list is empty, return false (Element not found)
                 return false;
             }
             // Check if the value to remove is at the head of the list
             if (head.Value.Equals(value))
             {
                 // If the value is at the head, update the head to the next node and decrease the count
                 head = head.Next;
                 count--;
                 return true; // Return true (Element found and removed)
             }
             // If the value is not at the head, start at the head
             Node<T> current = head;
             // Traverse the list to find the element with the specified value
             while (current.Next != null)
             {
                 // Check if the value of the next node matches the specified value
                 if (current.Next.Value.Equals(value))
                 {
                     // If a match is found, skip the next node by updating the 'Next' reference and decrease the count
                     current.Next = current.Next.Next;
                     count--;
                     return true; // Return true (Element found and removed)
                 }
                 current = current.Next;
             }
             // Return false (Element not found)
             return false;
         }

         // Indexer override to access elements by index
         public T this[int index]
         {
             get
             {
                 // Check if the provided index is out of range (negative or greater than or equal to the count of elements)
                 if (index < 0 || index >= count)
                 {
                     // Throw an IndexOutOfRangeException if the index is out of range
                     throw new IndexOutOfRangeException();
                 }
                 // Start at the head of the linked list
                 Node<T> current = head;
                 // Traverse the list to find the element at the specified index
                 for (int i = 0; i < index; i++)
                 {
                     // Move to the next node in the list
                     current = current.Next;
                 }
                 // Return the value of the element found at the specified index
                 return current.Value;
             }
         }

        public void InsertAtIndex(int index, T value)
        {
            // Check if the index is within valid bounds
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            // Create a new node with the given value
            Node<T> newNode = new Node<T>(value);

            // If the index is 0, insert the new node at the beginning of the list
            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
                count++;
                return;
            }

            // Traverse the list to find the node before the insertion point
            Node<T> current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            // Insert the new node after the node found in the previous loop
            newNode.Next = current.Next;
            current.Next = newNode;
            count++;
        }

        public void RemoveAt(int index)
        {
            // Check if the index is within valid bounds
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            // If the index is 0, remove the first node
            if (index == 0)
            {
                head = head.Next;
                count--;
                return;
            }

            // Traverse the list to find the node before the node to be removed
            Node<T> current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            // Remove the node at the specified index by adjusting references
            current.Next = current.Next.Next;
            count--;
        }

        public void Clear()
        {
            // Clear the linked list by resetting the head to null and count to 0
            head = null;
            count = 0;
        }
    }
}

