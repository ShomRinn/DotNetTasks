#pragma warning disable S107

namespace FormattingStrings
{
    public static class Interpolation
    {
        public static string GetDepositCsv(int id, string name, string iban, decimal deposit, decimal balance, double interestRate)
        {
            FormattableString csv = $@"{id},""{name}"",{balance:F2},""{interestRate:P2}"",""{deposit:C4}"",{iban}";
            return FormattableString.Invariant(csv);
        }

        public static string GetProductCsv(int id, string name, int supplierId, int categoryId, string quantityPerUnit, double unitPrice, int unitInStock, int unitsOnOrder, int reorderLevel, bool discontinued)
        {
            int discontinuednumber = 1;
            if (discontinued is true)
            {
                discontinuednumber = 0;
            }

            FormattableString csv = $@"{id},""{name}"",{supplierId},{categoryId},""{quantityPerUnit}"",{unitPrice:F2},{unitInStock},{unitsOnOrder},{reorderLevel},{discontinuednumber}";
            return FormattableString.Invariant(csv);
        }

        public static string GetDepositJson(int id, string name, string iban, decimal deposit, decimal balance, double interestRate)
        {
            FormattableString csv = $@"{{ ""id"": {id:D}, ""name"": ""{name}"", ""balance"": {balance:F2}, ""rate"": {interestRate:F2}, ""deposit"": {deposit:F4}, ""account"": ""{iban}"" }}";
            return FormattableString.Invariant(csv);
        }

        public static string GetProductXml(int id, string name, int supplierId, int categoryId, string quantityPerUnit, double unitPrice, int unitInStock, int unitsOnOrder, int reorderLevel, bool discontinued)
        {
            string discontinuednumber = string.Empty;
            if (discontinued is true)
            {
                discontinuednumber = "Yes";
            }
            else
            {
                discontinuednumber = "No";
            }

            FormattableString csv = $@"<product id=""{id}"" name=""{name}"" category=""{categoryId}"" available=""{discontinuednumber}""><supplier>{supplierId}</supplier><quantity>{quantityPerUnit}</quantity><price>{unitPrice:F4}</price><stock>{unitInStock}</stock><ordered>{unitsOnOrder}</ordered><reorder>{reorderLevel}</reorder></product>";
            return FormattableString.Invariant(csv);
        }

        public static string GetDepositTable(int id, string name, string iban, decimal deposit, decimal balance, double interestRate)
        {
            FormattableString csv = $@"| {id,5} | {name,-20} | {balance,-24:C4} | {interestRate,4:P0} | {deposit,-15:N2} | {iban,-25} |";
            return FormattableString.Invariant(csv);
        }

        public static string GetProductList(int id, string name, int supplierId, int categoryId, string quantityPerUnit, double unitPrice, int unitInStock, int unitsOnOrder, int reorderLevel, bool discontinued)
        {
            FormattableString csv = $@"{id,-5}{name,-27}{categoryId,-2}{unitPrice,-10:C2}{unitInStock,2} {quantityPerUnit,-20}";
            return FormattableString.Invariant(csv);
        }
    }
}
