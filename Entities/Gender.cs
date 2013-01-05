using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodreadsDotNET.Entities
{
    public enum Gender
    {
        Male = 0,
        Female
    }

    public static class GenderExtensions
    {
        public static Gender ToGender(this string gender)
        {
            if (gender.ToLower().Equals("male"))
                return Gender.Male;
            else
                return Gender.Female;
        }
    }
}
