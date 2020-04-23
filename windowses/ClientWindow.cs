using System;
using UserSpace;
using System.Data.SqlClient;
using CR_DataAccess;
namespace CreditRequest
{
public static class ClientFunction
{
    public static void MainClientWindow()
    {
        
        Console.WriteLine("Выберите действия:                               |");
        Console.WriteLine("1 - Подать заявку на получение кредита           |");
        Console.WriteLine("2 - История заявок                               |");
        Console.WriteLine("3 - Мои кредиты                                  |");
        Console.WriteLine("4 - Выход                                       |");
        Console.WriteLine("--------------------------------------------------");
    }
    public static Request CreditApplication(User user)
    {
        Request new_req = new Request();
        double percent;
        int command;
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("ЗАЯВКА НА КРЕДИТ");
        Console.WriteLine("---------------------------------------");
        Console.Write("Сумма кредита(сомони): ");
        new_req.CreditSum = int.Parse(Console.ReadLine());

        Console.WriteLine("Цель кредита:");
        Console.WriteLine("бытовая техника-- 1");
        Console.WriteLine("ремонт----------- 2");
        Console.WriteLine("телефон---------- 3");
        command = int.Parse(Console.ReadLine());
        if (command== 1)
            new_req.CreditAim = "бытовая техника";
        else  
        if (command== 2)
            new_req.CreditAim = "ремонт";
        else 
        if (command== 3)
            new_req.CreditAim = "телефон";

        Console.WriteLine("Семейное положение:");
        Console.WriteLine("холост(а) - 1");
        Console.WriteLine("в браке--------------- 2");
        Console.WriteLine("в разводе ------------ 3");
        Console.WriteLine("вдовец(ва)------------ 4");
        command = int.Parse(Console.ReadLine());
        if (command== 2)
            new_req.MaritalStatus = "в браке";
        else  
        if (command== 3)
            new_req.MaritalStatus = "в разводе";
        else 
        if (command== 1)
            new_req.MaritalStatus = "холост(а)";
        else 
        if (command== 4)
            new_req.MaritalStatus = "вдовец(ва)";

        Console.Write("ваш доход(сомони): ");
        new_req.ClientEarning = int.Parse(Console.ReadLine());

        Console.Write("Срок кредита(12 / 6): ");
        new_req.CreditTerm = int.Parse(Console.ReadLine());

        new_req.Nationality = user.Nationality;
        new_req.ClientAge = user.BirthDate.Year;
        percent = (new_req.CreditSum/new_req.ClientEarning)*100;
        new_req.CreditPecrectFromEarn = Math.Round(percent,4);
        new_req.PhoneNumber = user.Login;
        new_req.ClosedCreditCount = user.ClosedCreditCount;
        new_req.DelayCreditCount = user.DelayCreditCount;
        return new_req;

    }
    public static void AccountsPayable(int creditId)
    {}
} 
}
