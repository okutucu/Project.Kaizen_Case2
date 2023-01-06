using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Project.MVC.Dto;
using System.Globalization;
using System.Xml.Linq;

namespace Project.MVC.Controllers
{
    public class NewsController : BaseController
    {
        private readonly IStringLocalizer<NewsController> _localizer;

        public NewsController(IStringLocalizer<NewsController> localizer)
        {
            _localizer = localizer;
        }

 

        public async Task<IActionResult> Index()
        {
            using (LanguageDbContext _context = new LanguageDbContext())
            {
                // MVC projesinde o anki seçilen dili alıyoruz
                string cultureName = this.LANGUAGE_CODE();

                var title = _localizer["page.News.Title"];

                List<RequestNewsDto> results = await (from c in _context.Contents
                                                      join n in _context.News on c.Id equals n.ContentId
                                                      where n.LanguageCode == cultureName
                                                      select new RequestNewsDto
                                                      {
                                                          Name = c.Name,
                                                          Title = n.Title,
                                                          Detail = n.Detail,
                                                          ImageUrls = n.ImageUrls,
                                                          Category = n.Category
                                                      }).ToListAsync();


                return View(results);
            }
        }


    }
}
