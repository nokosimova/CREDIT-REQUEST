using System;
using UserSpace;
namespace CreditRequest
{
public static class WorkWithClient
{
    public static void MainWindow(User user)
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Добро пожаловать, {user.LastName}!              |");
        Console.WriteLine("Выберите действия:                               |");
        Console.WriteLine("1 - Подать заявку на получение кредита           |");
        Console.WriteLine("2 - История заявок                               |");
        Console.WriteLine("3 - Мои кредиты                                  |");
        Console.WriteLine("--------------------------------------------------");
    }
    public static void CreditRequestHistory(string user)
    {}
    public static void UsersCredit(string user)
    {}
    public static void CreditApplication(string user)
    {}
    public static void AccountsPayable(int creditId)
    {}
} 
}