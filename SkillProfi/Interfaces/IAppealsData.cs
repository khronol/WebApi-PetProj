using SkillProfi.Models;

namespace SkillProfi.Interfaces
{
    public interface IAppealsData
    {
        IEnumerable<Appeal> GetAppeals();
        void addAppeal(Appeal appeal);

    }
}
