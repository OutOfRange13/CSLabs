using System;
using System.Collections.Generic;

namespace HumanProject
{
    class ITStudent : Student, ICreator
    {
        public ITStudent() : this("Unknown", "Unknown", "Unknown") { }
        public ITStudent(string surname, string name, string middlename, Universities university, Degrees degree, DateTime dateOfBirth, Genders gender = Genders.Male, Educations education = Educations.HighSchool) : base(surname, name, middlename, university, degree, dateOfBirth, gender, education)
        {
            Marks = new Subjects();
            SeccionMarks = new List<int>();
            ProgrammingLanguges = 0;
        }
        public ITStudent(string surname, string name, string middlename) : base(surname, name, middlename, Universities.BSUIR, Degrees.Graduate)
        {
            Marks = new Subjects();
            SeccionMarks = new List<int>();
            ProgrammingLanguges = 0;
        }
        public int ProgrammingLevel { get; set; }
        private struct Subjects
        {
            public int Mathematics, Programming, English;
        }
        Subjects Marks;
        public int ProgrammingLanguges { get; set; }
        public override void PassSession()
        {
            Random rand = new Random();
            switch (Performance)
            {
                case PerformanceList.Excellent:
                    {
                        Marks.Mathematics = rand.Next(9, 10);
                        Marks.Programming = rand.Next(9, 10);
                        Marks.English = rand.Next(9, 10);
                        break;
                    }
                case PerformanceList.Good:
                    {
                        Marks.Mathematics = rand.Next(7, 9);
                        Marks.Programming = rand.Next(7, 9);
                        Marks.English = rand.Next(7, 9);
                        break;
                    }
                case PerformanceList.Satisfactory:
                    {
                        Marks.Mathematics = rand.Next(4, 7);
                        Marks.Programming = rand.Next(4, 7);
                        Marks.English = rand.Next(4, 7);
                        break;
                    }
                case PerformanceList.Unsatisfactory:
                    {
                        Marks.Mathematics = rand.Next(0, 5);
                        Marks.Programming = rand.Next(0, 5);
                        Marks.English = rand.Next(0, 5);
                        break;
                    }
                default:
                    {
                        GetExpelled();
                        break;
                    }
            }
            if (Marks.Mathematics < 4 || Marks.Programming < 4 || Marks.English < 4) 
            {
                Retake(); 
            }
            else
            {
                SeccionMarks.Add(Marks.Mathematics);
                SeccionMarks.Add(Marks.Programming);
                SeccionMarks.Add(Marks.English);
                CalculateAverageMarks();
                UpdateGrants();
            }
        }
        public override int Study()
        {
            int mark;
            Random rand = new Random();
            if (Education == Educations.University)
            {
                mark = rand.Next(8, 11);
            } else
            {
                mark = rand.Next(0, 11);
            }
            if (mark > 5)
            {
                ProgrammingLevel++;
            }
            return mark;
        }
        public void LearnProgrammingLanguage()
        {
            if (ProgrammingLevel > 50)
            {
                ProgrammingLanguges++;
                ProgrammingLevel = 0;
            }
        }
        public override bool WriteDiploma()
        {
            if (ProgrammingLanguges>3 && Performance == PerformanceList.Good)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public override void WorkHard()
        {
            ProgrammingLevel += 5;
            LearnProgrammingLanguage();
            Console.WriteLine("Learning to programming");
        }
        override public string ToString() => base.ToString()+ $"Specialization: Programmer\nDiploma: {WriteDiploma()}\nGrant: {Grants}";
        private readonly List<string> masterpieces = new List<string>()
        {
            "Linux", "Instagram", "Web page", "Java project", "compiler for C#", "Facebook", "C++",
            "BitTorrent protocol", "JavaScript project", "New game"
        };
        public string CreateMasterpiece()
        {
            Random rand = new Random();
            int number = rand.Next(0, masterpieces.Count);
            Console.WriteLine(this.Name + " create a masterpiece called " + masterpieces[number]);
            if (rand.Next(0, 2) == 1)
            {
                Success();
            }
            else
            {
                Fiasco();
            }
            return masterpieces[number];
        }
        public void Fiasco()
        {
            IsHappy = false;
            Console.WriteLine(this.Name + " masterpiece is awful. Program doesn't work properly");
        }
        public void Success()
        {
            IsHappy = true;
            Console.WriteLine(this.Name + " masterpiece is wonderful. Program works properly");
        }
    }
}
