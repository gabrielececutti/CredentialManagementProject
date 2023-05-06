
using Bogus;
using Bogus.Bson;
using Bogus.DataSets;
using CredentialManagementData;
using CredentialManagementData.FileWorking;
using CredentialManagementData.PeristenceService;
using CredentialManagementData.Repository;
using CredentialMangamentServices.LoggerService;
using CredentialMangamentServices.PeristenceService;
using CredentialMangamentServices.PrinterService;
using CredentialMangementConsoleApp;
using CredentialMangementConsoleApp.IOC;
using CredentialMangementModels.Entities;
using CredentialMangementModels.Requests.AccountRequests;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Validators.EmailValidator;
using Validators.PasswordValidator;

// rivedere File Writing 
// implementare copia del file
// rivedere gestione eccezioni ed errori
// uso di IOC e Json
// codice asincrono

var host = Startup.CreateHostBuilder().Build();

var appSettings = host.Services.GetRequiredService<AppSettings>();
var loggingService = host.Services.GetRequiredService<ILoggingService>();
var printerService = host.Services.GetRequiredService<IPrinterService>();
var accountFactory = host.Services.GetRequiredService<AccountFactory>();

var app = new App (appSettings, loggingService, printerService, accountFactory);
app.Run();
