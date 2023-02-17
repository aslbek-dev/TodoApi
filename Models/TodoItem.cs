using System;
namespace TodoApi.Models
{
    public class TodoItem
    {
        public int Id{get; set;}
        public int user_id {get; set;}
        public string? Name{get; set;}
        public string? Description{get; set;}
        public bool IsComplete{get; set;}
        public DateTime CreatedAt{get; set;}
        public DateTime UpdatedAt{get; set;}
        
    }
}