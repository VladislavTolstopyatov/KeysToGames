namespace KeysToGames.Controllers.Admin.Entities
{
    public class RegisterAdminBody
    {
        public string Login { get; set; }
        public int PasswordHash { get; set; }
    }
}
