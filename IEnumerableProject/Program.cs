using System.Collections;

namespace IEnumerableProject
{

    class StudyGroupEnumerator : IEnumerator
    {
        string[] students;

        int index = -2;
        bool fin = false;
        public StudyGroupEnumerator(string[] students)
        {
            this.students = students;
        }


        public object Current
        {
            get
            {
                return students[index];
            }
            
        }
        public bool MoveNext()
        {
            if (index + 1 < students.Length - 1)
            {
                index += 2;
                return true;
            }
            else
            {
                if (fin)
                    return false;
                else
                {
                    if (students.Length == 1) 
                        return false;
                    fin = true;
                    index = 1;
                    return true;
                }
            }

        }

        public void Reset()
        {
            fin = false;
            index = -2;
        }
    }
    class StudyGroup : IEnumerable
    {
        string[] names = { "Bob" };

        public IEnumerator GetEnumerator() //=> names.GetEnumerator();
        {
            return new StudyGroupEnumerator(names);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            StudyGroup studyGroup = new StudyGroup();
            foreach(var item in studyGroup)
            {
                Console.WriteLine(item);
            }
        }
    }
}