
using System;
using System.IO;
using System.Collections.Generic;
using System.Net.NetworkInformation;

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
        Ping png = new Ping();
        try
        {
            PingReply pr = png.Send(hostAdress);
            Console.WriteLine(string.Format("Status for {0} = {1}", hostAdress, pr.Status));
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("Status for {0} = {1}", hostAdress, ex.InnerException.Message));
        }
    }
}