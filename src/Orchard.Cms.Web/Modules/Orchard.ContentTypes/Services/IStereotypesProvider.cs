using System.Collections.Generic;

namespace Orchard.ContentTypes.Services
{
    public interface IStereotypesProvider
    {
        IEnumerable<StereotypeDescription> GetStereotypes();
    }

    public class StereotypeDescription
    {
        public string Stereotype { get; set; }
        public string DisplayName { get; set; }
    }
}