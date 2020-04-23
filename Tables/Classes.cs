using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CreditRequest;
using CR_DataAccess;

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
    public int ClosedCreditCount{get; set;}
    public int DelayCreditCount{get; set;}

    public string User_Status{get; set;} //клиент или администратор

        public static void Authorization( ref User user)
        {
            string login , password;
            bool circ = true;
            SqlConnection con = new SqlConnection(MSSqlDA.conString);
            con.Open();
            while (circ)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Введите логин и пароль:");
                Console.Write("Login(example:000950226): ");
                login = Console.ReadLine();

                Console.Write("Password: ");
                password = Console.ReadLine();
                user = User.SelectByLogin(con, login, password);
                if (user.Login == login && user.Password == password)
                    circ = false;
                else
                {
                    Console.WriteLine("Ошибка! Неверно введён логин или пароль.");
                    Console.WriteLine("Попробуйте ещё раз");
                }
            }
            con.Close();  
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
                
                Console.Write("Пол (мужской / женский)");
                user.Gender = Console.ReadLine();

                Console.Write("Дата рождения:(dd.mm.yyyy)");
                txt = Console.ReadLine();
                if (txt.Length != 10) 
                {
                    ErrorList.Add("Неверно введена дата рождения");
                    circ = true;
                } else {
                if ((int)txt[0] >= 48 && (int)txt[0] <= 57 && (int)txt[1] >= 48 && (int)txt[1] <= 57)
                    day = ((int)txt[0]-48) * 10 + (int)txt[1]-48;
                if ((int)txt[3] >= 48 && (int)txt[3] <= 57 && (int)txt[4] >= 48 && (int)txt[4] <= 57)
                    month = ((int)txt[3]-48) * 10 + (int)txt[4]-48;
                if ((int)txt[6] >= 48 && (int)txt[6] <= 57 && (int)txt[7] >= 48 && (int)txt[7] <= 57
                    && (int)txt[8] >= 48 && (int)txt[8] <= 57 && (int)txt[9] >= 48 && (int)txt[9] <= 57)
                    year = ((int)txt[6]-48)*1000 + ((int)txt[7]-48)*100 + ((int)txt[8]-48)*10 + (int)txt[9]-48;
              //  Console.WriteLine($"{day}  {month}  {year}");
                if (day > 31 || day == 0 || month == 0 || month > 12 || year == 0 || year < 1900 || year > 2006)
                {
                    ErrorList.Add("Неверно введена дата рождения");
                    circ = true;
                } else
                {
                    birth_date = new DateTime(year, month, day);
                    user.BirthDate = birth_date;
                    circ = false;
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
                   // Console.WriteLine($"{(int)txt[0]}, {(int)txt[1]}, {(int)txt[3]}, {(int)txt[4]}, {(int)txt[6]}, {(int)txt[7]}, {(int)txt[8]}, {(int)txt[9]}");
                if ((int)txt[0] >= 48 && (int)txt[0] <= 57 && (int)txt[1] >= 48 && (int)txt[1] <= 57)
                    day = ((int)txt[0]-48) * 10 + (int)txt[1]-48;
                if ((int)txt[3] >= 48 && (int)txt[3] <= 57 && (int)txt[4] >= 48 && (int)txt[4] <= 57)
                    month = ((int)txt[3]-48) * 10 + (int)txt[4]-48;
                if ((int)txt[6] >= 48 && (int)txt[6] <= 57 && (int)txt[7] >= 48 && (int)txt[7] <= 57
                    && (int)txt[8] >= 48 && (int)txt[8] <= 57 && (int)txt[9] >= 48 && (int)txt[9] <= 57)
                    year = ((int)txt[6]-48)*1000 + ((int)txt[7]-48)*100 + ((int)txt[8]-48)*10 + (int)txt[9]-48;
               // Console.WriteLine($"{day}  {month}  {year}");
                if (day > 31 || day == 0 || month == 0 || month > 12 || year == 0 || year < 2020)
                {
                    ErrorList.Add("Неверно введен срок паспорта");
                    circ = true;
                } else
                {
                    expiry_date = new DateTime(year, month, day);
                    user.Expiry_Date = expiry_date;
                    circ = false;
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
                    ErrorList.Clear();
                }
            }while (circ);
            Console.Write("Login:  ");
            user.Login = Console.ReadLine();

            Console.Write("Password:  ");
            user.Password = Console.ReadLine();
            return user;
        }
        //добавляет пользователя в таблицу UserTable
        public void InsertUser(SqlConnection con)//DONE
        {
            string bdate = BirthDate.ToString("MM/dd/yyyy");
            string exdate = Expiry_Date.ToString("MM/dd/yyyy");

            string insertSqlCommand = string.Format($"insert into User_Table([FirstName],[LastName],[MiddleName],[Login],[Password],[Gender],[BirthDate],[Passport_Id],[Nationality],[Expire_Date],[Address],[User_Status],[ClosedCreditCount],[DelayCreditCount]) Values('{FisrtName}', '{LastName}','{MiddleName}','{Login}','{Password}','{Gender}','{bdate}','{Passport_Id}','{Nationality}','{exdate}','{Address}','{User_Status}','{0}','{0}')");
            SqlCommand command = new SqlCommand(insertSqlCommand, con);
            var result = command.ExecuteNonQuery();
            
            if (result > 0) 
                Console.WriteLine("Данные успешно добавлены!");
        }
        public static void SelectAllUsers(SqlConnection con)//DONE
        {
            string commandText = "Select * from User_Table";
            SqlCommand command = new SqlCommand(commandText, con);

            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Login |             ФИО                   |Дата рождения| Серия паспорта |Статус|");
            while (reader.Read())
            {
                System.Console.WriteLine($"{reader.GetValue("Login")} |{reader.GetValue("FirstName")} {reader.GetValue("LastName")} {reader.GetValue("MiddleName")} |{reader.GetValue("BirthDate")} |{reader.GetValue("Passport_Id")} | {reader.GetValue("User_Status")}");
            }
            reader.Close();
        }
        public static User SelectByLogin(SqlConnection con, string Login, string Password)//DONE
        {
            string commandText = $"Select* from User_Table where User_Table.Login = {Login}";
            SqlCommand command = new SqlCommand(commandText, con);
            User user =new User();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user.UserId = (int)(reader.GetValue("UserId"));
                user.FisrtName=(string)reader.GetValue("FirstName");
                user.LastName=(string)reader.GetValue("LastName");
                user.MiddleName=(string)reader.GetValue("MiddleName");
                user.Login = (string)reader.GetValue("Login");
                user.Password = (string)reader.GetValue("Password");
                user.Gender = (string)reader.GetValue("Gender");
                user.BirthDate = (DateTime)reader.GetValue("BirthDate");
                user.Passport_Id = (string)reader.GetValue("Passport_Id");
                user.Nationality = (string)reader.GetValue("Nationality");
                user.Address= (string)reader.GetValue("Address");
                user.User_Status = (string)reader.GetValue("User_Status");
            }
            reader.Close();
            return user;
        }
        public static void WorkAsCLient(ref User user)
        {
            int command;
            bool circ = true;
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Добро пожаловать, {user.LastName}!              |");
            do{
               ClientFunction.MainClientWindow();
               Console.Write("действие: ");
               command = int.Parse(Console.ReadLine());
               if (command == 1)
               {
                   SqlConnection con = new SqlConnection(MSSqlDA.conString);
                   con.Open();
                   Request new_request = ClientFunction.CreditApplication(user); //заполнение заявки на кредит
                   new_request.InsertRequest(con, ref user);
                   con.Close();
                   //...
                   //circ = false;
               } else if (command == 2)
                 { 
                    SqlConnection con = new SqlConnection(MSSqlDA.conString);
                    con.Open();
                    Request.CreditRequestHistory(con, user.UserId);
                    con.Close();
                    //circ = false;
                 } else if (command == 3)
                   {
                       SqlConnection con = new SqlConnection(MSSqlDA.conString);
                       con.Open();
                       Request.ClientsCredits(con, user.UserId);
                       con.Close();
                    //   circ = false;
                   }
                   else if (command == 4)
                       circ = false;
                   else {
                       Console.WriteLine("Неверная команда, попробуйте ещё раз");
                   }
            } while(circ);
        }
        public void WorkAsAdmin()
        {}
}
public class Request:User
{
    public int RequestId{get; set;}
    public int CreditSum{get; set;} // в сомони
    public string CreditAim{get; set;}
    public int CreditTerm{get; set;} // в месяцах
    public string MaritalStatus{get; set;}
    public int ClientAge{get; set;}
    public int ClientEarning{get; set;}
    public string PhoneNumber{get; set;}
    public double CreditPecrectFromEarn{get;set;}//процент кредита от дохода

