﻿using Microsoft.AspNetCore.Mvc;
using startup.Models;

// lấy dữ liệu từ cơ sở dữ liệu truyền qua cho File Default.cshtml ở thư mục shared/Components/MenuView
namespace startup.Components
{
    [ViewComponent(Name = "MenuView")]
    public class MenuViewComponent : ViewComponent
    {
        private DataContext _context;
        public MenuViewComponent(DataContext context) 
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenu = (from m in _context.Menus
                              where (m.IsActive == true) && (m.Position == 1)
                              select m).ToList();
           
            return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));


        }
    }
}