namespace Expert.Domain.Entities
{
    public class ProjectComment(string content, int idProject, int idUser) : BaseEntity
    {
        public string Content { get; private set; } = content;

        public Project? Project { get; private set; }
        public int IdProject { get; private set; } = idProject;

        public User? User { get; private set; }
        public int IdUser { get; private set; } = idUser;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }
}
