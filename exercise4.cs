// Exercism practica 3 Isandel Abreu

//Annalyn's Infiltration 

using System;

static class QuestLogic
{
    public static bool CanFastAttack(bool knightIsAwake) =>
        !knightIsAwake;

    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake) =>
        prisonerIsAwake || knightIsAwake || archerIsAwake;

    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake) =>
        prisonerIsAwake && !archerIsAwake;

    public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent) =>
        prisonerIsAwake && !knightIsAwake && !archerIsAwake ||
        petDogIsPresent && !archerIsAwake;
}

class Program
{
    static void Main()
    {
        bool knightIsAwake = true;
        bool archerIsAwake = false;
        bool prisonerIsAwake = true;
        bool petDogIsPresent = true;

        Console.WriteLine("Annalyn's Infiltration");
        Console.WriteLine();

        Console.WriteLine("Can Fast Attack: " +
            QuestLogic.CanFastAttack(knightIsAwake));

        Console.WriteLine("Can Spy: " +
            QuestLogic.CanSpy(
                knightIsAwake,
                archerIsAwake,
                prisonerIsAwake));

        Console.WriteLine("Can Signal Prisoner: " +
            QuestLogic.CanSignalPrisoner(
                archerIsAwake,
                prisonerIsAwake));

        Console.WriteLine("Can Free Prisoner: " +
            QuestLogic.CanFreePrisoner(
                knightIsAwake,
                archerIsAwake,
                prisonerIsAwake,
                petDogIsPresent));

        Console.WriteLine();
        Console.WriteLine("Presiona una tecla para salir...");
        Console.ReadKey();
    }
}