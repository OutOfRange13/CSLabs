using System;
using System.Collections.Generic;

namespace HumanProject
{
    enum Genders
    {
        Male,
        Female
    }
    enum Educations
    {
        PrimarySchool,
        HighSchool,
        University
    }
    class Human : IComparable<Human>
    {
        public delegate void PrintMethod(string message);
        public delegate void SameSexMarriageHandler(Genders gender);
        static public event SameSexMarriageHandler SameSexMarriageEvent;
        public delegate void DivorceHandler();
        static public event DivorceHandler DivorceEvent;

        protected static int numberOfId;
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public bool IsHappy { get; protected set; }
        public int Age
        {
            get
            {
                return CalculateAge(DateOfBirth);
            }
        }
        public string Adress { get; set; }
        public Human Partner { get; private set; }
        public Educations Education { get; set; }
        public Genders Gender { get; set; }
        public Human Mother { get; private set; }
        public Human Father { get; private set; }
        public List<Human> Children = new List<Human>();
        public Human() : this("Unknown", "Unknown") { }
        public Human(string surname, string name, string middlename = "-") : this(surname, name, middlename, DateTime.Now, Genders.Male, Educations.HighSchool) { }
        public Human(string surname, string name, string middlename, DateTime dateOfBirth, Genders gender, Educations education, double weight = 0, double height = 0, string adress = null, Human mother = null, Human father = null)
        {
            Id = numberOfId++;
            Name = name;
            Surname = surname;
            Middlename = middlename;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Education = education;
            Weight = weight;
            Height = height;
            Adress = adress;
            Mother = mother;
            Father = father;
            IsHappy = true;
            Partner = null;
            if (Mother != null)
            {
                Mother.AddChild(this);
            }
            if (Father != null)
            {
                Father.AddChild(this);
            }
        }
        public string this[string propname]
        {
            get
            {
                switch (propname)
                {
                    case "FullName":
                        return Surname + " " + Name + " " + Middlename;
                    case "DateOfBirth":
                        return DateOfBirth.ToString("dd.MM.yyyy");
                    case "Education":
                        return Education.ToString();
                    case "Gender":
                        return Gender.ToString();
                    default:
                        return null;
                }
            }
            set
            {
                switch (propname)
                {
                    case "Name":
                        Name = value;
                        break;
                    case "Surname":
                        Surname = value;
                        break;
                    case "MiddleName":
                        Middlename = value;
                        break;
                    case "Adress":
                        Adress = value;
                        break;
                    default:
                        break;
                }
            }
        }
        public void AddChild(Human child)
        {
            if (child == null)
            {
                throw new ArgumentException("child doesn't exist\n");
            }
            Children.Add(child);   
        }
        public bool Marriage(Human another)
        {
            if (Gender == another.Gender)
            {
                SameSexMarriageEvent?.Invoke(Gender);
                return false;
            }
            Partner = another;
            another.Partner = this;
            return true;
        }

        public void Divorce()
        {
            if (Partner == null)
            {
                throw new ArgumentException("You have no partner");
            }
            Partner.Partner = null;
            Partner = null;
            DivorceEvent?.Invoke();
        }

        public void RemoveChild(Human child)
        {
            if (child == null)
            {
                throw new ArgumentException("child doesn't exist\n");
            }
            Children.Remove(child);
        }
        public void SetParent(Human parent)
        {
            if (parent != null)
            {
                if (parent.Gender == Genders.Male)
                {
                    Father = parent;
                }
                else
                {
                    Mother = parent;
                }
                parent.AddChild(this);
            }
        }
        public double IndexOfBody()
        {
            if (Height > 0)
            {
                return Weight / (Height * Height);
            }
            else
            {
                return 0;
            }
        }
        protected int CalculateAge(DateTime dateOfBirth)
        {
            DateTime nowDate = DateTime.Now;
            int age = nowDate.Year - dateOfBirth.Year;
            if (nowDate.Month < dateOfBirth.Month || (nowDate.Month == dateOfBirth.Month && nowDate.Day < dateOfBirth.Day))
            {
                age--;
            }
            return age;
        }
        public void ChangeGender()
        {
            if (Gender == Genders.Male)
            {
                Gender = Genders.Female;
            }
            else
            {
                Gender = Genders.Male;
            }
        }
        public void ChangeGender(Genders gender)
        {
            Gender = gender;
        }
        public bool LegalAge()
        {
            return Age >= 18;
        }
        public override string ToString()
        {
            string result = Id.ToString() + ". Full Name: " + this["FullName"] + '\n';
            int age = CalculateAge(DateOfBirth);
            result += "Date of birth: " + this["DateOfBirth"] + " Age: " + age.ToString() + '\n' + "Gender: " + this["Gender"] + '\n' + "Education: " + this["Education"] + '\n' + "Weight(kilos) " + Weight.ToString() + " height(meters): " + Height.ToString() + '\n';
            if (Mother != null)
            {
                result += "Mother " + Mother.Name + '\n';
            }
            if (Father != null)
            {
                result += "Father " + Father.Name + '\n';
            }
            if (Children.Count > 0)
            {
                result += "Children amount: " + Children.Count + '\n' + "Children names: ";
                for (int i = 0; i < Children.Count; i++)
                {
                    result += Children[i].Name + " ";
                }
                result += '\n';
            }
            result += "Adress: " + Adress + '\n';
            return result;
        }
        public int CompareTo(Human other)
        {
            return String.Compare(Surname, other.Surname);
        }
        virtual public void GetInfo(PrintMethod printMethod)
        {
            try
            {
                printMethod.Invoke(ToString());
            }
            catch
            {
                Console.WriteLine("Your PrintMethos is not valid");
            }
        }

    }
}
