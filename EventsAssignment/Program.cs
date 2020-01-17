using EventsAssignment;
using System;
using System.Collections.Generic;

namespace CustomersReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer()
            {
                FirstName = "Joe",
                LastName = "Smith"
            };

            Customer customer2 = new Customer()
            {
                FirstName = "Jane",
                LastName = "Jones"
            };
            Customer customer3 = new Customer()
            {
                FirstName = "Jack",
                LastName = "Jump"
            };
            Customer customer4 = new Customer()
            {
                FirstName = "Jeff",
                LastName = "Run"
            };
            Customer customer5 = new Customer()
            {
                FirstName = "Jill",
                LastName = "Hill"
            };
            Customer customer6 = new Customer()
            {
                FirstName = "John",
                LastName = "Winstone"
            };

            Queue<Customer> customers = new Queue<Customer>();
            customers.Enqueue(customer1);
            customers.Enqueue(customer2);
            customers.Enqueue(customer3);
            customers.Enqueue(customer4);
            customers.Enqueue(customer5);
            customers.Enqueue(customer6);

            Table table = new Table();

            for (int i= 0; i < 6; i++)
            {
                Customer customerToBeSeated = customers.Peek();
                table.TableOpenEvent += customerToBeSeated.HandleTableState;
                table.Open();
                customers.Dequeue();
                table.TableOpenEvent -= customerToBeSeated.HandleTableState;
                customerToBeSeated.MealSwitchedEvent += HandleMealChange;
                foreach (Meals meal in Enum.GetValues(typeof(Meals)))
                {
                    customerToBeSeated.Meal = meal;
                }
                customerToBeSeated.MealSwitchedEvent -= HandleMealChange;
            }
            Console.WriteLine("Everyone is Full!");
            Console.ReadKey();
        }
        public static void HandleMealChange(object source, MealEventArgs e)
        {
            Console.WriteLine($"{e.firstName} {e.lastName} is having {e.meal}");
        }
    }    
}
