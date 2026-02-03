using Bogus;

namespace TestDataGenerator
{
    internal class Accounts
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public string Industry { get; set; }

        public string Description { get; set; }


        public static Faker<Accounts> FakeData { get; } =
            new Faker<Accounts>()
                .RuleFor(p => p.Name, f => f.Company.CompanyName())
                .RuleFor(p => p.Phone, f => f.Person.Phone)
                .RuleFor(p => p.Website, f => f.Internet.Url())
                .RuleFor(p => p.Industry, f => f.Commerce.Department())
                .RuleFor(p => p.Description, f => f.Lorem.Sentence());
    }


}
