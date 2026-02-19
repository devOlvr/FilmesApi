using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;
using System.Reflection.Metadata.Ecma335;

namespace FilmesApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ListarSessoesPorId), new
            {
                id = sessao.Id
            }, sessao);
        }

        [HttpGet]
        public IEnumerable<ReadSessaoDto> ListarSessoes()
        {
            return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList());
            
        }

        [HttpGet("{id}")]
        public IActionResult ListarSessoesPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return Ok(sessaoDto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}