namespace FitnessTracker.DataModel.Direction
{
    public class UpdateDirectionModel
    {
        public int Id { get; set; }
        public string DirectionName { get; set; }
        public int Speed { get; set; }
        public int Duration { get; set; }
        public int Distance { get; set; }
        public string Street { get; set; }
        public int StreetId { get; set; }
    }
}
