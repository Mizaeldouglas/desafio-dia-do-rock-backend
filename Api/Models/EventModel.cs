namespace Api.Models;

public class EventModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime Datetime { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    
}
