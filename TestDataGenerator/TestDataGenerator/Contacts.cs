using Bogus;
using System;

namespace TestDataGenerator
{
    internal class Contacts
    {
        public int Id { get; set; } // not part of contact model but PK column needed for data stream setup

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AccountName { get; set; }

        public string Assistant { get; set; }

        public string AsstPhone { get; set; }

        public DateTime Birthdate { get; set; }

        public string Department { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string HomePhone { get; set; }

        public string LeadSource { get; set; }

        public string MailingStreet { get; set; }

        public string MailingCity { get; set; }

        public string MailingStateProvince { get; set; }

        public string MailingZipPostalCode { get; set; }

        public string MailingCountry { get; set; }

        public string Mobile { get; set; }

        public string OtherStreet { get; set; }

        public string Phone { get; set; }

        public string Title { get; set; }

        public string ReportsToEmail { get; set; }

        public static Faker<Contacts> FakeData { get; } =
            new Faker<Contacts>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.LastName, f => f.Person.LastName)
                .RuleFor(p => p.AccountName, "Acme")
                .RuleFor(p => p.Assistant, f => f.Name.FullName())
                .RuleFor(p => p.AsstPhone, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.Birthdate, f => f.Person.DateOfBirth)
                .RuleFor(p => p.Department, f => f.Commerce.Department())
                .RuleFor(p => p.Description, f => f.Lorem.Sentence())
                .RuleFor(p => p.Email, f => f.Person.Email)
                .RuleFor(p => p.HomePhone, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.LeadSource, f => f.PickRandom("Web", "Phone Inquiry", "Partner Referral", "Purchased List", "Other"))
                .RuleFor(p => p.MailingStreet, f => f.Address.StreetAddress())
                .RuleFor(p => p.MailingCity, f => f.Address.City())
                .RuleFor(p => p.MailingStateProvince, f => f.Address.State())
                .RuleFor(p => p.MailingZipPostalCode, f => f.Address.ZipCode())
                .RuleFor(p => p.MailingCountry, f => f.Address.Country())
                .RuleFor(p => p.Mobile, f => f.Person.Phone)
                .RuleFor(p => p.OtherStreet, f => f.Address.StreetAddress())
                .RuleFor(p => p.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.Title, f => "Sales Manager")
                .RuleFor(p => p.ReportsToEmail, f => f.Person.Email);
    }
}
    