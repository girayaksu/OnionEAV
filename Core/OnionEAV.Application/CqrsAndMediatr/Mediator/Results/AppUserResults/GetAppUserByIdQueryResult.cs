using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OnionEAV.Application.CqrsAndMediatr.Mediator.Results.AppUserResults
{
    public class GetAppUserByIdQueryResult
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}