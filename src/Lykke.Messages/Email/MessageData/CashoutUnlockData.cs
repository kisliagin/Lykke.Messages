﻿namespace Lykke.Messages.Email.MessageData
{
    public class CashoutUnlockData: IEmailMessageData
    {
        public const string QueueName = "CashoutUnlockEmail";

        public string Code { get; set; }
        public string ClientId { get; set; }
    }
}
