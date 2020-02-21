using System;
using System.Collections.Generic;
using Menu = GoldBadgeConsoleApps.CafeMenu.Menu;

namespace GoldBadgeConsoleApps
{
    class cafeUI
    {

        public Repo _menu = new Repo();


        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            bool basecase = true;
            while (basecase)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Komodo Cafe Menu System.\n" +
                    "please select one of the following options\n" +
                    "1) Show all Menu Items. \n" +
                    "2) Show a Specific Item on the Menu. \n" +
                    "3) Add a new Item to the Menu. \n" +
                    "4) Remove an Item from the menu. \n" +
                    "5) Change an Item on the menu.\n" +
                    "6) Exit.");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowMenuItems();
                        basecase = true;
                        break;
                    case "2":
                        ShowItemByName();
                        basecase = true;
                        break;
                    case "3":
                        AddItem();
                        basecase = true;
                        break;
                    case "4":
                        RemoveItem();
                        basecase = true;
                        break;
                    case "5":
                        UpdateItem();
                        basecase = true;
                        break;
                    case "6":
                        Console.Clear();
                        basecase = false;
                        break;
                    default:
                        RunMenu();
                        userInput = "";
                        break;
                }

            }
        }
        private void ShowMenuItems()
        {
            Console.Clear();
            List<Menu> menuDirectory = _menu.GetAllMenuItems();
            foreach (Menu menu in menuDirectory)
            {

                string ingredients = "";

                int ingLen = menu.Ingredients.Count;
                int counter = 0;
                while (counter < ingLen)
                {
                    ingredients = ingredients + " " + menu.Ingredients[counter];
                    counter += 1;
                }

                Console.WriteLine($"Meal name: {menu.MealName}\n" +
                    $"Meal name: {ingredients}\n" +
                    $"Meal name: {menu.Description}\n" +
                    $"Meal name: {menu.Price}\n" +
                    $"Meal name: {menu.MealNumber}\n");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            RunMenu();
        }
        private void ShowItemByName()
        {
            //List<Menu> menuDirectory = _menu.GetAllMenuItems();
            Console.WriteLine("Please enter the name of a menu item");
            string name = Console.ReadLine();
            Menu menu = _menu.GetMenuByName(name);



            string ingredients = "";

            int ingLen = menu.Ingredients.Count;
            int counter = 0;
            while (counter < ingLen)
            {
                ingredients = ingredients + " " + menu.Ingredients[counter];
                counter += 1;
            }

            //foreach (Menu menu in menuDirectory)
            //{
            //    if (menu.MealName == name)
            //    {
            Console.WriteLine($"Meal name: {menu.MealName}\n" +
            $"Meal name: {ingredients}\n" +
            $"Meal name: {menu.Description}\n" +
            $"Meal name: {menu.Price}\n" +
            $"Meal name: {menu.MealNumber}\n");
            Console.ReadKey();
            //    }
            //}
            RunMenu();
        }
        private void AddItem()
        {
            Menu menuinput = new Menu();
            List<Menu> menuDirectory = _menu.GetAllMenuItems();
            Console.WriteLine("Please enter the name of the new menu item.");
            string menuname = Console.ReadLine().ToLower();
            foreach (Menu menu in menuDirectory)
            {
                if (menu.MealName == menuname)
                {
                    Console.WriteLine($"Meal name taken, please enter a new one or go to main menu and select edit listing.\n" +
                        $"to return to main menu please press 1, to try again press any other key.");
                    int userinput = Console.Read();
                    if (userinput == 1)
                    {
                        RunMenu();
                    }
                    else
                    {
                        AddItem();
                    }
                }
            }
            menuinput.MealName = menuname;
            Console.WriteLine("Please enter the the list of ingredients for the new menu item.");
            List<string> menuIngredients = new List<string>();
            bool cont = true;
            while (cont)
            {
                menuIngredients.Add(Console.ReadLine());
                Console.WriteLine("Would you like to add another ingredient? Type yes to continue.");
                string userInput = Console.ReadLine().ToLower();
                if (userInput != "yes")
                {
                    cont = false;
                }
            }
            menuinput.Ingredients = menuIngredients;
            cont = true;
            Console.WriteLine("Please enter a description for the new Menu Item.");
            while (cont)
            {
                string userInput = Console.ReadLine();
                Console.WriteLine($"Your description is:\n" +
                    $"{userInput}\n" +
                    $"\n" +
                    $"Are you satisfied with this description?");
                string yes = Console.ReadLine().ToLower();
                if (yes == "yes")
                {
                    cont = false;
                }
                menuinput.Description = userInput;
            }
            cont = true;
            Console.WriteLine("Please enter a price.");
            while (cont)
            {
                string userInput = Console.ReadLine();
                Console.WriteLine($"Your price is:\n" +
                    $"{userInput}\n" +
                    $"\n" +
                    $"Are you satisfied with this price?");
                string yes = Console.ReadLine().ToLower();
                if (yes == "yes")
                {
                    cont = false;
                }
                menuinput.Price = userInput;

            }
            menuinput.MealNumber = (menuDirectory.Count + 1);
            cont = true;


            string ingredients = "";

            int ingLen = menuIngredients.Count;
            int counter = 0;
            while (counter < ingLen)
            {
                ingredients = ingredients + " " + menuIngredients[counter];
                counter += 1;
            }

            Console.WriteLine($"Your new Menu Item has the attributes:\n" +
                    $"Meal name: {menuinput.MealName}\n" +
                    $"Meal name: {ingredients}\n" +
                    $"Meal name: {menuinput.Description}\n" +
                    $"Meal name: {menuinput.Price}\n" +
                    $"Meal name: {menuinput.MealNumber}\n" +
                    $"\n" +
                    $"Are you satisfied with these Attributes? Type yes to submit to Menu. Type anything else to start over.");
            string yesOrNo = Console.ReadLine().ToLower();
            if (yesOrNo == "yes")
            {
                cont = false;
            }
            if (cont)
            {
                AddItem();
            }
            else
            {
                _menu.AddItemsToMenu(menuinput);
            }
            Console.WriteLine("your menu item has been added");
            Console.ReadKey();
            RunMenu();
        }
        private void RemoveItem()
        {
            List<Menu> menuDirectory = _menu.GetAllMenuItems();
            Console.WriteLine("What is the name of the item would you like to remove?");
            string menuItem = Console.ReadLine().ToLower();
           

            foreach (Menu menu in menuDirectory)
            {
                if (menuItem == menu.MealName)
                {
                    Console.WriteLine($"Would you like to delete {menu.MealName} from the menu? yes/no");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "yes")
                    {
                        _menu.RemoveItemFromMenu(menu);
                        Console.WriteLine($"{menuItem} has been deleted");
                        Console.ReadKey();
                        RunMenu();
                    }
                    else
                    {
                        Console.WriteLine("You will be returned to the main menu.");
                        Console.ReadKey();
                        RunMenu();
                    }

                }
            }

            Console.WriteLine($"{menuItem} Is not in the menu, please enter a new Menu Item.");
            RemoveItem();

        }
        private void UpdateItem()
        {
            List<Menu> menuDirectory = _menu.GetAllMenuItems();
            Menu menuInput = new Menu();
            Console.WriteLine("What is the name of the item would you like to update?");
            string menuItem = Console.ReadLine().ToLower();
            foreach (Menu menu in menuDirectory)
            {
                if (menuItem == menu.MealName)
                {
                    Console.WriteLine($"Would you like to update {menu.MealName}? yes/no");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "yes")
                    {

                        Console.WriteLine("Please enter the the updated list of ingredients.");
                        List<string> menuIngredients = new List<string>();
                        bool cont = true;
                        while (cont)
                        {
                            menuIngredients.Add(Console.ReadLine());
                            Console.WriteLine("Would you like to add another ingredient? Type yes to continue.");
                            string userInput = Console.ReadLine().ToLower();
                            if (userInput != "yes")
                            {
                                cont = false;
                            }
                        }
                        Console.WriteLine($"Your updated ingredient list is {menuIngredients}, are you satisfied with this list? yes/no");
                        string input = Console.ReadLine().ToLower();
                        if (input == "yes")
                            menuInput.Ingredients = menuIngredients;
                        else
                        {
                            UpdateItem();
                        }
                        cont = true;
                        Console.WriteLine("Please enter a description for the new Menu Item.");
                        while (cont)
                        {
                            string userInput = Console.ReadLine();
                            Console.WriteLine($"Your description is:\n" +
                                $"{userInput}\n" +
                                $"\n" +
                                $"Are you satisfied with this description?");
                            string yes = Console.ReadLine().ToLower();
                            if (yes == "yes")
                            {
                                cont = false;
                            }
                            menuInput.Description = userInput;
                        }
                        cont = true;
                        while (cont)
                        {
                            string userInput = Console.ReadLine();
                            Console.WriteLine($"Your price is:\n" +
                                $"{userInput}\n" +
                                $"\n" +
                                $"Are you satisfied with this price?");
                            string yes = Console.ReadLine().ToLower();
                            if (yes == "yes")
                            {
                                cont = false;
                            }
                            menuInput.Price = userInput;
                        }
                        menuInput.MealNumber = (menuDirectory.Count + 1);
                        cont = true;
                        string ingredients = "";

                        int ingLen = menuIngredients.Count;
                        int counter = 0;
                        while (counter < ingLen)
                        {
                            ingredients = ingredients + " " + menuIngredients[counter];
                            counter += 1;
                        }

                        Console.WriteLine($"Your new Menu Item has the attributes:\n" +
                                $"Meal name: {menuInput.MealName}\n" +
                                $"Meal name: {ingredients}\n" +
                                $"Meal name: {menuInput.Description}\n" +
                                $"Meal name: {menuInput.Price}\n" +
                                $"Meal name: {menuInput.MealNumber}\n" +
                                $"\n" +
                                $"Are you satisfied with these Attributes? Type yes to submit to Menu. Type anything else to start over.");
                        string yesOrNo = Console.ReadLine().ToLower();
                        if (yesOrNo == "yes")
                        {
                            cont = false;
                        }
                        if (cont)
                        {
                            UpdateItem();
                        }
                        else
                        {
                            _menu.UpdateItem(menu.MealName, menuInput);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You will be returned to the main menu.");
                        Console.ReadKey();
                        RunMenu();
                    }

                }
            }
            Console.WriteLine($"{menuItem} Is not in the menu, please enter a new Menu Item.");
            UpdateItem();
        }


    }
}
