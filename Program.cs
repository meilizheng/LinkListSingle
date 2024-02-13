namespace LinkListSingle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a linked list of strings
            LinkListSingle<string> myList = new LinkListSingle<string>();

            // Add elements to the linked list
            myList.Add("Welcome");
            myList.Add("To");
            myList.Add("2024");

            // Add an element
            myList.Add("Meili");
            myList.Remove("Meili");

            // Test the Display method to print the elements
            Console.WriteLine("Linked List Elements:");
            myList.Display();

            int index = 1;
            Console.WriteLine($"The element at index {index} is {myList[index]}");

            //Test InsertAtIndex method remove index 1 value is "Meili"
            myList.InsertAtIndex(1, "Meili");
            //Call Display method check result
            myList.Display();

            //Test RemoveAt method, remove index 1
            myList.RemoveAt(1);
            //Display result
            myList.Display();

            //Clear the data in LinkList
            myList.Clear();
            myList.Display();

        }
    }
}