namespace Common.DAO.Access
{
    public interface IAccountContext
    {
        string Domain { get; set; }
        string ConnectionString { get; set; }
        string default_username { get; set; }
        string default_password { get; set; }
        string default_role { get; set; }
        string ServerDirectoryRoot { get; set; }
    }


}
