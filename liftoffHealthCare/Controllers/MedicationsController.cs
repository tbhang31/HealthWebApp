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
    public class MedicationsController : Controller
    {
        private ApplicationDbContext context;
        public MedicationsController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index(string sortOrder)
        {
            ViewData["MedSort"] = string.IsNullOrEmpty(sortOrder) ? "medSort" : "";
            var medications = from m in context.Medications
                              select m;
            switch(sortOrder)
            {
                case "medSort":
                    medications = medications.OrderBy(v => v.Name);
                    break;
                case "":
                    medications = medications.OrderByDescending(v => v.Name);
                    break;
            }
            return View(medications.ToList());
        }

        public IActionResult Add()
        {
            AddMedicationViewModel viewModel = new AddMedicationViewModel();
            return View(viewModel);
        }

        public IActionResult AddMedication(AddMedicationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Medication newMedication = new Medication
                {
                    Name = viewModel.Name,
                    Dosage = viewModel.Dosage,
                    DosageDescription = viewModel.DosageDescription,
                    Instruction = viewModel.Instruction,
                    ApplicationUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
                context.Medications.Add(newMedication);
                context.SaveChanges();

                return Redirect("/medications");
            }
            return View("add", viewModel);
        }
        public IActionResult Delete()
        {
            ViewBag.Medications = context.Medications.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult DeleteEntry(int[] ids)
        {
            foreach (int id in ids)
            {
                Medication medication = context.Medications.Find(id);
                context.Medications.Remove(medication);
            }
            context.SaveChanges();
            return Redirect("/medications");
        }

        public IActionResult Edit(int id)
        {
            Medication medication = context.Medications.Find(id);
            AddMedicationViewModel viewModel = new AddMedicationViewModel();
            viewModel.Id = medication.Id;
            viewModel.Name = medication.Name;
            viewModel.Dosage = medication.Dosage;
            viewModel.Instruction = medication.Instruction;
            return View(viewModel);
        }
        public IActionResult ProcessEditedMedication(int id, AddMedicationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Medication medication = context.Medications.Find(id);
                medication.Name = viewModel.Name;
                medication.Dosage = viewModel.Dosage;
                medication.DosageDescription = viewModel.DosageDescription;
                medication.Instruction = viewModel.Instruction;

                context.Medications.Update(medication);
                context.SaveChanges();
                return Redirect("/medications");
            }
            return View("/Edit");
        }
    }
}
