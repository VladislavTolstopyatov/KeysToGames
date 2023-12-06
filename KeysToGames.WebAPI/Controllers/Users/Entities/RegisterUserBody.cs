namespace KeysToGames.Controllers.Users.Entities
{
    public class RegisterUserBody
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public float MoneyBalance { get; set; }
        public string CardNumber { get; set; }
    }
}
