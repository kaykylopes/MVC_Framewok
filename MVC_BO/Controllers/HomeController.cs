using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace MVC_BO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            AlunoBLL _aluno = new AlunoBLL();

            List<Aluno> alunos = _aluno.getAlunos().ToList();


            return View("Index",alunos);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                AlunoBLL alunobll = new AlunoBLL();
                alunobll.IncluirAluno(aluno);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            AlunoBLL alunobll = new AlunoBLL();
            Aluno aluno = alunobll.getAlunos().Single(x => x.Id == id);
            return View(aluno);
        }

        [HttpPost]

        [ActionName("Edit")]
        public ActionResult Edit_Post([Bind(Include ="Id,Nome,Email,Idade,Datainscricao,Sexo")] Aluno aluno)
        {
            AlunoBLL alunobll = new AlunoBLL();
            

            if (ModelState.IsValid)
            {
                alunobll.AtualizarAluno(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }
    }
}