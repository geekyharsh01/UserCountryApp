// Import necessary namespaces
using Microsoft.AspNetCore.Mvc;
using UserCountryApp.Models;
using UserCountryApp.Services;

// Namespace declaration for the UserController class, residing in the Controllers namespace
namespace UserCountryApp.Controllers
{
    // Controller class that handles HTTP requests for User operations
    public class UserController : Controller
    {
        // Private field to hold the UserService instance
        private readonly UserService _userService;

        // Constructor that initializes the UserController with the UserService instance
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // '''Method to handle GET requests for the Index action, which displays all users'''
        public async Task<IActionResult> Index()
        {
            // '''Retrieve all users asynchronously from the UserService'''
            var users = await _userService.GetAllAsync();
            // '''Return the view with the list of users'''
            return View(users);
        }

        // '''Method to handle GET requests for the Create action, which displays the user creation form'''
        public IActionResult Create()
        {
            // '''Return the view for creating a new user'''
            return View();
        }

        // '''Method to handle POST requests for the Create action, which creates a new user'''
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            // '''Check if the model state is valid'''
            if (ModelState.IsValid)
            {
                // '''Create the new user asynchronously using the UserService'''
                await _userService.CreateAsync(user);
                // '''Redirect to the Index action after successful creation'''
                return RedirectToAction("Index");
            }
            // '''If model state is not valid, return the view with the user object to display validation errors'''
            return View(user);
        }

        // '''Method to handle GET requests for the Details action, which displays details of a specific user'''
        public async Task<IActionResult> Details(string id)
        {
            // '''Retrieve the user by ID asynchronously from the UserService'''
            var user = await _userService.GetAsync(id);
            // '''If user is not found, return a NotFound result'''
            if (user == null)
            {
                return NotFound();
            }
            // '''Return the view with the user object'''
            return View(user);
        }
    }
}
