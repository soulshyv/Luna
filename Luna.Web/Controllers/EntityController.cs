using System;
using System.Threading.Tasks;
using Autofac;
using Luna.Commons.Models;
using Luna.Commons.Repositories.Interfaces;
using Luna.Commons.Services;
using Luna.Mvc;
using Luna.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Luna.Controllers
{
    public abstract class EntityController<TModel> : BaseController
    where TModel : ModelBase, new()
    {
        protected abstract string _entityName { get; }
        
        private IBaseRepository<TModel> _repo { get; set; }
        private IBaseRepository<TModel> Repo => _repo ??= _scope.Resolve<IBaseRepository<TModel>>();
        
        private CurrentUserAccessor _cua { get; set; }
        private CurrentUserAccessor CurrentUserAccessor => _cua ??= _scope.Resolve<CurrentUserAccessor>();
        
        public EntityController(ILifetimeScope scope) : base(scope)
        {
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = _entityName;
            
            var entities = await Repo.GetAll();
            
            return View("Entity/Index", entities);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Title = _entityName;

            return View("Entity/Add", new EntityViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(EntityViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            await Repo.Insert(new TModel
            {
                Name = model.Name,
                Description = model.Description,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Userid = await CurrentUserAccessor.GetUserId()
            });
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Title = _entityName;

            var entity = await Repo.GetById(id);
            
            return View("Entity/Edit", entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EntityViewModel model)
        {
            if (model?.Id == null)
            {
                return RedirectToAction("Index");
            }
            
            var entity = await Repo.GetById(model.Id.Value);
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Modified = DateTime.Now;
            entity.Userid = await CurrentUserAccessor.GetUserId();

            await Repo.Update(entity);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await Repo.DeleteById(id);
            
            return RedirectToAction("Index");
        }
    }
}