using System;

namespace BindingExercise
{
    internal class HouseHold
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("Whityyy", false);
            Dog dog = new Dog("Boggy", true);
            //Pet pet = dog;
            //pet.Move(true);
            /*HouseHold.Exercise(cat, 3);
            Console.WriteLine("------------------------------------------------------------");
            HouseHold.Exercise(dog, 3);*/

            Pet[] pet= new Pet[11];
            pet[0] = new Cat("cat_abc", true);
            pet[1] = new Cat("cat_bcd", false);
            pet[2] = new Dog("dog_abc", true);
            pet[3] = new Dog("dog_bcd", false);
            pet[4] = new Cat("cat_cde", false);
            pet[5] = new Cat("cat_dcf", true);
            pet[6] = new Dog("dog_cde", true);
            pet[7] = new Cat("cat_gfd", true);
            pet[8] = new Dog("dog_def", false);
            pet[9] = new Cat("cat_mno", true);
            pet[10] = new Cat("cat_pqr", false);

            //HouseHold.Exercise(pet);
            HouseHold.Play(pet[0]);
            HouseHold.Play(pet[2]);

        }
        static void Exercise(Pet p, int duration)
        {
            p.Speak();
            for (int i = 0; i < duration; i++) p.Move(true);
        }
        static void Exercise(Pet[] p)
        {
            foreach (Pet pet in p)
            {
                pet.Speak();
                pet.Move(false);
            }
        }
        static void Play(Pet p)
        {
            if(p is Cat)
            {
                Cat c = (Cat)p;
                if(c.IsPicky)
                    Console.WriteLine("Cats are picky");
                else
                    Console.WriteLine("Cats are not picky");
            }
            else
            {
                Dog d = p as Dog;
                if(d.canFetch)  
                    Console.WriteLine("Dogs can fetch.");
                else
                    Console.WriteLine("Dogs cannot fetch.");
            }
        }
    }
    abstract class Pet
    {
        public string Name;
        protected Pet(string name)
        {
            Name = name;
        }
        public virtual void Move(bool fast)
        {
            Console.WriteLine("Pets walk when moving slow and run when moving fast");
            if (fast)
                Console.WriteLine("Pets are running here.");
            else
                Console.WriteLine("Pets are walking here.");
        }
        public abstract void Speak();
    }
    class Cat : Pet
    {
        public bool IsPicky;
        public Cat(string name, bool isPicky)
            :base(name)
        {
            IsPicky = isPicky;
        }
        public override void Move(bool fast)
        {
            Console.WriteLine("Cats pounce when moving fast and slink when moving slow");
            if (fast)
                Console.WriteLine("Cats are pouncing here.\n");
            else
                Console.WriteLine("Cats are slinking here.\n");
        }
        public override void Speak()
        {
            Console.WriteLine($"{Name} meows");
        }
    }
    class Dog : Pet
    {
        public bool canFetch;
        public Dog(string name, bool canFetch)
            : base(name)
        {
            this.canFetch = canFetch;
        }
        public override void Move(bool fast)
        {
            Console.WriteLine("Dogs bound when moving fast and stride when moving slow");
            if (fast)
                Console.WriteLine("Dogs are bounding here.\n");
            else
                Console.WriteLine("Dogs are striding here.\n");
        }
        public override void Speak()
        {
            Console.WriteLine($"{Name} barks");
        }
    }
}
