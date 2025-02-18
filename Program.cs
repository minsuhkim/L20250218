using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    // 장점 : 임의 접근 (원하는 요소에 바로 접근할 수 있음)
    // 단점 : Add, Remove등을 할 때 각 요소의 계속 위치를 바꿔서 속도가 느려짐(10만개라고 생각해보면 됨)
    class DynamicArray
    {
        public DynamicArray()
        {
        }

        ~DynamicArray()
        {

        }

        //objects
        //[1][2][3]
        // ^  ^  ^  ^
        //newObjects
        //[1][2][3][][][]
        //          ^
        //objects <- newObjects 
        //[1][2][3][4][][]
        //          ^
        public void Add(Object inObject)
        {
            if (count >= objects.Length)
            {
                ExtendSpace();
            }
            objects[count] = inObject;
            count++;
        }

        //[][][][][]
        public void Remove(Object removObject)
        {
            for(int i=0; i<Count; i++)
            {
                if(removObject == objects[i])
                {
                    RemoveAt(i);
                    return;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if(index >= 0 && index < Count)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    objects[i] = objects[i + 1];
                }
                count--;
            }
        }

        public void Insert(int insertIndex, Object value)
        {
            if(count == objects.Length)
            {
                ExtendSpace();
            }
            for(int i= Count; i > insertIndex; i--)
            {
                objects[i] = objects[i - 1];
            }
            count++;
            objects[insertIndex + 1] = value;
        }

        protected void ExtendSpace()
        {
            Object[] newObject = new Object[objects.Length * 2];
            //이전값 이동
            for (int i = 0; i < objects.Length; ++i)
            {
                newObject[i] = objects[i];
            }
            objects = null;
            objects = newObject;
        }

        protected Object[] objects = new Object[3];

        protected int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
        }

        public Object this[int index]
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


    // Generic
    // 형태가 동일해져서 버그 발생이 적어짐
    

    class Program
    {
        // T가 값형식인지 아닌지 모르기 때문에 +를 할 수 없음
        //static public T Add<T>(T A, T B)
        //{
        //    return A + B;
        //}

        static void Main(string[] args)
        {
            //[] ->                  variable
            //[][][][][]             array -> Array
            //[][][][][][][][][][]   DynamicArray
            //DataStructure          자료구조
            //

            TDynamicArray<int> a = new TDynamicArray<int>();
            for (int i = 0; i < 10; ++i)
            {
                a.Add(i);
            }

            //down casting
            // >> 성능이 떨어짐
            // >> 구체적인 자료형 없이 Object로 퉁쳐서 down casting을 하게 되어 성능이 떨어지게 됨
            // >> 대신 아무 자료형 집어넣을 수 있어서 사용은 편함
            
            a[1] = 11;
            a[9] = 29;

            a.RemoveAt(9);
            a.RemoveAt(1);
            a.RemoveAt(3);
            a.Insert(2, 10);

            a.Remove(7);

            Console.WriteLine(1.Equals(1)); // >> True

            TDynamicArray<GameObject> gameobjects = new TDynamicArray<GameObject>();
            GameObject testObject = new GameObject();
            gameobjects.Add(testObject);
            gameobjects.Remove(testObject);

            Console.WriteLine(gameobjects[0].Equals(testObject));   // >> True (참조형은 가리키고 있는 것이 같은지를 판단)
            // int, float, char과 같은 값형식이 아니면 .Equals로 비교해야함! string을 ==으로 비교하면 문제 생김

            //for (int i = 0; i < a.Count; ++i)
            //{
            //    Console.Write(a[i] + ", ");
            //}
        }
    }
}