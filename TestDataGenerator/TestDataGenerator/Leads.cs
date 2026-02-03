using Bogus;

namespace TestDataGenerator
{
    internal class Leads
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string Company { get; set; }

        public string LeadStatus { get; set; }

        public int Id { get; set; } // not part of contact model but PK column needed for data stream setup

        public static Faker<Leads> FakeData { get; } =
            new Faker<Leads>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Email, (f, p) => f.Internet.Email(p.FirstName, p.LastName))
                .RuleFor(p => p.Company, f => f.Company.CompanyName())
                .RuleFor(p => p.LeadStatus, f => "New");
    }
}

