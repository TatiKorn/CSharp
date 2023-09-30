
namespace CSharpFunds
{
    class Program1 : Program3
    {
        String name;
        public Program1(String name)
        {
            this.name = name;
        }
        public void GetName()
        {
            Console.WriteLine("My name is " + this.name);
        }
        public void PrintHello(string text)
        {
            Console.WriteLine(text);
        }
        static void Main(string[] args)
        {
            Program1 p = new Program1("Tatiana");
            p.PrintHello("Hello from Main");
            p.SetData();
            p.GetName();
        }

    }
}