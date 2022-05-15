namespace Problem16.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FluentNHibernate.Mapping;

    internal class PostMap : ClassMap<Post>
    {
        public PostMap()
        {
            Id(post => post.Id).GeneratedBy.Guid();
            Map(post => post.CreationTime);
            Map(post => post.Text);
            References(post => post.User);
            Table("posts");
        }
    }
}
