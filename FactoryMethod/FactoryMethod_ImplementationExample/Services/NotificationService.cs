using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod_ImplementationExample.Services
{
    abstract class NotificationCreator
    {
        public abstract INotification FactoryMethod();

        // Você ainda pode usar o creator para implementar outras regras de negócio que tenham a ver com o a criação dos objetos
        public string DefaultNotification()
        {
            var product = FactoryMethod();

            var result = $"Notificação padrão: {product.SendNotification}";

            return result;
        }
    }

    class SMSNotificationCreator : NotificationCreator
    {
        public override INotification FactoryMethod()
        {
            return new SMSNotification();
        }
    }

    class WhatsappNotificationCreator : NotificationCreator
    {
        public override INotification FactoryMethod()
        {
            return new WhatsappNotification();
        }
    }

    class EmailNotificationCreator : NotificationCreator
    {
        public override INotification FactoryMethod()
        {
            return new EmailNotification();
        }
    }

    public interface INotification
    {
        string SendNotification();
    }

    class SMSNotification : INotification
    {
        public string SendNotification()
        {
            return "Você recebeu uma notificação via SMS";
        }
    }

    class WhatsappNotification : INotification
    {
        public string SendNotification()
        {
            return "Você recebeu uma notificação via Whatsapp";
        }
    }

    class EmailNotification : INotification
    {
        public string SendNotification()
        {
            return "Você recebeu uma notificação via Email";
        }
    }

    class NotificationService
    {
        public NotificationService(string notificationType)
        {
            switch (notificationType)
            {
                case "SMS":
                    var SMSNotification = new SMSNotification();
                    Console.WriteLine($"{SMSNotification.SendNotification()}");
                    break;
                case "Whatsapp":
                    var WhatsappNotification = new WhatsappNotification();
                    Console.WriteLine($"{WhatsappNotification.SendNotification()}");
                    break;
                case "Email":
                    var EmailNotification = new EmailNotification();
                    Console.WriteLine($"{EmailNotification.SendNotification()}");
                    break;
                default:
                    Console.WriteLine($"{SendNotification(new EmailNotificationCreator())}");
                    break;
            }
        }

        private string SendNotification(NotificationCreator notificationCreator)
        {
            return notificationCreator.DefaultNotification();
        }
    }
}
