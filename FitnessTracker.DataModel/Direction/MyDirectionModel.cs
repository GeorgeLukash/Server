namespace FitnessTracker.DataModel.Direction
{
    public class MyDirectionModel
    {
        public int Id { get; set; }
        public string DirectionName { get; set; }
        public string Street { get; set; }
        public int StreetId { get; set; }
        public int Distance { get; set; }
        public double Duration { get; set; }
        public double Speed { get; set; }
        public string Date { get; set; }    
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
}