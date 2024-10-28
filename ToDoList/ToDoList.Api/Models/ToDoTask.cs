namespace ToDoList.Api.Models;

public class ToDoTask
{
	public int Id { get; }
	public string Description { get; }

	public ToDoTask(int id, string description)
	{
		Id = id;
		Description = description;
	}

	public ToDoTask() {
	}


	protected bool Equals(ToDoTask other)
	{
		return Id == other.Id && Description == other.Description;
	}

	public override bool Equals(object? obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != this.GetType()) return false;
		return Equals((ToDoTask)obj);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Id, Description);
	}

	public virtual void MarkCompleted()
	{
		throw new NotImplementedException();
	}
}