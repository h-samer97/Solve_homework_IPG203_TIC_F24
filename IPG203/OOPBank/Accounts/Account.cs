using System;

namespace OOPBankDemo
{
    //في هذا الكلاس المجرد يتم وراثة من Interface IAccountOperations
    public abstract class Account : IAccountOperations
    {
        // تهئية الخصائص
        private readonly Guid _id; // خاصية للقراءة فقط
        private string _ownerName; // اسم المالك
        private decimal _balance; // الرصيد الحالي
        private decimal _threshold; // الحد الأدنى
        private static decimal _totalBalances; // الرصيد الاجمالي

        public Guid Id { get { return _id; } } // معرف الحساب
        public string OwnerName { get { return _ownerName; } set { _ownerName = value; } } // اسم المالك مع امكانية التعديل
        public decimal Balance { get { return _balance; } } // قراءة الرصيد
        public decimal Threshold { get { return _threshold; } set { _threshold = value; } }  // خاصية الحد الأدنى مع إمكانية التعديل


        // تعريف الحدث الذي يطلق عند انخفاض الرصيد عن الحد الأدنى

        public delegate void BalanceThresholdHandler(Account account, decimal currentBalance);
        public event BalanceThresholdHandler OnBalanceBelowThreshold;

        // انشاء الفئة: يهيئ الحساب الجديد ويحدث إجمالي الأرصدة وعدد الحسابات
        protected Account(string ownerName, decimal initialBalance, decimal threshold)
        {
            _id = Guid.NewGuid();
            _ownerName = ownerName;
            _balance = initialBalance;
            _threshold = threshold;

            _totalBalances += _balance;
            Bank.TotalAccounts++;
        }

        // عملية الإيداع ===> تضيف المبلغ إلى الرصيد وتحدث الإجمالي وتتحقق من الحد الأدنى
        public void Deposit(decimal amount)
        {
            _balance += amount;
            _totalBalances += amount;
            CheckThreshold();
        }

        // عملية السحب ===> تتحقق من توفر الرصيد ثم تخصم المبلغ وتحدث الإجمالي وتتحقق من الحد الأدنى
        public void Withdraw(decimal amount)
        {
            if (amount > _balance)
                throw new InvalidOperationException("Insufficient funds");
            _balance -= amount;
            _totalBalances -= amount;
            CheckThreshold();
        }

        public void ApplyMonthlyUpdate()
        {
            decimal delta = CalculateMonthlyDelta();
            _balance += delta;
            _totalBalances += delta;
            CheckThreshold();
        }

        // دالة مجردة تجبر الفئات المشتقة على تحديد منطق التحديث الشهري
        protected abstract decimal CalculateMonthlyDelta();

        // التحقق من تجاوز الرصيد للحد الأدنى وتفعيل الحدث إذا لزم الأمر
        protected void CheckThreshold()
        {
            if (Balance < Threshold && OnBalanceBelowThreshold != null)
                OnBalanceBelowThreshold(this, Balance);
        }

        // تمثيل نصي للحساب يعرض البيانات الأساسية
        public override string ToString()
        {
            return string.Format("[{0}] Id={1}, Owner={2}, Balance={3}, Threshold={4}",
                GetType().Name, Id, OwnerName, Balance, Threshold);
        }
        // خاصية ساكنة تعرض إجمالي أرصدة جميع الحسابات
        public static decimal TotalBalances { get { return _totalBalances; } }
    }
}
