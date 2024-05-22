using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientManagement.Data;
using PatientManagement.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Diseases = await _context.Diseases.ToListAsync();
            ViewBag.NCDs = await _context.NCDs.ToListAsync();
            ViewBag.Allergies = await _context.Allergies.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient patient, int[] selectedNCDs, int[] selectedAllergies)
        {
            _context.Add(patient);
            await _context.SaveChangesAsync();

            foreach (var ncdId in selectedNCDs)
            {
                _context.NCD_Details.Add(new NCD_Details { PatientId = patient.Id, NCDId = ncdId });
            }

            foreach (var allergyId in selectedAllergies)
            {
                _context.Allergies_Details.Add(new Allergies_Details { PatientId = patient.Id, AllergiesId = allergyId });
            }

            await _context.SaveChangesAsync();

            ViewBag.Diseases = await _context.Diseases.ToListAsync();
            ViewBag.NCDs = await _context.NCDs.ToListAsync();
            ViewBag.Allergies = await _context.Allergies.ToListAsync();
            return RedirectToAction(nameof(Create));
            //return View(patient);

        }

        public IActionResult Index()
        {
            var patients = _context.Patients.Include(p => p.Disease).ToList();
            return View(patients);
        }
    }
}
