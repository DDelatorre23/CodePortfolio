using System;
using System.ComponentModel.DataAnnotations;

namespace CommunityWebSite.Models
{
    public class Reply
    {
        public int ReplyID { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Please don't waste my time with such small replies.")]
        [MaxLength(50, ErrorMessage = "Too long, didn't read.")]
        public string Body { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
