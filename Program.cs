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
            int command=0;
            bool circ = true;
            SqlConnection con;
    Label1:
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Добро пожаловать, Уважаемый ползователь!          |");
            Console.WriteLine("Выберите дальнейшие действия:                     |");
            Console.WriteLine("Войти в систему:------------------1               |");
            Console.WriteLine("Зарегестрировать пользователя:----2               |");
            Console.WriteLine("Выйти из системы:-----------------3               |");
           /*for (i = 0; i <= 14; i++)
            {
              Console.WriteLine("                                                  |");   
            }*/
            
            while (circ)
            {
                Console.WriteLine("--------------------------------------------------");
                command = int.Parse(Console.ReadLine());
                if (command == 1 || command == 2 || command == 3) circ = false;
            }
            if (command == 1) { 
                    //con = new SqlConnection(MSSqlDA.conString);
                    User user = new User();

                    //con.Open();
                    circ = false; 
                    User.Authorization(ref user);
                    if (user.User_Status == "клиент")
                        User.WorkAsCLient(ref user);
                   // else if (user.User_Status == "админ")
                      //      user.WorkAsAdmin();
                    //con.Close();
            } else 
                
                if (command == 2) { 
                    con = new SqlConnection(MSSqlDA.conString);
                    con.Open();
                    User user = new User();
                    User.Authorization(ref user);
                    if (user.User_Status == "админ")
                    {    User new_user = User.Registration(); 
                         new_user.InsertUser(con); //добавляем нового пользователя
                    } else
                    {
                        Console.WriteLine("Добавлять пользователей могут только админы!");
                        circ = true;
                        goto Label1;
                    }
                    con.Close();
                } else 
                    Console.WriteLine("Всего доброго, заходите снова!");
            Console.ReadKey();
        }

    }
}
