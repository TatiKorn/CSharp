
//.dll  .exe
using System;

namespace CSharpFundas
{
    class Program : Program4
    {

        String name;
        String lastName;

        //method default constructor

        public Program(String name)

        {
            this.name = name;
        }


        public Program(String firstName,String lastName)

        {
            this.lastName = lastName;
        }





        public void getName()

        {
            Console.WriteLine("My name is " + this.name);
        }

        public void getData()

        {

            Console.WriteLine("I am inside the method");

        }

        static void Main(string[] args)
        {

            Program p = new Program("Rahul");
            Program p1 = new Program("Rahul","Shetty");

            p.getData();
            p.getName();
            p.SetData();


            Console.WriteLine("Hello World!");
            int a = 4;
           // Double c = 3.12;
            Console.WriteLine("number is " + a);

            String name = "Rahul";

            Console.WriteLine("Name is " + name);

            Console.WriteLine($"Name is {name}");

            var age = 23;
            Console.WriteLine("Age is " + age);
            // age = "hello";

            dynamic height = 13.2;
            Console.WriteLine($"Height is {height}");

            height = "hello";
            Console.WriteLine($"Height is {height}");


        }
    }


}
 