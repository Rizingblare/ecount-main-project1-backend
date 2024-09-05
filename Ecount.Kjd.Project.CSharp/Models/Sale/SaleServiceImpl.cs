using Command;
using Ecount.Kjd.Project.CSharp.Models.Sale;
using System.Collections.Generic;

namespace Ecount.Kjd.Project.CSharp
{
    public class SaleServiceImpl : ISaleService
    {
        public SaleResultDTO SelectSales(SaleRequestDTO.SelectSaleRequestDTO request)
        {
            var pipeLine = new PipeLine();
            var result = new SaleResultDTO();
            pipeLine.Register<SelectSaleCountDac, CommandResultWithBody<int>>(new SelectSaleCountDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = SaleDTOConverter.ToSelectCountRequestDTO(request);
                })
                .Executed((res) => pipeLine.Contexts.Add("totalCount", res.Body));

            pipeLine.Register<SelectSaleDac, CommandResultWithBody<List<Sale>>>(new SelectSaleDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = SaleDTOConverter.ToSelectRequestDTO(request);
                })
                .Executed((res) => result = SaleDTOConverter.ToSelectResultDTO(res.Body, (int)pipeLine.Contexts["totalCount"]));
            pipeLine.Execute();
            return result;
        }

        public void InsertSales(string comCode, SaleRequestDTO.InsertSaleRequestDTO request)
        {

            var pipeLine = new PipeLine();
            pipeLine.Register<SelectSaleNumDac, CommandResultWithBody<int?>>(new SelectSaleNumDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = SaleNumDTOConverter.ToSelectSaleNumRequestDTO(comCode, request.data_dt);
                })
                .Executed((res) =>
                {
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
               .Executed((res) => pipeLine.Contexts.Add("nextDateNo", (int)pipeLine.Contexts["currDateNo"] + 1));

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
                    cmd.Request = SaleDTOConverter.ToInsertRequestDTO(comCode, (int)pipeLine.Contexts["nextDateNo"], request);
                });

            pipeLine.Execute();
        }

        public void UpdateSales(string comCode, SaleRequestDTO.UpdateSaleRequestDTO request)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<SelectCountBeforeSaleDac, CommandResultWithBody<int>>(new SelectCountBeforeSaleDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = SaleDTOConverter.ToSelectCountBeforeSaleRequestDTO(comCode, request.data_dt, request.data_no);
                })
                .Executed((res) =>
                {
                    if (res.Body == 0) throw BaseException.SALE_NOT_EXIST;
                });
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