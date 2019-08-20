using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notebook.Data.ValidateModel
{
    public class Validate
    {
        public bool valid;
        public string Surname{ get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string YearOfBirth { get; set; }

        string NVName = "Please enter a valid name";
        string NVSurname = "Please enter a valid surname";
        string NVPhone = "Please enter a valid phone number";
        string NVYear = "Please enter a valid year";
        public Validate()
        {
            valid = false;
            Surname = "";
            Name = "";
            PhoneNumber = "";
            YearOfBirth = "";
        }
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
                valid = true;
            }
            else
            {
                valid = false;
            }
        }

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

        private bool CheckYearOfBirth(int yearOfBirth)
        {
            if (yearOfBirth < 1900 && yearOfBirth > 2010)
                return false;
            return true;
        }

        private bool CheckNameAndSurname(string str)
        {
            if (str == null)
                return false;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                    return false;
            }
                return true;
        }
    }
}
