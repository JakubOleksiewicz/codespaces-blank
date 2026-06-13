using System;
using System.Collections.Generic;

class Program
{
    abstract class Character
    {}

    interface IAttack
    {}

    abstract class NPC : Character
    {}

    class Skeleton : NPC, IAttack
    {}

    class Ork : NPC, IAttack
    {}

    static void Main()
    {
        Console.WriteLine("Hej");
    }
}