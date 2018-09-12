using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using AutoMapper;
using System.Web.Mvc;
using PracticeWebApplication.Models;
using EntityState = System.Data.Entity.EntityState;
using System.Configuration;
using System.Data.SqlClient;

namespace PracticeWebApplication.Controllers
{
    public class MappingClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //private int s;

        // GET: MappingClasses
        public async Task<ActionResult> Index()
        {
            var mappingClasses = db.MappingClasses.Include(m => m.Course).Include(m => m.Subject);
            var temp = await mappingClasses.ToListAsync();
            var a = await mappingClasses.GroupBy(u => u.CourseId).ToListAsync();

           // List<long> demoVar = null;

           // bool isprocessed = true;
            List<string> LstStringForMapping = new List<string>();
            foreach (var obj in temp)
            {
                obj.LstStringForMapping = temp.Where(aa => aa.CourseId == obj.CourseId)
                    .ToList().Select(ab => ab.Subject.SubjectName).ToList();
            }
            var tempDistinct = temp.Distinct();
            return View(tempDistinct.GroupBy(xx=>new { xx.Subject ,xx.CourseId}).Select(xx=>xx.FirstOrDefault()).ToList());
        }

        // GET: MappingClasses/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MappingClass mappingClass = await db.MappingClasses.FindAsync(id);
            if (mappingClass == null)
            {
                return HttpNotFound();
            }
            return View(mappingClass);
        }

        // GET: MappingClasses/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName");
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName");
            return View();
        }

        // POST: MappingClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MappingId,CourseId,SubjectId")] MappingClass mappingClass)
        {
            if (ModelState.IsValid)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select CourseId,SubjectId from MappingClass ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                //  con.Open();
                DataSet ds = new DataSet();
              
                da.Fill(dt);
                
              

                db.MappingClasses.Add(mappingClass);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName", mappingClass.CourseId);
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName", mappingClass.SubjectId);
            return View(mappingClass);
        }

        // GET: MappingClasses/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MappingClass mappingClass = await db.MappingClasses.FindAsync(id);
            if (mappingClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName", mappingClass.CourseId);
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName", mappingClass.SubjectId);
            return View(mappingClass);
        }

        // POST: MappingClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MappingId,CourseId,SubjectId")] MappingClass mappingClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mappingClass).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Course, "CourseId", "CourseName", mappingClass.CourseId);
            ViewBag.SubjectId = new SelectList(db.Subject, "SubjectId", "SubjectName", mappingClass.SubjectId);
            return View(mappingClass);
        }

        // GET: MappingClasses/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MappingClass mappingClass = await db.MappingClasses.FindAsync(id);
            if (mappingClass == null)
            {
                return HttpNotFound();
            }
            return View(mappingClass);
        }

        // POST: MappingClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            MappingClass mappingClass = await db.MappingClasses.FindAsync(id);
            db.MappingClasses.Remove(mappingClass);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //public async Task<ActionResult>  MapMultipleSubject(List<Subject>)
        //{
        //    return View();
        //}

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
