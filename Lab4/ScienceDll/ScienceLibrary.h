#pragma once
#ifdef SCIENCELIBRARY_EXPORTS
#define SCIENCELIBRARY_API __declspec(dllexport)
#else
#define SCIENCELIBRARY_API __declspec(dllimport)
#endif

extern "C" {
    SCIENCELIBRARY_API double _stdcall Mass(double amountOfSubstance, double molekularMassSubstance);
    SCIENCELIBRARY_API double _stdcall Volume(double amountOfSubstance);
    SCIENCELIBRARY_API double _stdcall NumberOfParticle(double mass, double massParticle);
    SCIENCELIBRARY_API double _stdcall AmountOfSubstance(double mass, double molekularMassSubstance);
    SCIENCELIBRARY_API double _stdcall MassOfSubstance(double massOfFluid, int procents);
    SCIENCELIBRARY_API double _cdecl Density(double mass, double volume);
    SCIENCELIBRARY_API double _cdecl AverageKineticEnergy(double massParticle, double speed);
    SCIENCELIBRARY_API double _cdecl AverageSquareSpeed(double temperature, double massParticle);
}