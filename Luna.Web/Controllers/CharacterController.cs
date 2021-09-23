using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Luna.Commons.Models.Dtos;
using Luna.Commons.Repositories;
using Luna.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Luna.Controllers
{
    public class CharacterController : BaseController
    {
        private CharacterRepository _characterRepository { get; set; }
        private CharacterRepository CharacterRepository =>
            _characterRepository ??= _scope.Resolve<CharacterRepository>();
        
        private RaceRepository _raceRepository { get; set; }
        private RaceRepository RaceRepository =>
            _raceRepository ??= _scope.Resolve<RaceRepository>();
        
        private CharacterTypeRepository _characterTypeRepository { get; set; }
        private CharacterTypeRepository CharacterTypeRepository =>
            _characterTypeRepository ??= _scope.Resolve<CharacterTypeRepository>();
        
        public CharacterController(ILifetimeScope scope) : base(scope)
        {
        }

        public async Task<IActionResult> Index()
        {
            var characters = await CharacterRepository.GetAll();
            
            return View(characters.Select(_ => new CharacterDto(_)));
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRacesForSelect()
        {
            var races = await RaceRepository.GetAll();
            
            return Ok(races.Select(_ => new SelectListItem(_.Name, _.Id.ToString())));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCharacterTypesForSelect()
        {
            var types = await CharacterTypeRepository.GetAll();
            
            return Ok(types.Select(_ => new SelectListItem(_.Name, _.Id.ToString())));
        }
    }
}