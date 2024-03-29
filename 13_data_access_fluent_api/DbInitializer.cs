﻿using _13_data_access_fluent_api.Entity;
using Microsoft.EntityFrameworkCore;

namespace _13_data_access_fluent_api
{
    public static class DbInitializer
    {

        public static void SeedAirplanes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
            {
                new Airplane()
                {
                    Id = 1,
                    Model = "Boing747",
                },
                new Airplane()
                {
                    Id = 2,
                    Model = "AN914",
                },
                new Airplane()
                {
                    Id = 3,
                    Model = "Mria",
                }
            });
        }
        public static void SeedFlights(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(new Flight[] {
                new Flight()
                {
                     Number = 1,
                     DepartureCity = "Kyiv",
                     ArrivalCity = "Lviv",
                     DepartureTime = new DateTime(2024,2,17),
                     ArrivalTime = new DateTime(2024,2,17),
                     AirplaneId = 1
                },
                new Flight()
                {
                     Number = 2,
                     DepartureCity = "Varshava",
                     ArrivalCity = "Lviv",
                     DepartureTime = new DateTime(2024,2,18),
                     ArrivalTime = new DateTime(2024,2,18),
                     AirplaneId = 2
                },
                new Flight()
                {
                     Number = 3,
                     DepartureCity = "Kyiv",
                     ArrivalCity = "Lviv",
                     DepartureTime = new DateTime(2024,2,22),
                     ArrivalTime = new DateTime(2024,2,22),
                     AirplaneId = 3
                }
            });
        }

        public static void SeedCredentials(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credentials>().HasData(new Credentials[] {
                new Credentials()
                {
                    Id = 1,
                    Login = "admin",
                    Password = "admin",
                    ClientId = 1,
                },
                new Credentials()
                {
                    Id = 2,
                    Login = "user",
                    Password = "user",
                    ClientId = 2,
                },
                new Credentials()
                {
                    Id = 3,
                    Login = "designer",
                    Password = "designer",
                    ClientId = 3,
                },
            });
        }
        public static void SeedClients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(new Client[]
            {
                new Client()
                {
                    Id = 1,
                    Name = "Victor",
                    Email = "victor@gmail.com",
                },
                new Client()
                {
                    Id = 2,
                    Name = "Ivanka",
                    Email = "ivanka@gmail.com",
                },
                new Client()
                {
                    Id = 3,
                    Name = "Oleg",
                    Email = "oleg@gmail.com",
                },
            });
        }
    }
}
