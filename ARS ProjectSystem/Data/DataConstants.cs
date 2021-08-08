﻿namespace ARS_ProjectSystem.Data
{
    public class DataConstants
    {
        public class Customer
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }
        public class Invoice
        {
            public const int InvoiceLength = 10;
            public const int IBANLength = 10;
        }
        public class Project
        {
            public const int MinLength = 2;
            public const int MaxLength = 50;
        }
        public class ProjectSystemUser
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;
            public const string ValidatePhoneNumber = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        }
        public class Proposal
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;
        }
        public class ShortApplication
        {
            public const int MaxCharacters = 1000;
            public const int MaxAcronymLength = 50;
            public const int MaxFeatureLength = 100;
            public const int MaxFeatureKnowleadgeOrTechnologyLength = 500;
        }
        public class User
        {
            public const int FullNameMinLength = 5;
            public const int FullNameMaxLength = 40;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;
        }
    }
}
