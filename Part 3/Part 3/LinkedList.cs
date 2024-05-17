using System.Collections;

namespace Part3
{
    class LinkedList
    {
        Node Head { get; set; }
        Node Current { get; set; }
        Node Max;
        Node Min;

        public LinkedList(Node head)
        {
            Head = head;
            Current = head;
            if (head == null || head.Next == null)
            {
                Max = head;
                Min = head;
            }
        }

        private bool IsNewMax(Node newLink)
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

        private bool IsNewMin(Node newLink)
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

        private void UpdateMinAndMax(Node newLink)
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

         private Node GetTailFromNode(Node currentNode)
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

         internal Node GetTail()
        {
            return GetTailFromNode(Head);
        }

        public void Append(int item)
        {
            Node tail = GetTail();
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

        public Node Pop()
        {
            Node tail = GetTail();
            if (Head == null || tail == null)
            {
                return null;
            }
            Node currentLink = Head;
            while (currentLink.Next != tail && currentLink.Next != null)
            {
                currentLink = currentLink.Next;
            }
            currentLink.Next = null;
            return tail;
        }

        public Node Unqueue()
        {
            Node firstNode = Head;
            if (Head != null)
            {
                Head = Head.Next;
            }
            return firstNode;
        }

         public IEnumerable<int> ToList()
        {
            Node current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public bool IsCircular()
        {
            Node tail = GetTail();
            if(Head == null || tail == null || tail.Next != Head)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<int> ConvertToSortedList()
        {
            List<int> numbers = [];
            Node current = Head;
            while (current != null)
            {
                numbers.Add(current.Value);
            }
            numbers.Sort();
            return numbers;
        }

        public void Sort()
        {
            List<int> sortedLinks = ConvertToSortedList();
            Node current = Head;
            foreach (int number in sortedLinks)
            {
                current.Value = number;
                current = current.Next;
            }
        }

        public Node GetMinNode()
        {
            return Min;
        }

        public Node GetMaxNode()
        {
            return Max;
        }
    }
}