using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OnionEAV.Application.CqrsAndMediatr.CQRS.Results.CategoryResults
{
    public class GetCategoryQueryResult
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}