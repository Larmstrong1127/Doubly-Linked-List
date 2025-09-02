using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{

    class DoublyLinkedList
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the Doubly Linked List of integers");

            Console.WriteLine();

            DoublyLinkedList<Object> list = new DoublyLinkedList<Object>(); //this is the list I will be referencing for my doubly linkedlist for all methods with integers
            //Add nodes to the list  
            list.AddFirst(10);
            list.AddFirst(20);
            list.AddFirst(30);
            list.AddFirst(40);
            list.AddFirst(50);
            list.AddLast(60);
            list.AddLast(80);
            list.DeleteValue(40);
            list.Reverse();
            list.Print();


            Console.WriteLine();
            list.Print();
            list.DeleteFirst();
            list.Print();


            Console.WriteLine();
            list.Print();
            list.DeleteLast();
            list.Print();


            Console.WriteLine();
            list.Print();
            list.Reverse();
            Console.WriteLine("Reversed list");
            list.Print();


            Console.WriteLine();
            list.Print();
            //list.DeleteNode(list.head.Next);
            list.Print();


            Console.WriteLine();

            list.Print();
            list.DeleteValue(3);
            list.Print();


            Console.WriteLine();

            list.Print();
            list.IsEmpty();
            list.Print();


            Console.WriteLine();

            list.Print();
            list.Clear();
            list.Print();

            Console.WriteLine();

            Console.WriteLine("This is Doubly Linked List of Strings");


            Console.WriteLine();

            DoublyLinkedList<Object> phrase = new DoublyLinkedList<Object>();  //this is the list I will be referencing for my doubly linkedlist for all methods with strings
            //Add nodes to the list  
            phrase.AddFirst("Happy");
            phrase.AddFirst("Sad");
            phrase.AddFirst("Mad");
            phrase.AddFirst("Running");
            phrase.AddFirst("Play");
            phrase.AddLast("Soccer");
            phrase.AddLast("Coding");


            Console.WriteLine();
            phrase.Print();
            phrase.DeleteFirst();
            phrase.Print();


            Console.WriteLine();
            phrase.Print();
            phrase.DeleteLast();
            phrase.Print();


            Console.WriteLine();
            phrase.Print();
            phrase.Reverse();
            Console.WriteLine("Reversed list");
            phrase.Print();


            Console.WriteLine();
            phrase.Print();
            phrase.DeleteNode(phrase.head.Next);
            phrase.Print();


            Console.WriteLine();

            phrase.Print();
            phrase.DeleteValue(3);
            phrase.Print();


            Console.WriteLine();

            phrase.Print();
            phrase.IsEmpty();
            phrase.Print();


            Console.WriteLine();

            phrase.Print();
            phrase.Clear();
            phrase.Print();



        }

    }
    class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }

        public Node(T val)
        {
            Value = val;

        }
    }
    class DoublyLinkedList<T>
    {
        public Node<T> head { get; private set; }  // the head pointer in doubly linked list
        public Node<T> tail { get; private set; }   //the tail pointer in doubly linked list




        public void AddFirst(T newValue)  // this method will had an element at the beginning of the list
        {
            Node<T> node1 = new Node<T>(newValue);

            if (head == null && tail == null)
            {
                head = node1;
                tail = node1;


            }
            else  //if head and tail are not null then add element at the beginning of the list
            {
                head.Previous = node1;
                node1.Next = head;
                node1.Previous = null;
                head = node1;


            }
        }

        public void AddLast(T newValue)  //this will add the last element to the end of the list and the parameter of the AddLast method will accept integers and strings
        {
            if (head == null)//if there is nothing in the head then the element will go to the start of the list using AddFirst method
            {
                AddFirst(newValue);
            }
            else //if the head is not null then the element will be added to the end of the list
            {
                Node<T> finger = tail;
                tail = new Node<T>(newValue);
                finger.Next = tail;
                tail.Previous = finger;

            }
        }


        public void DeleteFirst()  //this method will delete the first element in the list 
        {
            if (head == null) // if there is nothing in the list you can't delete an element when the list is empty
            {
                throw new Exception("you can't delete from empty list");
            }
            else if (head.Next == null && tail.Previous == null)  // if previous element of the head is null and the previous element in tail is null then both head and tail are null
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
        }


        public void DeleteLast() // this method will delete the last element in the list 
        {
            if (head == null) // if there is nothing in the head you can't delete it
            {
                throw new Exception("you can't delete from empty list");

            }
            else if (head.Next == null)
            {
                DeleteFirst();
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
        }


        public void DeleteValue(T funValue)  //delete a given vlaue
        {
            if (head == null)
            {
                ;
            }
            else if (head.Value.Equals(funValue))  // if value is in the head delete the element with DeleteFirst method
            {
                DeleteFirst();
            }
            else if (tail.Value.Equals(funValue)) // if value is in the tail delete the element with DeleteLast method
            {
                DeleteLast();
            }
            else
            {
                Node<T> finger = head;
                while (finger.Next != null && !finger.Next.Value.Equals(funValue))
                {
                    finger = finger.Next;
                }

                if (finger.Next != null)
                {
                    finger.Next = finger.Next.Next;
                }
            }


        }

        public void DeleteNode(Node<T> node)  //delete a given node
        {
            {

                if (node.Previous == null)// 
                {
                    head = node.Next;
                }
                if (node.Next == null)// if the node we want to remove is tail
                {
                    tail = node.Previous;
                }
                if ((node.Previous != null) && (node.Next != null))//if node is other than head or tail
                {
                    node.Previous.Next = node.Next; // removing the reference from the selected node
                    node.Next.Previous = node.Previous;
                }
            }
        }


        public void Reverse()  //this method will reverse the order of the doubly linked list from the main method 
        {
            Node<T> finger = head;
            head = tail;
            tail = finger;

            Node<T> values = head;

            while (values != null)
            { //swap prev and next of current node
                head = values.Next;
                values.Next = values.Previous;
                values.Previous = finger;
                values = values.Next;


            }
        }



        public bool IsEmpty()  //this method will see if the list is empty with using IsEmpty method
        {

            return head == null;

        }

        public void Clear() // this method will clear the list from the main method
        {
            head = null;

        }

        public void Print()  // this method will print out the doubly linked list in the main method
        {
            Console.WriteLine("Output");  // this message will provide where the print method is being used when you build the solution
            if (head != null)
            {
                Node<T> finger = head;



                while (finger != null) //if finger is not null print the value of the finger
                {
                    Console.WriteLine(finger.Value + " ");

                    finger = finger.Next; // then go to the next element in the list with finger
                }
            }

        }


    }

}

