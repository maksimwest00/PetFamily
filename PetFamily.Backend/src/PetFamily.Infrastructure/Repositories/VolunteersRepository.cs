using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFamily.Application.Volunteers;
using PetFamily.Domain.Entities;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Repositories
{
    public class VolunteersRepository : IVolunteersRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VolunteersRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Add(
            Volunteer volunteer,
            CancellationToken cancellationToken = default)
        {
            await _dbContext.Volunteers.AddAsync(
                volunteer,
                cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return volunteer.Id.Value;
        }

        public async Task<Result<Volunteer, Error>> GetById(
            VolunteerId volunteerId)
        {
            var volunteer = await _dbContext.Volunteers
                .Include(x => x.Pets)
                .FirstOrDefaultAsync(x => x.Id == volunteerId);

            if (volunteer is null)
            {
                return Errors.General.NotFound(volunteerId.Value);
            }

            return volunteer;
        }

        public async Task<Result<Volunteer, Error>> GetByName(string fullName)
        {
            var volunteer = await _dbContext.Volunteers
                .Include(x => x.Pets)
                .FirstOrDefaultAsync(x => x.FullName == fullName);

            if (volunteer is null)
            {
                return Errors.General.NotFound();
            }

            return volunteer;
        }
    }
}
