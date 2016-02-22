namespace GiftBox.Services.Data
{
    using GiftBox.Data.Common.Repositories;
    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;

    public class LocationService : ILocationService
    {
        private IDeletableEntityRepository<Location> locations;

        public LocationService(IDeletableEntityRepository<Location> locations)
        {
            this.locations = locations;
        }

        public void Add(Location location)
        {
            this.locations.Add(location);
            this.locations.SaveChanges();
        }
    }
}
