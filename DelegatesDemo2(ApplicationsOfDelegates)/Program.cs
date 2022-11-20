using System;

namespace DelegatesDemo2_ApplicationsOfDelegates_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            account.alert += Notification.SendEmail;
            account.alert += Notification.SendSMS;//subscribe
            account.alert += Notification.SendWhatsApp;

            account.alert -= Notification.SendWhatsApp;//Unsubscribe

           //account.alert("Credited $99999999999999999999.000"); - This should not happen. Client cannot alert or notify himself

            Console.WriteLine($"Initial Balance: {account.Balance}");
            account.Deposit(5000);
            Console.WriteLine($"After Deposit, Balance: {account.Balance}");
            account.Withdraw(1000);
            Console.WriteLine($"After Withdraw Balance: {account.Balance}");
        }
    }

    //declare new delegate
    delegate void Alert(string msg);
    class Account
    {
        public int Balance { get; set; }
        public event Alert alert = null;

        public void Deposit(int amount)
        {
            Balance += amount;
            //send email
            //Notification.SendEmail($"Credited {amount}");   - not good practice to use this
            if (alert != null)
                alert($"Credited {amount}");
        }
        public void Withdraw(int amount)
        {
            Balance -= amount;
            //Notification.SendEmail($"Debited {amount}");
            if (alert != null)
                alert($"Debited {amount}");
        }
    }
    public class Notification
    {
        public static void SendEmail(string msg)
        {
            //SmtpClient
            //MailMessage
            Console.WriteLine($"MAIL: {msg}");
        }
        public static void SendSMS(string msg)
        {
            //SmtpClient
            //MailMessage
            Console.WriteLine($"SMS: {msg}");
        }
        public static void SendWhatsApp(string msg)
        {
            //SmtpClient
            //MailMessage
            Console.WriteLine($"WhatsApp: {msg}");
        }
    }
}
