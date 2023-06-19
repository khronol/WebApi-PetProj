using SkillProfi.DataContext;
using SkillProfi.Interfaces;
using SkillProfi.Models;

namespace SkillProfi.Data
{
    public class AppealsData : IAppealsData
    {
        private readonly AppealDbContext _context;
        public AppealsData(AppealDbContext context)
        {
            _context = context;
        }
        public void addAppeal(Appeal appeal)
        {
            _context.Add(appeal);
            _context.SaveChanges();
        }

        public IEnumerable<Appeal> GetAppeals()
        {
            return _context.Appeals;
        }
    }
}
