using CheckIn.Entitites.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;


namespace CheckIn.Entitites
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    

    public class CheckInDbContext :  IdentityDbContext
    {
      

        public CheckInDbContext() : base("DefaultConnection")
        {
         //  Database.SetInitializer(new MigrateDatabaseToLatestVersion<CheckInDbContext,CheckIn.Entitites.Migrations.Configuration>());
           Database.SetInitializer<CheckInDbContext>(new ChceckInDbInitializer());
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<State>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<InvitationCard>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<InvitationMaker>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<EventType>()
                .HasKey(s => s.Id);
            
            

        }
        public static CheckInDbContext Create()
        {
            return new CheckInDbContext();
        }

       
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<InvitationCard> InvitationCards { get; set; }
        public DbSet<InvitationImage> InvitationImages { get; set; }
        public DbSet<InvitationNumbersList> InvitationNumbersLists { get; set; }




    }
    public class ChceckInDbInitializer : DropCreateDatabaseIfModelChanges<CheckInDbContext>
    {
        protected override void Seed(CheckInDbContext context)
        {
           
            IList<State> states = new List<State>()
            {
                new State()
                {
                    StateCode = "AL",
                    NameOfTheState = "Alabama"
                },
                new State()
                {
                    StateCode = "AK",
                    NameOfTheState = "Alaska"
                },
                new State()
                {
                StateCode = "Az",
                NameOfTheState = "Arizona"
                },
                new State()
                {
                    StateCode = "AR",
                    NameOfTheState = "Arkansas"
                },
                new State()
                {
                    StateCode = "CA",
                    NameOfTheState = "California"
                },
                new State()
                {
                    StateCode = "CO",
                    NameOfTheState = "Colorado"
                },
                new State()
                {
                    StateCode = "CT",
                    NameOfTheState = "Connecticut"
                },
                new State()
                {
                    StateCode = "DE",
                    NameOfTheState = "Delaware"
                },
                new State()
                {
                    StateCode = "DC",
                    NameOfTheState = "District of Columbia"
                },
                new State()
                {
                    StateCode = "FL",
                    NameOfTheState = "Florida"
                },
                new State()
                {
                    StateCode = "GA",
                    NameOfTheState = "Georgia"
                }, new State()
                {
                    StateCode = "HI",
                    NameOfTheState = "Hawaii"
                }, new State()
                {
                    StateCode = "ID",
                    NameOfTheState = "Idaho"
                }, new State()
                {
                    StateCode = "IL",
                    NameOfTheState = "Illinois"
                }, new State()
                {
                    StateCode = "IN",
                    NameOfTheState = "Indiana"
                }, new State()
                {
                    StateCode = "IA",
                    NameOfTheState = "Iowa"
                }, new State()
                {
                    StateCode = "KS",
                    NameOfTheState = "Kansas"
                }, new State()
                {
                    StateCode = "KY",
                    NameOfTheState = "Kentucky"
                }, new State()
                {
                    StateCode = "LA",
                    NameOfTheState = "Louisiana"
                }, new State()
                {
                    StateCode = "ME",
                    NameOfTheState = "Maine"
                }, new State()
                {
                    StateCode = "MD",
                    NameOfTheState = "Maryland"
                }, new State()
                {
                    StateCode = "MA",
                    NameOfTheState = "Massachusetts"
                }, new State()
                {
                    StateCode = "MI",
                    NameOfTheState = "Michigan"
                }, new State()
                {
                    StateCode = "MN",
                    NameOfTheState = "Minnesota"
                }, new State()
                {
                    StateCode = "MS",
                    NameOfTheState = "Mississippi"
                }, new State()
                {
                    StateCode = "MO",
                    NameOfTheState = "Missouri"
                }, new State()
                {
                    StateCode = "MT",
                    NameOfTheState = "Montana"
                }, new State()
                {
                    StateCode = "NE",
                    NameOfTheState = "Nebraska"
                }, new State()
                {
                    StateCode = "NV",
                    NameOfTheState = "Nevada"
                }, new State()
                {
                    StateCode = "NH",
                    NameOfTheState = "New Hampshire"
                }, new State()
                {
                    StateCode = "NJ",
                    NameOfTheState = "New Jersey"
                }, new State()
                {
                    StateCode = "NM",
                    NameOfTheState = "New Mexico"
                }, new State()
                {
                    StateCode = "NY",
                    NameOfTheState = "New York"
                }, new State()
                {
                    StateCode = "NC",
                    NameOfTheState = "North Carolina"
                }, new State()
                {
                    StateCode = "ND",
                    NameOfTheState = "North Dakota"
                }, new State()
                {
                    StateCode = "OH",
                    NameOfTheState = "Ohio"
                }, new State()
                {
                    StateCode = "OK",
                    NameOfTheState = "Oklahoma"
                }, new State()
                {
                    StateCode = "OR",
                    NameOfTheState = "Oregon"
                }, new State()
                {
                    StateCode = "PA",
                    NameOfTheState = "Pennsylvania"
                }, new State()
                {
                    StateCode = "RI",
                    NameOfTheState = "Rhode Island"
                }, new State()
                {
                    StateCode = "SC",
                    NameOfTheState = "South Carolina"
                }, new State()
                {
                    StateCode = "SD",
                    NameOfTheState = "South Dakota"
                }, new State()
                {
                    StateCode = "TN",
                    NameOfTheState = "Tennessee"
                }, new State()
                {
                    StateCode = "TX",
                    NameOfTheState = "Texas"
                }, new State()
                {
                    StateCode = "UT",
                    NameOfTheState = "Utah"
                }, new State()
                {
                    StateCode = "VT",
                    NameOfTheState = "Vermont"
                }, new State()
                {
                    StateCode = "VA",
                    NameOfTheState = "Virginia"
                }, new State()
                {
                    StateCode = "WA",
                    NameOfTheState = "Washington"
                }, new State()
                {
                    StateCode = "WV",
                    NameOfTheState = "West Virginia"
                }, new State()
                {
                    StateCode = "WI",
                    NameOfTheState = "Wisconsin"
                }, new State()
                {
                    StateCode = "WY",
                    NameOfTheState = "Wyoming"
                }
            };
            IList<EventType> eventTypes = new List<EventType>()
            {
                new EventType()
                {
                    IsActive = true,
                    EventTypeName = "Conference"
                },
                new EventType()
                {
                    IsActive = true,
                    EventTypeName = "Seminars"
                },
                new EventType()
                {
                    IsActive = true,
                    EventTypeName = "Meeting"
                },
                new EventType()
                {
                    IsActive = true,
                    EventTypeName = "Weeding"
                },new EventType()
                {
                    IsActive = true,
                    EventTypeName = "Meeting"
                },
                new EventType()
                {
                    IsActive = true,
                    EventTypeName = "Convention"
                },
                new EventType()
                {
                    IsActive = true,
                    EventTypeName = "Trade"
                },
                new EventType()
                {
                    IsActive = true,
                    EventTypeName = "Baby Shower"
                },
                new EventType()
                {
                    IsActive = true,
                    EventTypeName = "Birthday"
                },
                new EventType()
                {
                    IsActive = true,
                    EventTypeName = "Anniversaries"
                },
                new EventType()
                {
                    IsActive = true,
                    EventTypeName = "Family Events"
                },
                new EventType()
                {
                    IsActive = true,
                    EventTypeName = "Bridal Shower"
                }


            };

            //Seed InvitationCard/Invitaiton Image

            IList<InvitationImage> invitationImages = new List<InvitationImage>
            {
                new InvitationImage
                {   
                    IsActive = true,
                    Name = "Wedding Invitaion",
                    ImageSource = "/content/invitations/ZdjecieSlubne_1.jpg"
                }
            };

            IList<InvitationCard> invitaionCards = new List<InvitationCard>
            {
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                IsActive = true,
                Name = "Wedding Invitation",
                Price = (decimal)3.99,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                              ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                Quantity = 400,
                EventTypeId = 4,
                InvitationImageId = 0
                },
                new InvitationCard
                {
                 IsActive = true,
                 Name = "Bridal Shower Invitaion",
                 Price = (decimal)3.99,
                 Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                 Quantity = 400,
                 EventTypeId = 12,
                 InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Wedding Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 4,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 9,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
                ,
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Baby Shower Invitaion",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 8,
                    InvitationImageId = 0
                },
                new InvitationCard
                {
                    IsActive = true,
                    Name = "Bridal Shower Invitation",
                    Price = (decimal)3.99,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dapibus est tortor" +
                                  ", sagittis mattis nisi malesuada ut. Sed aliquam nibh eros",
                    Quantity = 400,
                    EventTypeId = 12,
                    InvitationImageId = 0
                }
            };


            context.States.AddRange(states);
            context.EventTypes.AddRange(eventTypes);
            context.InvitationImages.AddRange(invitationImages);
            context.InvitationCards.AddRange(invitaionCards);
            context.SaveChanges();
            base.Seed(context);

        }

    }
   

}
