using System;
using System.Collections.Generic;

namespace FinanceManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Finance Manager!");

            // create a list of budget categories
            List<string> budgetCategories = new List<string>();
            budgetCategories.Add("Housing");
            budgetCategories.Add("Transportation");
            budgetCategories.Add("Food");
            budgetCategories.Add("Utilities");
            budgetCategories.Add("Entertainment");
            budgetCategories.Add("Miscellaneous");

            // prompt user to enter budget amounts for each category
            Dictionary<string, double> budgetAmounts = new Dictionary<string, double>();
            foreach (string category in budgetCategories)
            {
                Console.Write($"Enter budget amount for {category}: ");
                double budgetAmount = Convert.ToDouble(Console.ReadLine());
                budgetAmounts.Add(category, budgetAmount);
            }

            // create a list of expenses
            List<Expense> expenses = new List<Expense>();

            // prompt user to enter expenses
            while (true)
            {
                Console.Write("Enter expense name (or 'q' to quit): ");
                string expenseName = Console.ReadLine();
                if (expenseName.ToLower() == "q")
                {
                    break;
                }

                Console.Write("Enter expense category: ");
                string expenseCategory = Console.ReadLine();

                Console.Write("Enter expense amount: ");
                double expenseAmount = Convert.ToDouble(Console.ReadLine());

                Expense expense = new Expense(expenseName, expenseCategory, expenseAmount);
                expenses.Add(expense);
            }

            // calculate total expenses and budget amounts
            double totalExpenses = 0;
            Dictionary<string, double> totalBudgetAmounts = new Dictionary<string, double>();
            foreach (string category in budgetCategories)
            {
                double budgetAmount = budgetAmounts[category];
                double categoryExpenses = 0;
                foreach (Expense expense in expenses)
                {
                    if (expense.Category == category)
                    {
                        categoryExpenses += expense.Amount;
                        totalExpenses += expense.Amount;
                    }
                }
                totalBudgetAmounts.Add(category, budgetAmount);
                Console.WriteLine($"Total expenses for {category}: {categoryExpenses}");
                Console.WriteLine($"Budget amount for {category}: {budgetAmount}");
            }

            // display spending report
            Console.WriteLine($"Total expenses: {totalExpenses}");
            Console.WriteLine("Spending report:");
            foreach (Expense expense in expenses)
            {
                Console.WriteLine($"{expense.Name} ({expense.Category}): {expense.Amount}");
            }

            Console.ReadLine();
        }
    }

    class Expense
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Amount { get; set; }

        public Expense(string name, string category, double amount)
        {
            Name = name;
            Category = category;
            Amount = amount;
        }
    }
}
