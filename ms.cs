6Develop a C# program that simulates a shopping system with base class “Item” with attributes name, price, and quantity and Implement methods to displayItem() and calculateTotalPrice(). Derive two Classes from “Item” named “GroceryItem” and “StationaryItem” with attributes category and type respectively. Inherit common properties from the base class to the derived classes and Override the displayItems() and calculateTotalPrice() method in both derived classes and provide 5% discount on Grocery items and apply 2% tax on Stationary Items. Create instance of both classes to display the shopping details.

using System;
// Base class Item
class Item
{   protected string name;
    protected double price;
    protected int quantity;
    public Item(string name, double price, int quantity)
    {  this.name = name;
        this.price = price;
        this.quantity = quantity;    }
    public virtual void DisplayItem()
    {
        Console.WriteLine($"Name: {name}, Price: ${price}, Quantity: {quantity}");
    }

    public virtual double CalculateTotalPrice()
    {
        return price * quantity;
    }
}

// Derived class GroceryItem
class GroceryItem : Item
{
    private string category;

    public GroceryItem(string name, double price, int quantity, string category) : base(name, price, quantity)
    {
        this.category = category;
    }

    public override void DisplayItem()
    {
        base.DisplayItem();
        Console.WriteLine($"Category: {category}");
    }

    public override double CalculateTotalPrice()
    {
        // Apply 5% discount
        return base.CalculateTotalPrice() * 0.95;
    }
}

// Derived class StationaryItem
class StationaryItem : Item
{
    private string type;

    public StationaryItem(string name, double price, int quantity, string type) : base(name, price, quantity)
    {
        this.type = type;
    }

    public override void DisplayItem()
    {
        base.DisplayItem();
        Console.WriteLine($"Type: {type}");
    }

    public override double CalculateTotalPrice()
    {
        // Apply 2% tax
        return base.CalculateTotalPrice() * 1.02;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of both classes
        GroceryItem groceryItem = new GroceryItem("Apple", 1.5, 10, "Fruit");
        StationaryItem stationaryItem = new StationaryItem("Notebook", 2.0, 5, "Notebook");

        // Displaying shopping details
        Console.WriteLine("Grocery Item:");
        groceryItem.DisplayItem();
        Console.WriteLine($"Total Price: ${groceryItem.CalculateTotalPrice()}");

        Console.WriteLine("\nStationary Item:");
        stationaryItem.DisplayItem();
        Console.WriteLine($"Total Price: ${stationaryItem.CalculateTotalPrice()}");

        Console.ReadLine();
    }
7Create a restaurant ordering system where you have different types of menu items like appetizers, main courses, and desserts. Define an interface named IMenuItem with methods like GetMenuItemName(), GetPrice(), and GetIngredients(). Implement this interface in classes representing each type of menu item. Use the interface methods to display menu details and process customer orders.
using System;
using System;
using System.Collections.Generic;

// Interface for menu items
public interface IMenuItem
{
    string GetMenuItemName();
    double GetPrice();
    List<string> GetIngredients();
}

// Base class for menu items
public abstract class MenuItem : IMenuItem
{
    protected string name;
    protected double price;
    protected List<string> ingredients;

    public MenuItem(string name, double price, List<string> ingredients)
    {
        this.name = name;
        this.price = price;
        this.ingredients = ingredients;
    }

    public string GetMenuItemName()
    {
        return name;
    }

    public double GetPrice()
    {
        return price;
    }

    public List<string> GetIngredients()
    {
        return ingredients;
    }
}

// Appetizer class
public class Appetizer : MenuItem
{
    public Appetizer(string name, double price, List<string> ingredients) : base(name, price, ingredients)
    {
    }
}

// Main course class
public class MainCourse : MenuItem
{
    public MainCourse(string name, double price, List<string> ingredients) : base(name, price, ingredients)
    {
    }
}

// Dessert class
public class Dessert : MenuItem
{
    public Dessert(string name, double price, List<string> ingredients) : base(name, price, ingredients)
    {
    }
}

public class Restaurant
{
    private List<IMenuItem> menu;

    public Restaurant()
    {
        menu = new List<IMenuItem>();
    }

    public void AddMenuItem(IMenuItem menuItem)
    {
        menu.Add(menuItem);
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        foreach (var item in menu)
        {
            Console.WriteLine($"Name: {item.GetMenuItemName()}, Price: {item.GetPrice()}, Ingredients: {string.Join(", ", item.GetIngredients())}");
        }
    }

