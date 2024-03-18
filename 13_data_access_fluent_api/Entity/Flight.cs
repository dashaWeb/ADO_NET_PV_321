namespace _13_data_access_fluent_api.Entity
{
    public class Flight
    {
        public int Number { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }


        //Navigation properties
        public ICollection<Client> Clients { get; set; }
    }
}
