using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OnionEAV.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands
{
    public class CreateAppUserCommand : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}