using CSharpFunctionalExtensions;

namespace PetFamily.Domain
{
    public class Volunteer : Entity
    {
        public Volunteer() { }

        // Id
        public int Id { get; private set; }
        // ФИО
        public string FullName { get; private set; }
        // Email
        public string Email { get; private set; }
        // Общее описание
        public string Description { get; private set; }
        // Опыт в годах
        public int ExperienceYear { get; private set; }
        // Количество домашних животных,
        // которые смогли найти дом (это должен быть метод, который берёт список животных и считает количество по их статусу)
        public int CountAnimalsWhichCouldFindHome()
        {
            return Pets.Where(x => x.StatusHelp == EStatusHelp.FoundHome).Count();
        }
        // Количество домашних животных,
        // которые ищут дом в данный момент времени (это должен быть метод, который берёт список животных и считает количество по их статусу)
        public int CountAnimalsWhichFindingHomeNow()
        {
            return Pets.Where(x => x.StatusHelp == EStatusHelp.LookingHome).Count();
        }
        // Количество животных,
        // которые сейчас находятся на лечении (это должен быть метод, который берёт список животных и считает количество по их статусу)
        public int CountAnimalsWhichLocateOnTreatment()
        {
            return Pets.Where(x => x.StatusHelp == EStatusHelp.NeedHelp).Count();
        }
        // Номер телефона
        public string PhoneNumber { get; private set; }
        // Социальные сети(список соц. сетей, у каждой социальной сети должна быть ссылка и название), поэтому нужно сделать отдельный класс для социальной сети.Это должен быть Value Object.
        public SocialNetwork[] SocialNetworks { get; private set; }
        // Реквизиты для помощи (у каждого реквизита будет название и описание, как сделать перевод), поэтому нужно сделать отдельный класс для реквизита.Это должен быть Value Object.
        public BankDetalis BankDetalis { get; private set; }
        // Список домашних животных, которыми владеет волонтёр.
        public Pet[] Pets { get; private set; }
    }
}
