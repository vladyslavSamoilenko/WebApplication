using laboratorium1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace laboratorium1.Controllers;

public class ContactController: Controller
{
    private static List<ContactModel> contacts = new List<ContactModel>();
    private static int index = 1;

    // GET: Contact
    public IActionResult Index()
    {
        return View(contacts);
    }

    // GET: Contact/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Contact/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ContactModel model)
    {
        if (ModelState.IsValid)
        {
            model.Id = index++;
            contacts.Add(model);
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }
}