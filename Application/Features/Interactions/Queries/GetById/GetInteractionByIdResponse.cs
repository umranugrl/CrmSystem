namespace Application.Features.Interactions.Queries.GetById
{
    public class GetInteractionByIdResponse
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public string InteractionType { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
    }
}