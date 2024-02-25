using EsemkaLibrary.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<EsemkaLibraryContext>();
builder.Services.AddDbContext<EsemkaLibraryContext>(x =>
{
    x.UseInMemoryDatabase("Example");
    x.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "EsemkaLibrary.API", Version = "v1" });

    // Define JWT security scheme
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    // Define the operation security requirements
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
.AddJwtBearer("JwtBearer", jwtOptions =>
{
    jwtOptions.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication")),
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = true,
        ValidateLifetime = true,
        ClockSkew = System.TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

Seed(app);


app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

static async void Seed(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<EsemkaLibraryContext>( );

    if (db == null)
        return;

    List<BookCategory> bookCategories = new List<BookCategory>
        {
            new BookCategory { Id = 1, CategoryName = "Fiction" },
            new BookCategory { Id = 2, CategoryName = "Non-fiction" },
            new BookCategory { Id = 3, CategoryName = "Drama" },
            new BookCategory { Id = 4, CategoryName = "Romance" },
            new BookCategory { Id = 5, CategoryName = "Fantasy" },
            new BookCategory { Id = 6, CategoryName = "Science" },
            new BookCategory { Id = 7, CategoryName = "History" },
            new BookCategory { Id = 8, CategoryName = "Mottography" },
            new BookCategory { Id = 9, CategoryName = "Education" },
            new BookCategory { Id = 10, CategoryName = "Art" },
            new BookCategory { Id = 11, CategoryName = "Sports" }
        };

    List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "To Kill a Mockingbird", Author = "Harper Lee", PublicationYear = 1960, Isbn = "9780061120084", Cover = "To_Kill_a_Mockingbird.jpeg", Categories = [bookCategories[0], bookCategories[3]]},
            new Book { Id = 2, Title = "1984", Author = "George Orwell", PublicationYear = 1949, Isbn = "9780451524935", Cover = "1984.jpeg" },
            new Book { Id = 3, Title = "Pride and Prejudice", Author = "Jane Austen", PublicationYear = 1813, Isbn = "9780141439518", Cover = "Pride.jpeg" },
            new Book { Id = 4, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublicationYear = 1925, Isbn = "9780743273565", Cover = "Gatsby.jpeg" },
            new Book { Id = 5, Title = "The Catcher in the Rye", Author = "J.D. Salinger", PublicationYear = 1951, Isbn = "9780316769488", Cover = "TheCatcher.jpeg" },
            new Book { Id = 6, Title = "To the Lighthouse", Author = "Virginia Woolf", PublicationYear = 1927, Isbn = "9780156907392", Cover = "To_the_Lighthouse.jpeg" },
            new Book { Id = 7, Title = "Moby", Author = "Herman Melville", PublicationYear = 1851, Isbn = "9780142437247", Cover = "Moby.jpeg" },
            new Book { Id = 8, Title = "Frankenstein", Author = "Mary Shelley", PublicationYear = 1818, Isbn = "9780199537150", Cover = "Frankenstein.jpeg" },
            new Book { Id = 9, Title = "The Picture of Dorian Gray", Author = "Oscar Wilde", PublicationYear = 1890, Isbn = "9780141439570", Cover = "The_Picture_of_Dorian_Gray.jpeg" }
        };
     


    List<User> users = new List<User>
        {
            new User { Id = 1, Username = "johndoe", Password = "password1", FullName = "John Doe", DateOfBirth = DateTime.Parse("1990-05-15 00:00:00.0000000"), Motto = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", JoinDate = DateTime.Parse("2024-02-23 09:11:05.7900000") },
            new User { Id = 2, Username = "janesmith", Password = "password2", FullName = "Jane Smith", DateOfBirth = DateTime.Parse("1985-09-23 00:00:00.0000000"), Motto = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.", JoinDate = DateTime.Parse("2024-02-23 09:11:05.7900000") },
            new User { Id = 3, Username = "michaeljohnson", Password = "password3", FullName = "Michael Johnson", DateOfBirth = DateTime.Parse("1993-02-10 00:00:00.0000000"), Motto = "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.", JoinDate = DateTime.Parse("2024-02-23 09:11:05.7900000") },
            new User { Id = 4, Username = "emilybrown", Password = "password4", FullName = "Emily Brown", DateOfBirth = DateTime.Parse("1988-07-30 00:00:00.0000000"), Motto = "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", JoinDate = DateTime.Parse("2024-02-23 09:11:05.7900000") },
            new User { Id = 5, Username = "davidwilson", Password = "password5", FullName = "David Wilson", DateOfBirth = DateTime.Parse("1995-11-18 00:00:00.0000000"), Motto = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium.", JoinDate = DateTime.Parse("2024-02-23 09:11:05.7900000") },
            new User { Id = 6, Username = "sarahtaylor", Password = "password6", FullName = "Sarah Taylor", DateOfBirth = DateTime.Parse("1983-04-27 00:00:00.0000000"), Motto = "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia", JoinDate = DateTime.Parse("2024-02-23 09:11:05.7900000") },
            new User { Id = 7, Username = "christophermartinez", Password = "password7", FullName = "Christopher Martinez", DateOfBirth = DateTime.Parse("1992-08-08 00:00:00.0000000"), Motto = "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit.", JoinDate = DateTime.Parse("2024-02-23 09:11:05.7900000") },
            new User { Id = 8, Username = "jessicawhite", Password = "password8", FullName = "Jessica White", DateOfBirth = DateTime.Parse("1987-12-12 00:00:00.0000000"), Motto = "Sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.", JoinDate = DateTime.Parse("2024-02-23 09:11:05.7900000") },
            new User { Id = 9, Username = "danielanderson", Password = "password9", FullName = "Daniel Anderson", DateOfBirth = DateTime.Parse("1991-03-25 00:00:00.0000000"), Motto = "Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam.", JoinDate = DateTime.Parse("2024-02-23 09:11:05.7900000") },
            new User { Id = 10, Username = "mariagarcia", Password = "password10", FullName = "Maria Garcia", DateOfBirth = DateTime.Parse("1986-06-06 00:00:00.0000000"), Motto = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint.", JoinDate = DateTime.Parse("2024-02-23 09:11:05.7900000") }
        };

    List<BookLike> bookLikes = new List<BookLike>
        {
            new BookLike { Id = 1, BookId = 3, UserId = 1, LikeDate = DateTime.Parse("2022-04-08 09:11:05.8200000") },
            new BookLike { Id = 2, BookId = 1, UserId = 7, LikeDate = DateTime.Parse("2022-04-08 09:11:05.8200000") },
            new BookLike { Id = 3, BookId = 2, UserId = 5, LikeDate = DateTime.Parse("2022-04-08 09:11:05.8200000") },
            new BookLike { Id = 4, BookId = 8, UserId = 9, LikeDate = DateTime.Parse("2022-04-08 09:11:05.8200000") },
            new BookLike { Id = 5, BookId = 10, UserId = 6, LikeDate = DateTime.Parse("2022-04-08 09:11:05.8200000") },
            new BookLike { Id = 6, BookId = 4, UserId = 5, LikeDate = DateTime.Parse("2022-04-08 09:11:05.8200000") },
            new BookLike { Id = 7, BookId = 3, UserId = 8, LikeDate = DateTime.Parse("2022-04-08 09:11:05.8200000") },
            new BookLike { Id = 8, BookId = 7, UserId = 9, LikeDate = DateTime.Parse("2022-04-08 09:11:05.8200000") },
            new BookLike { Id = 9, BookId = 2, UserId = 9, LikeDate = DateTime.Parse("2022-04-08 09:11:05.8200000") },
            new BookLike { Id = 10, BookId = 10, UserId = 9, LikeDate = DateTime.Parse("2022-04-08 09:11:05.8200000") },
            // Lanjutkan sampai semua data dimasukkan
        };

    List<BookContent> BookContents = new List<BookContent>
        {
            new BookContent { Id = 1, BookId = 1, Content = "To Kill a Mockingbird is a novel by Harper Lee published in 1960. It was immediately successful, winning the Pulitzer Prize, and has become a classic of modern American literature. The plot and characters are loosely based on Lee's observations of her family, her neighbors and an event that occurred near her hometown of Monroeville, Alabama, in 1936, when she was 10 years old. The story is told by the six-year-old Jean Louise 'Scout' Finch. The novel is renowned for its warmth and humor, despite dealing with serious issues such as racial inequality and rape. The narrator's father, Atticus Finch, has served as a moral hero for many readers and as a model of integrity for lawyers. Historian J.C. Furnas has described To Kill a Mockingbird as 'the most widely read book dealing with race in America, and its protagonist, Atticus Finch, the most enduring fictional image of racial heroism.'" },
            new BookContent { Id = 2, BookId = 1, Content = "The novel opens with Scout describing her family history and introducing the Finch family and their small town of Maycomb, Alabama. Scout, her brother Jem, and their friend Dill are intrigued by their reclusive neighbor Boo Radley and make it their mission to draw him out of his house. Meanwhile, their father Atticus, a lawyer, defends Tom Robinson, a black man falsely accused of raping a white woman. The trial exposes the deep-seated racism in Maycomb and leads to tragic consequences." },
            new BookContent { Id = 3, BookId = 2, Content = "1984 is a dystopian social science fiction novel by English novelist George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, Nineteen Eighty-Four centres on the consequences of totalitarianism, mass surveillance, and repressive regimentation of persons and behaviours within society. Orwell, a democratic socialist, modelled the totalitarian regime in the novel after Stalinist Russia and Nazi Germany. More broadly, the novel examines the role of truth and facts within politics and the ways in which they can be manipulated. The story takes place in an imagined future, the year 1984, when much of the world has fallen victim to perpetual war, omnipresent government surveillance, historical negationism, and propaganda. Great Britain, known as Airstrip One, has become a province of a totalitarian superstate named Oceania that is ruled by the Party, who employ the Thought Police to persecute individuality and independent thinking. Big Brother, the leader of the Party, enjoys an intense cult of personality despite the fact that he may not even exist. The protagonist, Winston Smith, is a diligent and skillful rank-and-file worker and Outer Party member who secretly hates the Party and dreams of rebellion. He enters into a forbidden love affair with a colleague, Julia, and starts to become rebellious by keeping a diary of his secret thoughts. Winston's desire to rebel is aroused by O Brien, a high-ranking Inner Party member who secretly opposes the Party, and believes Winston will be worth the risk to the Party if he can be cured of his disbelief in Party doctrine." },
            new BookContent { Id = 4, BookId = 2, Content = "As Winston and Julia's relationship deepens, they become involved in a subversive group known as the Brotherhood, led by the elusive Emmanuel Goldstein. However, their clandestine activities are discovered by the Thought Police, and they are arrested and tortured until they betray each other. In the end, Winston betrays Julia and is brainwashed into loving Big Brother, symbolizing the complete destruction of his individuality and humanity." },
            new BookContent { Id = 5, BookId = 3, Content = "Pride and Prejudice is an 1813 romantic novel of manners written by Jane Austen. The novel follows the character development of Elizabeth Bennet, the dynamic protagonist of the book who learns about the repercussions of hasty judgments and comes to appreciate the difference between superficial goodness and actual goodness. Its humour lies in its honest depiction of manners, education, marriage, and money during the Regency era in Great Britain. Mr. Bennet of the Longbourn estate has five daughters, but his property is entailed, meaning that none of the girls can inherit it. His wife has no fortune, so it is imperative that at least one of the girls marry well to support the others on his death. The novel revolves around the importance of marrying for love, not simply for financial gain or social status, despite the communal pressure to make a good (i.e., wealthy) match." },
            new BookContent { Id = 6, BookId = 3, Content = "Elizabeth Bennet, the spirited and intelligent protagonist, is one of Austen's most popular characters. As the novel progresses, she learns to set aside her prejudices and misconceptions, ultimately finding love and happiness with the proud and enigmatic Mr. Darcy. Their romance is marked by misunderstandings, social conventions, and personal growth, making Pride and Prejudice a timeless tale of love and self-discovery." },
            new BookContent { Id = 7, BookId = 4, Content = "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald. Set in the Jazz Age on Long Island, the novel depicts narrator Nick Carraway's interactions with mysterious millionaire Jay Gatsby and Gatsby's obsession to reunite with his former lover, Daisy Buchanan. The novel is widely regarded as a cautionary tale about the American Dream. It explores themes of decadence, idealism, resistance to change, social upheaval, and excess, creating a portrait of the Roaring Twenties that has been described as a cautionary tale regarding the American Dream." },
            new BookContent { Id = 8, BookId = 4, Content = "Nick Carraway, a young man from Minnesota, moves to New York in the summer of 1922 to learn about the bond business. He rents a house in the West Egg district of Long Island, a wealthy but unfashionable area populated by the newly rich. Across the bay in the more fashionable East Egg district, Nick's cousin Daisy Buchanan and her husband Tom live in a grand house. Nick quickly becomes drawn into the glamorous and hedonistic world of his wealthy neighbors, including the enigmatic Jay Gatsby, whose extravagant parties are the talk of the town." },
            new BookContent { Id = 9, BookId = 5, Content = "Holden Caulfield is a cynical teenager who has been expelled from several schools. After failing out of yet another prep school, he wanders the streets of New York City feeling increasingly isolated and disillusioned with the 'phoniness' of the adult world. He struggles with the loss of his brother Allie and his own mental health issues as he searches for authenticity in a world he perceives as superficial." },
            new BookContent { Id = 10, BookId = 5, Content = "Throughout his journey, Holden encounters various characters, including his younger sister Phoebe, a former teacher Mr. Antolini, and a prostitute named Sunny. Each interaction sheds light on different aspects of Holden's personality and worldview." },
            new BookContent { Id = 11, BookId = 6, Content = "To the Lighthouse is a novel that centers on the Ramsay family and their visits to the Isle of Skye in Scotland between 1910 and 1920. The novel explores themes of love, marriage, creativity, and the passage of time. It is divided into three parts: 'The Window,' 'Time Passes,' and 'The Lighthouse.'"},
            new BookContent { Id = 12, BookId = 6, Content = "In 'The Window,' the Ramsay family and their guests spend the summer at their vacation home on the Isle of Skye. Mrs. Ramsay, the matriarch of the family, organizes a trip to the lighthouse, but the journey is postponed due to bad weather. During this time, the characters reflect on their relationships and aspirations." },
            new BookContent { Id = 13, BookId = 7, Content = "Moby is a novel by Herman Melville that tells the story of Captain Ahab's quest for revenge on the white whale Moby, which had previously destroyed his ship and severed his leg at the knee. The novel is famous for its extensive descriptions of whaling and maritime life, as well as its philosophical reflections on fate, obsession, and the nature of evil." },
            new BookContent { Id = 14, BookId = 7, Content = "The narrative follows Ishmael, a sailor on Ahab's ship, the Pequod, as he recounts his experiences and observations during the voyage. As the crew hunts the elusive whale across the oceans, tensions rise and conflicts emerge among the diverse group of characters onboard." },
            new BookContent { Id = 15, BookId = 8, Content = "Frankenstein; or, The Modern Prometheus is a novel written by English author Mary Shelley that tells the story of Victor Frankenstein, a young scientist who creates a sapient creature in an unorthodox scientific experiment. The creature, often mistakenly referred to as 'Frankenstein,' is abandoned by his creator and left to fend for himself in a hostile world." },
            new BookContent { Id = 16, BookId = 8, Content = "The novel explores themes of ambition, responsibility, and the consequences of scientific discovery. Victor Frankenstein becomes consumed by guilt and remorse as he witnesses the havoc wreaked by his creation, while the creature grapples with his own identity and seeks acceptance from society." },
            new BookContent { Id = 17, BookId = 9, Content = "The Picture of Dorian Gray is a Gothic and philosophical novel by Oscar Wilde, first published complete in the July 1890 issue of Lippincott's Monthly Magazine. The novel tells the story of Dorian Gray, a young man who becomes obsessed with his own youth and beauty and makes a Faustian bargain to retain his youth while his portrait ages instead." },
            new BookContent { Id = 18, BookId = 9, Content = "As Dorian indulges in a life of hedonism and vice, his portrait becomes a reflection of his moral decay, while he remains perpetually youthful and unblemished. The novel explores themes of vanity, morality, and the pursuit of pleasure, and serves as a critique of the superficiality and decadence of Victorian society." }
        };


  

    foreach (var item in books)
    {
        Random randomrr = new Random();

        // Mendapatkan angka acak antara 1 hingga 5 (inklusif)
        int numCategories = randomrr.Next(1, 6);

        // Mendapatkan indeks acak dari bookCategories untuk kategori
        HashSet<int> chosenIndices = new HashSet<int>();
        while (chosenIndices.Count < numCategories)
        {
            chosenIndices.Add(randomrr.Next(0, bookCategories.Count));
        }

        // Membuat list kategori berdasarkan indeks yang dipilih
        foreach (var dd in chosenIndices)
        {
            item.Categories.Add(bookCategories[dd]);
        }
    }
     

    Random random = new Random();
    List<Bookmark> bookmarks = new List<Bookmark>();
    HashSet<Tuple<int, int>> uniqueBookmarks = new HashSet<Tuple<int, int>>(); // Tuple untuk menyimpan pasangan (UserId, BookId)

    // Generate random data for bookmarks
    for (int i = 1; i <= 20; i++)
    {
        int userId = random.Next(1, 11); // Random user id from 1 to 10
        int bookId = random.Next(1, 10); // Random book id from 1 to 9

        Tuple<int, int> bookmarkTuple = Tuple.Create(userId, bookId);

        // Check if the generated bookmark is unique
        if (!uniqueBookmarks.Contains(bookmarkTuple))
        {
            Bookmark bookmark = new Bookmark
            {
                Id = i,
                UserId = userId,
                BookId = bookId,
                BookmarkDate = DateTime.Now.AddDays(-random.Next(1, 365)) // Random date within the last year
            };

            bookmarks.Add(bookmark);
            uniqueBookmarks.Add(bookmarkTuple);
        }
    }

    Random random2 = new Random();
    List<BookLike> likes = new List<BookLike>();
    HashSet<Tuple<int, int>> uniqueLikes = new HashSet<Tuple<int, int>>(); // Tuple untuk menyimpan pasangan (UserId, BookId)

    // Generate random data for likes
    for (int i = 1; i <= 20; i++)
    {
        int userId = random2.Next(1, 11); // Random user id from 1 to 10
        int bookId = random2.Next(1, 10); // Random book id from 1 to 9

        Tuple<int, int> likeTuple = Tuple.Create(userId, bookId);

        // Check if the generated like is unique
        if (!uniqueLikes.Contains(likeTuple))
        {
            var like = new BookLike
            { 
                UserId = userId,
                BookId = bookId,
                LikeDate = DateTime.Now.AddDays(-random2.Next(1, 365)) // Random date within the last year
            };

            likes.Add(like);
            uniqueLikes.Add(likeTuple);
        }
    } 

    await db.AddRangeAsync(users);
    await db.AddRangeAsync(bookCategories);
    await db.AddRangeAsync(books);
    await db.AddRangeAsync(bookLikes);
    await db.AddRangeAsync(BookContents);
    await db.AddRangeAsync(bookmarks);


    await db.SaveChangesAsync();


    db = scope.ServiceProvider.GetService<EsemkaLibraryContext>();
    await db.BookLikes.AddRangeAsync(likes);


    await db.SaveChangesAsync();

}