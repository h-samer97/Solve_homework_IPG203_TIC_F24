using System;
using System.Media;

namespace OOPBankDemo
{
    //نقطة دخول البرنامج
    public class Program
    {
        //انشاء كائن بنك لتخزين وادراة الحسابات
        static Bank bank = new Bank();

        public static void Main()
        {
            // Fill Data ^_^
            SeedData(); 
            Console.Title = "Console Banking System";
            bool exit = false;

            // IF exit == true ======> Stop Loop while :)
            while (!exit)
            {
                // \n is New Line in Console
                // يتم استخدام \n لتجنب اتصال النصوص ببعضها في شاشة العرض
                // This is Screen 
                Console.WriteLine("\n=== Banking Menu ===");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Show Accounts");
                Console.WriteLine("5. Apply Monthly Update");
                Console.WriteLine("6. Exit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine(); // قراءة المدخلات من المستخدم
                //اختيار الاجراء بناء على رقم العملية 
                try
                {
                    switch (choice)
                    {
                        case "1": CreateAccount(); break;
                        case "2": Deposit(); break;
                        case "3": Withdraw(); break;
                        case "4": ShowAccounts(); break;
                        case "5": bank.ProcessMonthlyUpdates(); Console.WriteLine("Monthly updates applied."); break;
                        case "6": exit = true; break;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch (Exception ex)
                {
                    //التقاط الخطأ في حال حدوثه وعرضه
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        //انشاء حساب
        static void CreateAccount()
        {
            Console.Write("Owner name: ");
            string name = Console.ReadLine();
            Console.Write("Initial balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());
            Console.Write("Threshold: ");
            decimal threshold = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Account type (1=Saving, 2=Checking, 3=Business): ");
            string type = Console.ReadLine();

            Account acc;
            if (type == "1") acc = new SavingsAccount(name, balance, threshold);
            else if (type == "2") acc = new CheckingAccount(name, balance, threshold);
            else acc = new BusinessAccount(name, balance, threshold);

            acc.OnBalanceBelowThreshold += AlertLowBalance;
            bank.AddAccount(acc);

            Console.WriteLine("Account created successfully.");
        }
        //ايداع
        static void Deposit()
        {
            var acc = SelectAccount();
            Console.Write("Amount to deposit: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            acc.Deposit(amount);
            Console.WriteLine("Deposit successful.");
        }
        //سحب رصيد
        static void Withdraw()
        {
            var acc = SelectAccount();
            Console.Write("Amount to withdraw: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            acc.Withdraw(amount);
            Console.WriteLine("Withdraw successful.");
        }
        //عرض الحسابات
        static void ShowAccounts()
        {
            foreach (var acc in bank.GetAccounts())
                Console.WriteLine(acc);
            Console.WriteLine("Total accounts: " + Bank.TotalAccounts);
            Console.WriteLine("Total balances: " + Account.TotalBalances);
        }

        //اختيار حساب
        static Account SelectAccount()
        {
            var accounts = new System.Collections.Generic.List<Account>(bank.GetAccounts());
            for (int i = 0; i < accounts.Count; i++)
                Console.WriteLine("{0}. {1}", i + 1, accounts[i]);
            Console.Write("Select account #: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            return accounts[index];
        }
        //تنبيه انخفاض الرصيد
        static void AlertLowBalance(Account account, decimal balance)
        {
            Console.WriteLine("ALERT: Account {0} balance dropped to {1}, below threshold {2}",
                account.OwnerName, balance, account.Threshold);
            SystemSounds.Exclamation.Play();
        }
        //تعبئة بيانات وهمية
        static void SeedData()
        {
            var acc1 = new SavingsAccount("Ali", 1500m, 500m);
            acc1.OnBalanceBelowThreshold += AlertLowBalance;
            bank.AddAccount(acc1);

            var acc2 = new SavingsAccount("Omar", 800m, 300m);
            acc2.OnBalanceBelowThreshold += AlertLowBalance;
            bank.AddAccount(acc2);

            var acc3 = new SavingsAccount("Layla", 2500m, 1000m);
            acc3.OnBalanceBelowThreshold += AlertLowBalance;
            bank.AddAccount(acc3);

            var acc4 = new CheckingAccount("Samer", 300m, 200m);
            acc4.OnBalanceBelowThreshold += AlertLowBalance;
            bank.AddAccount(acc4);

            var acc5 = new CheckingAccount("Mona", 1200m, 400m);
            acc5.OnBalanceBelowThreshold += AlertLowBalance;
            bank.AddAccount(acc5);

            var acc6 = new CheckingAccount("Hassan", 90m, 150m);
            acc6.OnBalanceBelowThreshold += AlertLowBalance;
            bank.AddAccount(acc6);

            // Business Accounts
            var acc7 = new BusinessAccount("Noor", 10000m, 2000m);
            acc7.OnBalanceBelowThreshold += AlertLowBalance;
            bank.AddAccount(acc7);

            var acc8 = new BusinessAccount("Hadeel", 4500m, 1000m);
            acc8.OnBalanceBelowThreshold += AlertLowBalance;
            bank.AddAccount(acc8);

            var acc9 = new BusinessAccount("Ahmad", 7000m, 1500m);
            acc9.OnBalanceBelowThreshold += AlertLowBalance;
            bank.AddAccount(acc9);

        }


    }
}
