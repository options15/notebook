using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notebook.Data.ValidateModel
{
    public class Validate
    {
        // Boolean whether there is an error in the input data.If it is true - then there are no errors.
        public bool Valid { get; set; }

        // Error fields - first name, last name, phone number, and date of birth
        public string Surname{ get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string YearOfBirth { get; set; }

        // Constant expressions for errors.
        const string NVName = "Please enter a valid name";
        const string NVSurname = "Please enter a valid surname";
        const string NVPhone = "Please enter a valid phone number";
        const string NVYear = "Please enter a valid year";

        // The constructor sets the default value.
        public Validate()
        {
            Valid = false;
            Surname = "";
            Name = "";
            PhoneNumber = "";
            YearOfBirth = "";
        }

        // Runs a number of methods to verify the entered data. Sets true if all methods return true.
        public void ValidatePerson(string surname, string name, string phoneNumber, int yearOfBirth)
        {
            if (!CheckNameAndSurname(surname))
            { Surname = NVSurname; }
            if (!CheckNameAndSurname(name))
            { Name = NVName; }
            if (!ChecPhoneNumber(phoneNumber))
            { PhoneNumber = NVPhone; }
            if (!CheckYearOfBirth(yearOfBirth))
            { YearOfBirth = NVYear; }
            if (CheckNameAndSurname(surname) && CheckNameAndSurname(name) && ChecPhoneNumber(phoneNumber) && CheckYearOfBirth(yearOfBirth))
            {
                Valid = true;
            }
            else
            {
                Valid = false;
            }
        }

        // Checks if the phone number contains only digits.Returns false if it contains something other than digits.
        private bool ChecPhoneNumber(string phoneNumber)
        {
            if (phoneNumber == null)
                return false;
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (!char.IsDigit(phoneNumber[i]))
                    return false;
            }
            return true;
        }

        //Checks the year of birth.Returns true if the number is greater than 1900 and less than 2010.
        private bool CheckYearOfBirth(int yearOfBirth)
        {
            return (yearOfBirth > 1900 && yearOfBirth < 2010);
        }

        // Checks first and last name to see if it only contains letters.returns rights if it contains only letters.
        private bool CheckNameAndSurname(string str)
        {
            if (str == null)
                return false;
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsLetter(str[i]) && !(str[i] == '-'))
                    return false;
            }
                return true;
        }
    }
}
