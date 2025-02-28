using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace AssetManagement.Web.Helpers
{
    public class ControllerHelper
    {
        private readonly ApplicationPartManager _partManager;

        public ControllerHelper(ApplicationPartManager partManager)
        {
            _partManager = partManager;
        }

        public List<string> GetControllers()
        {
            var feature = new ControllerFeature();
            _partManager.PopulateFeature(feature);

            // Get all controller names and order them to ensure Home is first and Vehicles second
            var controllers = feature.Controllers
                .Select(c => c.Name.Replace("Controller", ""))
                .ToList();

            // Move Home to the first index
            var homeController = controllers.FirstOrDefault(c => c == "Home");
            if (homeController != null)
            {
                controllers.Remove(homeController);
                controllers.Insert(0, homeController);
            }

            // Move Vehicles to the second index
            var vehiclesController = controllers.FirstOrDefault(c => c == "Vehicles");
            if (vehiclesController != null)
            {
                controllers.Remove(vehiclesController);
                controllers.Insert(1, vehiclesController);
            }

            return controllers;
        }

    }
}
