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
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // ReadProduct();
            // CreateProduct();
            // UpdateProduct();
            // DeleteProduct();

            // ReadSale();
            // CreateSale();
            // UpdateSale();
            // DeleteSale();

            /*
            string entity;
            string command;

            while (true)
            {
                entity = Console.ReadLine();
                if (entity != null && entity.Equals("exit")) break;
                switch (entity)
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
                                break;
                            case "delete":
                                break;
                        }
                        break;
                    case "sale":
                        command = Console.ReadLine();

                        switch (command)
                        {
                            case "insert":
                                break;
                            case "select":
                                break;
                            case "update":
                                break;
                            case "delete":
                                break;
                        }
                        break;
                }

            }
            */
        }

        private static void CreateProduct()
        {
            var pipeLine = new PipeLine();
            int result;
            pipeLine.Register<InsertProductDac, CommandResultWithBody<int>>(new InsertProductDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) => {
                        cmd.Entity = new Product()
                        {
                            Key = new ProductKey()
                            {
                                COM_CODE = "80000",
                                PROD_CD = "test_cd"
                            },
                            PRICE = 1000,
                            PROD_NM = "test_name2",
                            WRITE_DT = DateTime.Now
                        };
                    })
                    .Executed((res) => result = res.Body);

            pipeLine.Execute();
        }

        private static void ReadProduct()
        {
            var pipeLine = new PipeLine();
            object result;
            pipeLine.Register<SelectProductDac, CommandResultWithBody<List<Product>>>(new SelectProductDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) => {
                        cmd.Request = new SelectProductDacRequestDto()
                        {
                            ComCode = "80000",
                            ProdCd = "test_cd"
                        };
                    })
                    .Executed((res) => {
                        foreach (var r in res.Body)
                        {
                            Console.WriteLine(r.WRITE_DT);
                            Console.WriteLine(r.PRICE);
                        }
                        result = res;
                    });

            pipeLine.Execute();
        }

        private static void UpdateProduct()
        {
            var pipeLine = new PipeLine();
            int result;
            pipeLine.Register<UpdateProductDac, CommandResultWithBody<int>>(new UpdateProductDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) => {
                        cmd.Request = new UpdateProductDac.UpdateProductDacRequestDto()
                        {
                            ComCode = "80000",
                            ProdCd = "test_cd",
                            ProdNm = "updated_name",
                            Price = 2000,
                            WriteDt = DateTime.Now
                        };
                    })
                    .Executed((res) => result = res.Body);

            pipeLine.Execute();
        }

        private static void DeleteProduct()
        {
            var pipeLine = new PipeLine();
            int result;
            pipeLine.Register<DeleteProductDac, CommandResultWithBody<int>>(new DeleteProductDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) => {
                        cmd.Request = new DeleteProductDac.DeleteProductDacRequestDto()
                        {
                            ComCode = "80000",
                            ProdCd = "test_cd"
                        };
                    })
                    .Executed((res) => result = res.Body);

            pipeLine.Execute();
        }

        private static void CreateSale()
        {
            var pipeLine = new PipeLine();
            int result;
            pipeLine.Register<InsertSaleDac, CommandResultWithBody<int>>(new InsertSaleDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) => {
                        cmd.sale = new Sale()
                        {
                            Key = new SaleKey()
                            {
                                COM_CODE = "80000",
                                IO_DATE = "20240122",
                                IO_NO = 3
                            },
                            PROD_CO = "test_prod_cd",
                            QTY = 10,
                            REMARK = "Test Sale"
                        };
                    })
                    .Executed((res) => result = res.Body);

            pipeLine.Execute();
        }

        private static void ReadSale()
        {
            var pipeLine = new PipeLine();
            object result;
            pipeLine.Register<SelectSaleDac, CommandResultWithBody<List<Sale>>>(new SelectSaleDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) => {
                        cmd.Request = new SelectSaleDac.SelectSaleDacRequestDto()
                        {
                            ComCode = "80000",
                            IoDate = "20240122",
                            IoNo = 3
                        };
                    })
                    .Executed((res) => {
                        foreach (var sale in res.Body)
                        {
                            Console.WriteLine($"Date: {sale.Key.IO_DATE}, Product: {sale.PROD_CO}, Quantity: {sale.QTY}, Remark: {sale.REMARK}");
                        }
                        result = res;
                    });

            pipeLine.Execute();
        }

        private static void UpdateSale()
        {
            var pipeLine = new PipeLine();
            int result;
            pipeLine.Register<UpdateSaleDac, CommandResultWithBody<int>>(new UpdateSaleDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) => {
                        cmd.Request = new UpdateSaleDac.UpdateSaleDacRequestDto()
                        {
                            ComCode = "80000",
                            IoDate = "20240122",
                            IoNo = 3,
                            ProdCd = "updated_prod_cd",
                            Qty = 20,
                            Remarks = "Updated Sale"
                        };
                    })
                    .Executed((res) => result = res.Body);

            pipeLine.Execute();
        }

        private static void DeleteSale()
        {
            var pipeLine = new PipeLine();
            int result;
            pipeLine.Register<DeleteSaleDac, CommandResultWithBody<int>>(new DeleteSaleDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) => {
                        cmd.Request = new DeleteSaleDac.DeleteSaleDacRequestDto()
                        {
                            ComCode = "80000",
                            IoDate = "20240122",
                            IoNo = 3
                        };
                    })
                    .Executed((res) => result = res.Body);

            pipeLine.Execute();
        }
    }
}
