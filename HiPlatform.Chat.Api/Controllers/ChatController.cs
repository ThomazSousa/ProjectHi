using HiPlatform.Chat.Api.App.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace HiPlaform.Chat.Api.Controllers
{
    [Route("1.0/api/chat")]
    public class ChatController : Controller
    {
        private readonly ChatService _chatService;
        private readonly ILogger<ChatController> _logger;

        public ChatController(ChatService chatService, ILogger<ChatController> logger)
        {
            _chatService = chatService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAvailableDialog() => Ok(_chatService.GetAvailableDialogs());

        [HttpGet("{protocolId:int}")]
        public IActionResult GetDialog(int protocolId)
        {
            try
            {
                var result = _chatService.GetDialog(protocolId);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ae)
            {
                _logger.LogError(ae, $"Failed to get dialog for protocol {protocolId}");

                return BadRequest();
            }
        }
    }
}
