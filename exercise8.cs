// Exercism practica 8 Isandel Abreu

//Authentication System 

using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Authenticator
{
    private class EyeColor
    {
        public const string Blue = "blue";
        public const string Green = "green";
        public const string Brown = "brown";
        public const string Hazel = "hazel";
        public const string Brey = "grey";
    }

    public Authenticator(Identity admin)
    {
        this.admin = admin;
    }

    private readonly Identity admin;

    private readonly IDictionary<string, Identity> developers
        = new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = "blue"
            },

            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = "brown"
            }
        };

    public Identity Admin =>
        new Identity
        {
            Email = admin.Email,
            EyeColor = admin.EyeColor
        };

    public IDictionary<string, Identity> GetDevelopers() =>
        new ReadOnlyDictionary<string, Identity>(developers);
}

public struct Identity
{   
    public string Email { get; set; }

    public string EyeColor { get; set; }
}

class Program
{
    static void Main()
    {
        Identity admin = new Identity
        {
            Email = "admin@exerc.ism",
            EyeColor = "green"
        };

        Authenticator authenticator = new Authenticator(admin);

        Console.WriteLine("Admin email: " + authenticator.Admin.Email);
        Console.WriteLine("Admin eye color: " + authenticator.Admin.EyeColor);

        var developers = authenticator.GetDevelopers();

        foreach (var developer in developers)
        {
            Console.WriteLine(
                developer.Key + ": " +
                developer.Value.Email + " - " +
                developer.Value.EyeColor);
        }
    }
}