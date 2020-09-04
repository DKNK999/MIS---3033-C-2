using System;
using System.Collections.Generic;
using System.Text;

namespace MoreDifficultStudent
{
    class Student
    {
        public int SoonerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsOnProbation { get; set; }
        public double GPA { get; set; }
        private double BursarBalance;
        
        //default constructor for the Student class
        public Student()
        {
            SoonerID = -1;
            FirstName = string.Empty;
            LastName = string.Empty;
            IsOnProbation = false;
            GPA = 0;
            BursarBalance = 10000;
        }

        public Student(int id, string fName, string lName, double BursarBalance)
        {
            SoonerID = id;
            FirstName = fName;
            LastName = lName;
            IsOnProbation = false;
            GPA = 0;
            this.BursarBalance = BursarBalance;
        }

        public void MakePayment(double amount)
        {
            if (amount > 0)
            {
                BursarBalance = BursarBalance - amount;
            }
            else
            {
                throw new Exception();
            }
        }

        public double CheckBalance()
        {
            return BursarBalance;
        }

        public override string ToString()
        {
            string result = $"{FirstName} {LastName} {SoonerID} has a {GPA.ToString("N2")} GPA and owes {BursarBalance.ToString("N2")}";
            if (IsOnProbation == true)
            {
                result += "\nIs on probation";
            }
            else
            {
                result += "\nIs not on probation";
            }
           
            return result + "\n";
        }

    }    
}
