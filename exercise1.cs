// Exercism practica 1 Isandel Abreu

//Hello World 

using System;

public class HelloWorld
{
    public string Hello()
    {
        return "Hello, World!";
    }
}

class Program
{
    static void Main()
    {
        HelloWorld helloWorld = new HelloWorld();

        Console.WriteLine(helloWorld.Hello());
    }
}