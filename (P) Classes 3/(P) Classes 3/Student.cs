using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace _P__Classes_3
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public double GPA { get; set; }
        public Address address { get; set; }

        public Student()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Major = string.Empty;
            GPA = 0.0;
            address = new Address();
        }

        public Student(string firstName, string lastName, string major, double gpa)
        {
            FirstName = firstName;
            LastName = lastName;
            Major = major;
            GPA = gpa;
            address = new Address();
        }

        public string CalculateDistinction()
        {
            string Distinction = string.Empty;
            if (GPA >= 3.8)
            {
                Distinction = "Ultra Nerd";
            }
            else if (GPA >= 3.6)
            {
                Distinction = "Nerd";
            }
            else
            {
                Distinction = "Average Joe";
            }

            return Distinction;
        }

        public void SetAddress(int streetNumber, string streetName, string state, string city, int zipcode)
        {
            address.StreetNumber = streetNumber;
            address.StreetName = streetName;
            address.State = state;
            address.City = city;
            address.Zipcode = zipcode;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {CalculateDistinction()}";
        }
    }

    public class Address
    {
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }

        public Address()
        {
            StreetNumber = -1;
            StreetName = string.Empty;
            State = string.Empty;
            City = string.Empty;
            Zipcode = -1;
        }

        public Address(int streetnumber, string streetname, string state, string city, int zipcode)
        {
            StreetNumber = streetnumber;
            StreetName = streetname;
            State = state;
            City = city;
            Zipcode = zipcode;
        }

    }
}
