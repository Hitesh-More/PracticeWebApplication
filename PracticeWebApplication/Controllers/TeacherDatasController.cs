using System;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using PracticeWebApplication.Models;
using Microsoft.AspNet.Identity;

namespace PracticeWebApplication.Controllers
{
  
    public class TeacherDatasController : Controller
    {
        
       
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: TeacherDatas
        public async Task<ActionResult> Index()
        {
            return View(await db.TeacherData.ToListAsync());
        }

        // GET: TeacherDatas/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherData teacherData = await db.TeacherData.FindAsync(id);
            if (teacherData == null)
            {
                return HttpNotFound();
            }
            return View(teacherData);
        }

        // GET: TeacherDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Gender,DateOfBirth,MobileNumber,Address1,City,State,Country,Zip")] TeacherData teacherData)
        {
            if (ModelState.IsValid)
            {
              
                teacherData.Id = Guid.NewGuid();
                db.TeacherData.Add(teacherData);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(teacherData);
        }

        // GET: TeacherDatas/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherData teacherData = await db.TeacherData.FindAsync(id);
            if (teacherData == null)
            {
                return HttpNotFound();
            }
            return View(teacherData);
        }

        // POST: TeacherDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Gender,DateOfBirth,MobileNumber,Address1,City,State,Country,Zip")] TeacherData teacherData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherData).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(teacherData);
        }

        // GET: TeacherDatas/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherData teacherData = await db.TeacherData.FindAsync(id);
            if (teacherData == null)
            {
                return HttpNotFound();
            }
            return View(teacherData);
        }

        // POST: TeacherDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            TeacherData teacherData = await db.TeacherData.FindAsync(id);
            db.TeacherData.Remove(teacherData);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
