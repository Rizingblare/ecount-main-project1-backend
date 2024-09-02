using Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecount.Kjd.Project.CSharp
{
    public class SaleServiceImpl : ISaleService
    {
        public SaleResultDTO.SelectSaleResultDTO SelectSales()
        {
            PipeLine pipe = new PipeLine();
            //pipe.Register();
            throw new NotImplementedException();
        }

        public void InsertSales(string comCode, SaleRequestDTO.InsertSaleRequestDTO request)
        {

        }
        public void UpdateSales(string comCode, SaleRequestDTO.UpdateSaleRequestDTO request)
        {

        }
        public void DeleteSales(string comCode, List<SaleRequestDTO.DeleteSaleRequestDTO> request)
        {

        }
    }
}