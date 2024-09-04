using Command;
using Ecount.Kjd.Project.CSharp.Models.Sale;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http.Results;

namespace Ecount.Kjd.Project.CSharp
{
    public class SaleServiceImpl : ISaleService
    {
        public SaleResultDTO.SelectSaleResultDTO SelectSales(SaleRequestDTO.SelectSaleRequestDTO request)
        {
            return new SaleResultDTO.SelectSaleResultDTO();
        }

        public void InsertSales(string comCode, SaleRequestDTO.InsertSaleRequestDTO request)
        {

            var pipeLine = new PipeLine();
            pipeLine.Register<SelectSaleNumDac, CommandResultWithBody<int?>>(new SelectSaleNumDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = SaleNumDTOConverter.ToSelectSaleNumRequestDTO(comCode, request.data_dt);
                })
                .Executed((res) => {
                    if (res.Body != null)
                    {
                        pipeLine.Contexts.Add("currDateNo", res.Body);
                    }
                });

            pipeLine.Register<UpdateSaleNumDac, CommandResultWithBody<int>>(new UpdateSaleNumDac())
                .AddFilter((cmd) => pipeLine.Contexts.ContainsKey("currDateNo"))
                .Mapping((cmd) =>
                {
                    cmd.Request = SaleNumDTOConverter.ToUpdateSaleNumRequestDTO(comCode, request.data_dt, (int)pipeLine.Contexts["currDateNo"] + 1);
                })
               .Executed((res) => pipeLine.Contexts.Add("nextDateNo", (int) pipeLine.Contexts["currDateNo"] + 1));

            pipeLine.Register<InsertSaleNumDac, CommandResultWithBody<int>>(new InsertSaleNumDac())
                .AddFilter((cmd) => !pipeLine.Contexts.ContainsKey("currDateNo"))
                .Mapping((cmd) =>
                {
                    cmd.Request = SaleNumDTOConverter.ToInsertSaleNumRequestDTO(comCode, request.data_dt);
                })
               .Executed((res) => pipeLine.Contexts.Add("nextDateNo", 1));
            
            pipeLine.Register<InsertSaleDac, CommandResultWithBody<int>>(new InsertSaleDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = SaleDTOConverter.ToInsertRequestDTO(comCode, (int) pipeLine.Contexts["nextDateNo"], request);
                });

            pipeLine.Execute();
        }

        public void UpdateSales(string comCode, SaleRequestDTO.UpdateSaleRequestDTO request)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<UpdateSaleDac, CommandResultWithBody<int>>(new UpdateSaleDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = SaleDTOConverter.ToUpdateRequestDTO(comCode, request);
                });
            pipeLine.Execute();
        }
        public void DeleteSales(string comCode, List<SaleRequestDTO.DeleteSaleRequestDTO> request)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<DeleteSaleDac, CommandResultWithBody<int>>(new DeleteSaleDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = SaleDTOConverter.ToDeleteRequestDTO(comCode, request);
                });
            pipeLine.Execute();
        }
    }
}