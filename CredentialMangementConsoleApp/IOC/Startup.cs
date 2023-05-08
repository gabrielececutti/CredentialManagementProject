using Bogus;
using CredentialManagementData;
using CredentialManagementData.PeristenceService;
using CredentialManagementData.Repository;
using CredentialMangamentServices.LoggerService;
using CredentialMangamentServices.PeristenceService;
using CredentialMangamentServices.PrinterService;
using CredentialMangementModels.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Validators.EmailValidator;
using Validators.PasswordValidator;

namespace CredentialMangementConsoleApp.IOC
{
    public static class Startup
    {
        public static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, service) =>
                {
                    service.AddSingleton(new AccountFactory(new Faker<Account>()));
                    string fileName = @"AppSettings.json";
                    string json = File.ReadAllText(fileName);
                    AppSettings? appSettings = JsonConvert.DeserializeObject<AppSettings>(json);
                    service.AddSingleton(appSettings);

                    var databaseOption = new DatabaseOption(appSettings.ConnectionStrings.MyConnectionString);

                    service.AddSingleton<IAccountRepository>(new AccountRepository(databaseOption));
                    service.AddSingleton<IAccountPersistenceServiceDb, AccountPersistenceServiceDb>();
                    service.AddSingleton<IAccountPersistenceServiceFile>(new AccountPersistenceServiceFile(appSettings.DownloadFolderPaths.MyPath));

                    service.AddSingleton(SetUpPasswordChain.SetUpChain());

                    service.AddSingleton<IEmailValidator>(new EmailValidator(appSettings.EmailPattern));

                    service.AddSingleton<ILoggingService, LoggingService>();

                    service.AddSingleton<IPrinterService, PrinterService>();
                });
        }
    }
}
