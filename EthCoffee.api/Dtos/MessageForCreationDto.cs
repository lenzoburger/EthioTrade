using System;

namespace EthCoffee.api.Dtos
{
    public class MessageForCreationDto
    {
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public DateTime MessageSent { get; private set; }
        public string Content { get; set; }
        public MessageForCreationDto()
        {
            MessageSent = DateTime.Now;
        }
    }
}