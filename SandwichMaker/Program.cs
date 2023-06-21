/*
Dictionary<string, int> ingredients = new Dictionary<string, int>
        {
            { "bread", 66 },
            { "ham", 72 },
            { "banana pepper", 10 },
            { "bologna", 57 },
            { "tomato", 4 },
            { "spinach", 7 },
            { "garlic aioli", 100 },
            { "chicken", 17 },
            { "corned beef", 53 },
            { "salami", 40 },
            { "butter", 102 },
            { "cheese, american", 104 },
            { "cheese, cheddar", 113 },
            { "avocado", 64 },
            { "cheese, havarti", 105 },
            { "mayonnaise", 94 },
            { "mustard", 10 },
            { "cucumber", 4 },
            { "sriracha", 15 },
            { "dressing, ranch", 73 },
            { "dressing, 1000 island", 59 },
            { "lettuce", 5 },
            { "green pepper", 3 },
            { "red onion", 6 },
        };


// User Input for Max and Min calories
Console.WriteLine("Enter the minimum number of calories you would like in your sandwich:");
int minCalories;
while (!int.TryParse(Console.ReadLine(), out minCalories))
{
    Console.WriteLine("Invalid input. Please enter a valid number:");
}

Console.WriteLine("Enter the maximum number of calories you would like in your sandwich:");
int maxCalories;
while (!int.TryParse(Console.ReadLine(), out maxCalories) || maxCalories <= minCalories)
{
    Console.WriteLine("Invalid input. Please enter a valid number:");
}


// Storing Ingredients to exclude in sandwich
string excludedIngredientsInput;
string[] excludedIngredientsArray;
do
{
    Console.WriteLine("\nDo you want to exclude any ingredients? (separated by / )");
    excludedIngredientsInput = Console.ReadLine();
    excludedIngredientsArray = excludedIngredientsInput.Split('/');

    if (excludedIngredientsArray.Contains("bread"))
    {
        Console.WriteLine("Note: The 'bread' ingredient cannot be excluded from the sandwich.");
    }
} while (excludedIngredientsArray.Contains("bread"));


// List to store ingrients to skip in sandwich
List<string> excludedIngredients = new List<string>();
foreach (string ingredient in excludedIngredientsArray)
{
    excludedIngredients.Add(ingredient.Trim().ToLower());
}

foreach (string ingridient in excludedIngredientsArray)
{
    Console.WriteLine($"You have excluded {ingridient}");
}



// Making sandwich
Console.WriteLine("\nMaking your sandwich\n");

int sandwichCalories = 0;
List<string> sandwich  = new List<string> { "bread" };



// I have taken reference from chatgpt for below functionality
while (sandwichCalories < minCalories || sandwichCalories > maxCalories)
{
    sandwich.Clear();
    sandwichCalories = 0;


    // Iterating over ingridients to skip excluded ingrideients
    foreach (KeyValuePair<string, int> ingredient in ingredients)
    {
        if (!excludedIngredients.Contains(ingredient.Key))
        {
            if (sandwichCalories + ingredient.Value <= maxCalories)
            {
                sandwich.Add(ingredient.Key);
                sandwichCalories += ingredient.Value;

                if (sandwichCalories >= minCalories && sandwichCalories <= maxCalories)
                {
                    sandwich.Add("bread");
                    break;
                }
            }
        }
    }

}

// Displaying ingridients that are added
foreach (string ingredient in sandwich)
{
    Console.WriteLine($"Adding {ingredient} ({ingredients[ingredient]} calories)");
}


// Sandwich calories
Console.WriteLine($"\nYour sandwich, with {sandwichCalories} calories, is ready. Enjoy!");

*/


using System.Diagnostics.Metrics;
using System.Numerics;
using System;

Dictionary<string, int> ingredients = new Dictionary<string, int>
        {
            { "bread", 66 },
            { "ham", 72 },
            { "bologna", 57 },
            { "chicken", 17 },
            { "corned beef", 53 },
            { "salami", 40 },
            { "cheese, american", 104 },
            { "cheese, cheddar", 113 },
            { "cheese, havarti", 105 },
            { "mayonnaise", 94 },
            { "mustard", 10 },
            { "butter", 102 },
            { "garlic aioli", 100 },
            { "sriracha", 15 },
            { "dressing, ranch", 73 },
            { "dressing, 1000 island", 59 },
            { "lettuce", 5 },
            { "tomato", 4 },
            { "cucumber", 4 },
            { "banana pepper", 10 },
            { "green pepper", 3 },
            { "red onion", 6 },
            { "spinach", 7 },
            { "avocado", 64 }
        };

// User Input for Calories Range....

Console.WriteLine("Please Enter minimum calories for Your sandwich :");
bool minValidInput = false;
int minCalories = 0;

while (!minValidInput)
{
    string input = Console.ReadLine().Trim();
    minValidInput = int.TryParse(input, out minCalories);
    if (!minValidInput)
    {
        Console.WriteLine("Please enter valid integer Input");
    }
}


Console.WriteLine();
bool maxValidInput = false;
int maxCalories = 0;


while (!maxValidInput)
{
    Console.WriteLine("Please Enter maximum calories for Your sandwich :");
    string input = Console.ReadLine().Trim();
    maxValidInput = int.TryParse(input, out maxCalories);

    if (!maxValidInput)
    {
        Console.WriteLine("Please enter valid integer Input");
    } else if (maxCalories <= minCalories)
    {
        Console.WriteLine("Maximum calories cannot be greater than minimum calories");
        maxValidInput = false;
    }
}

// User input for Item to exclude in sandwich....
Console.WriteLine();
Console.WriteLine("Please Enter items to exclude from Your sandwich (separated by space):");

bool validItem = false;
string itemsToSkip = "";

while (!validItem)
{
    try
    {
        itemsToSkip = Console.ReadLine();
        validInput(itemsToSkip);
        validItem = true;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


// Function to validate input as string only
static void validInput (string input)
{
    string itemWithoutSpace = input.Replace(" ", "");
    foreach (char c in itemWithoutSpace)
    {
        if (!char.IsLetter(c))
        {
            throw new Exception("Please enter only alphabetical characters");
        }
    }
}

// Array to store excluded items 
string[] excludedItems = itemsToSkip.ToLower().Split(" ").ToArray();
List<string> excluded = new List<string>();
foreach (string excludedItem in excludedItems)
{
    if (excludedItem == "bread")
    {
        Console.WriteLine("\nBread cannot be excluded from sandwich. \n");
        continue;
    }

    if (!string.IsNullOrEmpty(excludedItem))
    {
        excluded.Add(excludedItem);
        Console.WriteLine($"You excluded '{excludedItem}' from sandwich");

    }
    else
    {
        Console.WriteLine("You have excluded nothing....");
    }
}
Console.WriteLine();




// Making sandwich

Console.WriteLine("Making your sandwich");
Console.WriteLine();

int sandwichcalories = 0;
List <string> sandwich = new List<string>();

foreach (KeyValuePair<string, int> ingredient in ingredients)
{
    if (!excluded.Contains(ingredient.Key))
    {
        if (ingredient.Value + sandwichcalories + 66 < maxCalories)
        {
        sandwich.Add(ingredient.Key);
        sandwichcalories += ingredient.Value;

            if (sandwichcalories >= minCalories && sandwichcalories <= maxCalories)
            {
                sandwich.Add("bread");
                break;
            }
        }

    }
}

foreach (string s in sandwich)
{
    Console.WriteLine($"Adding '{s}' having {ingredients[s]} calories");
}

Console.WriteLine($"\nPlease enjoy your sandwich with total {sandwichcalories} calories");




