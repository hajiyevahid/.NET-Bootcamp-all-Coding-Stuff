using System;

namespace CSharp.Activity.Datastore
{
    public class ArrayStore<T> : AbstractArrayStore<T>
    {
        // declaration of constructors:
        public ArrayStore(int arraySize) : base(arraySize)
        {

        }
        public ArrayStore() : base(DEFAULT_SIZE)
        {

        }

        public override int Add(T argToAdd)
        {
            if (IsFull())
            {
                return NOT_IN_STRUCTURE;
            }

            if (argToAdd == null)
            {
                throw new ArgumentNullException("Adding null object is not allowed!");
            }
            base[Count] = argToAdd;
            Count++;

            return Count - 1;
        }

        public override int Insert(T argToInsert, int indexToInsert)
        {

            if (argToInsert == null)
            {
                throw new ArgumentNullException("It is not allowed to add null object to the structure !");
            }

            if (indexToInsert < 0 || indexToInsert >= Capacity)
            {
                throw new ArgumentOutOfRangeException("Please provide a correct index !");
            }
            if (!IsFull())
            {
                for (int i = Count; i > indexToInsert; i--)
                {
                    base[i] = base[i - 1];

                }
                base[indexToInsert] = argToInsert;
                Count++;

                return indexToInsert;
            }

            return NOT_IN_STRUCTURE;
        }

        public override void Remove(T argToRemove)
        {
            if (argToRemove == null)
            {
                throw new ArgumentNullException("Removing is not possible!");
            }

            if (!Contains(argToRemove))
            {
                throw new InvalidOperationException("Structure does not contain the supplied object to remove!");
            }
            //RemoveAt method will automatically
            //ensure that there is no any hole in
            //the structure by rearranging them
            RemoveAt(IndexOf(argToRemove));
        }

        public override void RemoveAt(int removeObjectIndex)
        {
            if (removeObjectIndex < 0 || removeObjectIndex >= Count)
            {
                throw new ArgumentOutOfRangeException("Removing is not possible!");
            }

            for (int i = removeObjectIndex; i < Count - 1; i++)
            {
                base[i] = base[i + 1];
            }
            Count--;
        }
    }
}