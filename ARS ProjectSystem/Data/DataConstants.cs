namespace ARS_ProjectSystem.Data
{
    public class DataConstants
    {
        public class Customer
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }
        public class ProjectSystemUser
        {
            public const int MaxLength = 50;
            public const int MinLength = 2;
        }
        public class Project
        {
            public const int MinLength = 2;
            public const int MaxLength = 50;
        }
        public class Invoice
        {
            public const int InvoiceLength = 10;
            public const int IBANLength = 10;
        }
    }
}
