﻿namespace Lykke.Messages.Email.MessageData
{
    public class BankCashInData : IEmailMessageData
    {
        public const string QueueName = "BankCashInEmail";

        public string AssetId { get; set; }
        public double Amount { get; set; }
        public string ClientId { get; set; }
    }
}
