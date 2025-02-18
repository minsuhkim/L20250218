using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    // Generic Class
    // Boxing/Unboxing(Down Casting)으로 인한 성능 감소를 방지하기 위해 사용
    class TDynamicArray<T>
    {
        public TDynamicArray()
        {

        }

        ~TDynamicArray()
        {

        }
        public void Add(T inObject)
        {
            if (count >= objects.Length)
            {
                ExtendSpace();
            }
            objects[count] = inObject;
            count++;
        }

        public void Remove(T removObject)
        {
            for (int i = 0; i < Count; i++)
            {
                if (removObject.Equals(objects[i]))
                {
                    RemoveAt(i);
                    return;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    objects[i] = objects[i + 1];
                }
                count--;
            }
        }

        public void Insert(int insertIndex, T value)
        {
            if (count == objects.Length)
            {
                ExtendSpace();
            }
            for (int i = Count; i > insertIndex; i--)
            {
                objects[i] = objects[i - 1];
            }
            count++;
            objects[insertIndex + 1] = value;
        }

        protected void ExtendSpace()
        {
            T[] newObject = new T[objects.Length * 2];
            
            for (int i = 0; i < objects.Length; ++i)
            {
                newObject[i] = objects[i];
            }
            objects = null;
            objects = newObject;
        }

        protected T[] objects = new T[3];

        protected int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
        }

        public T this[int index]
        {
            get
            {
                return objects[index];
            }
            set
            {
                if (index < objects.Length)
                {
                    objects[index] = value;
                }
            }
        }
    }
}
