using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaygunTrello.Models
{
    public class TrelloMember
    {
        public string Id { get; set; }
        public List<string> IdBoards { get; set; }
        public string UserName { get; set; }
    }
}