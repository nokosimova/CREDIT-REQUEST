using System;
using UserSpace;
namespace CreditRequest
{
public static class ClientFunction
{
    public static void MainClientWindow(User user)
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Добро пожаловать, {user.LastName}!              |");
        Console.WriteLine("Выберите действия:                               |");
        Console.WriteLine("1 - Подать заявку на получение кредита           |");
        Console.WriteLine("2 - История заявок                               |");
        Console.WriteLine("3 - Мои кредиты                                  |");
        Console.WriteLine("4 - Выход                                        |");
        Console.WriteLine("--------------------------------------------------");
    }
    public static void CreditRequestHistory(int UserId)
    {}
    public static void ClientsCredits(int UserId)
    {}
    public static void CreditApplication(User user)
    {}
    public static void AccountsPayable(int creditId)
    {}
} 
}
