using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Context
{
    public class RecipeBookContext : DbContext
    {
        public RecipeBookContext(DbContextOptions<RecipeBookContext> options)
            : base(options) { }

        public DbSet<IngredientType> IngredientTypes { get; set; }
        public DbSet<MeasurementType> MeasurementTypes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeBook> RecipeBooks { get; set; }
        public DbSet<RecipeBookItem> RecipeBookItems { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<RecipeType> RecipeTypes { get; set; }
        public DbSet<RecipeTag> RecipeTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientType>().HasData(
                new IngredientType { Id = 1, Name = "Su" },
                new IngredientType { Id = 2, Name = "Süt" },
                new IngredientType { Id = 3, Name = "Şeker" },
                new IngredientType { Id = 4, Name = "Un" },
                new IngredientType { Id = 5, Name = "Tuz" },
                new IngredientType { Id = 6, Name = "Çikolata" },
                new IngredientType { Id = 7, Name = "Kakao" },
                new IngredientType { Id = 8, Name = "Kabartma Tozu" },
                new IngredientType { Id = 9, Name = "Vanilin" },
                new IngredientType { Id = 10, Name = "Domates" },
                new IngredientType { Id = 11, Name = "Marul" },
                new IngredientType { Id = 12, Name = "Salatalık" },
                new IngredientType { Id = 13, Name = "Soğan" },
                new IngredientType { Id = 14, Name = "Turşu" },
                new IngredientType { Id = 15, Name = "Limon" },
                new IngredientType { Id = 16, Name = "Lime" },
                new IngredientType { Id = 17, Name = "Bisküvi" },
                new IngredientType { Id = 18, Name = "Krema" },
                new IngredientType { Id = 19, Name = "Buğday Nişastası" },
                new IngredientType { Id = 20, Name = "Mısır Nişastası" },
                new IngredientType { Id = 21, Name = "Nutella" },
                new IngredientType { Id = 22, Name = "Sirke" },
                new IngredientType { Id = 23, Name = "Milföy" },
                new IngredientType { Id = 24, Name = "Sosis" },
                new IngredientType { Id = 25, Name = "Salça" },
                new IngredientType { Id = 26, Name = "Kaşar Peyniri" },
                new IngredientType { Id = 27, Name = "Mozerella" },
                new IngredientType { Id = 28, Name = "Sıvıyağ" },
                new IngredientType { Id = 29, Name = "Zeytinyağ" },
                new IngredientType { Id = 30, Name = "Roka" },
                new IngredientType { Id = 31, Name = "Tavuk" },
                new IngredientType { Id = 32, Name = "Et" },
                new IngredientType { Id = 33, Name = "Balık" },
                new IngredientType { Id = 34, Name = "Kemalpaşa" },
                new IngredientType { Id = 35, Name = "Biber" },
                new IngredientType { Id = 36, Name = "Pirinç" },
                new IngredientType { Id = 37, Name = "Tavuk Suyu" },
                new IngredientType { Id = 38, Name = "Kekik" },
                new IngredientType { Id = 39, Name = "Karabiber" },
                new IngredientType { Id = 40, Name = "Pulbiber" },
                new IngredientType { Id = 41, Name = "Tereyağ" }
            );

            modelBuilder.Entity<IngredientType>()
                .Property(i => i.Id)
                .HasIdentityOptions(startValue: 42);

            modelBuilder.Entity<MeasurementType>().HasData(
                new MeasurementType { Id = 1, Name = "250 ml" },
                new MeasurementType { Id = 2, Name = "125 ml" },
                new MeasurementType { Id = 3, Name = "50 ml" },
                new MeasurementType { Id = 4, Name = "Su Barağı" },
                new MeasurementType { Id = 5, Name = "Çay Bardağı" },
                new MeasurementType { Id = 6, Name = "Yemek Kaşığı" },
                new MeasurementType { Id = 7, Name = "Çay Kaşığı" },
                new MeasurementType { Id = 8, Name = "Tatlı Kaşığı" },
                new MeasurementType { Id = 9, Name = "500 ml" },
                new MeasurementType { Id = 10, Name = "1000 ml" },
                new MeasurementType { Id = 11, Name = "1 pk" },
                new MeasurementType { Id = 12, Name = "1 adet" },
                new MeasurementType { Id = 13, Name = "Gram" },
                new MeasurementType { Id = 14, Name = "Çimdik" },
                new MeasurementType { Id = 15, Name = "Yaprak" },
                new MeasurementType { Id = 16, Name = "25 ml" }
            );

            modelBuilder.Entity<MeasurementType>()
                .Property(i => i.Id)
                .HasIdentityOptions(startValue: 17);

            modelBuilder.Entity<RecipeType>().HasData(
                new RecipeType { Id = 1, Name = "Sütlü Tatlılar" },
                new RecipeType { Id = 2, Name = "Tavuk Yemekleri" },
                new RecipeType { Id = 3, Name = "Salatalar" },
                new RecipeType { Id = 4, Name = "Et Yemekleri" },
                new RecipeType { Id = 5, Name = "Şerbetli Tatlılar" },
                new RecipeType { Id = 6, Name = "Çikolatalı  Tatlılar" }
            );

            modelBuilder.Entity<RecipeType>()
                .Property(i => i.Id)
                .HasIdentityOptions(startValue: 7);

            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "Çikolata" },
                new Tag { Id = 2, Name = "Şerbet" },
                new Tag { Id = 3, Name = "Hamur" },
                new Tag { Id = 4, Name = "Pratik" },
                new Tag { Id = 5, Name = "Tavuk" },
                new Tag { Id = 6, Name = "Pilav" },
                new Tag { Id = 7, Name = "Tatlı" },
                new Tag { Id = 8, Name = "Tuzlu" },
                new Tag { Id = 9, Name = "Az Kalorili" },
                new Tag { Id = 10, Name = "Etli" }
            );

            modelBuilder.Entity<Tag>()
                .Property(i => i.Id)
                .HasIdentityOptions(startValue: 11);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Kübra", LastName = "Doğan Er", Username = "dogankub", PasswordHash = "sffsafsfsfsas" },
                new User { Id = 2, FirstName = "Ralph", LastName = "Fiennes", Username = "fiennes", PasswordHash = "" },
                new User { Id = 3, FirstName = "Roy", LastName = "Scheider", Username = "scheider", PasswordHash = "" },
                new User { Id = 4, FirstName = "John", LastName = "Candy", Username = "candy", PasswordHash = "" },
                new User { Id = 5, FirstName = "Steve", LastName = "Buscemi", Username = "buscemi", PasswordHash = "" },
                new User { Id = 6, FirstName = "Pierce", LastName = "Brosnan", Username = "brosnan", PasswordHash = "" },
                new User { Id = 7, FirstName = "Ewan", LastName = "McGregor", Username = "mcgregor", PasswordHash = "" }
            );

            modelBuilder.Entity<User>()
                .Property(i => i.Id)
                .HasIdentityOptions(startValue: 8);

            modelBuilder.Entity<Recipe>().HasData(
                    new Recipe { Id = 1, Name = "İzmir Bombası", RecipeTypeId = 6, CreatedUserId = 1 },
                    new Recipe { Id = 2, Name = "Tavuklu Salata", RecipeTypeId = 3, CreatedUserId = 4 },
                    new Recipe { Id = 3, Name = "Kemalpaşa", RecipeTypeId = 5, CreatedUserId = 2 },
                    new Recipe { Id = 4, Name = "Tavuk Sote", RecipeTypeId = 2, CreatedUserId = 3 },
                    new Recipe { Id = 5, Name = "Et Sote", RecipeTypeId = 4, CreatedUserId = 1 },
                    new Recipe { Id = 6, Name = "Tavuklu Pilav", RecipeTypeId = 2, CreatedUserId = 1 }
                );

            modelBuilder.Entity<Recipe>()
                .Property(i => i.Id)
                .HasIdentityOptions(startValue: 7);

            modelBuilder.Entity<RecipeIngredient>().HasData(
               new RecipeIngredient { Id = 1, RecipeId = 1, IngredientTypeId = 1, MeasurementTypeId = 8, Amount = 1 },
                new RecipeIngredient { Id = 2, RecipeId = 1, IngredientTypeId = 2, MeasurementTypeId = 8, Amount = 1 },
                new RecipeIngredient { Id = 3, RecipeId = 1, IngredientTypeId = 4, MeasurementTypeId = 13, Amount = 40 },
                new RecipeIngredient { Id = 4, RecipeId = 1, IngredientTypeId = 5, MeasurementTypeId = 14, Amount = 1 },
                new RecipeIngredient { Id = 5, RecipeId = 1, IngredientTypeId = 21, MeasurementTypeId = 8, Amount = 10 },
                new RecipeIngredient { Id = 6, RecipeId = 1, IngredientTypeId = 22, MeasurementTypeId = 7, Amount = 1 },
                new RecipeIngredient { Id = 7, RecipeId = 1, IngredientTypeId = 28, MeasurementTypeId = 8, Amount = 2 },
                new RecipeIngredient { Id = 8, RecipeId = 1, IngredientTypeId = 19, MeasurementTypeId = 13, Amount = 5 },
                new RecipeIngredient { Id = 9, RecipeId = 2, IngredientTypeId = 11, MeasurementTypeId = 15, Amount = 3 },
                new RecipeIngredient { Id = 10, RecipeId = 2, IngredientTypeId = 12, MeasurementTypeId = 12, Amount = 1 },
                new RecipeIngredient { Id = 11, RecipeId = 2, IngredientTypeId = 13, MeasurementTypeId = 12, Amount = 1 },
                new RecipeIngredient { Id = 12, RecipeId = 2, IngredientTypeId = 14, MeasurementTypeId = 12, Amount = 2 },
                new RecipeIngredient { Id = 13, RecipeId = 2, IngredientTypeId = 15, MeasurementTypeId = 12, Amount = 1 },
                new RecipeIngredient { Id = 14, RecipeId = 2, IngredientTypeId = 10, MeasurementTypeId = 12, Amount = 1 },
                new RecipeIngredient { Id = 15, RecipeId = 2, IngredientTypeId = 30, MeasurementTypeId = 15, Amount = 10 },
                new RecipeIngredient { Id = 16, RecipeId = 2, IngredientTypeId = 31, MeasurementTypeId = 13, Amount = 250 },
                new RecipeIngredient { Id = 17, RecipeId = 2, IngredientTypeId = 29, MeasurementTypeId = 13, Amount = 5 },
                new RecipeIngredient { Id = 18, RecipeId = 2, IngredientTypeId = 5, MeasurementTypeId = 13, Amount = 5 },
                new RecipeIngredient { Id = 19, RecipeId = 3, IngredientTypeId = 34, MeasurementTypeId = 11, Amount = 1 },
                new RecipeIngredient { Id = 20, RecipeId = 3, IngredientTypeId = 1, MeasurementTypeId = 4, Amount = 5 },
                new RecipeIngredient { Id = 21, RecipeId = 3, IngredientTypeId = 3, MeasurementTypeId = 4, Amount = 4 },
                new RecipeIngredient { Id = 22, RecipeId = 3, IngredientTypeId = 15, MeasurementTypeId = 16, Amount = 1 },
                new RecipeIngredient { Id = 23, RecipeId = 4, IngredientTypeId = 31, MeasurementTypeId = 13, Amount = 500 },
                new RecipeIngredient { Id = 24, RecipeId = 4, IngredientTypeId = 29, MeasurementTypeId = 13, Amount = 20 },
                new RecipeIngredient { Id = 25, RecipeId = 4, IngredientTypeId = 25, MeasurementTypeId = 6, Amount = 1 },
                new RecipeIngredient { Id = 26, RecipeId = 4, IngredientTypeId = 10, MeasurementTypeId = 12, Amount = 1 },
                new RecipeIngredient { Id = 27, RecipeId = 4, IngredientTypeId = 13, MeasurementTypeId = 12, Amount = 1 },
                new RecipeIngredient { Id = 28, RecipeId = 4, IngredientTypeId = 35, MeasurementTypeId = 12, Amount = 2 },
                new RecipeIngredient { Id = 29, RecipeId = 5, IngredientTypeId = 32, MeasurementTypeId = 13, Amount = 500 },
                new RecipeIngredient { Id = 30, RecipeId = 5, IngredientTypeId = 29, MeasurementTypeId = 13, Amount = 20 },
                new RecipeIngredient { Id = 31, RecipeId = 5, IngredientTypeId = 25, MeasurementTypeId = 6, Amount = 1 },
                new RecipeIngredient { Id = 32, RecipeId = 5, IngredientTypeId = 10, MeasurementTypeId = 12, Amount = 1 },
                new RecipeIngredient { Id = 33, RecipeId = 5, IngredientTypeId = 13, MeasurementTypeId = 12, Amount = 1 },
                new RecipeIngredient { Id = 34, RecipeId = 5, IngredientTypeId = 35, MeasurementTypeId = 12, Amount = 2 },
                new RecipeIngredient { Id = 35, RecipeId = 6, IngredientTypeId = 31, MeasurementTypeId = 13, Amount = 300 },
                new RecipeIngredient { Id = 36, RecipeId = 6, IngredientTypeId = 36, MeasurementTypeId = 4, Amount = 2 },
                new RecipeIngredient { Id = 37, RecipeId = 6, IngredientTypeId = 37, MeasurementTypeId = 4, Amount = 3 },
                new RecipeIngredient { Id = 38, RecipeId = 6, IngredientTypeId = 39, MeasurementTypeId = 13, Amount = 2 },
                new RecipeIngredient { Id = 39, RecipeId = 6, IngredientTypeId = 41, MeasurementTypeId = 13, Amount = 25 },
                new RecipeIngredient { Id = 40, RecipeId = 6, IngredientTypeId = 28, MeasurementTypeId = 13, Amount = 10 }
           );

            modelBuilder.Entity<RecipeIngredient>()
                .Property(i => i.Id)
                .HasIdentityOptions(startValue: 41);

            modelBuilder.Entity<RecipeTag>().HasData(
                new RecipeTag { Id = 1, RecipeId = 1, TagId = 1 },
                new RecipeTag { Id = 2, RecipeId = 1, TagId = 7 },
                new RecipeTag { Id = 3, RecipeId = 1, TagId = 4 },
                new RecipeTag { Id = 4, RecipeId = 2, TagId = 9 },
                new RecipeTag { Id = 5, RecipeId = 2, TagId = 5 },
                new RecipeTag { Id = 6, RecipeId = 2, TagId = 8 },
                new RecipeTag { Id = 7, RecipeId = 3, TagId = 7 },
                new RecipeTag { Id = 8, RecipeId = 3, TagId = 2 },
                new RecipeTag { Id = 9, RecipeId = 3, TagId = 3 },
                new RecipeTag { Id = 10, RecipeId = 4, TagId = 8 },
                new RecipeTag { Id = 11, RecipeId = 4, TagId = 5 },
                new RecipeTag { Id = 12, RecipeId = 5, TagId = 8 },
                new RecipeTag { Id = 13, RecipeId = 5, TagId = 10 },
                new RecipeTag { Id = 14, RecipeId = 6, TagId = 5 },
                new RecipeTag { Id = 15, RecipeId = 6, TagId = 6 },
                new RecipeTag { Id = 16, RecipeId = 6, TagId = 8 }
            );

            modelBuilder.Entity<RecipeTag>()
                .Property(i => i.Id)
                .HasIdentityOptions(startValue: 17);

            modelBuilder.Entity<RecipeBook>().HasData(
                new RecipeBook { Id = 1, UserId = 1, Name = "Kubra'nın Defteri" },
                new RecipeBook { Id = 2, UserId = 2, Name = "Ralph'un Defteri" },
                new RecipeBook { Id = 3, UserId = 3, Name = "Roy'un Defteri" },
                new RecipeBook { Id = 4, UserId = 4, Name = "John'un Defteri" },
                new RecipeBook { Id = 5, UserId = 5, Name = "Steve'n Defteri" },
                new RecipeBook { Id = 6, UserId = 6, Name = "Pierce'n Defteri" },
                new RecipeBook { Id = 7, UserId = 7, Name = "Ewan'ın Defteri" }
            );

            modelBuilder.Entity<RecipeBook>()
                .Property(i => i.Id)
                .HasIdentityOptions(startValue: 8);

            modelBuilder.Entity<RecipeBookItem>().HasData(
                new RecipeBookItem { Id = 1, RecipeId = 1, RecipeBookId = 1 },
                new RecipeBookItem { Id = 2, RecipeId = 2, RecipeBookId = 1 },
                new RecipeBookItem { Id = 3, RecipeId = 3, RecipeBookId = 1 },
                new RecipeBookItem { Id = 4, RecipeId = 4, RecipeBookId = 1 },
                new RecipeBookItem { Id = 5, RecipeId = 5, RecipeBookId = 2 },
                new RecipeBookItem { Id = 6, RecipeId = 1, RecipeBookId = 2 },
                new RecipeBookItem { Id = 7, RecipeId = 2, RecipeBookId = 2 },
                new RecipeBookItem { Id = 8, RecipeId = 6, RecipeBookId = 3 },
                new RecipeBookItem { Id = 9, RecipeId = 1, RecipeBookId = 3 },
                new RecipeBookItem { Id = 10, RecipeId = 2, RecipeBookId = 3 },
                new RecipeBookItem { Id = 11, RecipeId = 4, RecipeBookId = 3 },
                new RecipeBookItem { Id = 12, RecipeId = 1, RecipeBookId = 4 },
                new RecipeBookItem { Id = 13, RecipeId = 5, RecipeBookId = 4 },
                new RecipeBookItem { Id = 14, RecipeId = 3, RecipeBookId = 4 },
                new RecipeBookItem { Id = 15, RecipeId = 4, RecipeBookId = 4 },
                new RecipeBookItem { Id = 16, RecipeId = 6, RecipeBookId = 4 },
                new RecipeBookItem { Id = 17, RecipeId = 5, RecipeBookId = 5 },
                new RecipeBookItem { Id = 18, RecipeId = 1, RecipeBookId = 6 },
                new RecipeBookItem { Id = 19, RecipeId = 4, RecipeBookId = 6 },
                new RecipeBookItem { Id = 20, RecipeId = 6, RecipeBookId = 6 },
                new RecipeBookItem { Id = 21, RecipeId = 2, RecipeBookId = 7 },
                new RecipeBookItem { Id = 22, RecipeId = 3, RecipeBookId = 7 },
                new RecipeBookItem { Id = 23, RecipeId = 6, RecipeBookId = 7 },
                new RecipeBookItem { Id = 24, RecipeId = 4, RecipeBookId = 7 }
            );

            modelBuilder.Entity<RecipeBookItem>()
                .Property(i => i.Id)
                .HasIdentityOptions(startValue: 25);

            modelBuilder.Entity<Menu>().HasData(
                new Menu { Id = 1, Name = "Akşam Yemegi" },
                new Menu { Id = 2, Name = "Lezzetli Bir Mola" },
                new Menu { Id = 3, Name = "Tatlı ve Daha Fazlası" },
                new Menu { Id = 4, Name = "Pratik Menü" }
            );

            modelBuilder.Entity<Menu>()
                .Property(i => i.Id)
                .HasIdentityOptions(startValue: 5);

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, RecipeId = 2, MenuId = 1 },
                new MenuItem { Id = 2, RecipeId = 3, MenuId = 1 },
                new MenuItem { Id = 3, RecipeId = 1, MenuId = 2 },
                new MenuItem { Id = 4, RecipeId = 1, MenuId = 3 },
                new MenuItem { Id = 5, RecipeId = 3, MenuId = 3 },
                new MenuItem { Id = 6, RecipeId = 2, MenuId = 4 }
            );

            modelBuilder.Entity<MenuItem>()
                .Property(i => i.Id)
                .HasIdentityOptions(startValue: 7);
        }
    }
}
