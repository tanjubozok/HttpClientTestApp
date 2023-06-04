namespace HttpClientTest.Repository.Seeds;

public class BlogCategorySeed : IEntityTypeConfiguration<BlogCategory>
{
    public void Configure(EntityTypeBuilder<BlogCategory> builder)
    {
        builder.HasData(new BlogCategory[]
        {
            new(){Id=1,CategoryId=1,BlogId=1},
            new(){Id=2,CategoryId=1,BlogId=2},
            new(){Id=3,CategoryId=2,BlogId=3},
            new(){Id=4,CategoryId=2,BlogId=4},
            new(){Id=5,CategoryId=3,BlogId=5},
            new(){Id=6,CategoryId=3,BlogId=6},
            new(){Id=7,CategoryId=4,BlogId=7},
            new(){Id=8,CategoryId=4,BlogId=8},
            new(){Id=9,CategoryId=5,BlogId=9},
            new(){Id=10,CategoryId=5,BlogId=10},
            new(){Id=11,CategoryId=6,BlogId=11},
            new(){Id=12,CategoryId=6,BlogId=12},
            new(){Id=13,CategoryId=7,BlogId=13},
            new(){Id=14,CategoryId=7,BlogId=14},
            new(){Id=15,CategoryId=8,BlogId=15},
            new(){Id=16,CategoryId=8,BlogId=16},
            new(){Id=17,CategoryId=9,BlogId=17},
            new(){Id=18,CategoryId=9,BlogId=18},
            new(){Id=19,CategoryId=10,BlogId=19},
            new(){Id=20,CategoryId=10,BlogId=20}
        });
    }
}
