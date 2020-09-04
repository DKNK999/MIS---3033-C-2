using System;

namespace MoreDifficultStudent
{
    class Program
    {
        static void Main(string[] args)
        {



            Student myStudent = new Student(5, "Nic", "Keller", 100000);
            Console.WriteLine(myStudent);

            myStudent.MakePayment(500);
            Console.WriteLine(myStudent);

            myStudent.MakePayment(500);
            Console.WriteLine(myStudent);

            



        }
    }
}
