// Exercism practica 18 Isandel Abreu

//Wizards and Warriors 

using System;

abstract class Character
{
    protected readonly string characterType;
    
    protected Character(string characterType)
    {
        this.characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
        => false;

    public override string ToString()
        => $"Character is a {this.characterType}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior") {}

    public override int DamagePoints(Character target)
        => (target.Vulnerable() ? 10 : 6);
}

class Wizard : Character
{
    private bool spellReady = false;

    public Wizard() : base("Wizard") {}

    public override bool Vulnerable() 
        => !spellReady;

    public override int DamagePoints(Character target) 
        => (spellReady ? 12 : 3);

    public void PrepareSpell() {
        this.spellReady = true;
    }
}


class Program
{
    static void Main()
    {
        Warrior warrior = new Warrior();
        Wizard wizard = new Wizard();

        Console.WriteLine(warrior);
        Console.WriteLine(wizard);

        Console.WriteLine(
            "Warrior damage to Wizard: " +
            warrior.DamagePoints(wizard));

        Console.WriteLine(
            "Wizard vulnerable: " +
            wizard.Vulnerable());

        wizard.PrepareSpell();

        Console.WriteLine(
            "Wizard vulnerable after preparing spell: " +
            wizard.Vulnerable());

        Console.WriteLine(
            "Wizard damage to Warrior: " +
            wizard.DamagePoints(warrior));

        Console.WriteLine(
            "Warrior damage to Wizard after spell: " +
            warrior.DamagePoints(wizard));
    }

}