    public string Credit_Status{get; set;}
    public void InsertRequest(SqlConnection con, ref User user)
    {
        string commandText = $"Select UserId from User_Table where User_Table.Login = {user.Login}";
        SqlCommand command = new SqlCommand(commandText, con);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
            user.UserId = (int)(reader.GetValue("UserId"));
        reader.Close();
        
        string insertSqlCommand = string.Format($"insert into Request_Table([UserId],[ClientFIO],[ClGender],[Nationality],[CreditSum],[CreditAim],[CreditTerm],[MaritalStatus],[ClientAge],[ClientEarning],[PhoneNumber]) Values('{user.UserId}','{user.FisrtName + user.LastName + user.MiddleName}','{user.Gender}','{user.Nationality}','{CreditSum}','{CreditAim}','{CreditTerm}','{MaritalStatus}','{ClientAge}','{ClientEarning}','{PhoneNumber}')");
        command = new SqlCommand(insertSqlCommand, con);
        var result = command.ExecuteNonQuery();
            
        if (result > 0) 
            Console.WriteLine("Запрос отправлен!");
    }
    public static void SelectAllRequest(SqlConnection con) // for admin work
    {
        string commandText = "Select * from Request_Table";
            SqlCommand command = new SqlCommand(commandText, con);

            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("----------------------------------------------------------------------");
            //Console.WriteLine("Id |               ФИО                |  Пол  | Серия паспорта |Статус|");
            while (reader.Read())
            {
                System.Console.WriteLine($"{reader.GetValue("RequestId")} |{reader.GetValue("FirstName")} {reader.GetValue("LastName")} {reader.GetValue("MiddleName")} |{reader.GetValue("ClientAge")} |{reader.GetValue("CreditSum")} | {reader.GetValue("Credit_Status")}");
            }
            reader.Close();
    }
 /*   public static Request SelectByUserId(SqlConnection con, int UserId) // for client
    {string commandText = $"Select r.RequestId, u.FirstName, u.LastName,u.Gender, r.CreditSum, r.Credit_Status from Request_Table r, User_Table u where (r.UserId = 3 and u.UserId = 3)";
            SqlCommand command = new SqlCommand(commandText, con);
            Request request =new Request();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                request.RequestId = (int)(reader.GetValue("requestId"));
                request.FisrtName = (string)reader.GetValue("FirstName");
                request.LastName = (string)reader.GetValue("LastName");
                request.MiddleName = (string)reader.GetValue("MiddleName");
                request.Login = (string)reader.GetValue("Login");
                request.Password = (string)reader.GetValue("Password");
                request.Gender = (string)reader.GetValue("Gender");
                request.BirthDate = (DateTime)reader.GetValue("BirthDate");
                request.Passport_Id = (string)reader.GetValue("Passport_Id");
                request.Nationality = (string)reader.GetValue("Nationality");
                request.Address= (string)reader.GetValue("Address");
                request.Credit_Status = (string)reader.GetValue("Credit_Status");
            }
            reader.Close();
            return request;

    }*/
    public static void CreditRequestHistory(SqlConnection con, int UserId)
    {
        string commandText = $"Select r.RequestId, u.FirstName, u.LastName,u.Gender, r.CreditSum,r.CreditAim, r.CreditTerm, r.Credit_Status from Request_Table r, User_Table u where (r.UserId = {UserId} and u.UserId = {UserId})";
        SqlCommand command = new SqlCommand(commandText, con);
        SqlDataReader reader = command.ExecuteReader();
        Console.WriteLine("История заявок:");
        while(reader.Read())
        {
            System.Console.WriteLine($"{reader.GetValue("RequestId")} | {reader.GetValue("FirstName")}{reader.GetValue("LastName")} | {reader.GetValue("Gender")}|{reader.GetValue("CreditSum")} |{reader.GetValue("CreditAim")}|{reader.GetValue("CreditTerm")}| {reader.GetValue("Credit_Status")}"); 
        }
        reader.Close();
    }

