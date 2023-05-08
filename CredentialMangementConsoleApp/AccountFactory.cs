using Bogus;
using CredentialMangementModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialMangementConsoleApp
{
    public class AccountFactory
    {
        private readonly Faker<Account> _faker;
        private string[] passwords = new string[] { "password", "Password1", "Password12*", "Querty12345$", "cevrtbrtvW6" };
        public AccountFactory(Faker<Account> faker)
        {
            _faker = faker;
        }

        public Account Create()
        {
            return _faker
                .RuleFor(a => a.Number, f => f.Random.Number(1, 1000))
                .RuleFor(a => a.Username, f => f.Internet.Email())
                .RuleFor(a => a.Password, f => f.PickRandom(passwords))
                .RuleFor(a => a.Date, f => DateTime.Now)
                .Generate();
        }
    }
}
