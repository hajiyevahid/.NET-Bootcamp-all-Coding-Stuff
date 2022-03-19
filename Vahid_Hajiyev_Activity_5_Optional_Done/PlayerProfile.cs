namespace CSharp.Activity.Profile
{
    /// <summary>
    ///      Summary description for PlayerProfile.
    /// </summary>
    public class PlayerProfile
    {
        private static int profileCtr = 0;
        public const char MALE = 'M';
        public const char FEMALE = 'F';

        /// <summary>
        ///      Constructor to initialize the PlayerProfile class.
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <param name="gender">Gender of the player</param>
        /// <param name="birthDate">The birthdate of the player</param>
        /// <param name="maximum">The maximum number of cards that player can hold</param>
        public PlayerProfile(string name, char gender, DateTime birthDate, byte maximum)
        {
            PlayerName = name;
            Gender = gender;
            BirthDate = birthDate;
            ProfileID = profileCtr++;
            MaxCardCount = maximum;
        }

        /// <summary>
        ///      Property to return the player's Name.
        /// </summary>
        public string PlayerName { get; private set; }

        /// <summary>
        ///      Property to return the player's Gender.
        /// </summary>
        public char Gender { get; private set; }
        // public int maximum { get;  set; }    

        /// <summary>
        ///      Property to return the player's Birth Date.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        ///      Property to return the maximum card count of player can hold.
        /// </summary>
        public byte MaxCardCount { get; set; }

        /// <summary>
        ///      Property to return the player's Profile Id.
        ///       Profile Id is used by the application instance, and is not designed to serve as a primary key for database storage.
        /// </summary>
        public int ProfileID { get; private set; }

        /// <summary>
        ///    Method to compute the age of the player based on the Birth Date.
        /// </summary>
        /// <returns>
        ///    Number of full years.
        /// </returns>
        public int ComputeAge()
        {
            //The following variables give you the current year/month/date and the actual birth year/month/date
            //for the age that you must compute

            DateTime currentDate = DateTime.Now;     // current date instance 

            int currentMonth = currentDate.Month;   // current month
            int birthdayMonth = this.BirthDate.Month;// month of birth

            int currentYear = currentDate.Year;      // current year
            int birthdayYear = this.BirthDate.Year;  // year of birth

            int currentDayOfMonth = currentDate.Day; // current day of month   
            int birthdayDay = this.BirthDate.Day;    // date of birth

            int tempAge = -1; // default value - invalid age 

            #region Activity 1.0
            // TODO: Compute the age in years, based on the values of
            // the variables given above and assign it to the variable 'tempAge'.
            // You may declare additional local variables if necessary, but
            // you are NOT allowed to use pre-built .NET APIs.

            // :::

            #endregion

            return tempAge;
        }
    }
}