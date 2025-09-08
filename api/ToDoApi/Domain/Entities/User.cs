namespace ToDoApi.Domain.Entities;

public class User : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public List<Task> Tasks { get; private set; } = [];

    public void Update(User newUser)
    {
        FirstName = newUser.FirstName;
        LastName = newUser.LastName;
    }

    public void AddTask(Task task)
    {
        this.Tasks.Add(task);
    }

    public void AssignTask(Task task)
    {
        this.Tasks.Add(task);
    }
}