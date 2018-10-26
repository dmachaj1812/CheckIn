using System.Text;
using Random = System.Random;

namespace CheckIn.Website.Models
{
    public class InivationNumberGenerator
    {
        public static string InvitationNumber()
        {
            //To do 
            Random rnd = new Random();
            StringBuilder RandomNumber = new StringBuilder();
            for(int i = 0; i<6; i++)
            {
                RandomNumber.Append(rnd.Next(0, 10));
            }

            return RandomNumber.ToString();
        }
    }
}