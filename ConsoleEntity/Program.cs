using ConsoleEntity;

var userManager = new UserManager();

while (true)
{
    Console.WriteLine("\n--- Student Management ---");
    Console.WriteLine("1. Create Student");
    Console.WriteLine("2. Read Students");
    Console.WriteLine("3. Update Student");
    Console.WriteLine("4. Delete Student");
    Console.WriteLine("5. Exit");
    Console.Write("Select an option: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            CreateUser();
            break;
        case "2":
            userManager.ReadUsers();
            break;
        case "3":
            UpdateUser();
            break;
        case "4":
            DeleteUser();
            break;
        case "5":
            Console.WriteLine("Exiting...");
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

void CreateUser()
{
    Console.Write("Enter Name: ");
    var name = Console.ReadLine();
    Console.Write("Enter Email: ");
    var email = Console.ReadLine();
    Console.Write("Enter Password: ");
    var password = Console.ReadLine();

    userManager.CreateUser(name, email, password);
}

void UpdateUser()
{
    Console.Write("Enter User ID to update: ");
    if (int.TryParse(Console.ReadLine(), out var id))
    {
        Console.Write("Enter New Name (leave blank to keep current): ");
        var name = Console.ReadLine();
        Console.Write("Enter New Email (leave blank to keep current): ");
        var email = Console.ReadLine();
        Console.Write("Enter New Password (leave blank to keep current): ");
        var password = Console.ReadLine();

        userManager.UpdateUser(id, name, email, password);
    }
    else
    {
        Console.WriteLine("Invalid ID.");
    }
}

void DeleteUser()
{
    Console.Write("Enter User ID to delete: ");
    if (int.TryParse(Console.ReadLine(), out var id))
    {
        userManager.DeleteUser(id);
    }
    else
    {
        Console.WriteLine("Invalid ID.");
    }
}