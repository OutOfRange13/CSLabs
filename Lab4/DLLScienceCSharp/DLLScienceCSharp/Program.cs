using System;
using System.Runtime.InteropServices;

namespace DLLScience
{
    class Program
    {
        [DllImport("ScienceDll.dll", CallingConvention = CallingConvention.StdCall)]
        static extern double Mass(double amountOfSubstance, double molekularMassSubstance);
        [DllImport("ScienceDll.dll", CallingConvention = CallingConvention.StdCall)]
        static extern double Volume(double amountOfSubstance);
        [DllImport("ScienceDll.dll", CallingConvention = CallingConvention.StdCall)]
        static extern double NumberOfParticle(double mass, double massParticle);
        [DllImport("ScienceDll.dll", CallingConvention = CallingConvention.StdCall)]
        static extern double AmountOfSubstance(double mass, double molekularMassSubstance);
        [DllImport("ScienceDll.dll", CallingConvention = CallingConvention.StdCall)]
        static extern double MassOfSubstance(double massOfFluid, int procents);
        [DllImport("ScienceDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Density(double mass, double volume);
        [DllImport("ScienceDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double AverageKineticEnergy(double massParticle, double speed);
        [DllImport("ScienceDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double AverageSquareSpeed(double temperature, double massParticle);
        static void Main(string[] args)
        {
            Console.WriteLine("Mass: " + Mass(2, 0.32));
            Console.WriteLine("Volume: " + Volume(2));
            Console.WriteLine("NumberOfParticle: " + NumberOfParticle(1200, 32));
            Console.WriteLine("AmountOfSubstance: " + AmountOfSubstance(12, 0.32));
            Console.WriteLine("MassOfSubstance: " + MassOfSubstance(300, 33));
            Console.WriteLine("Density: " + Density(15, 150));
            Console.WriteLine("AverageKineticEnergy: " + AverageKineticEnergy(2, 140));
            Console.WriteLine("AverageSquareSpeed: " + AverageSquareSpeed(214, 3));
            Console.ReadKey();
        }
    }
}
