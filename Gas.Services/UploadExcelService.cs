using Gas.Domain.Entities;
using Gas.Domain.Enums;
using Gas.Model.CompanyManagement;
using Gas.Services.CompanyManagement;
using Gas.Utils;
using Microsoft.AspNetCore.Http;
using NPOI.SS.UserModel;

namespace Gas.Services
{
    public class UploadExcelService
    {
        int SuperDealer = 0;
        public QueryResEntity UpLoadExcelIForm(IFormFile file,int SuperDealerId)
        {
            try
            {
                SuperDealer = SuperDealerId;
                UploadExcelUtil.ProcessExcel(file, ShopData, "shop");
                QueryResEntity res = new()
                {
                    Code = Codes.Success,
                    Msg = $"Uploaded Successfully"
                };
                return res;
            }
            catch (Exception ex)
            {
                Logger.Logger.Error($"Exception: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        private void ShopData(IRow row)
        {
            // Read data from each column in the current row
            string? id = row.GetCell(0)?.ToString(); // Column 1
            string? shopName = row.GetCell(1)?.ToString(); // Column 2
            string? phoneNumber = row.GetCell(2)?.ToString(); // Column 3
            string? region = row.GetCell(3)?.ToString(); // Column 4
            string? district = row.GetCell(4)?.ToString(); // Column 5
            string? ward = row.GetCell(5)?.ToString(); // Column 6
            string? street = row.GetCell(6)?.ToString(); // Column 7

            // Output the data to the console
            Console.WriteLine($"ID: {id}, Shop Name: {shopName}, Phone Number: {phoneNumber}, Region: {region}, District: {district}, Ward: {ward}, Street: {street}");

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                // Check if the phone number starts with "0"
                if (!phoneNumber.StartsWith("0"))
                {
                    // Add "+255" in front of the phone number
                    phoneNumber = "+255" + phoneNumber;
                }
                else
                {
                    phoneNumber = string.Concat("+255", phoneNumber.AsSpan(1));
                }
            }
            else
            {
                phoneNumber = "0";
            }

            InsShopModel rqModel = new()
            {
                Shopname = shopName??"",
                Phonenumber = phoneNumber,
                Superdealer = SuperDealer,
                Commonstreet = 1
            };

            new ShopService().AddShop(rqModel);
        }

    }
}
