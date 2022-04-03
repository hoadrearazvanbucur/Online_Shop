using Online_Shop.Services;
using Online_Shop.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Online_Shop.Exceptions;

namespace Tests
{
    public class Customer_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private CustomerServices customerServices;
        public Customer_Tests(ITestOutputHelper output)
        {
            this.outputHelper = output;
            this.customerServices = new CustomerServices("Test");
            this.customerServices.customerRepository.deleteAll();
        }

        [Fact]
        public void adaugare_stergere()
        {
            this.customerServices.create(new Customer("email1", "password1", "full_name1"));
            Assert.Equal("Acest client exista", Assert.Throws<CustomerException>(() => this.customerServices.create(new Customer("email1", "password1", "full_name1"))).Message);
            this.customerServices.delete(new Customer("email1", "password1", "full_name1"));
            Assert.Equal("Acest client nu exista", Assert.Throws<CustomerException>(() => this.customerServices.delete(new Customer("email1", "password1", "full_name1"))).Message);
        }

        [Fact]
        public void update()
        {
            this.customerServices.create(new Customer("email1", "password1", "full_name1"));
            Assert.Equal("Acest client exista", Assert.Throws<CustomerException>(() => this.customerServices.create(new Customer("email1", "password1", "full_name1"))).Message);

            this.customerServices.updateEmail(new Customer("email1", "password1", "full_name1"), "email2");
            Assert.Equal("Acest client nu exista", Assert.Throws<CustomerException>(() => this.customerServices.updateEmail(new Customer("email1", "password1", "full_name1"), "email2")).Message);
            this.customerServices.updatePassword(new Customer("email2", "password1", "full_name1"), "password2");
            Assert.Equal("Acest client nu exista", Assert.Throws<CustomerException>(() => this.customerServices.updatePassword(new Customer("email2", "password1", "full_name1"), "password2")).Message);
            this.customerServices.updateFull_name(new Customer("email2", "password2", "full_name1"), "full_name2");
            Assert.Equal("Acest client nu exista", Assert.Throws<CustomerException>(() => this.customerServices.updateFull_name(new Customer("email2", "password2", "full_name1"), "full_name2")).Message);

            this.customerServices.delete(new Customer("email2", "password2", "full_name2"));
            Assert.Equal("Acest client nu exista", Assert.Throws<CustomerException>(() => this.customerServices.delete(new Customer("email2", "password2", "full_name2"))).Message);

        }

    }
}
