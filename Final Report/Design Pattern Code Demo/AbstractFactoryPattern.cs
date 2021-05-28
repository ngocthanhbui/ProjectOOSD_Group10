using System;

namespace ConsoleApp2
{
    class Program
    {
        /// <summary>

        /// MainApp startup class for Real-World

        /// Abstract Factory Design Pattern.

        /// </summary>

        class MainApp

        {
            /// <summary>

            /// Entry point into console application.

            /// </summary>

            public static void Main()
            {
                // Create and run the Excerise 

                ContinentFactory Excecise = new ExceciseFactory();
                UsersWorld world = new UsersWorld(Excecise);
                world.RunFavorExcerciseChain();

                // Create and run the UsersWorld

                ContinentFactory Users = new UsersFactory();
                world = new UsersWorld(Users);
                world.RunFavorExcerciseChain();

                // Wait for user input

                Console.ReadKey();
            }
        }


        /// <summary>

        /// The 'AbstractFactory' abstract class

        /// </summary>

        abstract class ContinentFactory

        {
            public abstract Excercise CrFavoriteExceciseeExcercise();
            public abstract User CrFavoriteExceciseeUser();
        }

        /// <summary>

        /// The 'ConcreteFactory1' class

        /// </summary>

        class ExceciseFactory : ContinentFactory

        {
            public override Excercise CrFavoriteExceciseeExcercise()
            {
                return new Excercise1();
            }
            public override User CrFavoriteExceciseeUser()
            {
                return new User1();
            }
        }

        /// <summary>

        /// The 'ConcreteFactory2' class

        /// </summary>

        class UsersFactory : ContinentFactory

        {
            public override Excercise CrFavoriteExceciseeExcercise()
            {
                return new Excercise2();
            }
            public override User CrFavoriteExceciseeUser()
            {
                return new User2();
            }
        }

        /// <summary>

        /// The 'AbstractProductA' abstract class

        /// </summary>

        abstract class Excercise

        {
        }

        /// <summary>

        /// The 'AbstractProductB' abstract class

        /// </summary>

        abstract class User

        {
            public abstract void FavoriteExcecise(Excercise h);
        }

        /// <summary>

        /// The 'ProductA1' class

        /// </summary>

        class Excercise1 : Excercise

        {
        }

        /// <summary>

        /// The 'ProductB1' class

        /// </summary>

        class User1 : User

        {
            public override void FavoriteExcecise(Excercise h)
            {
                // FavoriteExcecise Excercise1

                Console.WriteLine(this.GetType().Name +
                  " love the " + h.GetType().Name);
            }
        }

        /// <summary>

        /// The 'ProductA2' class

        /// </summary>

        class Excercise2 : Excercise

        {
        }

        /// <summary>

        /// The 'ProductB2' class

        /// </summary>

        class User2 : User

        {
            public override void FavoriteExcecise(Excercise h)
            {
                // FavoriteExcecise Excercise2

                Console.WriteLine(this.GetType().Name +
                  " love the " + h.GetType().Name);
            }
        }

        /// <summary>

        /// The 'Client' class 

        /// </summary>

        class UsersWorld

        {
            private Excercise _Excercise;
            private User _User;

            // Constructor

            public UsersWorld(ContinentFactory factory)
            {
                _User = factory.CrFavoriteExceciseeUser();
                _Excercise = factory.CrFavoriteExceciseeExcercise();
            }

            public void RunFavorExcerciseChain()
            {
                _User.FavoriteExcecise(_Excercise);
            }
        }
    }
}
