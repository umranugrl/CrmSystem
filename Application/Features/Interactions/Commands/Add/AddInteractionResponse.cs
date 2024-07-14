namespace Application.Features.Interactions.Commands.Add
{
    public class AddInteractionResponse
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public string InteractionType { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}