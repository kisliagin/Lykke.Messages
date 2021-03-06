﻿namespace Lykke.Messages.Email.MessageData
{
    public class TransferCompletedData : IEmailMessageData
    {
        public const string QueueName = "TransferCompletedEmail";

        public string ClientName { get; set; }
        public double AmountFiat { get; set; }
        public double AmountLkk { get; set; }
        public double Price { get; set; }
        public string AssetId { get; set; }
        public string SrcBlockchainHash { get; set; }
    }
}
