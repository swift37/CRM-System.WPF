﻿using CRM.DAL.Entities;
using CRM.Models;

namespace CRM.Services.Interfaces
{
    public interface IUserDialogService
    {
        void OpenMainWindow(Employee? employee);

        bool EditProduct(Product product);

        bool EditCategory(Category category);

        bool EditCustomer(Customer customer);

        void ShowFullCustomerInfo(Customer customer);

        bool RegisterEmployee(RegisterRequest registerRequest);

        bool EditEmployee(Employee employee);

        void ShowFullEmployeeInfo(Employee employee);

        bool CreateOrder(Employee? employee, Order order);

        bool EditOrder(Order order);

        bool EditOrderDetails(OrderDetails orderDetails);

        bool EditSupply(Supply supply);

        bool EditSupplyDetails(SupplyDetails supplyDetails);

        void ShowFullSupplyInfo(Supply supply);

        void ShowFullSupplierInfo(Supplier supplier);

        void ShowFullOrderInfo(Order order);

        bool EditSupplier(Supplier supplier);

        bool EditShipper(Shipper shipper);

        void ShowStatisticsDetails(StatisticsDetails statisticsDetails);

        bool ChangePassword(out string? newLogin, out string? newPassword);

        bool Confirmation(string message, string caption);

        void Warning(string message, string caption);

        void Error(string message, string caption);
    }
}
