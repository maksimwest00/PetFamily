using CSharpFunctionalExtensions;
using PetFamily.Domain.Entities;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers
{
    public interface IVolunteersRepository
    {
        Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default);
        Task<Result<Volunteer, Error>> GetById(VolunteerId volunteerId);
        Task<Result<Volunteer, Error>> GetByName(string fullName);
    }
}