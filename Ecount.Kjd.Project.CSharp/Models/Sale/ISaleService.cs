using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecount.Kjd.Project.CSharp
{
    public interface ISaleService
    {
        SaleResultDTO.SelectSaleResultDTO SelectSales();
        void InsertSales(string comCode, SaleRequestDTO.InsertSaleRequestDTO request);
        void UpdateSales(string comCode, SaleRequestDTO.UpdateSaleRequestDTO request);
        void DeleteSales(string comCode, List<SaleRequestDTO.DeleteSaleRequestDTO> request);
    }
}
