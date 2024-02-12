using FlowerReviewApp.Models;

namespace FlowerReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();

        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromCountry(int countryId);
        bool HasCountry(int countryId);
        bool CreateCountry(Country country);
        bool Save();
    }
}
