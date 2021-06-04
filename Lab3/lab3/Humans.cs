using System;
using System.Collections.Generic;

namespace HumanProject
{
    class Humans
    {
        public int NumberOfHumans { get; private set; }
        private List<Human> humanList;
        public Humans()
        {
            NumberOfHumans = 0;
            humanList = new List<Human>();
        }
        public void AddHuman(Human name)
        {
            humanList.Add(name);
            NumberOfHumans++;
        }
        public void RemoveHuman(Human name)
        {
            humanList.Remove(name);
            NumberOfHumans--;
        }
        public Human this[int index]
        {
            get
            {
                if (index < 0 && index >= humanList.Count)
                {
                    throw new Exception("There is no person with such index\n");
                }
                return humanList[index];
            }
            set
            {
                humanList[index] = value;
            }
        }
    }
}
