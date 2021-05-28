using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    /// <summary>
    /// The 'Builder' interface
    /// </summary>
    public interface ICalCulateBuilder
    {
        void SetModel();
        void SetAge(string age);
        void SetValueB(string valueB);
        void SetValueA(string valueA);
        void SetResults(int tage, int tvalueA, int tvaluaB);

        Calculator GetCalculator();
    }

    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    public class BMIBuilder : ICalCulateBuilder
    {
        Calculator objCalculator = new Calculator();
        public void SetModel()
        {
            objCalculator.Model = "BMI";
        }

        public void SetAge(string age)
        {
            objCalculator.Age = age;
        }

        public void SetValueB(string valueB)
        {
            objCalculator.Weight = valueB + "kg";
        }

        public void SetValueA(string valueA)
        {
            objCalculator.Height = valueA + "cm";
        }

        public void SetResults(int age, int valueA, int valueB)
        {
            int BMI = 703 * (valueB /(valueA*valueA));
            if (age<25 &&BMI<16) 
            {
                objCalculator.Results.Add("Severe Thinness");
                objCalculator.Results.Add("Need more nuitrition");
            }
            else if(age>25&&BMI<25)
            {
                objCalculator.Results.Add("Severe Thinness");
                objCalculator.Results.Add("Need more nuitrition");
            }
            else
            {
                objCalculator.Results.Add("Normal");
                objCalculator.Results.Add("Balance nuitrition");
            }
        }

        public Calculator GetCalculator()
        {
            return objCalculator;
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    public class MacroBuilder : ICalCulateBuilder
    {
        Calculator objCalculator = new Calculator();
        public void SetModel()
        {
            objCalculator.Model = "Macro";
        }

        public void SetAge(string age)
        {
            objCalculator.Age = age.ToString();
        }

        public void SetValueB(string valueB)
        {
            objCalculator.Weight = valueB + "kg";
        }

        public void SetValueA(string valueA)
        {
            objCalculator.Height = valueA +"cm";
        }

        public void SetResults(int age,int valueA, int valueB)
        {
            if (age<25&&valueA*100>=170 && valueB <= 78) 
            {
                objCalculator.Results.Add("Good Shape");
                objCalculator.Results.Add("Balance diet");
                objCalculator.Results.Add("Healthy");
            }
            else if (age>25 && valueA*100>=160&&valueB<=70)
            {
                objCalculator.Results.Add("Good Shape");
                objCalculator.Results.Add("Balance diet");
                objCalculator.Results.Add("Healthy");
            }
            else
            {
                objCalculator.Results.Add("Not good Shape");
                objCalculator.Results.Add("Unbalance diet");
                objCalculator.Results.Add("Unhealthy");
            }
        }

        public Calculator GetCalculator()
        {
            return objCalculator;
        }
    }

    /// <summary>
    /// The 'Product' class
    /// </summary>
    public class Calculator
    {
        public string Model { get; set; }
        public string Age { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public List<string> Results { get; set; }

        public Calculator()
        {
            Results = new List<string>();
        }

        public void ShowInfo()
        {
            Console.WriteLine("Calculator Name: {0}", Model);
            Console.WriteLine("Age(age>18): {0}", Age);
            Console.WriteLine("Height(cm): {0}", Height);
            Console.WriteLine("Weight(kg): {0}", Weight);
            Console.WriteLine("Results:");
            foreach (var accessory in Results)
            {
                Console.WriteLine("\t{0}", accessory);
            }
        }
    }

    /// <summary>
    /// The 'Director' class
    /// </summary>
    public class CalculatorCreator
    {
        private readonly ICalCulateBuilder objBuilder;

        public CalculatorCreator(ICalCulateBuilder builder)
        {
            objBuilder = builder;
        }

        public void CreateCalculator()
        {
            Console.WriteLine("Enter age:");
            string age = Console.ReadLine();
            Console.WriteLine("Enter value height:");
            string valueA = Console.ReadLine();
            Console.WriteLine("Enter value weight:");
            string valueB = Console.ReadLine();
            int tage=0;
            
            int tvalueA=1;
            int tvalueB=0;
            if (age != "" || valueA != "" || valueB != "") 
            {
                tage = Convert.ToInt32(age);

                tvalueA = Convert.ToInt32(valueA) / 100;

                tvalueB = Convert.ToInt32(valueB);
            }
            objBuilder.SetModel();
            objBuilder.SetAge(age);
            objBuilder.SetValueA(valueA);
            objBuilder.SetValueB(valueB);
            objBuilder.SetResults(tage,tvalueA,tvalueB);
        }

        public Calculator GetCalculator()
        {
            return objBuilder.GetCalculator();
        }
    }
    class Program
    {   
        static void Main(string[] args)
        {
            var CalculatorCreator = new CalculatorCreator(new BMIBuilder());
            CalculatorCreator.CreateCalculator();
            var Calculator = CalculatorCreator.GetCalculator(); 
            Console.WriteLine("----------------------OBJECT CREATED-----------------------");
            Calculator.ShowInfo();
            Console.WriteLine("---------------------Second Object------------------------"); 
            CalculatorCreator = new CalculatorCreator(new MacroBuilder());
            CalculatorCreator.CreateCalculator();Calculator = CalculatorCreator.GetCalculator();
            Calculator.ShowInfo();
            Console.ReadKey();
        }
    }
}
