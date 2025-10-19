namespace OOPBankDemo
{
    // تعريف فئة BusinessAccount التي تمثل حساب نجاري وتورث من الفئة المجردة Account
    public class BusinessAccount : Account
    {
        private const decimal InterestRate = 0.005m;
        private const decimal MonthlyFee = -10m;

        // باني الفئة. يمرر البيانات الأساسية إلى المنشئ الأساسي في الفئة Account
        public BusinessAccount(string owner, decimal balance, decimal threshold)
            : base(owner, balance, threshold)
        { }

        // حساب الفرق الشهري. فائدة على الرصيد مطروح منها الرسوم الشهرية
        protected override decimal CalculateMonthlyDelta() { return (Balance * InterestRate) + MonthlyFee; }
    }
}
