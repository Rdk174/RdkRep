
using System;
using System.IO;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Management;
using System.ServiceProcess;

public class TestLambdaExpression
{
    private static List<string> hosts = new List<string>() { "google.ru", "ya.ru", "10.8.0.1", "aaaaa213213123123.ru" };

    public static void Main()
    {
        Action<string> asyn = new Action<string>(Pinger);

        hosts.ForEach(e =>
        {
            asyn.Invoke(e);
        });

        Console.WriteLine("End");
        Console.ReadKey();
    }

    private static void Pinger(string hostAdress)
    {
        ConnectionOptions options = new ConnectionOptions();

        //options.Username = @"Mavt3082\Администратор";
        //options.Password = "Vfdnjpfdh2016";
        // and also set 
        // options.Authority = "ntlmdomain:DOMAIN";
        // and replace DOMAIN with the remote computer's
        // domain.  You can also use Kerberos instead
        // of ntlmdomain.
        ManagementScope scope = new ManagementScope(@"\\10.8.0.111\root\cimv2");
        scope.Connect();
        Console.WriteLine("connet");

        // Use this code if you are connecting with a 
        // different user name and password:
        //
        // ManagementScope scope = 
        //    new ManagementScope(
        //        "\\\\FullComputerName\\root\\cimv2", options);
        // scope.Connect();

        //Query system for Operating System information

        /* для получения уведомления о завершении операции */
        ManagementOperationObserver Stop = new ManagementOperationObserver();
        //Stop.Completed += new CompletedEventHandler(Stop_CallBack);
        try
        {
            Console.WriteLine("-------------");
            string NameServices = "Transport";
            WqlObjectQuery query = new WqlObjectQuery("SELECT * FROM Win32_Service  WHERE Name=\"" + NameServices + "\"");
            ManagementObjectSearcher find = new ManagementObjectSearcher(scope, query);
            foreach (ManagementObject transport in find.Get())
            {
                /* Так работает */
                transport.InvokeMethod("StopService", new object[] { });
                /* Так не работает: выдает ошибку  80070005 - Access is denied  вопрос, почему, что не так*/
                //transport.InvokeMethod(Stop, "StopService", new object[] { });
                Console.WriteLine(transport.Scope.ToString());
            }
            //Console.WriteLine("ok");
        }
        catch (Exception e)
        {
            // обработка ошибок
            Console.WriteLine("Error: {0}", e.Message);
        }
        Console.Read();
    }
}