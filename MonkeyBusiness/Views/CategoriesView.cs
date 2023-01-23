using MonkeyBusiness.Handler;
using MonkeyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyBusiness.Views
{
    public class CategoriesView
    {
        public void ShowCategoriesView(AccountHandler handler)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Current categories: ");
                handler.ShowCategories();
                Console.WriteLine("What do you want to do?");
                int decision = ChoiceMenu();
                switch (decision)
                {
                    case 1:
                        CreateCategory(handler);
                        break;
                    case 2:
                        DeleteCategory(handler);
                        break;
                    case 3:
                        EditCategory(handler);
                        break;
                    case 4:
                        handler.Initialize();
                        break;
                    default:
                        break;
                }
            }
        }
        public int ChoiceMenu()
        {
            Console.WriteLine("(1) Create new Category");
            Console.WriteLine("(2) Delete category");
            Console.WriteLine("(3) Edit Categories");
            Console.WriteLine("(4) Exit");
            try
            {
                int decision = int.Parse(Console.ReadLine());
                if (decision is > 0 and < 5)
                {
                    return decision;
                }
                else
                {
                    throw new Exception("Number is out of bounds");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please select a valid option");
                Thread.Sleep(1000);
            }
            return 0;
        }
        public void CreateCategory(AccountHandler handler)
        {
            try
            {

                Console.WriteLine("Category name?");
                string newCat = Console.ReadLine();
                if (handler.categories.Count != 0)
                {
                    if (handler.categories.Where(c => c.Name == newCat).ToList().Count() != 0)
                    {
                        handler.categories.Add(new Models.Category(handler.categories.Last().Id, newCat));
                        handler.SaveCategoriesToJson();
                        Console.WriteLine("Category created!");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        throw new Exception("Category already exists");
                    }
                }
                else
                {
                    handler.categories.Add(new Models.Category(1, newCat));
                    handler.SaveCategoriesToJson();
                    Console.WriteLine("Category created!");
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please select a valid option");
                Thread.Sleep(1000);
            }
        }
        public void DeleteCategory(AccountHandler handler)
        {
            try
            {
                Console.WriteLine("Which category do you want to delete? (C) to cancel");
                string decision = Console.ReadLine();
                if (decision.ToLower() == "c")
                {
                    throw new Exception("Operation canceled");
                }
                if (int.Parse(decision) > handler.categories.Last().Id || int.Parse(decision) < 1)
                {
                    throw new Exception("Number is not valid, please select a valid number");
                }
                handler.categories.Remove(handler.categories.Where(c => c.Id == int.Parse(decision)).First());
                handler.UpdateCategoriesID();
                handler.SaveCategoriesToJson();
                Console.WriteLine("Category deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
            }
        }
        public void EditCategory(AccountHandler handler)
        {

        }
    }
}
