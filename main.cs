using System;
using System.Collections.Generic;

class Program
{
    abstract class Character
    {
        private int hp;
        public int Id { get; private set; }
        public string Name { get; private set; }

        public int Hp
        {
            get { return hp; }
            protected set
            {
                if (value < 0)
                    hp = 0;
                else
                    hp = value;
            }
        }

        public int Damage { get; protected set; }

        public Character(int id, string name, int hp, int damage)
        {
            Id = id;
            Name = name;
            Hp = hp;
            Damage = damage;
        }

        public abstract void ShowInfo();

        public void TakeDamage(int damage)
        {
            Hp -= damage;
            Console.WriteLine(Name + " otrzymuje " + damage + " obrazen. HP: " + Hp);
        }
    }

    interface IAttack
    {
        void Attack(Character target);
    }

    abstract class NPC : Character
    {
        protected string Attitude { get; set; }

        public NPC(int id, string name, int hp, int damage, string attitude) : base(id, name, hp, damage)
        {
            Attitude = attitude;
        }

    }

    class Skeleton : NPC, IAttack
    {
        public Skeleton(int id, string name) : base(id, name, 40, 8, "Agresywny")
        {}
        public void Attack(Character target)
        {
            Console.WriteLine("- " + Name + " atakuje koscia.");
            target.TakeDamage(Damage);
        }
        public override void ShowInfo()
        {
            Console.WriteLine("Szkielet | ID: " + Id + " | Nazwa: " + Name + " | HP: " + Hp);
        }
    }

    class Ork : NPC, IAttack
    {
        public Ork(int id, string name) : base(id, name, 70, 12, "Agresywny")
        {}
        public void Attack(Character target)
        {
            Console.WriteLine("- " + Name + " atakuje toporem.");
            target.TakeDamage(Damage);
        }
        public override void ShowInfo()
        {
            Console.WriteLine("Ork | ID: " + Id + " | Nazwa: " + Name + " | HP: " + Hp);
        }
    }

    static void Main()
    {
        Skeleton skeleton1 = new Skeleton(1, "Dr. Bones");
        Ork ork1 = new Ork(2, "Azog");

        Character[] characters = { skeleton1, ork1 };

        foreach (Character character in characters)
        {
            character.ShowInfo();
        }

        Console.WriteLine("--------------------------------------");

        IAttack attacker1 = skeleton1;
        IAttack attacker2 = ork1;

        Console.WriteLine("-=-=( Bitwa: " + skeleton1.Name + " vs " + ork1.Name + " )=-=-");
        while (ork1.Hp > 0 && skeleton1.Hp > 0)
        {
            attacker1.Attack(ork1);
            attacker2.Attack(skeleton1);
        }
        Console.WriteLine("-=-=( Wygrywa: " + (ork1.Hp == 0 ? skeleton1.Name : ork1.Name) + " )=-=-");
    }
}