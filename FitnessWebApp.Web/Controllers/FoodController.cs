namespace FitnessWebApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using FitnessWebApp.Services.Interfaces;
    using FitnessWebApp.Web.ViewModels.Models.Food;
    public class FoodController : BaseController
    {
        IFoodService foodService;

        public FoodController(IFoodService _foodService)
        {
            foodService = _foodService;
        }
        public async Task<IActionResult> All([FromQuery]AllFoodsQueryModel queryModel)
        {
            var serviceModel = await foodService.AllAsync(queryModel);
            queryModel.Foods = serviceModel.Foods;
            queryModel.TotalFoods = serviceModel.TotalFoodCount;         

            return View(queryModel);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddFoodViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddFoodViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           await foodService.AddAsync(model);
           return RedirectToAction(nameof(All));
        }
            
    }
}
