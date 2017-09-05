﻿using Lykke.Messages.Email;
using Lykke.Messages.Email.MessageData;
using System;
using System.Threading.Tasks;
using Autofac;

namespace Lykke.Messages.Utils
{
    class Program
    {
        public const string ClientId = "0dc14d6a-9bdf-47c3-8320-dd12612e7617";
        public const string PartnerId = "AlpineVault";
        //public const string EmailAddress = "darthjurassic@yopmail.com";
        public const string EmailAddress = "yury@batsyuro.ru";

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterEmailSenderViaAzureQueueMessageProducer("DefaultEndpointsProtocol=https;AccountName=lkedevmain;AccountKey=l0W0CaoNiRZQIqJ536sIScSV5fUuQmPYRQYohj/UjO7+ZVdpUiEsRLtQMxD+1szNuAeJ351ndkOsdWFzWBXmdw==", "emailsqueue");
            var container = builder.Build();
            var sender = container.Resolve<IEmailSender>();

            //SendTestEmailConfirmationAsync(sender).Wait();
            //SendRegistrationMessageMessageAsync(sender).Wait();
            //SendKycOkMessageAsync(sender).Wait();
            //SendCachInMessageAsync(sender).Wait();
            //SendRemindPasswordMessageAsync(sender).Wait();

            SendTestKycDeclined(sender).Wait();
        }

        private static Task SendTestKycDeclined(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new DeclinedDocumentsData
            {
                FullName = "Test User Fullname",
                Documents = new[]
                {
                    new KycDocumentData
                    {
                        ClientId = ClientId,
                        DocumentId = "1234",
                        DateTime = DateTime.Now,
                        DocumentName = "Test Document",
                        FileName = "Test Filename",
                        KycComment = "Test Comment",
                        Mime = "text/plain",
                        State = "Test state",
                        Type = "Plain text document"
                    }
                }
            });
        }

        private static Task SendTestEmailConfirmationAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new EmailComfirmationData
            {
                ConfirmationCode = "1234",
                Year = DateTime.Now.Year.ToString()
            });
        }

        private static Task SendRegistrationMessageMessageAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new RegistrationMessageData
            {
                ClientId = ClientId,
                Year = DateTime.Now.Year.ToString()
            });
        }

        private static Task SendKycOkMessageAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new KycOkData
            {
                ClientId = ClientId,
                Year = DateTime.Now.Year.ToString()
            });
        }

        private static Task SendCachInMessageAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new CashInData
            {
                AssetId = "USD",
                Multisig = "123Multisig456",
            });
        }

        private static Task SendRemindPasswordMessageAsync(IEmailSender sender)
        {
            return sender.SendEmailAsync(PartnerId, EmailAddress, new RemindPasswordData
            {
                PasswordHint = "Hello, World!"
            });
        }


    }
}