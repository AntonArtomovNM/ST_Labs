using Lab2.Task3_Linq;
using Lab2.Task3_Linq.Models;

Console.WriteLine("Lab 2, Task 3: LINQ to Objects");

// 1) Написати запит для знаходження елементів масиву А, які включають пробіл.

string[] A =
{
    "Falluot 3", "Daxter 2", "System Shok 2", "Morrowind", "Pes 2013"
};

ShowIEnumerable(A, "1) Initial");

var A_result = A.GetElementsWithSpace();

ShowIEnumerable(A_result, "1) Elements with spaces");

// 2) Написати запит для знаходження негативних елементів масиву В.

int[] B =
{
    2, -7, -10, 6, 7, 9, 3
};

ShowIEnumerable(B, "2) Initial");

var B_result = B.GetNegatives();

ShowIEnumerable(B_result, "2) Negative elemetns");

// 3) Написати запит для знаходження всіх відтінків зеленого кольору в масиві С.

string[] C =
{
    "Light Green", "Red", "Green", "Yellow", "Purple", "Dark Green", "Light Red", "Dark Red", "Dark Yellow", "Light Yellow"
};

ShowIEnumerable(C, "3) Initial");

var C_result = C.GetGreenHues();

ShowIEnumerable(C_result, "3) Green hues");

// 4) Створити перелік автомобілів класу Car. Вибрати зі списку автомобілі BMW та вивести всю інформацію про них.

Car[] cars =
{
    new Car("BMW", "Black", 150, 5),
    new Car("Ford Motor", "Gray", 193, 4),
    new Car("BMW", "White", 250, 4),
    new Car("Ford Motor", "Blue", 180, 5),
    new Car("Saab", "Black", 200, 4),
    new Car("BMW", "Dark Red", 290, 4),
};

ShowIEnumerable(cars, "4) Initial");

var cars_result = cars.GetBMWCars();

ShowIEnumerable(cars_result, "4) BMW only");

// 5) Створити перелік продуктів класу Product. Вибрати продукти, які закінчилися і вивести всю інформацію про них.

Product[] products =
{
    new Product("Banana", 100, "Fruit"),
    new Product("Apple", 0, "Fruit"),
    new Product("Potato", 210, "Vegetable"),
    new Product("Tomato", 90, "Fruit, but don't put it in a fruit salad"),
    new Product("Watermelon", 0, "Fruit"),
    new Product("Corn", 0, "Vegetable")
};

ShowIEnumerable(products, "5) Initial");

var products_result = products.GetRunOutProducts();

ShowIEnumerable(products_result, "5) Run out products");

// 6) Вивести результуючий набір списків myCars та yourCars, що містить спільні елементи.

List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };

ShowIEnumerable(myCars, "5) My cars");
ShowIEnumerable(yourCars, "5) Your cars");

var intersect_result = myCars.GetCommonElements(yourCars);

ShowIEnumerable(intersect_result, "5) Our cars");

static void ShowIEnumerable<T>(IEnumerable<T> values, string collectionName)
{
    Console.WriteLine($"{collectionName}:");
    Console.WriteLine();
    
    foreach(var value in values)
    {
        Console.WriteLine(value);
    }

    Console.WriteLine();
}