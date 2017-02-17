using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaygunTrello.Models
{
    public class TrelloCard
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Url { get; set; }
        public string Id { get; set; }
    }
}