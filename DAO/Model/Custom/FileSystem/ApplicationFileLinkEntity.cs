namespace SpeedFramework.DAO.Model.Custom.FileSystem
{
    public interface ApplicationFileLinkEntity
    {
        int Id { get; set; }
        ApplicationFileGroup ApplicationFileGroup { get; set; }
        int? ApplicationFileGroupId { get; set; }
    }
}