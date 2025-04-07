namespace Post.Domain.Entities.DTO
{
   public class UpdateDto
    {
        public string Id { get; set; } = null!;
        public string NickName { get; set; } = null!;
        public string? Description { get; set; }
        public string WhatIsFunc { get; set; } = null!;
    }
}
