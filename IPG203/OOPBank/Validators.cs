namespace OOPBankDemo
{
    // إجراء التحقق من الأسماء
    public static class Validators
    {
        // التحقق من صلاحية الإسم يجب الا يكون فارغ او به مسافات او اصغر من حرفين
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length >= 2;
        }

        // يجب ان يكون المبلغ لا يساوي الصفر
        public static bool IsValidAmount(decimal amount)
        {
            return amount > 0;
        }
    }
}
