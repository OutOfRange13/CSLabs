using System;
using System.Collections.Generic;

namespace HumanProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Human woman1 = new Human("Borisova", "Natalia", "Aleksandrovna", new DateTime(1976, 1, 12), Genders.Female, Educations.University);
            Human woman2 = new Human("Borisova", "Sasha", "Aleksandrova", new DateTime(1974, 1, 12), Genders.Female, Educations.University);
            Human man = new Human("Dedow", "Kole", "Anatolievich", new DateTime(2000, 12, 1), Genders.Male, Educations.HighSchool);
            Human.SameSexMarriageEvent += (Genders gender) => Console.WriteLine("Same-sex marriage prohibited");
            Human.DivorceEvent += () => Console.WriteLine("It's a pity!");
            woman1.Marriage(woman2);
            woman1.Marriage(man);
            woman1.Divorce();

            Human.PrintMethod consoleOutput = delegate (string message) 
            {
                Console.WriteLine(message);
            };
            woman1.GetInfo(consoleOutput);
            man.GetInfo(consoleOutput);
            Console.ReadKey();

            Student businessStudent = new ITStudent("Got", "Fedu", "Dagov");
            businessStudent.Plan += () => Console.WriteLine("Business in process");
            businessStudent.DoBusiness();

            Human first = new Human("Borisova", "Natalia", "Aleksandrovna", new DateTime(1976, 1, 12), Genders.Female, Educations.University);
            ITStudent prog = new ITStudent("Dedow", "Kole", "Anatolievich", Student.Universities.BSUIR, Student.Degrees.Graduate, new DateTime(2000, 12, 1), Genders.Male, Educations.HighSchool);
            Philologist philo = new Philologist("Tutov", "Pasha", "-");
            Student stud = new ArtStudent("Fulloc", "Nasa", "-");
            Student programmerAnother = new ITStudent("Ded", "Lesha", "Anatolievich", Student.Universities.BSU, Student.Degrees.Postgraduate, new DateTime(1999, 1, 16), Genders.Male, Educations.University);
            Human justHuman = new Philologist("Goga", "Faina", "-");
            prog.SetPerformance();
            prog.PassSession();
            Console.WriteLine(prog);
            philo.SetPerformance();
            philo.PassSession();
            Console.WriteLine(philo);
            Console.WriteLine(philo.SocialSkills);
            stud.GetExpelled();
            Console.WriteLine(stud);
            Console.ReadKey();

            Human firstHuman = new Human("Abram", "Oleg");
            Human secondHuman = new Human("Aamov", "Vitta");
            Human thirdHuman = new Human("Emoloc", "Domer");
            List<Human> people = new List<Human> { firstHuman, secondHuman, thirdHuman };
            people.Sort();
            foreach(Human hum in people)
            {
                Console.WriteLine(hum);
            }

            ICreator creator = prog;
            creator.CreateMasterpiece();
            IRelax relaxing = stud;
            relaxing.DoSport();
            relaxing.HaveFun();
            Console.ReadKey();
        }
    }
}
