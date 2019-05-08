using System;


namespace example
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo demo = new Demo();

            try
            {

                demo.GetOrderInfo();
                demo.GetOrderStatus();
                demo.GetAddOrderInfo();

                demo.GetInternationalPrice();
                demo.UpdateItemlPrice();

                demo.GetSellerStatusCheck();
                demo.GetSubcategoryProperties();
                demo.GetSubcategoryStatus();

                demo.SubmitFeed();
                demo.GetFeedStatus();
                demo.GetFeedResult();

                demo.GetRMAInfo();
                demo.GetCourtesyRefundRequestStatus();
                demo.GetCourtesyRefundInformation();

                demo.SubmitShippingRequest();
                demo.GetShippingRequestDetail();
                demo.VoidShippingRequest();
                demo.ConfirmShippingRequest();

                demo.SubmitDailyInventoryReport();
                demo.SubmitDailyPriceReport();
                demo.GetReportStatus();
                demo.GetDailyInventoryReport();

                demo.VerifyServiceStatus();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Exit with error.");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.WriteLine("Exit.");
            Console.ReadKey();

        }
    }
}
