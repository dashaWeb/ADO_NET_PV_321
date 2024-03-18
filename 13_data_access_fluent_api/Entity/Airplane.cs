namespace _13_data_access_fluent_api.Entity
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassanger { get; set; }
        //Navigation properties
        public ICollection<Flight> Flights { get; set; }
    }
}
