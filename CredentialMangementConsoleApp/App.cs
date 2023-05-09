using CredentialMangamentServices.LoggerService;
using CredentialMangamentServices.PrinterService;
using CredentialMangementModels.Entities;
using CredentialMangementModels.Requests;
using CredentialMangementModels.Requests.AccountRequests;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialMangementConsoleApp
{
    public class App
    {
        private readonly ILoggingService _loggingService;
        private readonly IPrinterService _printerService;
        private readonly AccountFactory _accountFactory;
        private readonly AppSettings _appSettings;

        public App(AppSettings appSettings, ILoggingService loggingService, IPrinterService printerService, AccountFactory accountFactory)
        {
            _appSettings = appSettings;
            _loggingService = loggingService;
            _printerService = printerService;
            _accountFactory = accountFactory;
        }

        public void Run ()
        {
            Console.WriteLine("Press enter to start the program");
            var x = Console.ReadLine(); 
            Console.WriteLine("Strat Program...");
            Thread.Sleep(1000);
            Console.WriteLine("-----------------------------------LOG-----------------------------------");
            var account = new Account();
            while (true)
            {
                account = _accountFactory.Create();
                Console.WriteLine(account.ToString());
                var logResponse = _loggingService.LogNewAccount(account);
                Thread.Sleep(1000);
                if (logResponse.Data != 0)
                {
                    Console.WriteLine($"account saved successfully (number account: {account.Number})");
                    break;
                }
                else
                {
                    Console.WriteLine($"error: {logResponse.Error}");
                }
            }

            Console.WriteLine("-----------------------------DOWNLOAD FILE-------------------------------");
            var userInput = new AccountByUsernamePasswordRequest{ Username = account.Username, Password = account.Password};
            while (true)
            {
                var printResponse = _printerService.PrintAccount(userInput);
                Thread.Sleep(1000);
                if (!string.IsNullOrEmpty(printResponse.Data))
                {
                    Console.WriteLine($"account downloaded in {_appSettings.DownloadFolderPaths.MyPath}");
                    Console.WriteLine("do you want to download the file again? (Y|N)");
                    var userAnswer = Console.ReadLine();
                    if (userAnswer.Equals("Y"))
                    {
                        var printCopyResponse = _printerService.PrintCopyAccount(printResponse.Data);
                        if (printCopyResponse) Console.WriteLine("file copy downloaded successfully");
                        else Console.WriteLine("errors while dowloading the file copy");
                    }          
                    break;
                }
                else
                {
                    Console.WriteLine(printResponse.Error);
                }
            }
            Console.WriteLine("End Program...");
            Thread.Sleep(1000);
        }
    }
}
