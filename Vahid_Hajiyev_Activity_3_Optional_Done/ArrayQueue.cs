using System;
namespace CSharp.Activity.Datastore
{
    /// <summary>
    /// Summary description for ArrayQueue.
    /// </summary>
    public class ArrayQueue<T> : ArrayBase<T>
    {
        // The following instance variables are accessible to all methods inside this class. You are not allowed to declare additional class members.
        // The indices of the first and last objects in the queue:
        private int first;
        private int last;

        // HINT: In addition to the above variables,
        // the indexer this[] (represents the queue)
        // and the Count (represents the number of objects inside the queue)
        // can be used also in this class because of inheritance.

        // HINT: Also the methods IsFull() and Contains() from ArrayBase<T>
        // can be used in this class because of inheritance.

        /// <summary>
        ///     Default constructor. Calls the base constructor.
        /// </summary>
        public ArrayQueue()
        {
            //No Logic
        }

        /// <summary>
        ///     Constructor to initialize the data structure to the specified size.
        ///     Call the overloaded base class constructor and pass the size of the array.
        /// </summary>
        /// <param name="size">The maximum length of the array.</param>
        /// 
        public ArrayQueue(int size) : base(size)
        {
            //No logic
        }

        /// <summary>
        ///     Method to accept an object and add to the end of the queue.
        /// </summary>
        /// <param name="next">object to enqueue</param>
        /// <returns></returns>

        public virtual bool Enqueue(T next)
        {
            //start solution
            if (next == null)
            {
                throw new ArgumentNullException("It is not possible to add null item to the queue !");
            }

            if (IsFull())
            {
                return false;
            }

            this[last] = next;
            last++;
            Count++;

            return true;
        }

        /// <summary>
        ///     Method to remove the object from the queue.
        /// </summary>
        /// <returns></returns>

        public virtual T Dequeue()
        {
            //start solution
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty !");
            }
            var firstElement = this[0];

            for (int i = 0; i < Count - 1; i++)     ////***********count-1** i yoxla
            {
                this[i] = this[i + 1];
            }
            last--;
            Count--;

            return firstElement; // in the final solution this statement should be deleted or modified
        }

        /// <summary>
        ///     Method to check an object at the beginning of the queue.
        /// </summary>
        /// <returns></returns>
        public T CheckNext()
            => base[0];

        /// <summary>
        ///     Method to check whether there is any other object in the queue.
        /// </summary>
        /// <returns></returns>
        public bool HasNext()
            => (base.Count != 0);


        /// <summary>
        ///     Method to accept an object and find whether the object exists in the array structure.
        /// </summary>
        /// <param name="arg">object</param>
        /// <returns></returns>

        public override int IndexOf(T arg)
        {
            //start solution
            if (arg == null)
            {
                throw new ArgumentNullException("Invalid operation !");
            }

            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(arg) && this[i] != null)
                {
                    return i;
                }
            }

            return NOT_IN_STRUCTURE;
        }


        /// <summary>
        ///     Method to accept the index of for and array object and return the corresponding object.
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>the object for the specified index</returns>

        public T Check(int index)
        {

            //start solution

            for (int i = 0; i < Count; i++)
            {
                if (i.Equals(index))
                {
                    return this[i];
                }
            }

            throw new IndexOutOfRangeException("Please provide valid index for checking !");
        }
    }
}