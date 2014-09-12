using BookStore.Domain;
using System.Data.Entity.ModelConfiguration;

namespace BookStore.Data.Mappings
{
    public class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            ToTable("Author");

            HasKey(x => x.Id);
            Property(x => x.FirstName).HasMaxLength(60).IsRequired();
            Property(x => x.LastName).HasMaxLength(60).IsRequired();
        }
    }
}
