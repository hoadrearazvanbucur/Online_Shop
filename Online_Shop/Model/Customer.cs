using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Model
{
    public class Customer : IComparable
    {
        private int id;
        private string email, password, full_name;

        public Customer(int id,string email,string password,string full_name)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.full_name = full_name;
        }
        public Customer(string email, string password, string full_name)
        {
            this.email = email;
            this.password = password;
            this.full_name = full_name;
        }

        public override string ToString() => this.id + "," + this.email + "," + this.password + "," + this.full_name;
        public override bool Equals(object obj) => (obj as Customer).ToString() == this.ToString();
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public string Email
        {
            get => this.email;
            set => this.email = value;
        }
        public string Password
        {
            get => this.password;
            set => this.password = value;
        }
        public string Full_name
        {
            get => this.full_name;
            set => this.full_name = value;
        }
    }
}
