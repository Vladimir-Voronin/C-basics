using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    class Program1
    {
        public static void FactoryMain()
        {
            AnimalFactory factory1 = new AnimalFactory();
            Animal dog = factory1.CreateAnimal(AnimalType.Dog);
            dog.Move();
            Animal elep = factory1.CreateAnimal(AnimalType.Elephant);
            elep.Move();
            factory1.DestroyObjects();
            elep.Move();
            foreach (var item in factory1.Created)
            {
                Console.WriteLine($"{item.GetType()} - is living");
            }
        }

        private abstract class Animal
        {
            public abstract void Move();
            public void Delete()
            {

            }
        }

        private enum AnimalType
        {
            Dog,
            Elephant
        }

        private class Dog : Animal
        {
            public override void Move()
            {
                Console.WriteLine("Dog moving");
            }
        }

        private class Elephant : Animal
        {
            public override void Move()
            {
                Console.WriteLine("Elephant moving");
            }
        }

        private interface IAnimalFactory
        {
            Animal CreateAnimal(AnimalType type);
        }

        //Simple Factory pattern
        private class AnimalFactory : IAnimalFactory
        {
            public List<Animal> Created = new List<Animal>();
            public Animal CreateAnimal(AnimalType type)
            {
                switch (type)
                {
                    case AnimalType.Dog:
                        Animal dog = new Dog();
                        Created.Add(dog);
                        return dog;
                    case AnimalType.Elephant:
                        Animal elephant = new Elephant();
                        Created.Add(elephant);
                        return elephant;
                    default:
                        return null;
                }
            }

            //clear "Created" list, but objects in variables will be living
            //I can implement func "Death" in class "Animal" and kill all animals from this function
            public void DestroyObjects()
            {
                Created.Clear();
            }
        }
    }

    
}
