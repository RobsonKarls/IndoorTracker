using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using IndoorTracker.API.Infrastructure.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace IndoorTracker.API.Extensions
{
   public static class Extensions
    {
        private static readonly Func<string, string> _envVariables = Environment.GetEnvironmentVariable;
        private static int HttpsPort = 44340;

        public static IWebHostBuilder UseKestrelHttps(this IWebHostBuilder builder) => builder
         .UseKestrel((context, options) =>
         {
             HttpsPort = context.Configuration.GetValue<int>("HttpsConfig:Port");

             Console.WriteLine(HttpsPort);
             if (!context.HostingEnvironment.IsEnvironment("DeveloperMachine"))
             {
                 
                 string certPath = Path.Combine(context.Configuration.GetValue<string>("HttpsConfig:CertFolder"), context.Configuration.GetValue<string>("HttpsConfig:CertFileName"));
                 string certPassword = context.Configuration.GetValue<string>("HttpsConfig:CertPassword");

                 X509Certificate2 cert;

                 try
                 {
                     cert = new X509Certificate2(certPath, certPassword);
                 }
                 catch (CryptographicException ex)
                 {
                     throw ex;
                 }

                 options.Listen(IPAddress.Any, HttpsPort, listenOptions => listenOptions.UseHttps(cert));
             }
         })
         .UseUrls($"https://{IPAddress.Any}:{HttpsPort}", $"https://*:{HttpsPort}");

        private static X509Certificate2 LoadCertificate(EndpointConfiguration config, IHostingEnvironment environment)
        {
            if (config.StoreName != null && config.StoreLocation != null)
            {
                using (var store = new X509Store(config.StoreName, Enum.Parse<StoreLocation>(config.StoreLocation)))
                {
                    store.Open(OpenFlags.ReadOnly);
                    var certificate = store.Certificates.Find(
                        X509FindType.FindBySubjectName,
                        config.Host,
                        validOnly: !environment.IsDevelopment());

                    if (certificate.Count == 0)
                    {
                        throw new InvalidOperationException($"Certificate not found for {config.Host}.");
                    }

                    return certificate[0];
                }
            }

            if (config.FilePath != null && config.Password != null)
            {
                return new X509Certificate2(config.FilePath, config.Password);
            }

            throw new InvalidOperationException("No valid certificate configuration found for the current endpoint.");
        }
    }
}