using Gas.Model.CompanyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gms.WebApplication.Pages
{
    public class ShopModel : PageModel
    {
        private readonly ILogger<ShopModel> _logger;

        [BindProperty]
        public RequestStaffLoginEntity StaffLoginEntity {  get; set; }
        public ShopModel(ILogger<ShopModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var data = StaffLoginEntity;
            return new RedirectToPageResult("Home");
        }
    }
}
