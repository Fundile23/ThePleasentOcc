using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThePleasantOcc.Data;
using ThePleasantOcc.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace ThePleasantOcc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LOGIN PAGE - Show login form
        public IActionResult Login()
        {
            return View();
        }

        // MAIN INDEX PAGE - Check if user is logged in
        public IActionResult Index()
        {
            // Check if user is logged in
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserEmail")))
            {
                return RedirectToAction("Login");
            }

            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            ViewBag.UserEmail = HttpContext.Session.GetString("UserEmail");
            return View();
        }

        // VALIDATE LOGIN - Called from AJAX
        [HttpPost]
        public IActionResult ValidateLogin([FromBody] LoginRequest request)
        {
            try
            {
                // Check if email matches student pattern (8 digits @VarsityOcc.az.ca)
                var studentPattern = @"^\d{8}@VarsityOcc\.az\.ca$";
                bool isStudent = Regex.IsMatch(request.Email, studentPattern);

                // Store in session
                HttpContext.Session.SetString("UserEmail", request.Email);
                HttpContext.Session.SetString("UserType", isStudent ? "student" : "demo");

                return Json(new
                {
                    success = true,
                    isStudent = isStudent,
                    message = isStudent ? "Student access granted" : "Demo access granted"
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // LOGOUT - Clear session
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // RESIDENCE DETAILS - Your existing method
        public async Task<IActionResult> ResidenceDetails(string residence)
        {
            // Check if user is logged in
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserEmail")))
            {
                return RedirectToAction("Login");
            }

            var rooms = await _context.Rooms
                .Where(r => r.Residence == residence)
                .OrderBy(r => r.Floor)
                .ThenBy(r => r.RoomNumber)
                .ToListAsync();

            int totalBeds = rooms.Sum(r => r.TotalBeds);
            int occupiedBeds = rooms.Sum(r => r.OccupiedBeds);
            int availableBeds = totalBeds - occupiedBeds;

            var roomTypes = rooms.Select(r => r.RoomType).Distinct().ToList();

            ViewBag.Residence = residence;
            ViewBag.Rooms = rooms;
            ViewBag.TotalBeds = totalBeds;
            ViewBag.AvailableBeds = availableBeds;
            ViewBag.OccupiedBeds = occupiedBeds;
            ViewBag.RoomTypes = roomTypes;
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            ViewBag.UserEmail = HttpContext.Session.GetString("UserEmail");

            return View();
        }

        // OCCUPY ROOM - Your existing method
        [HttpPost]
        public async Task<IActionResult> OccupyRoom([FromBody] BookingRequest request)
        {
            try
            {
                // CHECK IF USER IS STUDENT
                string userType = HttpContext.Session.GetString("UserType");
                if (userType != "student")
                {
                    return Json(new
                    {
                        success = false,
                        message = "Only registered students can occupy rooms. Please use a valid student email."
                    });
                }

                var room = await _context.Rooms.FindAsync(request.RoomId);
                if (room == null)
                {
                    return Json(new { success = false, message = "Room not found" });
                }

                if (room.OccupiedBeds >= room.TotalBeds)
                {
                    return Json(new { success = false, message = "Room is fully occupied" });
                }

                int bedNumber = room.OccupiedBeds + 1;

                var booking = new Booking
                {
                    RoomId = request.RoomId,
                    BedNumber = bedNumber,
                    StudentName = request.StudentName,
                    StudentEmail = request.StudentEmail,
                    StudentPhone = request.StudentPhone,
                    BookingDate = DateTime.UtcNow,
                    Status = "Active"
                };

                room.OccupiedBeds++;

                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();

                int bedsLeft = room.TotalBeds - room.OccupiedBeds;

                return Json(new
                {
                    success = true,
                    message = $"Room {room.RoomNumber} - Bed {bedNumber} assigned! {bedsLeft} bed(s) left in this room.",
                    roomId = room.Id,
                    bedsLeft = bedsLeft,
                    totalBeds = room.TotalBeds,
                    isFull = room.OccupiedBeds >= room.TotalBeds
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.ToString()
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms(string residence)
        {
            var rooms = await _context.Rooms
                .Where(r => r.Residence == residence && r.OccupiedBeds < r.TotalBeds)
                .OrderBy(r => r.Floor)
                .ThenBy(r => r.RoomNumber)
                .ToListAsync();

            return Json(rooms);
        }
    }

    // Request class - MUST be outside the controller class but in the same namespace
    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
    }

    public class BookingRequest
    {
        public int RoomId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public string StudentPhone { get; set; } = string.Empty;
    }
}