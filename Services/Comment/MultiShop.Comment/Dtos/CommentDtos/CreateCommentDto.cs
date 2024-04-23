﻿namespace MultiShop.Comment.Dtos
{
    public class CreateCommentDto
    {
        public string ProductId { get; set; }
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
