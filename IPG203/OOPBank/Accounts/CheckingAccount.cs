namespace OOPBankDemo
{
    // تعريف فئة CheckingAccount التي تمثل حساب جاري وتورث من الفئة الأساسية Account
    public class CheckingAccount : Account
    {
        private const decimal MonthlyFee = -5m;

        // منشء الفئة. يمرر اسم المالك، الرصيد الابتدائي، والحد الأدنى إلى المنشئ الأساسي
        public CheckingAccount(string owner, decimal balance, decimal threshold)
            : base(owner, balance, threshold)
        { }
        // حساب الفرق الشهري. يخصم فقط الرسوم الشهرية من الرصيد
        protected override decimal CalculateMonthlyDelta() { return MonthlyFee; }
    }
}
