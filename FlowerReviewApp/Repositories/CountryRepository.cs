using FlowerReviewApp.Interfaces;
using FlowerReviewApp.Models;

namespace FlowerReviewApp.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly SONUNGVIENREVIEWContext _context;
        public CountryRepository (SONUNGVIENREVIEWContext context)
        {
            _context = context;
        }
        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.CountryId == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.OwnerId == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromCountry(int countryId)
        {
            return _context.Owners.Where(o => o.CountryID == countryId).ToList();
        }

        public bool HasCountry(int countryId)
        {
            return _context.Countries.Any(c => c.CountryId == countryId);
        }
    }
}
