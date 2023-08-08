using Microsoft.AspNetCore.Mvc.Rendering;
using HIEULINHDEMO.Models;

namespace HIEULINHDEMO.ViewModels;


public class UpSertAddressVM
{
        public Address Address { get; set; }
        public List<SelectListItem> Peoples { get; set; }
}