namespace _13_data_access_fluent_api.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Flight> Flights { get; set; }
        // one to one
        public Credentials Credentials { get; set; }
    }
}
