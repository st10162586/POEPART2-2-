 using System;
using System.Collections.Generic;

class Recipe
{
    public string RecipeName { get; set; }
    public string IngredientName { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public string Description { get; set; }
    public int Calories { get; set; }
    public string FoodGroup { get; set; }

    public Recipe(string recipeName, string ingredientName, double quantity, string unit, string description, int calories, string foodGroup)
    {
        RecipeName = recipeName;
        IngredientName = ingredientName;
        Quantity = quantity;
        Unit = unit;
        Description = description;
        Calories = calories;
        FoodGroup = foodGroup;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Menu1 menu = new Menu1();
        menu.Run();
    }
}

class Menu1
{
    public List<Recipe> recipeList = new List<Recipe>();

    public void Run()
    {
        Creation creation = new Creation();

        while (true)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;

            Console.WriteLine("What would you like to do? (Enter a number)");
            Console.WriteLine("1: Enter recipe");
            Console.WriteLine("2: Display recipes");
            Console.WriteLine("3: Choose a recipe to display");
            Console.WriteLine("4: Scale recipe");
            Console.WriteLine("5: Reset to original scale");
            Console.WriteLine("6: Clear data");
            Console.WriteLine("7: Exit");

            int menuChoice;
            if (!int.TryParse(Console.ReadLine(), out menuChoice))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (menuChoice)
            {
                case 1:
                    creation.EnterRecipe();
                    break;
                case 2:
                    creation.DisplayRecipes();
                    break;
                case 3:
                    creation.ChooseRecipe();
                    break;
                case 4:
                    creation.ScaleRecipe();
                    break;
                case 5:
                    creation.ResetScale();
                    break;
                case 6:
                    creation.ClearData();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid menu choice. Please enter a number from 1 to 7.");
                    break;
            }
        }
    }

    class Creation
    {
        List<Recipe> recipeList = new List<Recipe>();

        public void EnterRecipe()
        {
            Console.WriteLine("How many recipes would you like to add: ");
            int numRecipes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numRecipes; i++)
            {
                Console.WriteLine("What is the name of the recipe: ");
                string recipeName = Console.ReadLine();

                Console.WriteLine("Enter the number of calories in the recipe: ");
                int calories = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the number of ingredients needed for the recipe: ");
                int numIngredients = int.Parse(Console.ReadLine());

                Recipe recipe = new Recipe(recipeName, "", 0, "", "", calories, "");

                for (int s = 0; s < numIngredients; s++)
                {
                    Console.WriteLine("Please add the name of ingredient " + (s + 1) + ": ");
                    string ingredientName = Console.ReadLine();

                    Console.WriteLine("Please add the quantity of " + ingredientName + ": ");
                    double quantity = double.Parse(Console.ReadLine());

                    Console.WriteLine("Please add the unit of measurement for " + ingredientName + " (e.g., ML, L, KG, grams): ");
                    string unit = Console.ReadLine();

                    Recipe ingredient = new Recipe(recipeName, ingredientName, quantity, unit, "", 0, "");
                    recipeList.Add(ingredient);
                }

                recipeList.Add(recipe);
            }

            Console.WriteLine("Recipe(s) added successfully!");
        }

        public void DisplayRecipes()
        {
            Console.WriteLine("Recipe List:");
            for (int i = 1; i <= recipeList.Count; i++)
            {
                Console.WriteLine(i + ": " + recipeList[i - 1].RecipeName);
            }
        }

        public void ChooseRecipe()
       {
    Console.WriteLine("Select a recipe to display:");
    for (int i = 0; i < recipeList.Count; i++)
    {
        Console.WriteLine((i + 1) + ": " + recipeList[i].RecipeName);
    }

    int recipeChoice;
    if (!int.TryParse(Console.ReadLine(), out recipeChoice) || recipeChoice < 1 || recipeChoice > recipeList.Count)
    {
        Console.WriteLine("Invalid recipe choice. Please enter a number within the range.");
        return;
    }

    Recipe selectedRecipe = recipeList[recipeChoice - 1];
    Console.WriteLine("Selected Recipe: " + selectedRecipe.RecipeName);
    Console.WriteLine("Calories: " + selectedRecipe.Calories);
    Console.WriteLine("Ingredients:");

    foreach (Recipe ingredient in recipeList)
    {
        if (ingredient.RecipeName == selectedRecipe.RecipeName)
        {
            Console.WriteLine("- " + ingredient.Quantity + " " + ingredient.Unit + " of " + ingredient.IngredientName);
        }
    }
    }

   public void ScaleRecipe()
  {
    Console.WriteLine("Enter the recipe name to scale:");
    string recipeName = Console.ReadLine();

    Recipe recipe = recipeList.Find(r => r.RecipeName == recipeName);
    if (recipe == null)
    {
        Console.WriteLine("Recipe not found.");
        return;
    }

    Console.WriteLine("Enter the scaling factor (e.g., 2 to double the recipe):");
    double scalingFactor = double.Parse(Console.ReadLine());

    foreach (Recipe ingredient in recipeList)
    {
        if (ingredient.RecipeName == recipeName)
        {
            ingredient.Quantity *= scalingFactor;
        }
    }

    Console.WriteLine("Recipe scaled successfully!");
   }

    public void ResetScale()
    {
    Console.WriteLine("Enter the recipe name to reset the scale:");
    string recipeName = Console.ReadLine();

    Recipe recipe = recipeList.Find(r => r.RecipeName == recipeName);
    if (recipe == null)
    {
        Console.WriteLine("Recipe not found.");
        return;
    }

    foreach (Recipe ingredient in recipeList)
    {
        if (ingredient.RecipeName == recipeName)
        {
            ingredient.Quantity = 0;
        }
    }

    Console.WriteLine("Recipe scale reset successfully!");
    }

    public void ClearData()
    {
    recipeList.Clear();
    Console.WriteLine("Recipe data cleared successfully!");
    }
  }
}