using System.ComponentModel.DataAnnotations;

namespace SkillProfi.Auth
{
    public class UserLogin
    {
        [Required, MaxLength(256)]
        public string? LoginProp { get; set; }
        [Required, DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
