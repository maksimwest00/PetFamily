using CSharpFunctionalExtensions;
using PetFamily.Domain.Entities;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public class CreateVolunteerHandler
    {
        private readonly IVolunteersRepository _volunteersRepository;

        public CreateVolunteerHandler(
            IVolunteersRepository volunteersRepository)
        {
            _volunteersRepository = volunteersRepository;
        }

        public async Task<Result<Guid, Error>> Handle(
            CreateVolunteerRequest request,
            CancellationToken cancellationToken = default)
        {
            var volunteer = await _volunteersRepository
                .GetByName(request.FullName, cancellationToken);

            if (volunteer.IsSuccess)
                return Errors.Volunteer.AlreadyExist();

            // Создание доменной модели
            var volunteerToCreate = Volunteer.Create(
                VolunteerId.NewVolunteerId(),
                request.FullName,
                request.Email,
                request.Description,
                request.PhoneNumber);

            if (volunteerToCreate.IsFailure)
            {
                return volunteerToCreate.Error;
            }

            // сохранение в БД
            return await _volunteersRepository.Add(
                volunteerToCreate.Value,
                cancellationToken);
        }
    }
}
