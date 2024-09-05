using System.Collections.Generic;

namespace Ecount.Kjd.Project.CSharp
{
    public interface ISaleService
    {
        SaleResultDTO SelectSales(SaleRequestDTO.SelectSaleRequestDTO request);
        void InsertSales(string comCode, SaleRequestDTO.InsertSaleRequestDTO request);
        void UpdateSales(string comCode, SaleRequestDTO.UpdateSaleRequestDTO request);
        void DeleteSales(string comCode, List<SaleRequestDTO.DeleteSaleRequestDTO> request);
    }
}
