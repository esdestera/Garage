using System.Data.Entity.Migrations;
using System.Linq;

namespace Models
{
    /// <summary>
    /// Summary description for UserInformationModel
    /// </summary>
    public class UserInformationModel
    {
        public UserInformation GetUserInformation(string guID)
        {
            GarageEntities context = new GarageEntities();

            var userInfo = context.UserInformation.FirstOrDefault(i => i.GUID.Equals(guID));

            return userInfo;
        }

        public void InsertUserInformation(UserInformation info)
        {
            var context = new GarageEntities();
            context.UserInformation.AddOrUpdate(info);
            context.SaveChanges();
        }
    }
}