using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BL
{
    public static class UserBL
    {
        ///<summary> return all the users    
        ///</summary>
        public static List<UserDTO> GetUsers()
        {
            return Converters.UserConverters.GetListUserDTO(DAL.UserDal.GetUsers());
        }

        ///<summary> find user by identity
        ///</summary>
        public static UserDTO GetUser(string id)
        {
            return Converters.UserConverters.GetUserDTO(DAL.UserDal.GetUser(id));
        }

        /// <summary> add a new user in the db
        /// </summary>
        public static UserDTO Add(UserDTO user)
        {
            return Converters.UserConverters.GetUserDTO(UserDal.AddUser(Converters.UserConverters.GetUser(user)));
        }

        ///<summary> update details' user in the db
        ///</summary>
        public static void UpdateUser(string id, UserDTO user)
        {
            UserDal.UpdateUser(Converters.UserConverters.GetUser(user), id);
        }

        ///<summary> delete a user from the db
        ///</summary>
        public static void DeleteUser(string id)
        {
            UserDal.DeleteUser(id);
        }
    }
}
