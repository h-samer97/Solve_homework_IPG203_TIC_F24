namespace OOPBankDemo
{
    // إستخدام ميزة الواجهة
    public interface IAccountOperations
    {
        void Deposit(decimal amount); // ايداع
        void Withdraw(decimal amount); //  سحب
        void ApplyMonthlyUpdate();  // تطبيق التحديثات الشهرية
    }
}
