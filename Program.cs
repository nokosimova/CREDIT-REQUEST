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
                if (command == 1 || command == 2) circ = false;
            }
            if (command == 1) { 
                    con = new SqlConnection(MSSqlDA.conString);
                    User user = new User();

                    con.Open();
                    circ = false; 
                    User.Authorization(con, ref user);
                    con.Close();
            } else 
                
                if (command == 2) { 
                    con = new SqlConnection(MSSqlDA.conString);
                    con.Open();
                    User new_user = User.Registration(); 
                    new_user.InsertUser(con); //добавляем нового пользователя, ПОКА НЕ РАБОТАЕТ
                    User.SelectAllUsers(con);
                    con.Close();
                    }
           
            
            Console.ReadKey();
        }

    }
}
