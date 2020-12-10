using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RMotownFestival.Api.DAL;
using RMotownFestival.Api.Domain;

namespace RMotownFestival.Api.DAL
{
    public class MotownDbContext : DbContext
    {
        public MotownDbContext(DbContextOptions options): base(options)
        {
            var description = "A music festival is a festival oriented towards music that is sometimes presented with a theme such as musical genre, nationality or locality of musicians, or holiday. They are commonly held outdoors, and are often inclusive of other attractions such as food and merchandise vending machines, performance art, and social activities. Large music festivals such as Lollapalooza are constructed around well known main stage acts and lesser known musicians and bands on side stages. Many festivals are annual, or repeat at some other interval, and have modular staging of many types. Each year Lollapalooza often features multiple acts on its main and side stages.";

            
            var stages = new List<Stage>() {
                         new Stage { Id = 1, Name = "Main Stage", Description = description },
                         new Stage { Id = 2, Name = "Orange Room", Description = description },
                         new Stage { Id = 3, Name = "StarDust", Description = description },
                         new Stage { Id = 4 , Name = "Marvin Gaye", Description = description }
            };

            

            var artists = new List<Artist>() {
                      new Artist { Id = 1, Name = "Diana Ross", ImagePath = "dianaross.jpg", Website = new Uri("http://www.dianaross.co.uk/indexb.html") },
                      new Artist { Id = 2, Name = "The Commodores", ImagePath = "thecommodores.jpg", Website = new Uri("http://en.wikipedia.org/wiki/Commodores") },
                      new Artist { Id = 3, Name = "Stevie Wonder", ImagePath = "steviewonder.jpg", Website = new Uri("http://www.steviewonder.net/") },
                      new Artist { Id = 4, Name = "Lionel Richie", ImagePath = "lionelrichie.jpg", Website = new Uri("http://lionelrichie.com/") },
                      new Artist { Id = 5, Name = "Marvin Gaye", ImagePath = "marvingaye.jpg", Website = new Uri("http://www.marvingayepage.net/") }
        };

            Schedule lineUp = new Schedule();
            lineUp.Items.Add(new ScheduleItem { Id = 1, Artist = artists[0], Stage = stages[0], Time = new DateTime(1972, 07, 01, 20, 0, 0) });
            lineUp.Items.Add(new ScheduleItem { Id = 2, Artist = artists[4], Stage = stages[1], Time = new DateTime(1972, 07, 01, 20, 30, 0) });
            lineUp.Items.Add(new ScheduleItem { Id = 3, Artist = artists[2], Stage = stages[0], Time = new DateTime(1972, 07, 01, 22, 0, 0) });
            lineUp.Items.Add(new ScheduleItem { Id = 4, Artist = artists[1], Stage = stages[1], Time = new DateTime(1972, 07, 01, 22, 15, 0) });
            lineUp.Items.Add(new ScheduleItem { Id = 5, Artist = artists[0], Stage = stages[0], Time = new DateTime(1972, 07, 02, 20, 15, 0) });
            lineUp.Items.Add(new ScheduleItem { Id = 6, Artist = artists[4], Stage = stages[1], Time = new DateTime(1972, 07, 02, 20, 45, 0) });
            lineUp.Items.Add(new ScheduleItem { Id = 7, Artist = artists[3], Stage = stages[0], Time = new DateTime(1972, 07, 02, 22, 0, 0) });
            lineUp.Items.Add(new ScheduleItem { Id = 8, Artist = artists[1], Stage = stages[1], Time = new DateTime(1972, 07, 02, 22, 30, 0) });


            Festival Current = new Festival
            {
                LineUp = lineUp,
                Stages = stages,
                Artists = artists
            };
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Stage> Stages { get; set; }
        //public DbSet<ScheduleItem> ScheduleItems { get; set; }
        //public DbSet<Schedule> Schedules { get; set; }
        //public DbSet<Festival> Festivals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var description = "A music festival is a festival oriented towards music that is sometimes presented with a theme such as musical genre, nationality or locality of musicians, or holiday. They are commonly held outdoors, and are often inclusive of other attractions such as food and merchandise vending machines, performance art, and social activities. Large music festivals such as Lollapalooza are constructed around well known main stage acts and lesser known musicians and bands on side stages. Many festivals are annual, or repeat at some other interval, and have modular staging of many types. Each year Lollapalooza often features multiple acts on its main and side stages.";
            var stages = new List<Stage>() {
                new Stage { Id = 1, Name = "Main Stage", Description = description },
                new Stage { Id = 2, Name = "Orange Room", Description = description },
                new Stage { Id = 3, Name = "StarDust", Description = description },
                new Stage { Id = 4 , Name = "Marvin Gaye", Description = description }
            };

            

            var artists = new List<Artist>()
            {
                new Artist
                {
                    Id = 1, Name = "Diana Ross", ImagePath = "dianaross.jpg",
                    Website = new Uri("http://www.dianaross.co.uk/indexb.html")
                },
                new Artist
                {
                    Id = 2, Name = "The Commodores", ImagePath = "thecommodores.jpg",
                    Website = new Uri("http://en.wikipedia.org/wiki/Commodores")
                },
                new Artist
                {
                    Id = 3, Name = "Stevie Wonder", ImagePath = "steviewonder.jpg",
                    Website = new Uri("http://www.steviewonder.net/")
                },
                new Artist
                {
                    Id = 4, Name = "Lionel Richie", ImagePath = "lionelrichie.jpg",
                    Website = new Uri("http://lionelrichie.com/")
                },
                new Artist
                {
                    Id = 5, Name = "Marvin Gaye", ImagePath = "marvingaye.jpg",
                    Website = new Uri("http://www.marvingayepage.net/")
                }
            };
            modelBuilder.Entity<Stage>().HasData(
                new Stage {Id = 1, Name = "Main Stage", Description = description},
                new Stage {Id = 2, Name = "Orange Room", Description = description},
                new Stage {Id = 3, Name = "StarDust", Description = description},
                new Stage {Id = 4, Name = "Marvin Gaye", Description = description}
            );

            modelBuilder.Entity<Artist>().HasData(
                new Artist { Id = 1, Name = "Diana Ross", ImagePath = "dianaross.jpg", Website = new Uri("http://www.dianaross.co.uk/indexb.html") },
                new Artist { Id = 2, Name = "The Commodores", ImagePath = "thecommodores.jpg", Website = new Uri("http://en.wikipedia.org/wiki/Commodores") },
                new Artist { Id = 3, Name = "Stevie Wonder", ImagePath = "steviewonder.jpg", Website = new Uri("http://www.steviewonder.net/") },
                new Artist { Id = 4, Name = "Lionel Richie", ImagePath = "lionelrichie.jpg", Website = new Uri("http://lionelrichie.com/") },
                new Artist { Id = 5, Name = "Marvin Gaye", ImagePath = "marvingaye.jpg", Website = new Uri("http://www.marvingayepage.net/") }
                );

            

            Schedule lineUp = new Schedule();
            lineUp.Items.Add(new ScheduleItem { Id = 1, Artist = artists[0], Stage = stages[0], Time = new DateTime(1972, 07, 01, 20, 0, 0) });
            lineUp.Items.Add(new ScheduleItem { Id = 2, Artist = artists[4], Stage = stages[1], Time = new DateTime(1972, 07, 01, 20, 30, 0) });
            lineUp.Items.Add(new ScheduleItem { Id = 3, Artist = artists[2], Stage = stages[0], Time = new DateTime(1972, 07, 01, 22, 0, 0) });
            lineUp.Items.Add(new ScheduleItem { Id = 4, Artist = artists[1], Stage = stages[1], Time = new DateTime(1972, 07, 01, 22, 15, 0) });
            lineUp.Items.Add(new ScheduleItem { Id = 5, Artist = artists[0], Stage = stages[0], Time = new DateTime(1972, 07, 02, 20, 15, 0) });
            lineUp.Items.Add(new ScheduleItem { Id = 6, Artist = artists[4], Stage = stages[1], Time = new DateTime(1972, 07, 02, 20, 45, 0) });
            lineUp.Items.Add(new ScheduleItem { Id = 7, Artist = artists[3], Stage = stages[0], Time = new DateTime(1972, 07, 02, 22, 0, 0) });
            lineUp.Items.Add(new ScheduleItem { Id = 8, Artist = artists[1], Stage = stages[1], Time = new DateTime(1972, 07, 02, 22, 30, 0) });

            //modelBuilder.Entity<ScheduleItem>().HasKey(c => new {c.Stage, c.Artist});

            //modelBuilder.Entity<ScheduleItem>().HasData(
            //    new ScheduleItem
            //        {Id = 1, Artist = artists[0], Stage = stages[0], Time = new DateTime(1972, 07, 01, 20, 0, 0)},
            //    new ScheduleItem
            //        {Id = 2, Artist = artists[4], Stage = stages[1], Time = new DateTime(1972, 07, 01, 20, 30, 0)},
            //    new ScheduleItem
            //        {Id = 3, Artist = artists[2], Stage = stages[0], Time = new DateTime(1972, 07, 01, 22, 0, 0)},
            //    new ScheduleItem
            //        {Id = 4, Artist = artists[1], Stage = stages[1], Time = new DateTime(1972, 07, 01, 22, 15, 0)},
            //    new ScheduleItem
            //        {Id = 5, Artist = artists[0], Stage = stages[0], Time = new DateTime(1972, 07, 02, 20, 15, 0)},
            //    new ScheduleItem
            //        {Id = 6, Artist = artists[4], Stage = stages[1], Time = new DateTime(1972, 07, 02, 20, 45, 0)},
            //    new ScheduleItem
            //        {Id = 7, Artist = artists[3], Stage = stages[0], Time = new DateTime(1972, 07, 02, 22, 0, 0)},
            //    new ScheduleItem
            //        {Id = 8, Artist = artists[1], Stage = stages[1], Time = new DateTime(1972, 07, 02, 22, 30, 0)}
            //);

            //modelBuilder.Entity<Schedule>().HasKey(c => new 
            //{
            //    c.Items
            //});

            //modelBuilder.Entity<Schedule>().HasData(
            //     new Schedule { Items = lineUp.Items }
            //     );

            //modelBuilder.Entity<Festival>().HasKey(c => new {c.LineUp, c.Artists, c.Stages});

            //modelBuilder.Entity<Festival>().HasData(
            //    new Festival
            //    {
            //        LineUp = lineUp,
            //        Stages = stages,
            //        Artists = artists
            //    }
            //);
        }
    }
}

