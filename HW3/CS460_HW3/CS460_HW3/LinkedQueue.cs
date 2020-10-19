using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS460_HW3
{
    public class LinkedQueue<T> : IQueueInterface<T>
    {
        private Node<T> front;
        private Node<T> rear;
        
        public LinkedQueue()
        {
            front = null;
            rear = null;
        }

        //Add a node to queue
        public T Push(T element)
        {
            if (element == null)
            {
                throw new NullReferenceException(); // equivalent to java NullPointerException
            }

            if (IsEmpty())
            {
                Node<T> tempNode = new Node<T>(element, null);
                front = rear = tempNode;
            }
            else
            {
                Node<T> tempNode = new Node<T>(element, null);
                rear.next = tempNode;
                rear = tempNode;
            }

            return element;
        }

        //Take a node out of queue
        public T Pop()
        {
            T tempNode;

            if(IsEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when pop was invoked.");
            }
            else if (front == rear)
            {   //One item in queue
                tempNode = front.data;
                front = null;
                rear = null;
            }
            else
            {   //General case
                tempNode = front.data;
                front = front.next;
            }

            return tempNode;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when peek was invoked.");
            }

            return front.data;
        }

        //Queue is empty
        public bool IsEmpty()
        {
            if (front == null && rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
