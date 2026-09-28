// Exercism practica 13 Isandel Abreu

//Face ID 2.0 

using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }
    
    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    
    // TODO: implement equality and GetHashCode() methods
    
    public override bool Equals(object obj) => this.Equals(obj as FacialFeatures);
    
    public bool Equals(FacialFeatures face) => EyeColor == face.EyeColor && PhiltrumWidth == face.PhiltrumWidth; 
    
    public override int GetHashCode() => HashCode.Combine(this.EyeColor, this.PhiltrumWidth);
    
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    
    // TODO: implement equality and GetHashCode() methods
    
    public override bool Equals(object obj) => this.Equals(obj as Identity); 
    
    public bool Equals(Identity ident) 
    {
        return Email == ident.Email && FacialFeatures.Equals(ident.FacialFeatures);
    }
    public override int GetHashCode() => HashCode.Combine(this.Email, this.FacialFeatures);
    
}

public class Authenticator
{
    HashSet<Identity> uniqueFaces = new HashSet<Identity>();
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);
    
    public bool IsAdmin(Identity identity) 
    {
        var adminIdent = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
        return identity.Equals(adminIdent);        
    }

    public bool Register(Identity identity) => uniqueFaces.Add(identity);
       
    public bool IsRegistered(Identity identity) => uniqueFaces.Contains(identity);
    
    public static bool AreSameObject(Identity identityA, Identity identityB) => System.Object.ReferenceEquals(identityA, identityB);
    
}

class Program
{
    static void Main()
    {
        FacialFeatures face1 = new FacialFeatures("green", 0.9m);
        FacialFeatures face2 = new FacialFeatures("green", 0.9m);

        Identity identity1 = new Identity(
            "user@exerc.ism",
            face1);

        Identity identity2 = new Identity(
            "admin@exerc.ism",
            new FacialFeatures("green", 0.9m));

        Authenticator authenticator = new Authenticator();

        Console.WriteLine(
            "Same face: " +
            Authenticator.AreSameFace(face1, face2));

        Console.WriteLine(
            "Is admin: " +
            authenticator.IsAdmin(identity2));

        Console.WriteLine(
            "Registered: " +
            authenticator.Register(identity1));

        Console.WriteLine(
            "Is registered: " +
            authenticator.IsRegistered(identity1));

        Console.WriteLine(
            "Same object: " +
            Authenticator.AreSameObject(identity1, identity2));
    }
}