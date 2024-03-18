using _13_data_access_fluent_api.Entity;
using Microsoft.EntityFrameworkCore;

namespace _13_data_access_fluent_api
{
    public class AirplaneDb : DbContext
    {
        public AirplaneDb()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"data source=DESKTOP-83U7DVV\SQLEXPRESS;
                                    initial catalog=newAirPlanePV321;
                                    integrated security=True;
                                    Connect Timeout = 2;
                                    Encrypt = False;
                                    Trust Server Certificate = False;
                                    Application Intent = ReadWrite;
                                    Multi Subnet Failover = False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Initializator - Seeder
            // Fluent API configuration
            modelBuilder.Entity<Airplane>()
                .Property(a=>a.Model) // column
                .IsRequired() // not null
                .HasMaxLength(100);// nvarchar(100)

            modelBuilder.Entity<Client>().ToTable("Passangers");
            modelBuilder.Entity<Client>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("FirstName");
            modelBuilder.Entity<Client>()
                .Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Flight>().HasKey(a => a.Number);
            modelBuilder.Entity<Flight>()
                .Property(a => a.DepartureCity)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Flight>()
                .Property(a => a.ArrivalCity)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Credentials>()
                .Property(a => a.Login)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Credentials>()
                .Property(a => a.Password)
                .IsRequired()
                .HasMaxLength(50);

            // one to many (1 .... *)
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airplane)
                .WithMany(f => f.Flights)
                .HasForeignKey(f => f.AirplaneId);

            // many to many (*......*)
            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Clients)
                .WithMany(f => f.Flights);

            // one to one (1...1)
            modelBuilder.Entity<Credentials>()
                .HasOne(c => c.Client)
                .WithOne(c => c.Credentials)
                .HasForeignKey<Credentials>(c => c.ClientId);

            modelBuilder.SeedAirplanes();
            modelBuilder.SeedClients();
            modelBuilder.SeedFlights();
            modelBuilder.SeedCredentials();
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
    }
}
