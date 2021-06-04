#include "pch.h" 
#include "ScienceLibrary.h"

double _stdcall Mass(double amountOfSubstance, double molekularMassSubstance) {
	return amountOfSubstance * molekularMassSubstance;
}

double _stdcall Volume(double amountOfSubstance) {
	return amountOfSubstance * 22.4;
}

double _stdcall NumberOfParticle(double mass, double massParticle) {
	return mass / massParticle;
}
double _stdcall AmountOfSubstance(double mass, double molekularMassSubstance) {
	return mass / molekularMassSubstance;
}

double _stdcall MassOfSubstance(double massOfFluid, int procents) {
	return (massOfFluid / 100) * procents;
}

double _cdecl Density(double mass, double volume) {
	return mass / volume;
}

double _cdecl AverageKineticEnergy(double massParticle, double speed) {
	return massParticle * speed * speed / 2;
}

double _cdecl AverageSquareSpeed(double temperature, double massParticle) {
	return temperature * 1.38 * 3 / massParticle;
}