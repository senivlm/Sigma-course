using System;

namespace Pr4
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynom myPolynom = new Polynom();
            Polynom myPolynom2 = new Polynom();
            myPolynom.Parse("9*x^1+3*x^2");
            myPolynom2.Parse("2*x^1+3*x^2+5*x^5");

            Polynom myPolynom3 = new Polynom();
            myPolynom3 = myPolynom.Add(myPolynom2);
        }
    }
}
