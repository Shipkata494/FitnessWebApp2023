﻿namespace FitnessWebApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using FitnessWebApp.Common.Exceptions;
    using FitnessWebApp.Services.FormModels.GymUser;
    using FitnessWebApp.Services.Interfaces;
    using FitnessWebApp.Web.ViewModels.Models.Food;

    using static FitnessWebApp.Common.NotificationMessegeConstants;
    using FitnessWebApp.Web.ViewModels.Models.Activities;
    using FitnessWebApp.Web.Infrastructure.Extentions;

    public class GymUserController : BaseController
    {
        private readonly IGymUserService gymUserService;
        private readonly IFoodService foodService;
        private readonly IPartOfDayService partOfDayService;

        public GymUserController(IGymUserService _gymUserService, IPartOfDayService _partOfDayService, IFoodService _foodService)
        {
            gymUserService = _gymUserService;
            partOfDayService = _partOfDayService;
            foodService = _foodService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = User.GetId();
            bool isGymUSer = await gymUserService.GymUserExistsByUserIdAsync(userId);
            if (isGymUSer)
            {
                TempData[ErrorMessage] = "You are already an GymUser!";

                return RedirectToAction("Index", "Home");
            }
            var model = new BecomeGymUserFormModel()
            {
                Activities = await gymUserService.AllActivitiesAsync(),
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Become(BecomeGymUserFormModel model)
        {
            string? userId = User.GetId();
            bool isGymUser = await gymUserService.GymUserExistsByUserIdAsync(userId);
            if (isGymUser)
            {
                TempData[ErrorMessage] = "You are already training in the gym!";

                return RedirectToAction("Index", "Home");
            }


            if (!ModelState.IsValid)
            {
                this.GeneralError();
            }
            await gymUserService.AddGymUserAsync(userId,model);
            return RedirectToAction("All", "Food");
        }
        [HttpGet]
        public async Task<IActionResult> Diary()
        {
            string? userId = User.GetId();
            bool isGymUserExist = await gymUserService.GymUserExistsByUserIdAsync(userId);          
            if (!isGymUserExist) 
            {
                TempData[ErrorMessage] = "You should be a GymUser!";
                return RedirectToAction("Become", "GymUser");
            }
            IEnumerable<FoodSelectPartOfDayFormModel> formModel = await partOfDayService.AllPartOfDaysAsync();
            DiaryUserFormModel model = new DiaryUserFormModel()
            {
              PartOfDays = formModel
            };
            if (!ModelState.IsValid)
            {
                this.GeneralError();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Diary(DiaryUserFormModel model)
        {
            string? userId = User.GetId();
            bool isGymUser = await gymUserService.GymUserExistsByUserIdAsync(userId);
            if (!isGymUser)
            {
                TempData[ErrorMessage] = "You are already an GymUser!";
                return RedirectToAction("Become", "GymUser");
            }
            if (!ModelState.IsValid) 
            {
                this.GeneralError();
            }
            try
            {
                await gymUserService.AddFoodInFoodsCollectionAsync(userId, model);
            }
            catch (FoodDoesNotExistException)
            {
                TempData[InfoMessage] = "This Food Does not exist if you want you can add food here!";
                return RedirectToAction("Add", "Food");
            }
           
            return RedirectToAction("Mine","GymUser");
        }
        [HttpGet]
        public async Task<IActionResult> Mine([FromQuery] MineFoodsQueryModel queryModel)
        {
            string? userId = User.GetId();
            bool isGymUserExist = await gymUserService.GymUserExistsByUserIdAsync(userId);
            if (!isGymUserExist)
            {
                TempData[ErrorMessage] = "You should be a GymUser!";
                return RedirectToAction("Become", "GymUser");
            }
            var serviceModel = await gymUserService.MineFoodsAsync(queryModel, userId);
            queryModel.Foods = serviceModel.Foods;
            queryModel.Day = serviceModel.Day;

            return View(queryModel);
        }


        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact administrator";

            return RedirectToAction("Index", "Home");
        }
    }
}
