using System;
using System.Collections.Generic;
using System.Diagnostics;
using NorthwindData;
using NorthwindData.Services;


namespace NorthwindBusiness
{
    //Front-end can use all these methods
    public class CustomerManager
    {
        private readonly ICustomerService _service;

        //Takes an ICustomer service type - must provide the service they want to use
        public CustomerManager(ICustomerService service)
        {
            if (service == null)
            {
                throw new ArgumentException("ICustomerService object cannot be null");
            }
            _service = service;
        }

        public Customer SelectedCustomer { get; set; }

        //Casts the object to a customer object
        public void SetSelectedCustomer(object selectedItem)
        {
            SelectedCustomer = (Customer)selectedItem;
        }

        public List<Customer> RetrieveAll()
        {
            return _service.GetCustomerList();
        }

        //Takes parameters and calls create customer method to create a new customer
        public void Create(string customerId, string contactName, string companyName, string city = null)
        {
            var newCust = new Customer() { CustomerId = customerId, ContactName = contactName, CompanyName = companyName };
            _service.CreateCustomer(newCust);
        }

        //Once it has found the customer ID it allows us to update the details as specified, and then saves the changes to the database
        public bool Update(string customerId, string contactName, string country, string city, string postcode)
        {
            var customer = _service.GetCustomerById(customerId);
            if (customer == null)
            {
                Debug.WriteLine($"Customer {customerId} not found");
                return false;
            }
            customer.ContactName = contactName;
            customer.City = city;
            customer.PostalCode = postcode;
            customer.Country = country;
            // write changes to database
            try
            {
                _service.SaveCustomerChanges();
                SelectedCustomer = customer;
            }
            catch (Exception e) // an exception can be thrown if the database has been updated since last loaded 
            {
                Debug.WriteLine($"Error updating {customerId}");
                return false;
            }
        	return true;
        }

        public bool Delete(string customerId)
        {
            var customer = _service.GetCustomerById(customerId);
            if (customer == null)
            {
                Debug.WriteLine($"Customer {customerId} not found");
                return false;
            }
            _service.RemoveCustomer(customer);
            SelectedCustomer = null;
            return true;
        }
    }
}
