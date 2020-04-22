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
            bool circ = true;
            while (circ)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Введите логин и пароль:");
                Console.Write("Login(example:000950226): ");
                login = Console.ReadLine();

                Console.Write("Password: ");
                password = Console.ReadLine();
                //Проверить данные в базе и выдать сообщение при ошибке
            }
        }
        public static void Registration()
        {
            bool circ = false;
            int    day,        month,       year;
            string fname,      lname,       mname;
            string gender,     passport_id, nationality;
            string address,     status;
            string txt;  
            DateTime birth_date, expiry_date;
            List<string> ErrorList = new List<string>();
            User user = new User();
            do
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("РЕГИСТРАЦИЯ:");
                Console.WriteLine("--------------------------------------------------");
                Console.Write("Фамилия:        ");
                user.FisrtName = Console.ReadLine();

                Console.Write("Имя:            ");
                user.LastName = Console.ReadLine();
                
                Console.Write("Отчесвтво:      ");
                user.MiddleName = Console.ReadLine();
                
                Console.Write("Пол  ");
                user.Gender = Console.ReadLine();

                Console.WriteLine("Дата рождения:(dd.mm.yyyy)");
                txt = Console.ReadLine();
                if (txt[0] >= '0' && txt[0] <= 9 && txt[1] >= '0' && txt[1] <= 9)
                {
                    day = (int)txt[0] * 10 + (int)txt[1];
                } else {
                    circ = true;
                    ErrorList.Add("неверно введена дата рождения");
                }
                // вытащить из текста год, месяц, день;
                //birth_date = new DateTime(year, month, day);
                //user.BirthDate = bdate;
                Console.Write("Серия Паспорта  ");
                user.Passport_Id = Console.ReadLine();
            
                Console.Write("Гражданство:    ");
                user.Nationality = Console.ReadLine();

                Console.Write("Срок пасспорта(dd.mm.yyyy):");
                // вытащить из текста год, месяц, день;
                //expiry_date = new DateTime(year, month, day);
                //user.BirthDate = expiry_date;

                Console.Write("Адрес:");
                user.Address = Console.ReadLine();

                Console.Write("Статус(client/admin:)");
                user.User_Status = Console.ReadLine();

            }while (circ);
        }

    }
}
