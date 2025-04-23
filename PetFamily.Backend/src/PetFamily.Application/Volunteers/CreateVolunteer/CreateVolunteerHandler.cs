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
                .GetByName(request.FirstName,
                           cancellationToken);

            if (volunteer.IsSuccess)
                return Errors.Volunteer.AlreadyExist();

            var fullNameReuslt = FullName.Create(request.LastName,
                                                 request.FirstName,
                                                 request.MiddleName);
            if (fullNameReuslt.IsFailure)
                return fullNameReuslt.Error;

            var emailResult = Email.Create(request.Email);
            if (emailResult.IsFailure)
                return emailResult.Error;

            var descriptionResult = Description.Create(request.Email);
            if (descriptionResult.IsFailure)
                return descriptionResult.Error;

            var phoneNumberResult = PhoneNumber.Create(request.PhoneNumber);
            if (phoneNumberResult.IsFailure)
                return phoneNumberResult.Error;

            var experienceResult = ExperienceYear.Create(request.ExpirienceYear);
            if (experienceResult.IsFailure)
                return experienceResult.Error;

            // Создание доменной модели
            var volunteerToCreate = Volunteer.Create(
                VolunteerId.NewVolunteerId(),
                fullNameReuslt.Value,
                emailResult.Value,
                descriptionResult.Value,
                phoneNumberResult.Value,
                experienceResult.Value);

            if (volunteerToCreate.IsFailure)
                return volunteerToCreate.Error;

            // сохранение в БД
            return await _volunteersRepository.Add(
                volunteerToCreate.Value,
                cancellationToken);
        }
    }
}
