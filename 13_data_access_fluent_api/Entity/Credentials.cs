namespace _13_data_access_fluent_api.Entity
{
    public class Credentials
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int? ClientId { get; set; }

        public Client Client { get; set; }
    }
}
