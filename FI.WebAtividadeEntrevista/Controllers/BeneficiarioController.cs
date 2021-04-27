using System.Web.Mvc;

namespace WebAtividadeEntrevista.Controllers
{
    public class BeneficiarioController : Controller
    {
        // GET: Beneficiario
        public ActionResult Index()
        {
            return PartialView();
        }

        // GET: Beneficiario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Beneficiario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beneficiario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Beneficiario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Beneficiario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Beneficiario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Beneficiario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
