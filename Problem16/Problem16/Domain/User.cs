namespace Problem16
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class User
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string SecondName { get; set; }
        public virtual string Email { get; set; }
        public virtual Location Location { get; set; }
        public virtual IList<Post> Posts { get; set; } = new List<Post>();

        public virtual void Add(Post post)
        {
            post.User = this;
            Posts.Add(post);
        }

    }

    internal class Location
    {
        public virtual string Country { get; set; }
        public virtual string City { get; set; }
        public virtual string Adress { get; set; }
        
    }
}
