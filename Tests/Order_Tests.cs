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
    public class Order_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private OrderServices orderServices;
        private CustomerServices customerServices;
        public Order_Tests(ITestOutputHelper output)
        {
            this.outputHelper = output;
            this.orderServices = new OrderServices("Test");
            this.customerServices = new CustomerServices("Test");
        }

        [Fact]
        public void adaugare_stergere()
        {
            this.customerServices.create(new Customer("email1", "password1", "full_name1"));
            Assert.Equal("Acest client exista", Assert.Throws<CustomerException>(() => this.customerServices.create(new Customer("email1", "password1", "full_name1"))).Message);
            this.orderServices.create(new Order(1,"adresa1",this.customerServices.customerRepository.getIdWithCustomer(new Customer("email1", "password1", "full_name1"))));
            Assert.Equal("Aceasta comanda exista", Assert.Throws<OrderException>(() => this.orderServices.create(new Order(1,"adresa1",this.customerServices.customerRepository.getIdWithCustomer(new Customer("email1", "password1", "full_name1"))))).Message);

            //this.orderServices.delete(new Order(1, "adresa1", this.customerServices.customerRepository.getIdWithCustomer(new Customer("email1", "password1", "full_name1"))));
            //Assert.Equal("Aceasta comanda nu exista", Assert.Throws<OrderException>(() => this.orderServices.delete(new Order(1, "adresa1", this.customerServices.customerRepository.getIdWithCustomer(new Customer("email1", "password1", "full_name1"))))).Message);
            this.customerServices.delete(new Customer("email1", "password1", "full_name1"));
            Assert.Equal("Acest client nu exista", Assert.Throws<CustomerException>(() => this.customerServices.delete(new Customer("email1", "password1", "full_name1"))).Message);


        }

        //[Fact]
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
