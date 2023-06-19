using WebApi.Models;

namespace WebApi.Interface
{
    public interface IAppealsData
    {
        IEnumerable<Appeal> GetAppeals();
        void addAppeal(Appeal appeal);

    }
}
