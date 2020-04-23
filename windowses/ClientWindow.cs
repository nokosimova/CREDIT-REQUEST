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
        Console.WriteLine("4 - Выход                                       |");
        Console.WriteLine("--------------------------------------------------");
    }
    public static void CreditRequestHistory(int UserId)
    {}
    public static void ClientsCredits(int UserId)
    {}
    public static Request CreditApplication(User user)
    {
        Request new_req = new Request();
        double percent;
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("ЗАЯВКА НА КРЕДИТ");
        Console.WriteLine("---------------------------------------");
        Console.Write("Сумма кредита(сомони): ");
        new_req.CreditSum = int.Parse(Console.ReadLine());

        Console.WriteLine("Цель кредита:");
        Console.WriteLine("бытовая техника-- 1");
        Console.WriteLine("ремонт----------- 2");
        Console.WriteLine("телефон---------- 3");
        new_req.CreditAim = Console.ReadLine();

        Console.WriteLine("Семейное положение:");
        Console.WriteLine("холост/незамужем-- 1");
        Console.WriteLine("в браке----------- 2");
        Console.WriteLine("в разводе -------- 3");
        Console.WriteLine("вдовец/вдова------ 4");
        new_req.MaritalStatus = Console.ReadLine();

        Console.Write("ваш доход(сомони): ");
        new_req.ClientEarning = int.Parse(Console.ReadLine());

        Console.Write("Срок кредита(12 / 6): ");
        new_req.CreditTerm = int.Parse(Console.ReadLine());

        new_req.Nationality = user.Nationality;
        new_req.ClientAge = user.BirthDate.Year;
        percent = (new_req.CreditSum/new_req.ClientEarning)*100;
        new_req.CreditPecrectFromEarn = Math.Round(percent,4);

        return new_req;

    }
    public static void AccountsPayable(int creditId)
    {}
} 
}
