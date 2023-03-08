using System;
using System.Linq;

public class User
{
    public string Username { get; set; }
    private string _password;

    public string Password
    {
        get { return _password; }
        set
        {
            while (value.Length < 8 || !value.Any(char.IsUpper) || !value.Any(char.IsDigit))
            {
                Console.WriteLine("Password must be at least 8 characters long and contain at least one uppercase letter and one digit");
                Console.Write("Enter a valid password: ");
                value = Console.ReadLine();
            }
            _password = value;
        }
    }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}

public class UserArray
{
    private User[] _users;

    public UserArray(int size)
    {
        _users = new User[size];
    }

    public void AddUser(User user)
    {
        for (int i = 0; i < _users.Length; i++)
        {
            if (_users[i] == null)
            {
                _users[i] = user;
                return;
            }
        }

        Console.WriteLine("Array is full.");
    }

    public User this[int index]
    {
        get
        {
            if (index < 0 || index >= _users.Length)
            {
                Console.WriteLine("Index out of range.");
            }

            return _users[index];
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        UserArray userArray = new UserArray(10);

        Console.Write("Enter a username: ");
        string username = Console.ReadLine();

        Console.Write("Enter a password: ");
        string password = Console.ReadLine();

        User user1 = new User(username, password);
        userArray.AddUser(user1);

        Console.WriteLine("User added successfully.");

        Console.WriteLine(userArray[0].Username);
    }
}
