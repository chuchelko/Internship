namespace Problem16
{
    using System;

    internal class Post
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public virtual User User { get; set; }
        public virtual string Text { get; set; }
    }
}