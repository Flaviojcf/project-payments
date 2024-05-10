using Expert.Domain.Entities;

namespace Expert.Infrastructure.Persistance
{
    public class ExpertDbContext
    {
        public ExpertDbContext()
        {
            Projects =
            [
                new Project("Meu Projeto 1", "Minha descricao  1", 1, 1, 10000),
                new Project("Meu Projeto 2", "Minha descricao  2", 2, 2, 20000),
            ];
            Users =
            [
             new User("Flavio", "flaviojcostafilho@gmail.com", new DateTime(2000,04,04)),
             new User("Flavio", "flaviojcostafilho@gmail.com", new DateTime(2000,04,04)),
            ];
            Skills =
            [
             new Skill(".net"),
             new Skill("SQL"),
            ];
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> Comments { get; set; }
    }
}
