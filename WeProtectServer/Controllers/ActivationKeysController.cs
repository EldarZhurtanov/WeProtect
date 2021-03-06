﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeProtectServer.Models;

namespace WeProtectServer.Controllers
{
    [Authorize(Roles = "admin")]
    public class ActivationKeysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ActivationKeys
        public async Task<ActionResult> Index()
        {
            return View(await db.ActivationKeys.ToListAsync());
        }

        // GET: ActivationKeys/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivationKey activationKey = await db.ActivationKeys.FindAsync(id);
            if (activationKey == null)
            {
                return HttpNotFound();
            }
            return View(activationKey);
        }

        // GET: ActivationKeys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActivationKeys/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DateOfPurchase,UserId,Key,KeyNumber")] ActivationKey activationKey)
        {
            if (ModelState.IsValid)
            {
                db.ActivationKeys.Add(activationKey);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(activationKey);
        }

        // GET: ActivationKeys/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivationKey activationKey = await db.ActivationKeys.FindAsync(id);
            if (activationKey == null)
            {
                return HttpNotFound();
            }
            return View(activationKey);
        }

        // POST: ActivationKeys/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DateOfPurchase,UserId,Key,KeyNumber")] ActivationKey activationKey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activationKey).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(activationKey);
        }

        // GET: ActivationKeys/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivationKey activationKey = await db.ActivationKeys.FindAsync(id);
            if (activationKey == null)
            {
                return HttpNotFound();
            }
            return View(activationKey);
        }

        // POST: ActivationKeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            ActivationKey activationKey = await db.ActivationKeys.FindAsync(id);
            db.ActivationKeys.Remove(activationKey);
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
