using System;
using System.Collections.Generic;
namespace User
{
    namespace VisitorDesignPattern
    {
        public interface IElement
        {
            void Accept(IVisitor visitor);
        }
    }
    namespace VisitorDesignPattern
    {
        public class FriendAccout : IElement
        {
            public string FriendAccoutName { get; set; }

            public FriendAccout(string name)
            {
                FriendAccoutName = name;
            }

            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }
    }
    namespace VisitorDesignPattern
    {
        public interface IVisitor
        {
            void Visit(IElement element);
        }
    }

    namespace VisitorDesignPattern
    {
        public class User : IVisitor
        {
            public string Name { get; set; }
            public User(string name)
            {
                Name = name;
            }

            public void Visit(IElement element)
            {
                FriendAccout FriendAccout = (FriendAccout)element;
                Console.WriteLine("User: " + this.Name + " did a check up on " + FriendAccout.FriendAccoutName);
            }
        }
    }

     namespace VisitorDesignPattern
    {
        class MainUser : IVisitor
        {
            public string Name { get; set; }
            public MainUser(string name)
            {
                Name = name;
            }
            public void Visit(IElement element)
            {
                FriendAccout FriendAccout = (FriendAccout)element;
                Console.WriteLine("MainUser: " + this.Name + " like something on "
                                + FriendAccout.FriendAccoutName + " account page");
            }
        }
    }
    
    namespace VisitorDesignPattern
    {
        public class Friendlist
        {
            private static List<IElement> elements;
            static Friendlist()
            {
                elements = new List<IElement>
            {
                new FriendAccout("Friend2"),
                new FriendAccout("Friend3"),
                new FriendAccout("Friend4")
            };
            }
            public void PerformOperation(IVisitor visitor)
            {
                foreach (var FriendAccout in elements)
                {
                    FriendAccout.Accept(visitor);
                }
            }
        }
    }

namespace VisitorDesignPattern
    {
        class Program
        {
            static void Main(string[] args)
            {
                Friendlist Friendlist = new Friendlist();
                var visitor1 = new User("User 01");
                Friendlist.PerformOperation(visitor1);
                Console.WriteLine();
                var visitor2 = new MainUser("John");
                Friendlist.PerformOperation(visitor2);
                Console.Read();
            }
        }
    }
}


