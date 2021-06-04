using System;
using System.Collections.Generic;

namespace HumanProject
{
    abstract class Student : Human, IComparable<Student>, IRelax
    {
        public Student(string surname, string name, string middlename, Universities university, Degrees degree):base(surname, name, middlename)
        {
            University = university;
            Degree = degree;
        }
        public Student() : base()
        {
            University = Universities.None;
            Degree = Degrees.Graduate;
        }
        public Student(string surname, string name, string middlename, Universities university, Degrees degree, DateTime dateOfBirth, Genders gender, Educations education):base(surname, name, middlename, dateOfBirth, gender, education)
        {
            University = university;
            Degree = degree;
            while (Age < 17 || Age > 80)
            {
                Console.WriteLine("Person with such age can't be a student. Try again");
                Console.WriteLine("Enter year");
                string data = Console.ReadLine();
                int year, month, date;
                int.TryParse(data, out year);
                Console.WriteLine("Enter month");
                data = Console.ReadLine();
                int.TryParse(data, out month);
                Console.WriteLine("Enter day");
                data = Console.ReadLine();
                int.TryParse(data, out date);
                if (year > 0 && month>0 || month<13 && date > 0 && date < 32)
                {
                    DateOfBirth = new DateTime(year, month, date);
                }
            }
        }
        public enum Universities
        {
            None,
            BSUIR,
            BSU,
            BNTU,
            BSEU,
            BSPU,
            BSMU,
            BSTU
        }
        public Universities University { get; set; }
        public enum Degrees
        {
            Undergraduate,
            Graduate,
            Postgraduate
        }
        public Degrees Degree { get; set; }
        public enum PerformanceList
        {
            Unsatisfactory, //0-3
            Satisfactory,   //4-6
            Good,           //7-8
            Excellent       //9-10
        }
        public PerformanceList Performance { get; private set; }
        public enum GrantsList
        {
            None = 0,
            Low = 87,
            Medium = 96,
            High = 112,
            Elevated = 136
        }
        public GrantsList Grants { get; set; }
        public void UpdateGrants()
        {
            switch (Performance)
            {
                case PerformanceList.Unsatisfactory:
                    Grants = GrantsList.Low;
                    break;
                case PerformanceList.Satisfactory:
                    Grants = GrantsList.Medium;
                    break;
                case PerformanceList.Good:
                    Grants = GrantsList.High;
                    break;
                case PerformanceList.Excellent:
                    Grants = GrantsList.Elevated;
                    break;
                default:
                    Grants = GrantsList.None;
                    break;
            }
        }
        public void SetPerformance()
        {
            int marks = 0;
            for (int marksAmount = 0; marksAmount < 10; marksAmount++)
            {
                int mark = Study();
                marks += mark;
            }
            marks /= 10;
            if (marks >= 9)
            {
                Performance = PerformanceList.Excellent;
            } 
            else if (marks >= 7)
            {
                Performance = PerformanceList.Good;
            }
            else if (marks >= 4)
            {
                Performance = PerformanceList.Satisfactory;
            }
            else
            {
                Performance = PerformanceList.Unsatisfactory;
            }
        }
        public void Retake()
        {
            NumberOfRetakes++;
            if (NumberOfRetakes > 3)
            {
                GetExpelled();
                IsHappy = false;
            }
            else
            {
                PassSession();
                IsHappy = true;
            }
        }
        public void GetExpelled()
        {
            IsExpelled = true;
            IsHappy = false;
            University = Universities.None;
            SeccionMarks.Clear();
        }
        public List<int> SeccionMarks { get; protected set; }
        abstract public int Study(); 
        abstract public void PassSession();
        abstract public bool WriteDiploma();
        virtual public void WorkHard()
        {
            NumberOfRetakes = 0;
            Grants = GrantsList.High;
        }
        public double AveragePoint { get; private set; }
        public void CalculateAverageMarks()
        {
            if (SeccionMarks.Count == 0)
            {
                throw new Exception("Student has no marks");
            }
            double sum = 0;
            for (int i = 0; i < SeccionMarks.Count; i++)
            {
                sum += SeccionMarks[i];
            }
            AveragePoint = sum / SeccionMarks.Count;
        }
        public bool IsExpelled { get; protected set; }
        public int NumberOfRetakes { get; private set; }
        public void ChangeUniversity(Universities university)
        {
            University = university;
            SeccionMarks.Clear();
        }
        public override string ToString() => base.ToString() + $"University: {University}\nDegree: {Degree}\nAverage point: {AveragePoint}\nPerformance: {Performance}";
        public int CompareTo(Student other)
        {
            if (AveragePoint > other.AveragePoint)
                return 1;
            else if (AveragePoint < other.AveragePoint)
                return -1;
            else
                return 0;
        }
        public void DoSport()
        {
            IsHappy = true;
            WorkHard();
            Console.WriteLine(this.Name + " is running");
        }
        public void Read()
        {
            Study();
            Console.WriteLine(this.Name + " is reading");
        }
        public void HaveFun()
        {
            IsHappy = true;
            Console.WriteLine(this.Name + " is happy right now");
        }
        override public void GetInfo(PrintMethod printMethod)
        {
            printMethod(ToString());
        }
        public delegate void Business();
        public event Business Plan;
        public void DoBusiness()
        {
            Console.WriteLine($"{Name} try to do business...");
            Plan?.Invoke();
            Grants = GrantsList.Elevated;
            WorkHard();
        }
    }
}
