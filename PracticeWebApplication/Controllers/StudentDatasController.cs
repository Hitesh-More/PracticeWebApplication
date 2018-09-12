using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PracticeWebApplication.Models;
using EntityState = System.Data.Entity.EntityState;

namespace PracticeWebApplication.Controllers
{
    public class StudentDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentDatas
        public async Task<ActionResult> Index()
        {
            var studentData = db.StudentData.Include(s => s.Course);
            return View(await studentData.ToListAsync());
        }

        // GET: StudentDatas/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentData studentData = await db.StudentData.FindAsync(id);
            if (studentData == null)
            {
                return HttpNotFound();
            }
            return View(studentData);
        }

        // GET: StudentDatas/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName");
            return View();
        }

        // POST: StudentDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Gender,DateOfBirth,MobileNumber,Address1,City,State,Country,Zip,CourseId")] StudentData studentData)
        {
            if (ModelState.IsValid)
            {
                studentData.Id = Guid.NewGuid();
                db.StudentData.Add(studentData);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName", studentData.CourseId);
            return View(studentData);
        }

        // GET: StudentDatas/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentData studentData = await db.StudentData.FindAsync(id);
            if (studentData == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName", studentData.CourseId);
            return View(studentData);
        }

        // POST: StudentDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Gender,DateOfBirth,MobileNumber,Address1,City,State,Country,Zip,CourseId")] StudentData studentData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentData).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName", studentData.CourseId);
            return View(studentData);
        }

        // GET: StudentDatas/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentData studentData = await db.StudentData.FindAsync(id);
            if (studentData == null)
            {
                return HttpNotFound();
            }
            return View(studentData);
        }

        // POST: StudentDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            StudentData studentData = await db.StudentData.FindAsync(id);
            db.StudentData.Remove(studentData);
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
