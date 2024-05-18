﻿namespace MultiShop.DtoLayer
{
    public class ResultInboxMessageDto
    {
        public int UserMessageId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public bool IsRead { get; set; }
        public string DataProtect { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
