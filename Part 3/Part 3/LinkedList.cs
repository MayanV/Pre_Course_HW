namespace Part3
{
    class LinkedList
    {
        Node? Head { get; set; }
        Node? Max { get; set; }
        Node? Min { get; set; }

        public LinkedList(Node? head)
        {
            Head = head;
            if (head == null || head.Next == null)
            {
                Max = head;
                Min = head;
            }
        }

        private void UpdateMinAndMax(Node? newLink)
        {
            if(IsNewMax(newLink))
            {
                Max = newLink;
            }
            if(IsNewMin(newLink))
            {
                Min = newLink;
            }
        }

         private Node? GetTailFromNode(Node? currentNode)
        {
            if (currentNode == null || currentNode.Next == null)
            {
                return currentNode;
            }
            else
            {
                return GetTailFromNode(currentNode.Next);
            }
        }

         internal Node? GetTail()
        {
            return GetTailFromNode(Head);
        }

        private bool IsNewMax(Node? newLink)
        {
            if(Max != null && newLink != null && Max.Value > newLink.Value)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsNewMin(Node? newLink)
        {
            if(Min != null && newLink != null && Min.Value < newLink.Value)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Append(int item)
        {
            Node? tail = GetTail();
            Node newLink = new(item, null);
            UpdateMinAndMax(newLink);

            if(Head == null || tail == null)
            {
                Head = newLink;
            }
            else
            {
                tail.Next = newLink;
            }
        }

        public void Prepend(int item)
        {
            Node newLink = new(item, null);
            if (Head != null)
            {
                newLink.Next = Head;
            }
            Head = newLink;
        }

        public Node? Unqueue()
        {
            Node? firstNode = Head;
            if (Head != null)
            {
                Head = Head.Next;
            }
            return firstNode;
        }

        public bool IsCircular()
        {
            Node? tail = GetTail();
            if(Head == null || tail == null || tail.Next != Head)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /* Both GetMaxNode and GetMinNode are not needed since Min and Max already have getters.
           I wasn't sure if it counts so i added them anyways. */
        public Node? GetMinNode()
        {
            return Min;
        }

        public Node? GetMaxNode()
        {
            return Max;
        }
    }
}