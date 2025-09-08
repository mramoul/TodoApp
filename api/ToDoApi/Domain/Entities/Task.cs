using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApi.Domain.Entities;

public class Task : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public StatusType Status { get; private set; }

    [ForeignKey("UserId")]
    public User? AssignedUser { get; private set; }

    public void Update(Task newTask)
    {
        Title = newTask.Title;
        Description = newTask.Description;
        AssignedUser = newTask.AssignedUser;
    }

    public void AssignUser(User? newUser)
    {
        AssignedUser = newUser;
    }

    public void UpdateStatus(StatusType newStatus)
    {
        Status = newStatus == StatusType.Void ? Status : newStatus;
    }
}