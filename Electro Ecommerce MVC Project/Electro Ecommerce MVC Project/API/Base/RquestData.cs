namespace Electro_Ecommerce_MVC_Project.API.Base;

public class RequestData
{
    public int Day { get; set; }
    public int Mounth { get; set; }
    public int Year { get; set; }
    public bool IsToday { get; set; }
}


public class ResponceDatacreate
{
    public string Code { get; set; }
    public string Name { get; set; }
    public int Unit { get; set; }
    public decimal ByPrice { get; set; }
    public decimal SalePrice { get; set; }

    public decimal EffectiveByPrice { get; set; }
    public decimal EffectiveSalePrice { get; set; }
}

public class ResponceData
{
    public List<ResponceDatacreate> Data { get; set; }
    public string Error { get; set; }

}

