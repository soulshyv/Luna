using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Luna.Commons.Communication.Config;
using Luna.Commons.Communication.Interfaces;
using Luna.Commons.Communication.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Luna.Commons.Communication.Services
{
    public class MailService : IMailService
    {
        private MailSettings _settings { get; set; }
        private ILifetimeScope _scope { get; set; }
        
        private ILogger<MailService> _logger;
        private ILogger<MailService> Logger => _logger ??= _scope.Resolve<ILogger<MailService>>();

        public MailService(ILifetimeScope scope, MailSettings settings)
        {
            _scope = scope;
            _settings = settings;
        }

        public async Task Send(Mail mail)
        {
            mail.From ??= new Person(_settings.DisplayName, string.Empty, _settings.Mail);
            
            var from = new MailAddress(mail.From.Email, $"{mail.From.FirstName} {mail.From.LastName}", Encoding.UTF8);
            var to = new MailAddress(mail.To.Email, $"{mail.To.FirstName} {mail.To.LastName}", Encoding.UTF8);
            using var client = new SmtpClient(_settings.Host, _settings.Port)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_settings.Login, _settings.Password)
            };

            var message = new MailMessage(from, to)
            {
                Body = mail.Body,
                Subject = mail.Subject
            };


            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            try
            {
                client.Send(message);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Erreur lors de l'envoi du mail");
            }
        }
    }
}