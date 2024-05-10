namespace Expert.Application.OutPutModels
{
    public class SkillOutputModel(int id, string description)
    {
        public int Id { get; private set; } = id;
        public string Description { get; private set; } = description;
    }
}
