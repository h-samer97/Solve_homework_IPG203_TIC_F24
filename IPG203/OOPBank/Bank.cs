using System.Collections.Generic;

namespace OOPBankDemo
{
    // تعريف فئة Bank التي تمثل المؤسسة البنكية وتدير مجموعة من الحسابات
    public class Bank
    {
        // قائمة خاصة تحتوي على جميع الحسابات المرتبطة بالبنك
        private readonly List<Account> _accounts = new List<Account>();

        // خاصية ساكنة لتتبع العدد الإجمالي للحسابات في النظام
        public static int TotalAccounts { get; set; }

        // إضافة حسا جديد إلى قائمة الحسابات
        public void AddAccount(Account account) { _accounts.Add(account); }

        // تنفيذ التحديثات الشهرية لجميع الحسابات في البنك
        public void ProcessMonthlyUpdates() { foreach (var acc in _accounts) acc.ApplyMonthlyUpdate(); }

        // إرجاع قائمة الحسابات الحالية للقراءة فقط
        public IEnumerable<Account> GetAccounts() { return _accounts; }
    }
}
