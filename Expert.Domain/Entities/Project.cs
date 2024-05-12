using Expert.Domain.Enums;

namespace Expert.Domain.Entities
{
    public class Project(string title, string description, decimal totalCost, int idClient, int idFreelancer) : BaseEntity
    {
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public decimal TotalCost { get; private set; } = totalCost;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public ProjecStatusEnum Status { get; private set; } = ProjecStatusEnum.Created;

        public List<ProjectComment> Comments { get; private set; } = new List<ProjectComment>();
        public User Client { get; private set; }
        public int IdClient { get; private set; } = idClient;

        public User Freelancer { get; private set; }
        public int IdFreelancer { get; private set; } = idFreelancer;


        public void Cancel()
        {
            if (Status == ProjecStatusEnum.InProgress || Status == ProjecStatusEnum.Created)
                Status = ProjecStatusEnum.Cancelled;
        }

        public void Start()
        {
            if (Status == ProjecStatusEnum.Created)
            {
                Status = ProjecStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }

        public void Finish()
        {
            if (Status == ProjecStatusEnum.InProgress)
            {
                Status = ProjecStatusEnum.Finished;
                FinishedAt = DateTime.Now;
            }
        }

        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }

    }
}
