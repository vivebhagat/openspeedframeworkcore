using SpeedFramework.Common.CoreModels;

namespace SpeedFramework.DAO.Model.Custom.Scripting
{
    public class Script: Auditable, IActivableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public bool Inactive { get; set; }
        public string ApplicationNumber { get; set; }
        public string LegacyNumber { get; set; }
    }
}