    public static void ClientsCredits(SqlConnection con, int UserId)
    {
        string commandText = $"Select r.RequestId, u.FirstName, u.LastName,u.Gender, r.CreditSum,r.CreditAim, r.CreditTerm, r.Credit_Status from Request_Table r, User_Table u where (r.UserId = {UserId} and u.UserId = {UserId} and r.Credit_Status = 'принят')";
        SqlCommand command = new SqlCommand(commandText, con);
        SqlDataReader reader = command.ExecuteReader();
        Console.WriteLine("История заявок:");
        while(reader.Read())
        {
            System.Console.WriteLine($"{reader.GetValue("RequestId")} | {reader.GetValue("FirstName")}{reader.GetValue("LastName")} | {reader.GetValue("Gender")}|{reader.GetValue("CreditSum")} |{reader.GetValue("CreditAim")}|{reader.GetValue("CreditTerm")}| {reader.GetValue("Credit_Status")}"); 
        }
        reader.Close();

    }
    public string DecisionForRequest(Request req)
    {
        string decision = "";
        int points = 0;
        points++;
        //проверка пола
        if (req.Gender == "женский") points ++;
        points++;
        if (req.MaritalStatus == "в браке" || req.MaritalStatus == "вдовец(ва)")  points++;
        //проверка возраста
        if (req.ClientAge > 25) points++;
        if ((req.ClientAge >=36 && req.ClientAge <=62)) points++;
        //проверка гражданства
        if (req.Nationality.ToLower() == "таджикистан") points++;
        //проверка дохода
        if (req.CreditPecrectFromEarn < 80) points = points + 4;
        else 
        if (req.CreditPecrectFromEarn >= 80 && req.CreditPecrectFromEarn < 150)
            points = points + 3;
        else
        if (req.CreditPecrectFromEarn >= 150 && req.CreditPecrectFromEarn<250)
            points = points + 2;
        else 
        if (req.CreditPecrectFromEarn >= 250) points++;
        //проверка закрытых кредитов
        if (req.ClosedCreditCount >= 3) points = points + 2;
        else
        if (req.ClosedCreditCount == 0) points--;
        else points++;
        //проверка просроченных кредитов
        if (req.DelayCreditCount > 7) points = points - 3;
        else
        if (req.DelayCreditCount >= 5 && req.DelayCreditCount <= 7)
            points = points - 2;
        else 
        if (req.DelayCreditCount == 4) points--;
        //проверка на цель кредита
        if (req.CreditAim == "бытовая техника") points = points + 2;
        else 
        if (req.CreditAim == "ремонт") points++;
        else
        if (req.CreditAim != "телефон") points--;
        //проверка на срок погашения
        points++;

        if (points > 11) decision = "принят";
        else decision = "отклонён";

        return decision;
    }
}

}