using System;
public class User
{
    public int Id{get; set;}
    public string FIO{get; set;}
    public string Passport_Id{get; set;}
    public string Gender{get; set;}
    public DateTime BirthDate{get; set;}
    public string Nationality{get; set;}
    public DateTime Expiry_Date{get; set;}// срок действия паспорта
    public DateTime Address{get; set;}
    public string Login{get; set;}
    public string Password{get; set;}
    public string User_Status{get; set;} //клиент или администратор
}

public class CredRequest
{
    public int CreditSum{get; set;} // в сомони
    public string CreditAim{get; set;}
    public int CtreditTerm{get; set;} // в месяцах
}