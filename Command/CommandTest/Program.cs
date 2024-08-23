using Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static Command.SelectProductDac;

namespace CommandTest
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string domain;
            string command;

            int cnt = 0;
            while (true)
            {
                Console.WriteLine(MessageConstants.Index.INPUT_DOMAIN);
                domain = Console.ReadLine();
                if (domain != null && domain.Equals("exit")) break;
                Console.WriteLine(MessageConstants.Index.INPUT_COMMAND);
                switch (domain)
                {
                    case "product":
                        command = Console.ReadLine();

                        switch (command)
                        {
                            case "insert":
                                CreateProduct();
                                break;
                            case "select":
                                ReadProduct();
                                break;
                            case "update":
                                UpdateProduct();
                                break;
                            case "delete":
                                DeleteProduct();
                                break;
                        }
                        break;
                    case "sale":
                        command = Console.ReadLine();

                        switch (command)
                        {
                            case "insert":
                                CreateSale();
                                break;
                            case "select":
                                ReadSale();
                                break;
                            case "update":
                                UpdateSale();
                                break;
                            case "delete":
                                DeleteSale();
                                break;
                        }
                        break;
                }
                Console.WriteLine($"# 루프 {++cnt}종료\n");
            }

        }

        private static void CreateProduct()
        {
            CreateProductExecute(CreateProductIO());
        }
        private static void ReadProduct()
        {
            ReadProductExecute(ReadProductIO());
        }
        private static void UpdateProduct()
        {
            //UpdateProductExecute(UpdateProductIO());
        }
        private static void DeleteProduct()
        {
            //DeleteProductExecute(DeleteProductIO());
        }
        private static void CreateSale()
        {
            //CreateSaleExecute(CreateSaleIO());
        }
        private static void ReadSale()
        {
            //ReadSaleExecute(ReadSaleIO());
        }
        private static void UpdateSale()
        {
            //UpdateSaleExecute(UpdateSaleIO());
        }
        private static void DeleteSale()
        {
            //DeleteSaleExecute(DeleteSaleIO());
        }


        private static CreateInputDTO CreateProductIO()
        {
            Console.WriteLine(MessageConstants.Product.INPUT_COM_CODE_FOR_CREATE);
            string comCode = Console.ReadLine();
            Console.WriteLine(MessageConstants.Product.INPUT_PROD_CD_FOR_CREATE);
            string prodCd = Console.ReadLine();
            Console.WriteLine(MessageConstants.Product.INPUT_PRICE_FOR_CREATE);
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine(MessageConstants.Product.INPUT_PROD_NM_FOR_CREATE);
            string prodNm = Console.ReadLine();

            return new CreateInputDTO(comCode, prodCd, price, prodNm);
        }
        private static void CreateProductExecute(CreateInputDTO dto)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<InsertProductDac, CommandResultWithBody<int>>(new InsertProductDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        cmd.Request = new InsertRequestDto("flow.product_kjd");
                        cmd.Request.fieldValues.Add("com_code", dto.comCode);
                        cmd.Request.fieldValues.Add("prod_cd", dto.prodCd);
                        cmd.Request.fieldValues.Add("price", dto.price);
                        cmd.Request.fieldValues.Add("prod_nm", dto.prodNm);
                        cmd.Request.fieldValues.Add("write_dt", DateTime.Now);
                    })
                    .Executed((res) => Console.WriteLine($"{res.Body}개 처리 완료됨."));

            pipeLine.Execute();
        }
        
        private static ReadInputDTO ReadProductIO()
        {
            Console.WriteLine(MessageConstants.Product.INPUT_COM_CODE_FOR_READ);
            string comCode = Console.ReadLine();
            Console.WriteLine(MessageConstants.Product.INPUT_PROD_CD_FOR_READ);
            string prodCd = Console.ReadLine();

            return new ReadInputDTO(comCode, prodCd);
        }

        private static void ReadProductExecute(ReadInputDTO dto)
        {
            Console.WriteLine("1");
            var pipeLine = new PipeLine();
            pipeLine.Register<SelectProductDac, CommandResultWithBody<List<Product>>>(new SelectProductDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        var reqDto = new SelectRequestDto("flow.product_kjd");
                        reqDto.WhereConditions.Add(new WhereConditionDto("prod_cd", dto.prodCd));
                        reqDto.WhereConditions.Add(new WhereConditionDto("com_code", dto.comCode));
                        cmd.Request = reqDto;
                    })
                    .Executed((res) =>
                    {
                        foreach (var r in res.Body)
                        {
                            Console.WriteLine($"작성일: {r.WRITE_DT}, 가격: {r.PRICE}");
                        }
                    });
            pipeLine.Execute();
        }
        /*
        private static UpdateInputDTO UpdateProductIO()
        {
            Console.WriteLine(MessageConstants.Product.INPUT_COM_CODE_FOR_UPDATE);
            string comCode = Console.ReadLine();
            Console.WriteLine(MessageConstants.Product.INPUT_PROD_CD_FOR_UPDATE);
            string prodCd = Console.ReadLine();

            return new UpdateInputDTO(comCode, prodCd);
        }

        private static void UpdateProductExecute(UpdateInputDTO dto)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<UpdateProductDac, CommandResultWithBody<int>>(new UpdateProductDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        cmd.Request = new UpdateProductDac.UpdateProductDacRequestDto()
                        {
                            ComCode = dto.comCode,
                            ProdCd = dto.prodCd,
                            WriteDt = DateTime.Now
                        };
                    })
                    .Executed((res) => Console.WriteLine($"{res.Body}개 품목이 업데이트되었습니다."));

            pipeLine.Execute();
        }

        private static DeleteInputDTO DeleteProductIO()
        {
            Console.WriteLine(MessageConstants.Product.INPUT_COM_CODE_FOR_DELETE);
            string comCode = Console.ReadLine();
            Console.WriteLine(MessageConstants.Product.INPUT_PROD_CD_FOR_DELETE);
            string prodCd = Console.ReadLine();

            return new DeleteInputDTO(comCode, prodCd);
        }

        private static void DeleteProductExecute(DeleteInputDTO dto)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<DeleteProductDac, CommandResultWithBody<int>>(new DeleteProductDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        cmd.Request = new DeleteProductDac.DeleteProductDacRequestDto()
                        {
                            ComCode = dto.comCode,
                            ProdCd = dto.prodCd
                        };
                    })
                    .Executed((res) => Console.WriteLine($"{res.Body}개 품목이 삭제되었습니다."));

            pipeLine.Execute();
        }

        private static CreateSaleInputDTO CreateSaleIO()
        {
            Console.WriteLine(MessageConstants.Sale.INPUT_COM_CODE_FOR_CREATE);
            string comCode = Console.ReadLine();
            Console.WriteLine(MessageConstants.Sale.INPUT_IO_DATE_FOR_CREATE);
            string ioDate = Console.ReadLine();
            Console.WriteLine(MessageConstants.Sale.INPUT_IO_NO_FOR_CREATE);
            int ioNo = int.Parse(Console.ReadLine());
            Console.WriteLine(MessageConstants.Sale.INPUT_PROD_CD_FOR_CREATE);
            string prodCd = Console.ReadLine();
            Console.WriteLine(MessageConstants.Sale.INPUT_QTY_FOR_CREATE);
            int qty = int.Parse(Console.ReadLine());
            Console.WriteLine(MessageConstants.Sale.INPUT_REMARKS_FOR_CREATE);
            string remarks = Console.ReadLine();

            return new CreateSaleInputDTO(comCode, ioDate, ioNo, prodCd, qty, remarks);
        }

        private static void CreateSaleExecute(CreateSaleInputDTO dto)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<InsertSaleDac, CommandResultWithBody<int>>(new InsertSaleDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        cmd.sale = new Sale()
                        {
                            Key = new SaleKey()
                            {
                                COM_CODE = dto.comCode,
                                IO_DATE = dto.ioDate,
                                IO_NO = dto.ioNo
                            },
                            PROD_CO = dto.prodCd,
                            QTY = dto.qty,
                            REMARK = dto.remarks
                        };
                    })
                    .Executed((res) => Console.WriteLine($"{res.Body}개 판매 내역이 생성되었습니다."));

            pipeLine.Execute();
        }

        private static ReadSaleInputDTO ReadSaleIO()
        {
            Console.WriteLine(MessageConstants.Sale.INPUT_IS_SORT_PROD_CD_FOR_READ);
            bool isOptionalProdCdAes = Console.ReadLine().Equals("yes") ? true : false; 
            Console.WriteLine(MessageConstants.Sale.INPUT_IS_SORT_QTY_FOR_READ);
            bool isOptionalQtyDesc = Console.ReadLine().Equals("yes") ? true : false;

            return new ReadSaleInputDTO(isOptionalProdCdAes, isOptionalQtyDesc);
        }

        private static void ReadSaleExecute(ReadSaleInputDTO dto)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<SelectSaleDac, CommandResultWithBody<List<Sale>>>(new SelectSaleDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        cmd.Request = new SelectSaleDac.SelectSaleDacRequestDto()
                        {
                            isOptionalProdCdAes = dto.isOptionalProdCdAes,
                            isOptionalQtyDesc = dto.isOptionalQtyDesc,
                        };
                    })
                    .Executed((res) =>
                    {
                        foreach (var sale in res.Body)
                        {
                            Console.WriteLine($"Date: {sale.Key.IO_DATE}, Product: {sale.PROD_CO}, Quantity: {sale.QTY}, Remark: {sale.REMARK}");
                        }
                    });

            pipeLine.Execute();
        }

        private static UpdateSaleInputDTO UpdateSaleIO()
        {
            Console.WriteLine(MessageConstants.Sale.INPUT_COM_CODE_FOR_UPDATE);
            string comCode = Console.ReadLine();
            Console.WriteLine(MessageConstants.Sale.INPUT_IO_DATE_FOR_UPDATE);
            string ioDate = Console.ReadLine();
            Console.WriteLine(MessageConstants.Sale.INPUT_IO_NO_FOR_UPDATE);
            int ioNo = int.Parse(Console.ReadLine());
            Console.WriteLine(MessageConstants.Sale.INPUT_PROD_CD_FOR_CREATE);
            string prodCd = Console.ReadLine();
            Console.WriteLine(MessageConstants.Sale.INPUT_QTY_FOR_CREATE);
            int qty = int.Parse(Console.ReadLine());
            Console.WriteLine(MessageConstants.Sale.INPUT_REMARKS_FOR_CREATE);
            string remarks = Console.ReadLine();

            return new UpdateSaleInputDTO(comCode, ioDate, ioNo, prodCd, qty, remarks);
        }

        private static void UpdateSaleExecute(UpdateSaleInputDTO dto)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<UpdateSaleDac, CommandResultWithBody<int>>(new UpdateSaleDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        cmd.Request = new UpdateSaleDac.UpdateSaleDacRequestDto()
                        {
                            ComCode = dto.comCode,
                            IoDate = dto.ioDate,
                            IoNo = dto.ioNo,
                            ProdCd = dto.prodCd,
                            Qty = dto.qty,
                            Remarks = dto.remarks
                        };
                    })
                    .Executed((res) => Console.WriteLine($"{res.Body}개 판매 내역이 업데이트되었습니다."));

            pipeLine.Execute();
        }

        private static DeleteSaleInputDTO DeleteSaleIO()
        {
            Console.WriteLine(MessageConstants.Sale.INPUT_COM_CODE_FOR_DELETE);
            string comCode = Console.ReadLine();
            Console.WriteLine(MessageConstants.Sale.INPUT_IO_DATE_FOR_DELETE);
            string ioDate = Console.ReadLine();
            Console.WriteLine(MessageConstants.Sale.INPUT_IO_NO_FOR_DELETE);
            int ioNo = int.Parse(Console.ReadLine());

            return new DeleteSaleInputDTO(comCode, ioDate, ioNo);
        }

        private static void DeleteSaleExecute(DeleteSaleInputDTO dto)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<DeleteSaleDac, CommandResultWithBody<int>>(new DeleteSaleDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        cmd.Request = new DeleteSaleDac.DeleteSaleDacRequestDto()
                        {
                            ComCode = dto.comCode,
                            IoDate = dto.ioDate,
                            IoNo = dto.ioNo
                        };
                    })
                    .Executed((res) => Console.WriteLine($"{res.Body}개 판매 내역이 삭제되었습니다."));

            pipeLine.Execute();
        }
        */
        private class CreateInputDTO
        {
            public string comCode { get; set; }
            public string prodCd { get; set; }
            public int price { get; set; }
            public string prodNm { get; set; }

            public CreateInputDTO(string comCode, string prodCd, int price, string prodNm)
            {
                this.comCode = comCode;
                this.prodCd = prodCd;
                this.price = price;
                this.prodNm = prodNm;
            }
        }
        
        private class ReadInputDTO
        {
            public string comCode { get; set; }
            public string prodCd { get; set; }

            public ReadInputDTO(string comCode, string prodCd)
            {
                this.comCode = comCode;
                this.prodCd = prodCd;
            }
        }
        /*
        private class UpdateInputDTO
        {
            public string comCode { get; set; }
            public string prodCd { get; set; }

            public UpdateInputDTO(string comCode, string prodCd)
            {
                this.comCode = comCode;
                this.prodCd = prodCd;
            }
        }
        private class DeleteInputDTO
        {
            public string comCode { get; set; }
            public string prodCd { get; set; }

            public DeleteInputDTO(string comCode, string prodCd)
            {
                this.comCode = comCode;
                this.prodCd = prodCd;
            }
        }
        private class CreateSaleInputDTO
        {
            public string comCode { get; set; }
            public string ioDate { get; set; }
            public int ioNo { get; set; }
            public string prodCd { get; set; }
            public int qty { get; set; }
            public string remarks { get; set; }

            public CreateSaleInputDTO(string comCode, string ioDate, int ioNo, string prodCd, int qty, string remarks)
            {
                this.comCode = comCode;
                this.ioDate = ioDate;
                this.ioNo = ioNo;
                this.prodCd = prodCd;
                this.qty = qty;
                this.remarks = remarks;
            }
        }
        private class ReadSaleInputDTO
        {
            public bool isOptionalProdCdAes { get; set; }
            public bool isOptionalQtyDesc { get; set; }

            public ReadSaleInputDTO(bool isOptionalProdCdAes, bool isOptionalQtyDesc)
            {
                this.isOptionalProdCdAes = isOptionalProdCdAes;
                this.isOptionalQtyDesc = isOptionalQtyDesc;
            }
        }
        private class UpdateSaleInputDTO
        {
            public string comCode { get; set; }
            public string ioDate { get; set; }
            public int ioNo { get; set; }
            public string prodCd { get; set; }
            public int qty { get; set; }
            public string remarks { get; set; }

            public UpdateSaleInputDTO(string comCode, string ioDate, int ioNo, string prodCd, int qty, string remarks)
            {
                this.comCode = comCode;
                this.ioDate = ioDate;
                this.ioNo = ioNo;
                this.prodCd = prodCd;
                this.qty = qty;
                this.remarks = remarks;
            }
        }
        private class DeleteSaleInputDTO
        {
            public string comCode { get; set; }
            public string ioDate { get; set; }
            public int ioNo { get; set; }

            public DeleteSaleInputDTO(string comCode, string ioDate, int ioNo)
            {
                this.comCode = comCode;
                this.ioDate = ioDate;
                this.ioNo = ioNo;
            }
        }
        */

        public static class MessageConstants
        {
            public static class Index
            {
                public static readonly string INPUT_DOMAIN = "접근할 도메인을 입력하세요\nproduct / sale / exit:";
                public static readonly string INPUT_COMMAND = "작동시킬 커맨드를 입력하세요\ninsert / select / update / delete:";
            }
            public static class Product
            {
                public static readonly string INPUT_COM_CODE_FOR_CREATE = "생성할 품목의 회사코드를 입력하세요: ";
                public static readonly string INPUT_PROD_CD_FOR_CREATE = "생성할 품목의 품목코드를 입력하세요: ";
                public static readonly string INPUT_PRICE_FOR_CREATE = "생성할 품목의 가격을 입력하세요: ";
                public static readonly string INPUT_PROD_NM_FOR_CREATE = "생성할 품목의 품목명을 입력하세요: ";

                public static readonly string INPUT_COM_CODE_FOR_READ = "(PK로 검색) 검색할 품목의 회사코드를 입력하세요: ";
                public static readonly string INPUT_PROD_CD_FOR_READ = "(PK로 검색) 검색할 품목의 품목코드를 입력하세요: ";

                public static readonly string INPUT_COM_CODE_FOR_UPDATE = "수정할 품목의 회사코드를 입력하세요: ";
                public static readonly string INPUT_PROD_CD_FOR_UPDATE = "수정할 품목의 품목코드를 입력하세요: ";

                public static readonly string INPUT_COM_CODE_FOR_DELETE = "삭제할 품목의 회사코드를 입력하세요: ";
                public static readonly string INPUT_PROD_CD_FOR_DELETE = "삭제할 품목의 품목코드를 입력하세요: ";
            }

            public static class Sale
            {
                public static readonly string INPUT_COM_CODE_FOR_CREATE = "생성할 판매내역의 회사코드를 입력하세요: ";
                public static readonly string INPUT_IO_DATE_FOR_CREATE = "생성할 판매내역의 전표일자를 입력하세요: ";
                public static readonly string INPUT_IO_NO_FOR_CREATE = "생성할 판매내역의 전표번호를 입력하세요: ";
                public static readonly string INPUT_PROD_CD_FOR_CREATE = "생성할 판매내역의 품목코드를 입력하세요: ";
                public static readonly string INPUT_QTY_FOR_CREATE = "생성할 판매내역의 수량을 입력하세요: ";
                public static readonly string INPUT_REMARKS_FOR_CREATE = "생성할 판매내역의 적요를 입력하세요: ";

                public static readonly string INPUT_IS_SORT_PROD_CD_FOR_READ = "(전체검색) 검색할 판매내역의 품목코드 정렬 여부를 입력하세요\n yes / no:";
                public static readonly string INPUT_IS_SORT_QTY_FOR_READ = "(전체검색) 검색할 판매내역의 수량 정렬 여부를 입력하세요\n yes / no:";

                public static readonly string INPUT_COM_CODE_FOR_UPDATE = "검색할 판매내역의 회사코드를 입력하세요: ";
                public static readonly string INPUT_IO_DATE_FOR_UPDATE = "검색할 판매내역의 전표일자를 입력하세요: ";
                public static readonly string INPUT_IO_NO_FOR_UPDATE = "검색할 판매내역의 전표번호를 입력하세요: ";

                public static readonly string INPUT_COM_CODE_FOR_DELETE = "검색할 판매내역의 회사코드를 입력하세요: ";
                public static readonly string INPUT_IO_DATE_FOR_DELETE = "검색할 판매내역의 전표일자를 입력하세요: ";
                public static readonly string INPUT_IO_NO_FOR_DELETE = "검색할 판매내역의 전표번호를 입력하세요: ";
            }
        }
    }
}
