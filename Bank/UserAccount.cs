using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Bank
{
    public class UserAccount : Entity
    {
        private string firstName;

        private string lastName;

        private string phone;

        public UserAccount(string inputFirstName, string inputLastName, string inputPhone)
        {
            this.FirstName = inputFirstName;

            this.LastName = inputLastName;

            this.Phone = inputPhone;
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new UserAccountException($"Value {nameof(FirstName)} not entered!");
                }
                else
                {
                    string regex = @"^[A-Z]{1}[a-z]{1,15}";
                    if (!Regex.IsMatch(value.ToString(), regex))
                    {
                        throw new UserAccountException($"Value {nameof(FirstName)} is not correct! Example Ivan");
                    }
                    else
                    {
                        firstName = value;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new UserAccountException($"Value {nameof(LastName)} not input!");
                }
                else
                {
                    string regex = @"^[A-Z]{1}[a-z]{1,20}";
                    if (!Regex.IsMatch(value.ToString(), regex))
                    {
                        throw new UserAccountException($"Value {nameof(FirstName)} is not correct! Example Ivanov");
                    }
                    else
                    {
                        lastName = value;
                    }
                }
            }
        }


        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone
        {
            get { return phone; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new UserAccountException($"Value {nameof(Phone)} not input!");
                }
                else
                {
                    string regex = @"[+375]-[(]{1}[0-9]{2}[)]{1}-[0-9]{3}-[0-9]{2}-[0-9]{2}";
                    if (!Regex.IsMatch(value.ToString(), regex))
                    {
                        throw new UserAccountException($"Value {nameof(Phone)} is not correct! Example +375-(29)-700-70-70");
                    }
                    else
                    {
                        phone = value;
                    }
                }
            }
        }
    }
}
