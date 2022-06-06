using liftoffHealthCare.Data;
using liftoffHealthCare.Models;
using liftoffHealthCare.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace liftoffHealthCare.Controllers
{
    [Authorize]
    public class VitalsController : Controller
    {
        private ApplicationDbContext context;
        
        public VitalsController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        
        public IActionResult Index(string sortOrder)
        {
            ViewData["DateSort"] = sortOrder == "dateLate" ? "dateEarly" : "dateLate";
            ViewData["HeartRSort"] = String.IsNullOrEmpty(sortOrder) ? "heart_rate" : "";
            ViewData["BPSort"] = sortOrder == "systolicLow" ? "systolicHigh" : "systolicLow";
            var vitals = from v in context.Vitals
                        select v;
            switch(sortOrder)
            {
                case "dateEarly":
                    vitals = vitals.OrderByDescending(v => v.Date);
                    break;
                case "dateLate":
                    vitals = vitals.OrderBy(v => v.Date);
                    break;
                case "heart_rate":
                    vitals = vitals.OrderByDescending(v => v.HeartRate);
                    break;
                case "systolicLow":
                    vitals = vitals.OrderBy(v => v.Systolic);
                    break;
                case "systolicHigh":
                    vitals = vitals.OrderByDescending(v => v.Systolic);
                    break;
                default:
                    vitals = vitals.OrderBy(d => d.Date);
                    break;
            }
            return View(vitals.ToList());
        }

        public IActionResult Add()
        {
            AddVitalViewModel viewModel = new AddVitalViewModel();
            return View(viewModel);
        }

        public IActionResult AddVitalSigns(AddVitalViewModel viewModel, string[] selectedMedications)
        {
            if (ModelState.IsValid)
            {
                Vital newVitals = new Vital
                {
                    Date = viewModel.Date,
                    HeartRate = viewModel.HeartRate,
                    Systolic = viewModel.Systolic,
                    Diastolic = viewModel.Diastolic,
                    ApplicationUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
                for (int i = 0; i < selectedMedications.Length; i++)
                {
                    VitalMedication newVitalMedication = new VitalMedication
                    {
                        MedicationId = int.Parse(selectedMedications[i]),
                        Vital = newVitals,
                        VitalId = newVitals.Id
                    };
                    context.VitalMedications.Add(newVitalMedication);
                }
                context.Vitals.Add(newVitals);
                context.SaveChanges();

                return Redirect("/vitals");
            }
            return View("add", viewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.vitals = context.Vitals.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult DeleteEntry(int[] ids)
        {
            foreach (int id in ids)
            {
                Vital vital = context.Vitals.Find(id);
                context.Vitals.Remove(vital);
            }
            context.SaveChanges();
            return Redirect("/vitals");
        }

        public IActionResult Edit(int id)
        {
            Vital vitals = context.Vitals.Find(id);
            return View(vitals);
        }
        public IActionResult ProcessEditedVitals(int id,AddVitalViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                Vital vital = context.Vitals.Find(id);
                vital.Date = viewModel.Date;
                vital.HeartRate = viewModel.HeartRate;
                vital.Systolic = viewModel.Systolic;
                vital.Diastolic = viewModel.Diastolic;

                context.Vitals.Update(vital);
                context.SaveChanges();
                return Redirect("/vitals");
            }
            return View("/Edit");
        }
    }
}