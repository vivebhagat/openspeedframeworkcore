namespace SpeedFramework.Common.CoreModels
{
    public interface TEntity 
    {
        int Id { get; set; }
        string ApplicationNumber { get; set; }
        string LegacyNumber { get; set; }

//        [NotMapped]
//        Dictionary<int, string> ExtraData { get; set; }
    }
}