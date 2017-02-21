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
        public string IdBoard { get; set; }
    }

    public class TrelloComment
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public CommentData Data { get; set; }

        public class CommentData
        {
            public string Text { get; set; }
            public CardData Card { get; set; }

            public class CardData
            {
                public string Id { get; set; }
                public string Name { get; set; }
            }
        }

        public class MemberData
        {
            public string FullName { get; set; }
        }
    }
}