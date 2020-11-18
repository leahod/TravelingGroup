using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DTO;

namespace BL.Converters
{
    public class UserConverters
    {
        public static User GetUser(DTO.UserDTO dtoUser)
        {
            User user = new User()
            {
                Identity = dtoUser.Identity,
                Name = dtoUser.Name,
                Mail = dtoUser.Mail,
                Gender = dtoUser.Gender,
                Cellphone =dtoUser.Cellphone,
                CreditCardNumber = dtoUser.CreditCardNumber,
                Validity = dtoUser.Validity,
                Cvv = dtoUser.Cvv,
                IdCardOwner = dtoUser.IdCardOwner
            };
            return user;
        }

        public static UserDTO GetUserDTO(User user)
        {
            if (user == null)
                return null;
            UserDTO userDto = new UserDTO()
            {
                Identity = user.Identity,
                Name = user.Name,
                Mail = user.Mail,
                Gender = user.Gender,
                Cellphone = user.Cellphone,
                CreditCardNumber = user.CreditCardNumber,
                Validity = user.Validity,
                Cvv = user.Cvv,
                IdCardOwner = user.IdCardOwner
            };
            return userDto;
        }
        public static List<UserDTO> GetListUserDTO(List<User> luser)
        {
            List<UserDTO> l = new List<UserDTO>();
            luser.ForEach(u => l.Add(GetUserDTO(u)));
            return l;

        }
        public static List<User> GetListUser(List<UserDTO> luser)
        {
            List<User> l = new List<User>();
            luser.ForEach(u => l.Add(GetUser(u)));
            return l;

        }
    }
}

