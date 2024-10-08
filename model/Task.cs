public class Task {
    public Guid Guid{ get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public enum Status{
    ToDo, InProgress, Done
}