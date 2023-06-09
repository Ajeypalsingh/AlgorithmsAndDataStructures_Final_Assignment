
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
