using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.Context;
using WebChat.Exceptions;
using WebChat.Models;
using WebChat.Services;

namespace WebChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public readonly ChatMessageService _chatMessageService;
        public MessageController(ChatMessageService chatMessageService)
        {
            _chatMessageService = chatMessageService;
        }
        [Route("GetMessages")]
        [HttpGet]
        public IActionResult GetMessages()
        {
            return Ok(_chatMessageService.GetMessages());
        }
        [Route("Create")]
        [HttpPost]
        public IActionResult CreateMessages([FromBody] ChatMessageViewModel viewModel)
        {
            try
            {
                _chatMessageService.CreateMessage(viewModel);
                return Ok();
            }
            catch (CustomException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                WriteExceptionInfo(ex);
                return StatusCode(500);
            }
        }

        #region Private methods
        private void WriteExceptionInfo(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
        #endregion
    }
}
