# TestDataGenerator

A .NET console application that generates realistic test data as CSV files for **Salesforce** (Contacts, Leads, Accounts) and **Marketing Cloud** (Standard Data Extension). Uses [Bogus](https://github.com/bchavez/Bogus) for fake data and [CsvHelper](https://joshclose.github.io/CsvHelper/) for CSV output.

## Requirements

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Build & Run

```bash
# Restore and build
dotnet build

# Run
dotnet run --project TestDataGenerator
```

Or open `TestDataGenerator.sln` in Visual Studio and run the project.

## Usage

1. Run the application.
2. Choose an object type:
   - **1** – Salesforce Contact
   - **2** – Salesforce Lead
   - **3** – Salesforce Account
   - **4** – Marketing Cloud Standard Data Extension
3. Enter the number of rows to generate.
4. Enter the full file path (including filename and extension) for the output CSV.

Example:

```
Pick an object
 1 - SF Contact
 2 - SF Leads
 3 - SF Accounts
 4 - MC Standard DataExtension

1
Total rows to generate :
100
File path with file name and extn :
C:\output\contacts.csv
```

The CSV file is written to the path you specify.

## Data Types

| Option | Description | Sample fields |
|--------|-------------|---------------|
| **1 – SF Contact** | Salesforce Contact-style records | FirstName, LastName, Email, Phone, Mailing address, Department, LeadSource, etc. |
| **2 – SF Leads** | Salesforce Lead-style records | FirstName, LastName, Email, Company, LeadStatus |
| **3 – SF Accounts** | Salesforce Account-style records | Name, Phone, Website, Industry, Description |
| **4 – MC Standard DataExtension** | Marketing Cloud DE-style records | FirstName, MiddleName, LastName, Title, DOB, Email, SSN, Suffix, Phone |

## Tech Stack

- **.NET 8.0**
- **Bogus** – fake data generation
- **CsvHelper** – CSV writing

## Project Structure

```
TestDataGenerator/
├── TestDataGenerator.sln
└── TestDataGenerator/
    ├── TestDataGenerator.csproj
    ├── Program.cs              # Console UI and CSV export
    ├── Contacts.cs             # SF Contact model + Bogus rules
    ├── Leads.cs                # SF Lead model + Bogus rules
    ├── Accounts.cs             # SF Account model + Bogus rules
    └── StandardDataExtension.cs # MC DE model + Bogus rules
```

## License

See repository or project for license details.
