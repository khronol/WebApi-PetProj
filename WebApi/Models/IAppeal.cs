namespace WebApi.Models
{
    public interface IAppeal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string userAppeal { get; set; }

        public IEnumerable<IAppeal> GetAppeal();
        public void AddAppeal(IAppeal appeal);
    }
}
