namespace RainChance.DAL.Models
{
    using SWE.Http.Models;

    public class DarkSkyActions : Actions
    {
        public DarkSkyActions()
        : base("Create", string.Empty, "Update", "Delete")
        {
        }
    }
}