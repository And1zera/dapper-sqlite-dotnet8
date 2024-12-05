namespace dapperdotnet8.Domain.Entity;

public abstract class Base
{
    public string ID { get; set; } 
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? RemovedDate { get; set; }
    public bool Removed { get; set; }
    
    public virtual void Create()
    {
        ID = Guid.NewGuid().ToString();
        CreatedDate = DateTime.UtcNow;
        Removed = false;
    }

    public virtual void Update()
    {
        UpdatedDate = DateTime.UtcNow;
    }

    public virtual void Remove()
    {
        RemovedDate = DateTime.UtcNow;
        Removed = true;
    }
}