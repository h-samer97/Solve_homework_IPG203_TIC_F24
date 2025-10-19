namespace OOPBankDemo
{
    //فئة حفظ البيانات الحساب
    public class SavingsAccount : Account
    {
        private const decimal InterestRate = 0.01m;
        public SavingsAccount(string owner, decimal balance, decimal threshold)
            : base(owner, balance, threshold)
        { }
        // CalculateMonthlyDelta اعادة تعريف دالة
        protected override decimal CalculateMonthlyDelta() { return Balance * InterestRate; }
    }
}
