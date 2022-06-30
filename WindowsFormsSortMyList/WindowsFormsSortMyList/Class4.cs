using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsSortMyList
{
    class Node<T> where T : IComparable<T>  // это объект, который содержит в себе информацию о элементе
    {
        private T element; // ссылка на значение элемента списка
        private Node<T> next; //создание поля next класса Node
        private Node<T> previous; //создание поля previous класса List
        public T Element // это поле, которое предоставляет значение элемента по ссылке
        {
            get { return this.element; }
            set { this.element = value; }
        }

        public Node<T> Next
        {
            get { return this.next; }
        }

        public Node<T> Previous
        {
            get { return this.previous; }
        }
        public void SetNextNode(Node<T> _nextNode) //задаем ссылку на следующий элемент
        { this.next = _nextNode; }

        public void SetPreviousNode(Node<T> _previousNode) //задаем ссылку на предыдущий элемент
        { this.previous = _previousNode; }


        // переопределили операторы сравнения 
        public static bool operator >(Node<T> n1, Node<T> n2)
        {
           
            if (n1.element.CompareTo(n2.element) > 0)
                
                return true;
            else
                return false;
        }
        public static bool operator <(Node<T> n1, Node<T> n2)
        {
          
            if (n1.element.CompareTo(n2.element) < 0)
           
                return true;
            else
                return false;
        }
        public static bool operator <=(Node<T> n1, Node<T> n2)
        {
            int compare=n1.element.CompareTo(n2.element);
       
            if (compare <= 0)
                return true;
            else
                return false;
        }
        public static bool operator >=(Node<T> n1, Node<T> n2)
        {
            int compare = n1.element.CompareTo(n2.element);
          
            if (compare >= 0)
                return true;
            else
                return false;
        }


    
        
    }
    



    class Utilities<T> where T : IComparable<T> // класс, в котором создаётся рандомный список и копируется список
    {


        public static vector<int> RandomInt(int size) // создание случайного списка типа int
        {
            var vec = new vector<int>(); // выделение памяти на объект класса vector неявного типа 
            var rnd = new Random();
            
            for (int i = 0; i < size; i++)
            {
                vec.Push(rnd.Next(-50, 50));
               
            }
           
            return vec;
        }

        public static vector<double> RandomDouble(int size) // создание случайного списка типа double
        {
            var vec = new vector<double>();
            var rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                vec.Push(rnd.NextDouble() * rnd.Next(-50, 50));
            }
            return vec;
        }

        public static vector<string> RandomString(int size)   // создание случайного списка типа  string
        {
            var vec = new vector<string>();
            var rnd = new Random();
            string tstr = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < rnd.Next(1, 4); j++)
                {
                    tstr += (char)rnd.Next(65, 91);
                }
                vec.Push(tstr);
                tstr = "";
            }
            return vec;
        }
                    
        public static vector<T> Copy(vector<T> vec) // метод, который копирует список и передаёт его в другой список
        {
            vector<T> vec1 = new vector<T>();
            for (int i = 0; i < vec.Length; i++)
                vec1.Push(vec[i].Element);
           
            return vec1;
        }

        public static vector<T> SortVar(vector<T> vec, sortAbstract<T> sort) //это внешний метод, в котором применяется абстрактный метод Sort
        {

            vector<T> vecsorted = new vector<T>();
            vecsorted = sort.Sorting(vec);
            return vecsorted;
        }


    }



    class vector<T> where T : IComparable<T>
    {
        public Node<T> headNode; //поле класса vector, головной элемент списка
        public Node<T> tailNode; //поле класса vector, хвостовой элемент списка

        public Node<T> Cur; //поле класса vecotor, текущий элемент списка
        public int Ncur; //место текущего элемента в списке

        public int Length; 
        public vector() //конструктор
        {
            this.headNode = null;
            this.tailNode = this.headNode;
            this.Length = 0;
            this.Cur = null;   
        }
        public Node<T> this[int _position] //индексатор списка
        {   
            get //чтение

            {

                Node<T> tempNode = new Node<T>(); //выделение памяти под текущий элемен
                tempNode.Element = default(T);

                if (_position < this.Length) //Если индекс меньше размера списка

                {

                    if (Math.Abs(Ncur - _position) < Math.Abs(this.Length / 2 - _position) || Math.Abs(Ncur - _position) < Math.Abs(this.Length / 2 + 1 - _position))

                    {
                        if (Cur == null)
                        {
                            Cur = headNode;
                        }
                        tempNode = Cur;

                        if ((_position - Ncur) < 0)

                        {

                            for (int i = Ncur; i > _position + 1; --i) tempNode = tempNode.Previous; //Ссылаюсь на предыдущий элемент

                        }

                        if ((_position - Ncur) > 0)

                        {

                            for (int i = Ncur; i < _position; ++i)
                            

                             
                                tempNode = tempNode.Next; //Ссылаюсь на следующий элемент
                            

                        }

                    }

                    if (_position <= this.Length / 2)

                    {

                        tempNode = headNode;

                        for (int i = 0; i < _position; ++i) tempNode = tempNode.Next; //Ссылаюсь на следующий элемент

                    }

                    if (_position > this.Length / 2)

                    {

                        tempNode = tailNode;

                        for (int i = this.Length; i > _position + 1; --i) tempNode = tempNode.Previous; //Ссылаюсь на предыдущий элемент

                    }

                    Cur = tempNode;

                    Ncur = _position;

                }

                return tempNode;

            }

            


        }
        public void Push(T _element) // метод добавления элемента в конец списка
        {
            if (headNode == null) // если нет ни одного элемента
            {
                this.headNode = new Node<T>();
                this.headNode.Element = _element;
                this.tailNode = this.headNode;
                this.headNode.SetNextNode(null);
                this.headNode.SetPreviousNode(null);
            }
            else
            {
                Node<T> newNode = new Node<T>();
                this.tailNode.SetNextNode(newNode);
                newNode.SetPreviousNode(this.tailNode);
                this.tailNode = newNode;
                this.tailNode.Element = _element;
                this.tailNode.SetNextNode(null);
            }
            ++this.Length;


        }


      
       
        public void swap(int pos1, int pos2) // метод меняющий два элемента местами по индексу
        {
            Node<T> tempNode = new Node<T>();
          
            tempNode.Element = this[pos1].Element;
            this[pos1].Element = this[pos2].Element;
            this[pos2].Element = tempNode.Element;
        }
        public void clear() //очистка списка
        {
            this.headNode = null;
            this.tailNode = this.headNode;
            this.Length = 0;
        }
        public string vecToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Length; i++)
                sb.Append(this[i].Element + " ");
            return sb.ToString();
        }
    }


    abstract class sortAbstract<T> where T : IComparable<T> // абстрактный класс сортировки
    {
        public abstract vector<T> Sorting(vector<T> unsorted);

    }

    class sortingQuick<T> : sortAbstract<T> where T : IComparable<T> // быстрая сортировка без рекурсии 
    {
        public int comparison, shift; // переменные для подсчёта сравнений и перестановок




        public override vector<T> Sorting(vector<T> input)
            {
            var stack = new Stack<int>();
            comparison = 0;
            shift = 0;

            Node<T> pivot;
            int pivotIndex = 0;

            int leftIndex = pivotIndex + 1;
            int rightIndex = input.Length - 1;

            stack.Push(pivotIndex);
            stack.Push(rightIndex);

            int leftIndexOfSubSet, rightIndexOfSubset;


            while (stack.Count > 0)
                {
                    rightIndexOfSubset = stack.Pop();//pop always with right and left
                    leftIndexOfSubSet = stack.Pop();

                    leftIndex = leftIndexOfSubSet + 1;
                    pivotIndex = leftIndexOfSubSet;
                    rightIndex = rightIndexOfSubset;

                    pivot = input[pivotIndex];

                    if (leftIndex > rightIndex)
                        continue;

                    while (leftIndex < rightIndex)
                    {
                    while ((leftIndex <= rightIndex) && (input[leftIndex] <= pivot))
                    {
                        
                        leftIndex++;    //increment right to find the greater 
                                        //element than the pivot
                    }
                    while ((leftIndex <= rightIndex) && (input[rightIndex] >= pivot))
                    {
                     
                        rightIndex--;//decrement right to find the 
                                     //smaller element than the pivot
                    }
                    comparison++;
                    if (rightIndex >= leftIndex)
                        {   //if right index is 
                            //greater then only swap

                        
                        input.swap(leftIndex, rightIndex);
                        shift++;

                        }
                    }
                
                     if (pivotIndex <= rightIndex)
                    {
                    comparison++;
                    if (input[pivotIndex] > input[rightIndex])
                            {
                        
                        input.swap(pivotIndex, rightIndex);
                                shift++;
                            }
                        }
                    
                if (leftIndexOfSubSet < rightIndex)
                    {
                        stack.Push(leftIndexOfSubSet);
                        stack.Push(rightIndex - 1);
                    }

                    if (rightIndexOfSubset > rightIndex)
                    {
                        stack.Push(rightIndex + 1);
                        stack.Push(rightIndexOfSubset);
                    }
                }
                return input;
            }
        }

    

    class sortingMerge<T> : sortAbstract<T> where T : IComparable<T>
    {
        public int k = 0;
        public int comparison = 0, shift = 0;
      
        public override vector<T> Sorting(vector<T> list)
        {

            comparison = 0;
            shift = 0;
            vector<T> left = new vector<T>();
            vector<T> right = new vector<T>();
            if (list.Length == 1)
            {
                return list;
            }
            int mid = list.Length / 2;

            left.Length = mid;
            left.headNode = list.headNode;
            left.tailNode = list[mid - 1];

            right.Length = list.Length - mid;
            right.headNode = list[mid];
            right.tailNode = list.tailNode;

            return Merge(Sorting(left), Sorting(right));

        }
        public vector<T> Merge(vector<T> left, vector<T> right)
        {
           
            int length = left.Length + right.Length;
            int leftPoint = 0;
            int rightPoint = 0;

            vector<T> result = new vector<T>();

            for (int i = 0; i < length; i++)
            {
                if (leftPoint < left.Length && rightPoint < right.Length)
                {
                    comparison++;
                    if (left[leftPoint] < right[rightPoint])
                    {
                        
                        result.Push(left[leftPoint].Element);
                        leftPoint++;
                    }
                    else
                    {
                        shift++;
                        result.Push(right[rightPoint].Element);
                        rightPoint++;

                    }

                }
                else
                {
                    if (rightPoint < right.Length)
                    {

                        result.Push(right[rightPoint].Element);
                        rightPoint++;
                    }
                    else
                    {

                        result.Push(left[leftPoint].Element);
                        leftPoint++;
                    }
                }
            }
            return result;
        }

    }
}


