using System;
using UserSpace;
namespace CreditRequest
{
public class ClientFunction
{
    public static void MainClientWindow(User user)
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
    public static void ClientsCredits(string user)
    {}
    public static void CreditApplication(string user)
    {}
    public static void AccountsPayable(int creditId)
    {}
} 
}
