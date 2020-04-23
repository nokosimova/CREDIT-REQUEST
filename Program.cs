using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CR_DataAccess;
using UserSpace;
namespace CreditRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, command;
            bool circ = true;


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Добро пожаловать, Уважаемый ползователь!          |");
            Console.WriteLine("Выберите дальнейшие действия:                     |");
            Console.WriteLine("Войти в систему:-------1                          |");
            Console.WriteLine("Зарегестрироваться:----2                          |");
           /*for (i = 0; i <= 14; i++)
            {
              Console.WriteLine("                                                  |");   
            }*/
            while (circ)
            {
                Console.WriteLine("--------------------------------------------------");
                command = int.Parse(Console.ReadLine());
                if (command == 1) { User.Authorization(); circ = false; }
                else if (command == 2) { User.Registration(); circ = false;}
                else Console.WriteLine("");
            }
            

           
            
            Console.ReadKey();
        }

    }
}
