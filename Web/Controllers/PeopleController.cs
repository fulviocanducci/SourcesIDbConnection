using Data;
using Microsoft.AspNetCore.Mvc;
using Repositories;
namespace Web.Controllers
{
   public class PeopleController : Controller
   {
      public PeopleRepositoryAbstract PeopleRepository { get; }

      public PeopleController(PeopleRepositoryAbstract peopleRepository)
      {
         PeopleRepository = peopleRepository;
      }

      protected async Task<People> GetPeopleAsync(ulong id)
      {
         return await PeopleRepository.FirstOrDefaultAsync(id);
      }

      public async Task<ActionResult> Index()
      {
         IEnumerable<People> model = await PeopleRepository.AllAsync();
         return View(model);
      }

      public async Task<ActionResult> Details(ulong id)
      {
         People model = await GetPeopleAsync(id);
         if (model != null)
         {
            return View(model);
         }
         return RedirectToAction(nameof(Index));
      }

      public ActionResult Create()
      {
         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Create(People people)
      {
         try
         {
            if (ModelState.IsValid)
            {
               people.Id = await PeopleRepository.InsertAsync(people);
               return RedirectToAction(nameof(Edit), new { people.Id });
            } 
            return View(people);
         }
         catch
         {
            return View();
         }
      }

      public async Task<ActionResult> Edit(ulong id)
      {
         People model = await GetPeopleAsync(id);
         if (model != null)
         {
            return View(model);
         }
         return RedirectToAction(nameof(Index));
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Edit(People people)
      {
         try
         {
            if (ModelState.IsValid)
            {
               if (await PeopleRepository.UpdateAsync(people))
               {
                  return RedirectToAction(nameof(Edit), new { people.Id });
               }
            }
            return View(people);
         }
         catch
         {
            return View();
         }
      }

      public async Task<ActionResult> Delete(ulong id)
      {
         People model = await GetPeopleAsync(id);
         if (model != null)
         {
            return View(model);
         }
         return RedirectToAction(nameof(Index));
      }

      [HttpPost]
      [ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> DeletePost(ulong id)
      {
         try
         {
            People model = await GetPeopleAsync(id);
            if (model != null)
            {
               await PeopleRepository.DeleteAsync(model);
            }
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }
   }
}
