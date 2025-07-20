﻿using System.ComponentModel.DataAnnotations;

namespace Online_Learning.Models.DTOs.Comment
{
    public class UpdateCommentRequest
    {
        [Required(ErrorMessage = "Content is required")]
        [StringLength(1000, ErrorMessage = "Content cannot exceed 1000 characters")]
        public string Content { get; set; } = null!;
    }
}
