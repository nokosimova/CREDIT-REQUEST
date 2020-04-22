using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CR_DataAccess;
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
                if (command == 1) { Authorization(); circ = false; }
                else if (command == 2) { Registration(); circ = false;}
                else Console.WriteLine("");
            }
            

           
            
            Console.ReadKey();
        }

        public static void Authorization()
        {
            string login , password;
            int count = 0;
            while (count == 0)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Введите логин и пароль:");
                Console.Write("Login: ");
                login = Console.ReadLine();

                Console.Write("Password: ");
                password = Console.ReadLine();
                //Проверить данные в базе и выдать сообщение при ошибке
            }
        }
        public static void Registration()
        {}

    }
}
