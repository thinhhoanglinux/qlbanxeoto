using Microsoft.AspNet.Identity;
using qlbanxeoto.Models;
using qlbanxeoto.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace qlbanxeoto.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class TinTucsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public TinTucsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: TinTucs
        [Authorize]
        public ActionResult Index()
        {
            return View(_dbContext.TinTucs.Include(c => c.LoaiTinTuc).Include(c => c.NhanVien).Where(w => w.TrangThai == true));
        }

        // GET: TinTucs/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var userId = User.Identity.GetUserId();
            var tintuc = _dbContext.TinTucs
                .Include(c => c.LoaiTinTuc)
                .Include(c => c.NhanVien)
                .Single(s => s.TinTucId == id && s.NhanVienId == userId);
            return View(tintuc);
        }

        // GET: TinTucs/Create
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new TinTucViewModel
            {
                LoaiTinTucs = _dbContext.LoaiTinTucs.ToList(),
                Heading = "Tạo mới"
            };
            return View(viewModel);
        }

        // POST: TinTucs/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TinTucViewModel viewModel, HttpPostedFileBase chonHinh)
        {
            if (chonHinh != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(chonHinh.FileName);
                string extensions = Path.GetExtension(chonHinh.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extensions;
                viewModel.Hinh = "~/Content/images/" + fileName;
                chonHinh.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            TinTuc tintuc = new TinTuc
            {
                TieuDe = viewModel.TieuDe,
                NoiDung = viewModel.NoiDung,
                ThoiGianDang = viewModel.ThoiGianDang,
                Hinh = viewModel.Hinh,
                LoaiTinTucId = viewModel.LoaiTinTuc,
                NhanVienId = User.Identity.GetUserId(),
                TrangThai = true
            };
            _dbContext.TinTucs.Add(tintuc);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: TinTucs/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var userId = User.Identity.GetUserId();
            var tintuc = _dbContext.TinTucs.Single(s => s.TinTucId == id && s.NhanVienId == userId);
            var viewModel = new TinTucViewModel
            {
                TinTucId = tintuc.TinTucId,
                Heading = "Sửa",
                LoaiTinTucs = _dbContext.LoaiTinTucs.ToList(),
                TieuDe = tintuc.TieuDe,
                NoiDung = tintuc.NoiDung,
                ThoiGianDang = tintuc.ThoiGianDang,
                Hinh = tintuc.Hinh,
                LoaiTinTuc = tintuc.LoaiTinTucId
            };
            return View("Create", viewModel);
        }

        // POST: TinTucs/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(TinTucViewModel viewModel, HttpPostedFileBase chonHinh)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    viewModel.LoaiTinTucs = _dbContext.LoaiTinTucs.ToList();
                    return View("Create", viewModel);
                }
                if (chonHinh != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(chonHinh.FileName);
                    string extensions = Path.GetExtension(chonHinh.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extensions;
                    viewModel.Hinh = "~/Content/images/" + fileName;
                    chonHinh.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                var userId = User.Identity.GetUserId();
                var tintuc = _dbContext.TinTucs
                    .Include(c => c.LoaiTinTuc)
                    .Include(c => c.NhanVien)
                    .Single(s => s.TinTucId == viewModel.TinTucId && s.NhanVienId == userId);

                tintuc.TieuDe = viewModel.TieuDe;
                tintuc.NoiDung = viewModel.NoiDung;
                tintuc.Hinh = viewModel.Hinh;
                tintuc.LoaiTinTucId = viewModel.LoaiTinTuc;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TinTucs/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var tintuc = _dbContext.TinTucs
                .Include(c => c.LoaiTinTuc)
                .Include(c => c.NhanVien)
                .Single(s => s.TinTucId == id);
            return View(tintuc);
        }

        // POST: TinTucs/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, TinTuc tintuc)
        {
            try
            {
                // TODO: Add delete logic here
                tintuc = _dbContext.TinTucs
                    .Include(c => c.NhanVien)
                    .Include(c => c.LoaiTinTuc)
                    .Single(s => s.TinTucId == id);
                tintuc.TrangThai = false;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TinTucs/Deleted
        [Authorize]
        public ActionResult Deleted()
        {
            var tintuc = _dbContext.TinTucs
                .Include(c => c.LoaiTinTuc)
                .Include(c => c.NhanVien)
                .Where(w => w.TrangThai == false);
            return View(tintuc);
        }

        // GET: TinTucs/Delete/5
        [Authorize]
        public ActionResult Delete2(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var tintuc = _dbContext.TinTucs
                .Include(c => c.LoaiTinTuc)
                .Include(c => c.NhanVien)
                .Single(s => s.TinTucId == id);
            return View(tintuc);
        }

        // POST: TinTucs/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete2(int id, TinTuc tintuc)
        {
            try
            {
                // TODO: Add delete logic here
                tintuc = _dbContext.TinTucs
                    .Include(c => c.NhanVien)
                    .Include(c => c.LoaiTinTuc)
                    .Single(s => s.TinTucId == id);
                tintuc.TrangThai = true;
                _dbContext.SaveChanges();
                return RedirectToAction("Deleted");
            }
            catch
            {
                return View();
            }
        }
    }
}