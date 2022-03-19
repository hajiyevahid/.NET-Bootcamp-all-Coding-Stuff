using System;
namespace Activity1
{
    /// <summary>
    /// Summary description for PlayerProfile.
    /// </summary>
    public class PlayerProfile
    {
        private static int profileCtr = 0;
        public const char MALE = 'M';
        public const char FEMALE = 'F';
        /// <summary>
        /// Constructor to initialize the PlayerProfile class.
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <param name="gender">Gender of the player</param>
        /// <param name="birthDate">The birthdate of the player</param>
        public PlayerProfile(string name, char gender, DateTime birthDate)
        {
            PlayerName = name;
            Gender = gender;
            BirthDate = birthDate;
            ProfileID = profileCtr++;
        }
        public string PlayerName { get; private set; }
        public char Gender { get; private set; }
        public DateTime BirthDate { get; set; }
        public int ProfileID { get; private set; }

        public int ComputeAge()
        {
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
            if ((currentMonth == birthdayMonth && birthdayDay < currentDayOfMonth) || (currentMonth > birthdayMonth))
            {
                tempAge = currentYear - birthdayYear;
            }
            else
            {
                tempAge = currentYear - birthdayYear - 1;
            }
            #endregion

            return tempAge;
        }
    }
}