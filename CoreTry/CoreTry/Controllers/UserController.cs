using CoreTry.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTry.Controllers
{
    public class UserController:Controller
    {
        private IUsersAssets _assets;
        private UserColorContext db;
     public UserController(IUsersAssets assets,UserColorContext _db)
        {
            _assets = assets;
            db = _db;
        }
        [HttpGet]
        public IActionResult Index() {
            var userlist = _assets.GetAll();
            return View(userlist.ToList());
        }

        #region Create
     
        [HttpGet]
        public IActionResult Create()
        {
            #region ddlColor
            List<Color> colorlist = new List<Color>();
            colorlist = (from c in db.Colors select c).ToList();

            ViewBag.Colors = colorlist;

            #endregion
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User model)
        {       
            if (ModelState.IsValid)
            {
            
                _assets.Add(model);
                _assets.Save();
                ViewBag.title = "Başarılı";
                return RedirectToAction("index");

            }
            else
            {
                ViewBag.title = "Başarısız";
            }  
            return RedirectToAction("index");
        }

        #endregion Create

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            #region ddlColor
            List<Color> colorlist = new List<Color>();
            colorlist = (from c in db.Colors select c).ToList();

            ViewBag.Colors = colorlist;

            #endregion
            var usr = _assets.GetById(id);
            return View(usr);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id)
        {
            var userToUpdate =_assets.GetById(id);
            if (await TryUpdateModelAsync<User>(
                userToUpdate,
                "",
                s => s.FirstName, s => s.LastName, s => s.Mail, s=>s.BirthDate, s => s.Phone, s => s.ColorID))
            {
                try
                {
                     _assets.Save();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again");
                }
            }
            return View(userToUpdate);
        }
        #endregion

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _assets.Delete(id);
            _assets.Save();
            return RedirectToAction("index");
        }
    }
 
}
