using FinalExam.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("data source=.;initial catalog=FinalExam;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set composite primary key
            modelBuilder.Entity<ProductVariant>()
                .HasKey(p => new { p.ProductId, p.ProductTypeId });

            modelBuilder.Entity<ProductType>().HasData
                (
                    new ProductType() { Id = 1, Name = "Default" },
                    new ProductType() { Id = 2, Name = "Paperback" },
                    new ProductType() { Id = 3, Name = "E-Book" },
                    new ProductType() { Id = 4, Name = "Audiobook" },
                    new ProductType() { Id = 5, Name = "Stream" },
                    new ProductType() { Id = 6, Name = "Blu-ray" },
                    new ProductType() { Id = 7, Name = "VHS" },
                    new ProductType() { Id = 8, Name = "PC" },
                    new ProductType() { Id = 9, Name = "PlayStation" },
                    new ProductType() { Id = 10, Name = "Xbox" }
                );

            modelBuilder.Entity<Category>().HasData
                (
                    new Category()
                    {
                        Id = 1,
                        Name = "Books",
                        Url = "books"
                    },
                    new Category()
                    {
                        Id = 2,
                        Name = "Movies",
                        Url = "movies"
                    },
                    new Category()
                    {
                        Id = 3,
                        Name = "Video Games",
                        Url = "video-games"
                    }
                );

            modelBuilder.Entity<Product>().HasData
                (
                    new Product()
                    {
                        Id = 1,
                        Title = "The Lies of Locke Lamora",
                        Description = "The Lies of Locke Lamora is a 2006 fantasy novel by American writer Scott Lynch, the first book of the Gentleman Bastard series. Elite con artists calling themselves the \"Gentleman Bastards\" rob the rich of the city of Camorr, based on late medieval Venice but on an unnamed world.[2] Two stories interweave: in the present, the Gentleman Bastards fight a mysterious Grey King taking over the criminal underworld; alternate chapters describe the history of Camorr and the Gentleman Bastards, in particular Locke Lamora.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b1/Locke_Lamora.jpg",
                        Featured = true,
                        CategoryId = 1
                    },
                    new Product()
                    {
                        Id = 2,
                        Title = "Gardens of the Moon",
                        Description = "Gardens of the Moon is the first of ten novels in Canadian author Steven Erikson's high fantasy series the Malazan Book of the Fallen.The novel details the various struggles for power on an intercontinental region dominated by the Malazan Empire. It is notable for the use of high magic, and unusual plot structure. Gardens of the Moon centres around the Imperial campaign to conquer the city of Darujhistan on the continent of Genabackis.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/76/Three_Gardens_of_the_Moon.jpg",
                        CategoryId = 1
                    },
                    new Product()
                    {
                        Id = 3,
                        Title = "Hyperion Cantos",
                        Description = "The Hyperion Cantos is a series of science fiction novels by Dan Simmons. The title was originally used for the collection of the first pair of books in the series, Hyperion and The Fall of Hyperion,[1][2] and later came to refer to the overall storyline, including Endymion, The Rise of Endymion, and a number of short stories.[3][4] More narrowly, inside the fictional storyline, after the first volume, the Hyperion Cantos is an epic poem written by the character Martin Silenus covering in verse form the events of the first two books.[5]",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/73/Hyperion_cover.jpg",
                        CategoryId = 1
                    },
                    new Product()
                    {
                        Id = 4,
                        Title = "The Lord of the Rings: The Fellowship of the Ring",
                        Description = "The Lord of the Rings: The Fellowship of the Ring is a 2001 epic fantasy adventure film directed by Peter Jackson from a screenplay by Fran Walsh, Philippa Boyens, and Jackson, based on 1954's The Fellowship of the Ring, the first volume of the novel The Lord of the Rings by J. R. R. Tolkien. The film is the first installment in The Lord of the Rings trilogy. It features an ensemble cast including Elijah Wood, Ian McKellen, Liv Tyler, Viggo Mortensen, Sean Astin, Cate Blanchett, John Rhys-Davies, Billy Boyd, Dominic Monaghan, Orlando Bloom, Christopher Lee, Hugo Weaving, Sean Bean, Ian Holm, and Andy Serkis. Set in Middle-earth, the story tells of the Dark Lord Sauron, who seeks the One Ring, which contains part of his soul, in order to return to power. The Ring has found its way to the young hobbit Frodo Baggins. The fate of Middle-earth hangs in the balance as Frodo and eight companions (who form the Fellowship of the Ring) begin their journey to Mount Doom in the land of Mordor, the only place where the Ring can be destroyed.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Lord_of_the_Rings_The_Fellowship_of_the_Ring_%282001%29.jpg",
                        Featured = true,
                        CategoryId = 2
                    },
                    new Product()
                    {
                        Id = 5,
                        Title = "Avengers: Endgame",
                        Description = "Avengers: Endgame is a 2019 American superhero film based on the Marvel Comics superhero team the Avengers. Produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures, it is the direct sequel to Avengers: Infinity War (2018) and the 22nd film in the Marvel Cinematic Universe (MCU). Directed by Anthony and Joe Russo and written by Christopher Markus and Stephen McFeely, the film features an ensemble cast including Robert Downey Jr., Chris Evans, Mark Ruffalo, Chris Hemsworth, Scarlett Johansson, Jeremy Renner, Don Cheadle, Paul Rudd, Brie Larson, Karen Gillan, Danai Gurira, Benedict Wong, Jon Favreau, Bradley Cooper, Gwyneth Paltrow, and Josh Brolin. In the film, the surviving members of the Avengers and their allies attempt to reverse the destruction caused by Thanos in Infinity War.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg",
                        CategoryId = 2
                    },
                    new Product()
                    {
                        Id = 6,
                        Title = "Dune (2021 film)",
                        Description = "Dune (titled onscreen as Dune: Part One) is a 2021 American epic science fiction film directed by Denis Villeneuve from a screenplay by Villeneuve, Jon Spaihts, and Eric Roth. It is the first of a two-part adaptation of the 1965 novel by Frank Herbert, primarily covering the first half of the book. Set in the distant future, the film follows Paul Atreides as his family, the noble House Atreides, is thrust into a war for the deadly and inhospitable desert planet Arrakis. The ensemble cast includes Timothée Chalamet, Rebecca Ferguson, Oscar Isaac, Josh Brolin, Stellan Skarsgård, Dave Bautista, Stephen McKinley Henderson, Zendaya, David Dastmalchian, Chang Chen, Sharon Duncan-Brewster, Charlotte Rampling, Jason Momoa, and Javier Bardem.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/8e/Dune_%282021_film%29.jpg",
                        CategoryId = 2
                    },
                    new Product()
                    {
                        Id = 7,
                        Title = "Children of Morta",
                        Description = "Children of Morta is an action role-playing video game with roguelike elements, released in September 2019. Developed by studio Dead Mage, it follows the story of the Bergson family, custodians of Mount Morta, who must defend it from an evil called the Corruption.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/ae/Children_of_Morta.jpg",
                        Featured = true,
                        CategoryId = 3
                    },
                    new Product()
                    {
                        Id = 8,
                        Title = "Inscryption",
                        Description = "Inscryption is a roguelike deck-building game developed by Daniel Mullins Games and published by Devolver Digital. Inscryption was released for Microsoft Windows on October 19, 2021.[2]It was released on Linux and MacOS on June 22, 2022. Versions for PlayStation 4 and PlayStation 5 are scheduled for release in August 2022.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/48/Inscryption_Cover_Art.jpg",
                        CategoryId = 3
                    },
                    new Product()
                    {
                        Id = 9,
                        Title = "Ori and the Blind Forest",
                        Description = "Ori and the Blind Forest is a platform-adventure Metroidvania video game developed by Moon Studios and published by Microsoft Studios. The game was released for Xbox One and Microsoft Windows in March 2015, and for Nintendo Switch in September 2019. Players assume control of Ori, a small white spirit, and Sein, the \"light and eyes\" of the Forest's Spirit Tree. Players are tasked to move between platforms and solve puzzles. The game features a save system called \"Soul Links\", which allows players to save their progress at will with limited resources, and an upgrade system that gives players the ability to strengthen Ori's skills and abilities.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b2/Ori_and_the_Blind_Forest_Logo.jpg",
                        CategoryId = 3
                    },
                    new Product
                    {
                        Id = 10,
                        CategoryId = 3,
                        Title = "Xbox",
                        Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                    },
                    new Product
                    {
                        Id = 11,
                        CategoryId = 3,
                        Title = "Super Nintendo Entertainment System",
                        Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
                    }
                );

            modelBuilder.Entity<ProductVariant>().HasData
                (
                    new ProductVariant
                    {
                        ProductId = 1,
                        ProductTypeId = 2,
                        Price = 9.99m,
                        OriginalPrice = 19.99m
                    },
                    new ProductVariant
                    {
                        ProductId = 1,
                        ProductTypeId = 3,
                        Price = 7.99m
                    },
                    new ProductVariant
                    {
                        ProductId = 1,
                        ProductTypeId = 4,
                        Price = 19.99m,
                        OriginalPrice = 29.99m
                    },
                    new ProductVariant
                    {
                        ProductId = 2,
                        ProductTypeId = 2,
                        Price = 7.99m,
                        OriginalPrice = 14.99m
                    },
                    new ProductVariant
                    {
                        ProductId = 3,
                        ProductTypeId = 2,
                        Price = 6.99m
                    },
                    new ProductVariant
                    {
                        ProductId = 4,
                        ProductTypeId = 5,
                        Price = 3.99m
                    },
                    new ProductVariant
                    {
                        ProductId = 4,
                        ProductTypeId = 6,
                        Price = 9.99m
                    },
                    new ProductVariant
                    {
                        ProductId = 4,
                        ProductTypeId = 7,
                        Price = 19.99m
                    },
                    new ProductVariant
                    {
                        ProductId = 5,
                        ProductTypeId = 5,
                        Price = 3.99m,
                    },
                    new ProductVariant
                    {
                        ProductId = 6,
                        ProductTypeId = 5,
                        Price = 2.99m
                    },
                    new ProductVariant
                    {
                        ProductId = 7,
                        ProductTypeId = 8,
                        Price = 19.99m,
                        OriginalPrice = 29.99m
                    },
                    new ProductVariant
                    {
                        ProductId = 7,
                        ProductTypeId = 9,
                        Price = 69.99m
                    },
                    new ProductVariant
                    {
                        ProductId = 7,
                        ProductTypeId = 10,
                        Price = 49.99m,
                        OriginalPrice = 59.99m
                    },
                    new ProductVariant
                    {
                        ProductId = 8,
                        ProductTypeId = 8,
                        Price = 9.99m,
                        OriginalPrice = 24.99m,
                    },
                    new ProductVariant
                    {
                        ProductId = 9,
                        ProductTypeId = 8,
                        Price = 14.99m
                    },
                    new ProductVariant
                    {
                        ProductId = 10,
                        ProductTypeId = 1,
                        Price = 159.99m,
                        OriginalPrice = 299m
                    },
                    new ProductVariant
                    {
                        ProductId = 11,
                        ProductTypeId = 1,
                        Price = 79.99m,
                        OriginalPrice = 399m
                    }
                );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
    }
}
