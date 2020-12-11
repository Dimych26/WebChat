using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.Context;
using WebChat.Entities;
using WebChat.Exceptions;
using WebChat.Models;

namespace WebChat.Services
{
    public class ChatMessageService
    {
        public ApplicationDbContext _dbContext { get; }
        public ChatMessageService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateMessage(ChatMessageViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.Message))
                throw new BadRequestException("Message doesn't have a text");

            _dbContext.ChatMessages.Add(new Entities.ChatMessage { Message = viewModel.Message });
            _dbContext.SaveChanges();
        }
        public IEnumerable<ChatMessage> GetMessages()
        {
            return _dbContext.ChatMessages.AsEnumerable();
        }
    }
}
