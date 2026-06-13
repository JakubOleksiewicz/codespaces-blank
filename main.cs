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
        public Skeleton(int id, string name) : base(id, name, 0, 0, "Neutral")
        {}
        public override void ShowInfo()
        {}
        public void Attack(Character target)
        {}
    }

    class Ork : NPC, IAttack
    {
        public Ork(int id, string name) : base(id, name, 0, 0, "Neutral")
        {}
        public override void ShowInfo()
        {}
        public void Attack(Character target)
        {}
    }

    static void Main()
    {
        Skeleton skeleton = new Skeleton(1, "Kosciotrup");
        Ork ork = new Ork(2, "Grum");
        
        Console.WriteLine("Hej");
    }
}