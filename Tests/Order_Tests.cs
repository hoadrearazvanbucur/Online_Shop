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
        private CustomerServices customerServices;
        private OrderServices orderServices;
        public Order_Tests(ITestOutputHelper output)
        {
            this.outputHelper = output;
            this.customerServices = new CustomerServices("Test");
            this.orderServices = new OrderServices("Test");
            this.customerServices.customerRepository.deleteAll();
            this.orderServices.orderRepository.deleteAll();
        }

        [Fact]
        public void adaugare()
        {
            //Preconditie
            Customer customer1 = new Customer("email1", "password1", "full_name1");
            Customer customer2 = new Customer("email2", "password2", "full_name2");
            Customer customer3 = new Customer("email3", "password3", "full_name3");
            this.customerServices.create(customer1);
            this.customerServices.create(customer2);
            this.customerServices.create(customer3);



            Assert.Equal("Acest client exista",
                Assert.Throws<CustomerException>(
                    () => this.customerServices.create(customer1)).Message);



            Assert.Equal("Acest client exista", 
               Assert.Throws<CustomerException>(
                    () => this.customerServices.create(customer2)).Message);


            Assert.Equal("Acest client exista", 
                Assert.Throws<CustomerException>(
                    () => this.customerServices.create(customer3)).Message);

            this.outputHelper.WriteLine(
                this.customerServices.
                customerRepository.
                getIdWithCustomer(customer1.Email,customer1.Password,customer1.Full_name).ToString());
            
            
            //Order order1 = new Order(1, "adresa1",this.customerServices.customerRepository.getIdWithCustomer(customer1));
            //Order order2 = new Order(2, "adresa2",this.customerServices.customerRepository.getIdWithCustomer(customer2));
            //Order order3 = new Order(3, "adresa3",this.customerServices.customerRepository.getIdWithCustomer(customer3));


        }



    }
}
