using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<User> users = new List<User>();

        Admin admin = new Admin { UserName = "AdminUser", Email = "admin@example.com" };
        admin.SetPassword("adminpass");

        Moderator moderator = new Moderator { UserName = "ModUser", Email = "mod@example.com" };
        moderator.SetPassword("modwrong");

        RegularUser regUser = new RegularUser { UserName = "RegUser", Email = "user@example.com" };
        regUser.SetPassword("userpass");


        users.Add(admin);
        users.Add(moderator);
        users.Add(regUser);

        Console.WriteLine("=== Інформація про користувачів ===");
        foreach (User user in users)
        {
            user.DisplayInfo();
        }

        Console.WriteLine("\n=== Тестування методів ===");
        foreach (User user in users)
        {
            if (user is Admin a)
                a.BlockUser(regUser);
            else if (user is Moderator m)
                m.ModerateContent();
            else if (user is RegularUser r)
                r.PostComment();
        }

        Console.WriteLine("\n=== Перевірка аутентифікації ===");
        Console.WriteLine($"{admin.UserName}: {(admin.Authenticate("adminpass") ? "Успішна" : "Невірний пароль")} аутентифікація");
        Console.WriteLine($"{moderator.UserName}: {(moderator.Authenticate("modpass") ? "Успішна" : "Невірний пароль")} аутентифікація");
        Console.WriteLine($"{regUser.UserName}: {(regUser.Authenticate("userpass") ? "Успішна" : "Невірний пароль")} аутентифікація");
    }
}