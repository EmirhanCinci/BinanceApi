using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BinanceApi;
using BinanceApi.Models;
using BinanceApi.Service;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using GetKlineList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GetKlineList.Controllers
{

    public class HomeController : Controller
    {
        List<Kliner> klineList;
        BinanceService _binanceService;

        public HomeController(BinanceService binanceService)
        {
            _binanceService = binanceService;
        }

        public async Task<IActionResult> Index()
        {
            using var _context = new BinanceDbContext();

            var getList = await _context.Klines.ToListAsync();
            return View(getList);
        }   

       
        //public async Task<object> Get(DataSourceLoadOptions loadOptions)
        //{
            
        //    return DataSourceLoader.Load(getList, loadOptions);
        //}


    }
}
