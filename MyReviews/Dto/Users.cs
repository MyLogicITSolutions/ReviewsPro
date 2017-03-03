using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    [Serializable]
    public class Users
    {
        private int dbkey;
        private string firstName;
        private string lastName;
        private string email;
        private string gender;
        private DateTime dateofBirth;
        private long mobileNumber;
        private string password;
        private string adress;
        private string city;
        private string country;

        public int DBKey {
            get { return this.dbkey; }
            set { this.dbkey = value; }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }
        public DateTime DateofBirth
        {
            get { return this.dateofBirth; }
            set { this.dateofBirth = value; }
        }
        public long MobileNumber
        {
            get { return this.mobileNumber; }
            set { this.mobileNumber = value; }
        }
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        public string Adress
        {
            get { return this.adress; }
            set { this.adress = value; }
        }
        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }
        public string Country
        {
            get { return this.country; }
            set { this.country = value; }
        }
    }
   
}
