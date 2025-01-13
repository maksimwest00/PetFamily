namespace PetFamily.Domain
{
    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Breed CollectionAnimalBreeds { get; set; }
    }
}
