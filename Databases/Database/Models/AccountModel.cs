using System.Collections.Generic;

namespace Database.Models
{
    /// <summary>
    ///     Account model
    /// </summary>
    public class AccountModel
    {
        public AccountModel()
        {
            Characters = new List<CharacterModel>();
        }

        public int Id { get; set; }

        /// <summary>
        ///     Login
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        ///     Password
        /// </summary>
        public string Password { get; set; }

        public List<CharacterModel> Characters { get; set; }
    }
}