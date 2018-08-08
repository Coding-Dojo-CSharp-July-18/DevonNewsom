namespace DoingDataStructures
{
    public class Node
    {
        public int Value {get;set;}
        public Node Next {get;set;}
        public Node(int val)
        {
            Value = val;
        }
    }
    public class SLL
    {
        public Node Head {get;set;}
        private bool isEmpty
        {
            get { return Head == null; }
        }
        public void AddToFront(int value)
        {
            Node newNode = new Node(value);

            newNode.Next = Head;
            Head = newNode;

        }
        public void AddToBack(int value)
        {
            Node newNode = new Node(value);

            if(isEmpty)
            {
                Head = newNode;
                return;
            }
            // traverse list
            Node current = Head;
            while(current.Next != null)
                current = current.Next;

            // add when null is found
            current.Next = newNode;
        }
        public int Size
        {
            get
            {
                Node current = Head;
                int counter = 0;
                
                // code goes here!
                
                return counter;
            }
        }
        public bool AddAtPosition(int value, int pos)
        {
            return true;
        }
    }
}