namespace Expert.Application.OutPutModels
{
    public class ProjectDetailsOutputModel(int id, string title, string description, decimal totalCost, DateTime? startedAt, DateTime? finishedAt)
    {
        public int Id { get; private set; } = id;
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public decimal TotalCost { get; private set; } = totalCost;
        public DateTime? StartedAt { get; private set; } = startedAt;
        public DateTime? FinishedAt { get; private set; } = finishedAt;
    }
}
