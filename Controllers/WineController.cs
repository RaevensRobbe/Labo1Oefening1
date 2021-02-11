using System;
using System.Linq;
using Labo1Oefening1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Labo1Oefening1.Controllers
{
    [ApiController]
    [Route("api")]
    public class WineController : ControllerBase
    {
        private static List<Wine> _wines;

        public WineController()
        {
            if (_wines == null)
            {
                _wines = new List<Wine>();
                _wines.Add(new Wine(){
                    WineId = 1, Name = "Barolo", Country = "Italy", Price = 35, Color = "Red", Year = 2007, Grapes = "Nebiollo"
                });

                _wines.Add(new Wine(){
                    WineId = 2, Name = "Riesling", Country = "Germany", Price = 35, Color = "White", Year = 2018, Grapes = "Riesling"
                });
            }
        }

        [HttpGet]
        [Route("wines")]
        public ActionResult<List<Wine>> GetWines(){
            return new OkObjectResult(_wines);
        }

        [HttpGet]
        [Route("wine/{wineId}")]
        public ActionResult<Wine> GetWine(int wineId){
            var wine = _wines.Where(w => w.WineId == wineId).SingleOrDefault();
            if (wine == null) {
                return new NotFoundObjectResult(wineId);
            }
            else {
                return new OkObjectResult(wine);
            }
        }

        [HttpPost]
        [Route("wine")]
        public ActionResult<Wine> AddWines(Wine wine){
            if (wine == null){
                return new BadRequestResult();
            }
            wine.WineId =_wines.Count + 1;
            _wines.Add(wine);
            return new OkObjectResult(wine);
        }
            
    }
}