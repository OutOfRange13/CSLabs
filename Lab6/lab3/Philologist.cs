using System;
using System.Collections.Generic;

namespace HumanProject
{
    class Philologist:Student
    {
        public Philologist() : this("Unknown", "Unknown", "Unknown") { }
        public Philologist(string surname, string name, string middlename, Universities university, Degrees degree, DateTime dateOfBirth, Genders gender = Genders.Male, Educations education = Educations.HighSchool) : base(surname, name, middlename, university, degree, dateOfBirth, gender, education)
        {
            Marks = new Subjects();
            SeccionMarks = new List<int>();
            SocialSkills = 0;
        }
        public Philologist(string surname, string name, string middlename) : base(surname, name, middlename, Universities.BSPU, Degrees.Graduate)
        {
            Marks = new Subjects();
            SeccionMarks = new List<int>();
            SocialSkills = 0;
        }
        private struct Subjects
        {
            public int English, Philosophy, Literature;
        }
        Subjects Marks;
        public int SocialSkills { get; set; }
        public override void PassSession()
        {
            Random rand = new Random();
            switch (Performance)
            {
                case PerformanceList.Excellent:
                    {
                        Marks.Philosophy = rand.Next(9, 10);
                        Marks.Literature = rand.Next(9, 10);
                        Marks.English = rand.Next(9, 10);
                        break;
                    }
                case PerformanceList.Good:
                    {
                        Marks.Philosophy = rand.Next(7, 9);
                        Marks.Literature = rand.Next(7, 9);
                        Marks.English = rand.Next(7, 9);
                        break;
                    }
                case PerformanceList.Satisfactory:
                    {
                        Marks.Philosophy = rand.Next(4, 7);
                        Marks.Literature = rand.Next(4, 7);
                        Marks.English = rand.Next(4, 7);
                        break;
                    }
                case PerformanceList.Unsatisfactory:
                    {
                        Marks.Philosophy = rand.Next(0, 5);
                        Marks.Literature = rand.Next(0, 5);
                        Marks.English = rand.Next(0, 5);
                        break;
                    }
                default:
                    {
                        GetExpelled();
                        break;
                    }
            }
            if (Marks.Literature < 4 || Marks.Philosophy < 4 || Marks.English < 4)
            {
                if (AttemptToLearn() == false)
                {
                    Retake();
                }
            }
            else
            {
                SeccionMarks.Add(Marks.Philosophy);
                SeccionMarks.Add(Marks.Literature);
                SeccionMarks.Add(Marks.English);
                CalculateAverageMarks();
                UpdateGrants();
            }
        }
        private bool AttemptToLearn()
        {
            int mark = Study();
            if (mark>6 && SocialSkills > 10)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public override void WorkHard()
        {
            SocialSkills += 5;
            Console.WriteLine(Name + " write an essay");
        }
        public override int Study()
        {
            int mark;
            Random rand = new Random();
            if (Gender == Genders.Female)
            {
                mark = rand.Next(5, 11);
            }
            else
            {
                mark = rand.Next(0, 11);
            }
            if (mark > 7)
            {
                SocialSkills+=2;
            } else
            {
                SocialSkills++;
            }
            return mark;
        }
        
        public override bool WriteDiploma()
        {
            if (SocialSkills > 15 && Performance == PerformanceList.Satisfactory)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        override public string ToString() => base.ToString() + $"Specialization: Philologist\nDiploma: {WriteDiploma()}\nGrant: {Grants}";
    }
}