    public void ProcessOrder(IMenuItem item)
    {
        Console.WriteLine($"Processing order for {item.GetMenuItemName()}...");
        // Add order processing logic here
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create some menu items
        var appetizer = new Appetizer("Salad", 5.99, new List<string> { "Lettuce", "Tomato", "Cucumber" });
        var mainCourse = new MainCourse("Steak", 15.99, new List<string> { "Beef", "Potatoes", "Broccoli" });
        var dessert = new Dessert("Cake", 4.99, new List<string> { "Flour", "Sugar", "Eggs" });

        // Create a restaurant and add menu items
        var restaurant = new Restaurant();
        restaurant.AddMenuItem(appetizer);
        restaurant.AddMenuItem(mainCourse);
        restaurant.AddMenuItem(dessert);

        // Display the menu
        restaurant.DisplayMenu();

        // Example order
        restaurant.ProcessOrder(mainCourse);
    }
}





8 Design a C# program to create a shopping list of electronic goods & another of books. Provide options to add item at specified location, to append an item, to delete an item. The shopping lists have to be merged & sorted alphabetically.

using System;
using System.Collections.Generic;
using System.Linq;
class Program
{ static List<string> electronicGoods = new List<string>();
    static List<string> books = new List<string>();
    static void Main(string[] args)
    { bool exit = false;
        while (!exit)
        {
 Console.WriteLine("Select an option:");
 Console.WriteLine("1. Add item to electronic goods list");
 Console.WriteLine("2. Add item to books list");
 Console.WriteLine("3. Append item to electronic goods list");
 Console.WriteLine("4. Append item to books list");
Console.WriteLine("5.Add item to a specified location in electronic goods list");
Console.WriteLine("6. Add item to a specified location in books list");
Console.WriteLine("7. Delete item from electronic goods list");
Console.WriteLine("8. Delete item from books list");
Console.WriteLine("9. Merge and sort shopping lists");
Console.WriteLine("10. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            { case 1:
       Console.WriteLine("Enter electronic item:");
        string electronicItem = Console.ReadLine();
          electronicGoods.Add(electronicItem);
            break;
                case 2:
                    Console.WriteLine("Enter book:");
                    string book = Console.ReadLine();
                    books.Add(book);
                    break;
                case 3:
    Console.WriteLine("Enter electronic item to append:");
       string appendElectronicItem = Console.ReadLine();
        electronicGoods.Add(appendElectronicItem);
       break;
                case 4:
         Console.WriteLine("Enter book to append:");
              string appendBook = Console.ReadLine();
              books.Add(appendBook);
                    break;
                case 5:
         Console.WriteLine("Enter electronic item:");
         string insertElectronicItem = Console.ReadLine();
             Console.WriteLine("Enter index to insert:");
 int electronicIndex = Convert.ToInt32(Console.ReadLine());
electronicGoods.Insert(electronicIndex,insertElectronicItem);
                    break;
                case 6:
                 Console.WriteLine("Enter book:");
                    string insertBook = Console.ReadLine();
                Console.WriteLine("Enter index to insert:");
       int bookIndex = Convert.ToInt32(Console.ReadLine());
            books.Insert(bookIndex, insertBook);
                    break;
            case 7:
Console.WriteLine("Enter index of item to delete from electronic goods list:");
int deleteElectronicIndex = Convert.ToInt32(Console.ReadLine());
 if (deleteElectronicIndex >= 0 && deleteElectronicIndex < electronicGoods.Count)
     electronicGoods.RemoveAt(deleteElectronicIndex);
                    else
                     Console.WriteLine("Invalid index");
                    break;
                case 8:
Console.WriteLine("Enter index of item to delete from books list:");
   int deleteBookIndex = Convert.ToInt32(Console.ReadLine());
   if (deleteBookIndex >= 0 && deleteBookIndex < books.Count)
            books.RemoveAt(deleteBookIndex);
                    else
                        Console.WriteLine("Invalid index");
                    break;
                case 9:
                    MergeAndSortLists();
                    break;
                case 10:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            } } }
    static void MergeAndSortLists()
 {List<string> mergedList = new List<string>(electronicGoods);
     mergedList.AddRange(books);
        mergedList.Sort();
  Console.WriteLine("\nMerged and sorted shopping list:");
        foreach (string item in mergedList)
        {  Console.WriteLine(item);  }
    }}


9 Design a C# structure CUSTOMER, with data members - name, account number, balance & account status (enumerated type – current /overdue /delinquent). Write a C# program to implement the above through structure variables & display customer’s details categorized by account status.

// Enum to represent account status
enum AccountStatus
{
    Current,
    Overdue,
    Delinquent
}

// Structure to represent customer
struct Customer
{
    public string name;
    public int accountNumber;
    public double balance;
    public AccountStatus accountStatus;
}

class Program
{
    static void Main(string[] args)
    {
        // Creating structure variables for customers
        Customer[] customers = new Customer[3];

        // Initializing customer details
        customers[0].name = "John";
        customers[0].accountNumber = 1001;
        customers[0].balance = 5000.0;
        customers[0].accountStatus = AccountStatus.Current;

        customers[1].name = "Alice";
        customers[1].accountNumber = 1002;
        customers[1].balance = 200.0;
        customers[1].accountStatus = AccountStatus.Overdue;

        customers[2].name = "Bob";
        customers[2].accountNumber = 1003;
        customers[2].balance = -100.0;
        customers[2].accountStatus = AccountStatus.Delinquent;

        // Displaying customer details categorized by account status
        Console.WriteLine("Customer Details Categorized by Account Status:\n");

        foreach (Customer customer in customers)
        {
            Console.WriteLine("Name: " + customer.name);
            Console.WriteLine("Account Number: " + customer.accountNumber);
            Console.WriteLine("Balance: " + customer.balance);
            Console.WriteLine("Account Status: " + customer.accountStatus);
            Console.WriteLine();
        }
    }
}

