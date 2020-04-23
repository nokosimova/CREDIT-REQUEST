using System;
using System.Collections.Generic;
namespace UserSpace 
{
public class User
{
    public int UserId{get; set;}
    public string FisrtName{get; set;}
    public string LastName{get; set;}
    public string MiddleName{get; set;}
    public string Passport_Id{get; set;}
    public string Gender{get; set;}
    public DateTime BirthDate{get; set;}
    public string Nationality{get; set;}
    public DateTime Expiry_Date{get; set;}// срок действия паспорта
    public string Address{get; set;}
    public string Login{get; set;}
    public string Password{get; set;}
    public string User_Status{get; set;} //клиент или администратор

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
    public static User Registration()
        {
            bool circ = false;
            int    day, month, year;
            string txt;  
            DateTime birth_date, expiry_date;
            List<string> ErrorList = new List<string>();
            User user = new User();

            do
            {
                day   = 0;
                month = 0;
                year  = 0;
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("РЕГИСТРАЦИЯ:");
                Console.WriteLine("--------------------------------------------------");
                Console.Write("Фамилия:        ");
                user.FisrtName = Console.ReadLine();

                Console.Write("Имя:            ");
                user.LastName = Console.ReadLine();
                
                Console.Write("Отчесвтво:      ");
                user.MiddleName = Console.ReadLine();
                
                Console.Write("Пол (М / Ж)");
                user.Gender = Console.ReadLine();

                Console.WriteLine("Дата рождения:(dd.mm.yyyy)");
                txt = Console.ReadLine();
                if (txt.Length != 10) 
                {
                    ErrorList.Add("Неверно введена дата рождения");
                    circ = true;
                } else {
                if (txt[0] >= '0' && txt[0] <= 9 && txt[1] >= '0' && txt[1] <= 9)
                    day = (int)txt[0] * 10 + (int)txt[1];
                if (txt[3] >= '0' && txt[3] <= 9 && txt[4] >= '0' && txt[4] <= 9)
                    month = (int)txt[3] * 10 + (int)txt[4];
                if (txt[6] >= '0' && txt[6] <= 9 && txt[7] >= '0' && txt[7] <= 9
                    && txt[8] >= '0' && txt[8] <= 9 && txt[9] >= '0' && txt[9] <= 9)
                    year = (int)txt[6]*1000 + (int)txt[7]*100 + (int)txt[8]*10 + (int)txt[9];
                if (day > 31 || day == 0 || month == 0 || month > 12 || year == 0 || year < 1900 || year > 2006)
                {
                    ErrorList.Add("Неверно введена дата рождения");
                    circ = true;
                } else
                {
                    birth_date = new DateTime(year, month, day);
                    user.BirthDate = birth_date;
                }
                }
                Console.Write("Серия Паспорта  ");
                user.Passport_Id = Console.ReadLine();
            
                Console.Write("Гражданство:    ");
                user.Nationality = Console.ReadLine();
               
                day   = 0;
                month = 0;
                year  = 0;
                Console.Write("Срок пасспорта(dd.mm.yyyy):");
                txt = Console.ReadLine();
                if (txt.Length != 10) 
                {
                    ErrorList.Add("Неверно введен срок паспорта");
                    circ = true;
                } else {
                if (txt[0] >= '0' && txt[0] <= 9 && txt[1] >= '0' && txt[1] <= 9)
                    day = (int)txt[0] * 10 + (int)txt[1];
                if (txt[3] >= '0' && txt[3] <= 9 && txt[4] >= '0' && txt[4] <= 9)
                    month = (int)txt[3] * 10 + (int)txt[4];
                if (txt[6] >= '0' && txt[6] <= 9 && txt[7] >= '0' && txt[7] <= 9
                    && txt[8] >= '0' && txt[8] <= 9 && txt[9] >= '0' && txt[9] <= 9)
                    year = (int)txt[6]*1000 + (int)txt[7]*100 + (int)txt[8]*10 + (int)txt[9];
                if (day > 31 || day == 0 || month == 0 || month > 12 || year == 0 || year < 1900 || year > 2006)
                {
                    ErrorList.Add("Неверно введен срок паспорта");
                    circ = true;
                } else
                {
                    expiry_date = new DateTime(year, month, day);
                    user.Expiry_Date = expiry_date;
                }
                }
                Console.Write("Адрес:");
                user.Address = Console.ReadLine();

                Console.Write("Статус(клиент / админ)");
                user.User_Status = Console.ReadLine();

                if (circ)
                {
                    Console.WriteLine("----------");
                    Console.WriteLine("ОШИБКА!!!!");
                    for (int i = 0; i < ErrorList.Count; i++)
                    {
                        Console.WriteLine(ErrorList[i]);
                    }
                }
            }while (circ);
            Console.WriteLine("\nУСПЕШНО! Пользователь зарегистрирован");
            return user;
        }
        public static void InsertUser()
        {}
        public static User FindUser(int UserId)
        {}
        public static void DeleteUser(int UserId)
        {}
        public static void UploadUser(int UserId)
        {}


}
public class CredRequest : User
{
    public int RequestId{get; set;}
    public int CreditSum{get; set;} // в сомони
    public string CreditAim{get; set;}
    public int CtreditTerm{get; set;} // в месяцах
    public string MaritalStatus{get; set;}
    public int ClientAge{get; set;}
    public int ClinetEarning{get; set;}
    public string PhoneNumber{get; set;}
    public int ClosedCreditCount{get; set;}
    public int DelayCreditCount{get; set;}

}
}