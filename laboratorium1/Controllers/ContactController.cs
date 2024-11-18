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
    // GET: Contact/Edit/5
    public IActionResult Edit(int id)
    {
        var contact = contacts.FirstOrDefault(c => c.Id == id);
        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }

// POST: Contact/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, ContactModel model)
    {
        if (ModelState.IsValid)
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Email = model.Email;
            contact.PhoneNumber = model.PhoneNumber;
            contact.DateBirt = model.DateBirt;
            contact.Category = model.Category;

            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

// GET: Contact/Delete/5
    public IActionResult Delete(int id)
    {
        var contact = contacts.FirstOrDefault(c => c.Id == id);
        if (contact == null)
        {
            return NotFound();
        }

        return View(contact);
    }

// POST: Contact/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var contact = contacts.FirstOrDefault(c => c.Id == id);
        if (contact != null)
        {
            contacts.Remove(contact);
        }

        return RedirectToAction(nameof(Index));
    }
}