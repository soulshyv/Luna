using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Luna.Commons.Models;
using Luna.Commons.Models.Dtos;
using Luna.Commons.Repositories.Implementations;
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
        
        private CustomPropertyTypeRepository _CustomPropertyTypeRepository { get; set; }
        private CustomPropertyTypeRepository CustomPropertyTypeRepository =>
            _CustomPropertyTypeRepository ??= _scope.Resolve<CustomPropertyTypeRepository>();
        
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
        public async Task<IActionResult> GetCharacterById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            
            var character = await CharacterRepository.GetById(id);
            
            return Ok(character);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRacesForSelect()
        {
            var races = await RaceRepository.GetAll();
            
            return Ok(races.Select(_ => new SelectListItem(_.Name, _.Id.ToString())));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewRace(string name, string description)
        {
            var race = await RaceRepository.GetByName(name);

            if (race != null)
            {
                return Unauthorized();
            }
            
            race = await RaceRepository.Insert(new Race
            {
                Name = name,
                Description = description
            });

            if (race?.Name == name)
            {
                return Ok(race);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCharacterTypesForSelect()
        {
            var types = await CharacterTypeRepository.GetAll();
            
            return Ok(types.Select(_ => new SelectListItem(_.Name, _.Id.ToString())));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCharacterType(string name, string description)
        {
            var type = await CharacterTypeRepository.GetByName(name);

            if (type != null)
            {
                return Unauthorized();
            }
            
            type = await CharacterTypeRepository.Insert(new CharacterType
            {
                Name = name,
                Description = description
            });

            if (type?.Name == name)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomPropertyTypesForSelect()
        {
            var types = await CustomPropertyTypeRepository.GetAll();
            
            return Ok(types.Select(_ => new SelectListItem(_.Name, _.Id.ToString())));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomPropertyType(string name, string description)
        {
            var type = await CustomPropertyTypeRepository.GetByName(name);

            if (type != null)
            {
                return Unauthorized();
            }
            
            type = await CustomPropertyTypeRepository.Insert(new CustomPropertyType
            {
                Name = name,
                Description = description
            });

            if (type?.Name == name)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}