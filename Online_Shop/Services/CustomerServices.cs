using Online_Shop.Exceptions;
using Online_Shop.Model;
using Online_Shop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Services
{
    public class CustomerServices
    {
        public CustomerRepository customerRepository;

        public CustomerServices(string dataBase)
        {
            this.customerRepository = new CustomerRepository(dataBase);
        }

        public List<Customer> lista()
        {
            return this.customerRepository.getAll();
        }

        public void create(Customer customer)
        {
            if (!this.exist(customer.Email, customer.Password, customer.Full_name))
            {
                this.customerRepository.add(customer);
            }
            else
            {
                throw new CustomerException("Acest client exista");
            }
        }
        public void deleteById(int id)
        {
            if (this.existId(id))
            {
                this.customerRepository.deleteById(id);
            }
            else
            {
                throw new CustomerException("Acest client nu exista");
            }
        }
        public void delete(Customer customer)
        {
            if (this.exist(customer.Email, customer.Password, customer.Full_name))
            {
                this.customerRepository.delete(customer);
            }
            else
            {
                throw new CustomerException("Acest client nu exista");
            }
        }

        public void updateEmail(Customer customer, string newEmail)
        {
            if (this.exist(customer.Email, customer.Password, customer.Full_name))
            {
                this.customerRepository.updateEmail(customer, newEmail);
            }
            else
            {
                throw new CustomerException("Acest client nu exista");
            }
        }
        public void updatePassword(Customer customer, string newPassword)
        {
            if (this.exist(customer.Email, customer.Password, customer.Full_name))
            {
                this.customerRepository.updatePassword(customer, newPassword);
            }
            else
            {
                throw new CustomerException("Acest client nu exista");
            }
        }
        public void updateFull_name(Customer customer, string newFull_name)
        {
            if (this.exist(customer.Email, customer.Password, customer.Full_name))
            {
                this.customerRepository.updateFull_name(customer, newFull_name);
            }
            else
            {
                throw new CustomerException("Acest client nu exista");
            }
        }


        public bool exist(string email, string password, string full_name)
        {
            foreach (Customer customer in this.lista())
                if (customer.Email == email && customer.Password == password && customer.Full_name == full_name)
                    return true;
            return false;
        }
        public bool existId(int id)
        {
            foreach (Customer customer in this.lista())
                if (customer.Id == id)
                    return true;
            return false;
        }
    }
}
