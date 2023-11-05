using Electro_Ecommerce_MVC_Project.API.Base;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace Electro_Ecommerce_MVC_Project.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class DailyController : ControllerBase
{
    [HttpPost]
    public ResponceData Run(RequestData request)
    {
        ResponceData result = new ResponceData();

        try
        {

            string link = string.Format("http://www.tcmb.gov.tr/kurlar/{0}.xml",
                (request.IsToday) ? "today" : string.Format("{2}{2}/{0}{1}{2}",
                request.Day.ToString().PadLeft(2, '0'), request.Mounth.ToString().PadLeft(2, '0'), request.Year
                )
                );

            result.Data = new List<ResponceDatacreate>();


            XmlDocument doc = new XmlDocument();
            doc.Load(link);

            if (doc.SelectNodes("Tarih_Date" ).Count<1)
            {
                result.Error = "Currencies not found";
                return result;
            }


            foreach(XmlNode node in doc.SelectNodes("Tarih_Date")[0].ChildNodes)
            {
                ResponceDatacreate responceDatacreate = new ResponceDatacreate();

                responceDatacreate.Code = node.Attributes["Kod"].Value;
               responceDatacreate.Name = node["Isim"].InnerText;
                responceDatacreate.Unit = int.Parse(node["Unit"].InnerText);
                responceDatacreate.ByPrice = Convert.ToDecimal("0" + node["ForexBuying"].InnerText.Replace(".", ","));
                responceDatacreate.SalePrice = Convert.ToDecimal("0" + node["ForexSelling"].InnerText.Replace(".", ","));
                responceDatacreate.EffectiveByPrice = Convert.ToDecimal("0" + node["BanknoteBuying"].InnerText.Replace(".", ","));
                responceDatacreate.EffectiveSalePrice = Convert.ToDecimal("0" + node["BanknoteSelling"].InnerText.Replace(".", ","));

                result.Data.Add(responceDatacreate);
            }


        }
        catch (Exception e)
        {

            result.Error = e.Message;
        }




        return result;
    }


}
