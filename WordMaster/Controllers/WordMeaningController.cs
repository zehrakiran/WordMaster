using DataAccessLayer.Entities;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordMaster.Models;

namespace WordMaster.Controllers
{
    public class WordMeaningController : Controller
    {
        IWordMeaningRepository _repository;
        public WordMeaningController (IWordMeaningRepository repository)
        {
            _repository = repository;
        }
        // GET: WordMeaningController
        public ActionResult Index()
        {
            List<WordMeaningViewModel> model = new List<WordMeaningViewModel>();
            List<WordMeaning> liste = _repository.List();
            foreach (WordMeaning item in liste)
            {
                WordMeaningViewModel wmvm = new WordMeaningViewModel()
                {
                    Id = item.Id,
                    Meaning = item.Meaning,
                    LangId = item.LangId,
                    WordDefinitionId = item.WordDefinitionId

                };
                model.Add(wmvm);

            }
            return View(model);
        }

        // GET: WordMeaningController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WordMeaningController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WordMeaningController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WordMeaningController/Edit/5
        public ActionResult Edit(int? id)
        {
            WordMeaningViewModel model = new WordMeaningViewModel();
            if (id.HasValue && id > 0)
            {
                WordMeaning meaning = _repository.GetById(id.Value);
                model.Id = meaning.Id;
                model.Meaning = meaning.Meaning;
                model.LangId = meaning.LangId;
                model.WordDefinitionId = meaning.WordDefinitionId;

            }
            return View(model);
        }

        // POST: WordMeaningController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WordMeaningViewModel model)
        {
            WordMeaning entity = new WordMeaning()
            {
                Id = model.Id,
                Meaning = model.Meaning,
                LangId = model.LangId,
                WordDefinitionId=model.WordDefinitionId

            };
            if (entity.Id > 0)
            {
                _repository.Update(entity);
            }
            else
            {
                _repository.Add(entity);
            }
            return RedirectToAction("Index");
        }

        // GET: WordMeaningController/Delete/5
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: WordMeaningController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
