using CSharpFunctionalExtensions;

namespace PetFamily.Domain
{
    public class Pet : Entity
    {
        public Pet() { }

        //  Id
        public int Id { get; private set; }

        //  Кличка
        public string Nickname { get; private set; }

        //  Вид (например - собака, кошка)
        public Species Species { get; private set; }

        //  Общее описание
        public string Description { get; private set; }

        //  Порода
        public Breed Breed { get; private set; }

        //  Окрас
        public string Color { get; private set; }

        //  Информация о здоровье питомца
        public string InfoAboutHealthPet { get; private set; }

        //  Адрес, где находится питомец
        public string AddressLocatePet { get; private set; }

        //  Вес
        public int Weight { get; private set; }

        //  Рост
        public int Height { get; private set; }

        //  Номер телефона для связи с владельцем
        public int NumberPhone { get; private set; }

        //  Кастрирован или нет
        public bool IsCostrate { get; private set; }

        //  Дата рождения
        public DateTime DateOfBirth { get; private set; }

        //  Вакцинирован или нет
        public bool IsVaccinated { get; private set; }

        //  Статус помощи - Нуждается в помощи/Ищет дом/Нашел дом
        public EStatusHelp StatusHelp { get; private set; }

        //  Реквизиты для помощи(у каждого реквизита будет название и описание, как сделать перевод),
        //  поэтому нужно сделать отдельный класс для реквизита. Это должен быть Value Object.
        public BankDetalis BankingData { get; private set; }

        //  Дата создания
        public DateTime DateCreate { get; private set; }
    }
}
