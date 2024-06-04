using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SafErgyReal.Models;
using Microsoft.AspNetCore.Http;
using SafErgyReal.Services;
using System.Text.Json;


namespace SafErgyReal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ClarifaiService _clarifaiService;

    public HomeController(ILogger<HomeController> logger, ClarifaiService clarifaiService)
    {
        _logger = logger;
        _clarifaiService = clarifaiService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    /*
    public async Task<IActionResult> ScanImage(IFormFile foodImage)
    {
        if (foodImage != null && foodImage.Length > 0)
        {
            // Convert IFormFile to a byte array or a format that Clarifai API expects
            using var ms = new MemoryStream();
            foodImage.CopyTo(ms);
            var fileBytes = ms.ToArray();
            // Assume your ClarifaiService expects a byte array and returns a task of string for simplicity
            string result = await _clarifaiService.PredictFoodAsync(fileBytes);

            Console.WriteLine(result);
           // Process the result here and decide how you want to display it

            var apiResponse = JsonSerializer.Deserialize<ScanResultViewModel>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var viewModel = new ScanResultViewModel();

            foreach (var concept in apiResponse.Outputs[0].Data.Concepts)
            {
                viewModel.IdentifiedFoodItems.Add(new FoodItem
                {
                    Name = concept.Name,
                    Value = concept.Value
                });
            }

            return View("Index", viewModel);
            

        }
        return View("Index"); // Consider redirecting to a different view to show the results
    }
    */

    public async Task<IActionResult> ScanImage(IFormFile foodImage)
    {
        if (foodImage != null && foodImage.Length > 0)
        {
            // Convert IFormFile to a byte array
            using var ms = new MemoryStream();
            foodImage.CopyTo(ms);
            var fileBytes = ms.ToArray();

            // Call the Clarifai API and get the result as a JSON string
            string jsonResponse = await _clarifaiService.PredictFoodAsync(fileBytes);
            Console.WriteLine(jsonResponse);
            // Deserialize the JSON response into the ClarifaiApiResponse object
            var clarifaiResponse = JsonSerializer.Deserialize<ClarifaiApiResponse>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var viewModel = new ScanResultViewModel();
            // Check if clarifaiResponse and Outputs are not null before proceeding
            if (clarifaiResponse != null && clarifaiResponse.Outputs != null)
            {
                foreach (var output in clarifaiResponse.Outputs)
                {
                    foreach (var concept in output.Data.Concepts)
                    {
                        viewModel.IdentifiedFoodItems.Add(new FoodItem
                        {
                            Name = concept.Name,
                            Value = (float)concept.Value // Ensure you handle the conversion here appropriately
                        });
                    }
                }
            }

            return View("Index", viewModel);



        }

        // Return to the index view if there's no foodImage or in case of an error
        return View("Index");
    }


}

