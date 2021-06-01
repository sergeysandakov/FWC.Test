using FunnyWaterCarrier.Models.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FunnyWaterCarrier
{
    public class ServiceClient
    {
        public void CreateDepartament(string name, Employee leader)  // Create dapartament
        {
            Departament departament = new Departament()
            {
                Name = name,
                Leader = leader
            };

            using (var dbContext = new AppDbContext())
            {
                if (departament.Leader != null)
                {
                    var lead = dbContext.Employees.Find(departament.Leader.Id);
                    departament.Leader = lead;
                }
                dbContext.Departaments.Add(departament);
                dbContext.SaveChanges();
            }
        } 

        public void CreateEmployee(string surname, string name, string patronymic, DateTime birthDate, Genders gender, Departament departament) // Create employee
        {
            Employee employee = new Employee()
            {
                Surname = surname,
                Name = name,
                Patronymic = patronymic,
                BirthDate = birthDate,
                Gender = gender,
                Departament = departament
            };

            using (var dbContext = new AppDbContext()) 
            {
                var div = dbContext.Departaments.Find(employee.Departament.Id);
                employee.Departament = div;
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
            }
        } 

        public void CreateOrder(int number, string partner, Employee worker) // Create order
        {
            Order order = new Order()
            {
                Number = number,
                Partner = partner,
                Worker = worker
            };

            using (var dbContext = new AppDbContext()) 
            {
                var work = dbContext.Employees.Find(order.Worker.Id); 
                order.Worker = work;
                dbContext.Orders.Add(order);
                dbContext.SaveChanges();
            }
        } 

        public void ChangeDepartament(Departament departament) // Update departament
        {
            using (var dbContext = new AppDbContext())
            {
                var newDivision = dbContext.Departaments.Find(departament.Id);
                newDivision.Name = departament.Name;
                newDivision.Leader = dbContext.Employees.Find(departament.Leader.Id);
                dbContext.SaveChanges();
            }
        } 

        public void ChangeEmployee(Employee employee) // Update employee
        {
            using (var dbContext = new AppDbContext())
            {
                Employee newEmployee = dbContext.Employees.Find(employee.Id);
                newEmployee.Surname = employee.Surname;
                newEmployee.Name = employee.Name;
                newEmployee.Patronymic = employee.Patronymic;
                newEmployee.BirthDate = employee.BirthDate;
                newEmployee.Gender = employee.Gender;
                newEmployee.Departament = dbContext.Departaments.Find(employee.Departament.Id);
                dbContext.SaveChanges();
            }
        } 

        public void ChangeOrder(Order order) // Update order
        {
            using (var dbContext = new AppDbContext())
            {
                Order newOrder = dbContext.Orders.Find(order.Id);
                newOrder.Number = order.Number;
                newOrder.Partner = order.Partner;
                newOrder.Worker = dbContext.Employees.Find(order.Worker.Id);
                dbContext.SaveChanges();
            }
        } 

        public List<Departament> GetDepartaments() // Creating a list of departaments
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Departaments.Include(x => x.Leader).ToList();
            }
        } 

        public List<Employee> GetEmployees() // Creating a list of employees
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Employees.Include(x => x.Departament).ToList();
            }
        } 

        public List<Employee> GetEmployeesInDepartament(Departament departament) // Creating a list of eployees
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Employees.Where(e => e.Departament.Id == departament.Id).Include(u => u.Departament).ToList();
            }
        }

        public List<Order> GetOrders() // Creating a list of orders
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Orders.Include(x => x.Worker).ToList();
            }
        }
    }
}
