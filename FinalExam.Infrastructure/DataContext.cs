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
						Price = 9.99m,
						CategoryId = 1
					},
					new Product()
					{
						Id = 2,
						Title = "Gardens of the Moon",
						Description = "Gardens of the Moon is the first of ten novels in Canadian author Steven Erikson's high fantasy series the Malazan Book of the Fallen.The novel details the various struggles for power on an intercontinental region dominated by the Malazan Empire. It is notable for the use of high magic, and unusual plot structure. Gardens of the Moon centres around the Imperial campaign to conquer the city of Darujhistan on the continent of Genabackis.",
						ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/76/Three_Gardens_of_the_Moon.jpg",
						Price = 7.99m,
						CategoryId = 1
					},
					new Product()
					{
						Id = 3,
						Title = "Hyperion Cantos",
						Description = "he Hyperion Cantos is a series of science fiction novels by Dan Simmons. The title was originally used for the collection of the first pair of books in the series, Hyperion and The Fall of Hyperion,[1][2] and later came to refer to the overall storyline, including Endymion, The Rise of Endymion, and a number of short stories.[3][4] More narrowly, inside the fictional storyline, after the first volume, the Hyperion Cantos is an epic poem written by the character Martin Silenus covering in verse form the events of the first two books.[5]",
						ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/73/Hyperion_cover.jpg",
						Price = 11.99m,
						CategoryId = 1
					}
				);
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
