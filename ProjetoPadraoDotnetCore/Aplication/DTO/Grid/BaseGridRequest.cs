namespace Aplication.DTO.Grid;

public class BaseGridRequest
{
    public int Take { get; set; }
    public int Page { get; set; }
    public Order Order { get; set; }
}

public class Order
{
    public string Active { get; set; }
    public string Direction { get; set; }
}


