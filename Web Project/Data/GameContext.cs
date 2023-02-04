using Microsoft.EntityFrameworkCore;
using Web_Project.Models;

public class GameContext : DbContext
{
    public GameContext(DbContextOptions<GameContext> options)
        : base(options)
    {
    }

    public DbSet<Game> Games { get; set; } = default!;

    public DbSet<Platform> Platforms { get; set; } = default!;
    public DbSet<GameState> gameStates { get; set; } = default!;

    public DbSet<Admin> Admins { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<Platform>().HasData(
            new Platform
            {
                Name = "Pc",
                Id = 1
            }
            ,
            new Platform
            {
                Name = "Console",
                Id = 2
            }
            ,
            new Platform
            {
                Name = "Playstation",
                Id = 3
            });


        modelBuilder.Entity<GameState>().HasData(
        new GameState
        {
            
            Name = "Released",
            Id = 1
        }
        ,
        new GameState
        {
            Name = "EarlyAccess",
            Id = 2
        }
        ,
        new GameState
        {
            Name = "Upcoming",
            Id = 3
        });


        modelBuilder.Entity<Admin>().HasData(

            new Admin
            {
                Name = "yousef",
                Password = "123",
                Id = 1
            }
             ,
             new Admin
             {
                 Name = "ali",
                 Password = "234",
                 Id = 2
             }
             ,
              new Admin
              {
                  Name = "hi",
                  Password = "345",
                  Id = 3
              }
            ) ;

        modelBuilder.Entity<Game>().HasData(
         new Game
         {

             GameStateId = 1,
             name = "Overwatch",
             src = "https://blz-contentstack-images.akamaized.net/v3/assets/blta8f9a8e092360c6c/bltdf9dd58b1d2893d5/6324a79fe337fa0dc7263db4/overwatch2.jpg?format=webply&quality=80&auto=webp",
             PlatformId = 1,
             releaseDate = "12/2",
             GameId = 1 ,
             

         }
         ,
            new Game
            {

                GameStateId = 2,
                name = "Overwatch",
                src = "https://blz-contentstack-images.akamaized.net/v3/assets/blta8f9a8e092360c6c/bltdf9dd58b1d2893d5/6324a79fe337fa0dc7263db4/overwatch2.jpg?format=webply&quality=80&auto=webp",
                PlatformId = 2,
                releaseDate = "12/2",
                GameId = 2,


            }
            ,
               new Game
               {

                   GameStateId = 3,
                   name = "Overwatch",
                   src = "https://blz-contentstack-images.akamaized.net/v3/assets/blta8f9a8e092360c6c/bltdf9dd58b1d2893d5/6324a79fe337fa0dc7263db4/overwatch2.jpg?format=webply&quality=80&auto=webp",
                   PlatformId = 3,
                   releaseDate = "12/2",
                   GameId = 3,


               }
               ,
                  new Game
                  {

                      GameStateId = 3,
                      name = "Heroes of the storm",
                      src = "https://blz-contentstack-images.akamaized.net/v3/assets/blta8f9a8e092360c6c/bltce07525c7490946d/61a50fc22e73ff101cdc1c8d/heroes.jpg?format=webply&quality=80&auto=webp",
                      PlatformId = 1,
                      releaseDate = "12/2",
                      GameId = 4,


                  }
                  ,
                     new Game
                     {

                         GameStateId = 2,
                         name = "Starcraft II",
                         src = "https://blz-contentstack-images.akamaized.net/v3/assets/blta8f9a8e092360c6c/blt3873027b9450f357/61a50f033c4e21100a80f1fc/starcraft2.jpg?format=webply&quality=80&auto=webp",
                         PlatformId = 2,
                         releaseDate = "12/2",
                         GameId = 5,


                     }


         ) ; 





    }

}

