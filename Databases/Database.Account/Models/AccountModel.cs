namespace Database.Account.Models
{
    /// <summary>
    ///     Account model
    /// </summary>
    public class AccountModel
    {
        public int Id { get; set; }

        /// <summary>
        ///     Login
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        ///     Password
        /// </summary>
        public string Password { get; set; }
    }
}