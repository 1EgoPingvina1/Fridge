namespace API.DTO
{
    public class CreateFridgeDTO
    {
        public string Name { get; set; } = null!;

        public string OwnerName { get; set; } = null!;

        public Guid? ModelId { get; set; }

        public List<CreateFridgeProductDTO> FridgeProducts { get; set; } = new();
    }
}
