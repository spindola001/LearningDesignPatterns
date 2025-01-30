using System.Net.Http.Headers;
using FactoryMethod_ImplementationExample.Services;

namespace FactoryMethod_ImplementationExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o tipo de notificação que você prefere receber:");
            var notificationType = Console.ReadLine();
            var NotificationService = !string.IsNullOrEmpty(notificationType) ? new NotificationService(notificationType) : new NotificationService("");
        }
    }
}
