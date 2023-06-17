﻿using Librarian.DAL.Entities;
using Librarian.Interfaces;
using Librarian.Services.Interfaces;
using Librarian.ViewModels;
using Librarian.Views.Windows;
using System.Collections.Generic;
using System.Windows;

namespace Librarian.Services
{
    public class UserDialogService : IUserDialogService
    {
        public bool EditProduct(
            Product product, 
            IRepository<Category> categoriesRepository,
            IRepository<Supplier> suppliersRepository)
        {
            var productEditorModel = new ProductEditorViewModel(product, categoriesRepository, suppliersRepository);
            var productEditorWindow = new BookEditorWindow
            {
                DataContext = productEditorModel,
            };

            if (productEditorWindow.ShowDialog() != true) return false;

            product.Name = productEditorModel.ProductName;
            product.Category = productEditorModel.ProductCategory;
            product.Supplier = productEditorModel.ProductSupplier;
            product.UnitPrice = productEditorModel.ProductUnitPrice;
            product.UnitsInStock = productEditorModel.ProductUnitsInStock;
            product.UnitsInEnterprise = productEditorModel.ProductUnitsInEnterprise;

            return true;
        }

        public bool EditCategory(Category category)
        {
            var categoryEditorModel = new CategoryEditorViewModel(category);
            var categoryEditorWindow = new CategoryEditorWindow
            {
                DataContext = categoryEditorModel,
            };

            if (categoryEditorWindow.ShowDialog() != true) return false;

            category.Name = categoryEditorModel.CategoryName;

            return true;
        }

        public bool EditCustomer(Customer customer)
        {
            var customerEditorModel = new CustomerEditorViewModel(customer);
            var customerEditWindow = new BuyerEditorWindow
            {
                DataContext = customerEditorModel,
            };

            if(customerEditWindow.ShowDialog() != true) return false;

            customer.Name = customerEditorModel.CustomerName;
            customer.Surname = customerEditorModel.CustomerSurname;
            customer.ContactName = customerEditorModel.CustomerContactName;
            customer.ContactTitle = customerEditorModel.CustomerContactTitle;
            customer.ContactNumber = customerEditorModel.CustomerContactNumber;
            customer.ContactMail = customerEditorModel.CustomerContactMail;
            customer.Address = customerEditorModel.CustomerAddress;

            return true;
        }

        public bool EditEmployee(Employee employee, IRepository<WorkingRate> workingRatesRepository)
        {
            var employeeEditorModel = new EmployeeEditorViewModel(employee, workingRatesRepository);
            var employeeEditorWindow = new SellerEditorWindow
            {
                DataContext = employeeEditorModel
            };

            if (employeeEditorWindow.ShowDialog() != true) return false;

            employee.Name = employeeEditorModel.EmployeeName;
            employee.Surname = employeeEditorModel.EmployeeSurname;
            employee.DateOfBirth = employeeEditorModel.EmployeeDateOfBirth;
            employee.HireDate = employeeEditorModel.EmployeeHireDate;
            employee.Extension = employeeEditorModel.EmployeeExtension;
            employee.Title = employeeEditorModel.EmployeeTitle;
            employee.ContactNumber = employeeEditorModel.EmployeeContactNumber;
            employee.ContactMail = employeeEditorModel.EmployeeMail;
            employee.IdentityDocumentNumber = employeeEditorModel.EmployeeIdentityDocumentNumber;
            employee.WorkingRate = employeeEditorModel.EmployeeWorkingRate;
            employee.Address = employeeEditorModel.EmployeeAddress;

            return true;
        }

        public bool EditOrder(
            Order order, 
            ICollection<OrderDetails>? orderDetails,
            IRepository<Product> products, 
            IRepository<Employee> employees, 
            IRepository<Customer> customers,
            IRepository<Shipper> shippers)
        {
            var orderEditorModel = new OrderEditorViewModel(order, orderDetails, products, employees, customers, shippers);
            var orderEditorWindow = new TransactionEditorWindow
            {
                DataContext = orderEditorModel
            };

            if (orderEditorWindow.ShowDialog() != true) return false;

            order.OrderDate = orderEditorModel.OrderDate;
            order.RequiredDate = orderEditorModel.RequiredDate;
            order.ShippedDate = orderEditorModel.ShippedDate;
            order.Amount = orderEditorModel.OrderAmount;
            order.Employee = orderEditorModel.OrderEmployee;
            order.Customer = orderEditorModel.OrderCustomer;
            order.ShipVia = orderEditorModel.OrderShipVia;
            order.ShippingCost = orderEditorModel.OrderShippingCost;
            order.ShipName = orderEditorModel.OrderShipName;
            order.ShipAddress = orderEditorModel.OrderShipAddress;
            order.OrderDetails = orderEditorModel.OrderDetails;

            return true;
        }

        public bool Confirmation(string message, string caption) => 
            MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;

        public void Warning(string message, string caption) =>
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Warning);

        public void Error(string message, string caption) =>
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
