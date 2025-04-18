using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Entities;
using PetFamily.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Infrastructure.Repositories
{
    public class VolunteersRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VolunteersRepository(ApplicationDbContext dbContext)
        { 
            _dbContext = dbContext; 
        }

        public async Task<Guid> Add(Volunteer volunteer,
                                    CancellationToken cancellationToken = default)
        {
            await _dbContext.Volunteers.AddAsync(volunteer, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return volunteer.Id.Value;
        }

        public async Task<Result<Volunteer>> GetById(VolunteerId volunteerId)
        {
            var volunteer = await _dbContext.Volunteers
                .Include(x => x.Pets)
                .FirstOrDefaultAsync(x => x.Id == volunteerId);

            if (volunteer is null)
            {
                return Result.Failure<Volunteer>("Voluntee not found");
            }

            return volunteer;
        }
    }
}
