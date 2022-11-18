using Microsoft.AspNetCore.Mvc;
using Netflix.Api.Models;
using Netflix.Api.Services;

namespace Netflix.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeApi : ControllerBase
{
    private readonly IFilmeService _filmeService;

    public FilmeApi(IFilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    [HttpGet]
    public IEnumerable<Filme> Get(){
        return _filmeService.ListarFilmes();
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id){
        var filme = _filmeService.ObterFilme(id);
        if(filme!= null){
            
            return Ok(filme);
        }
        else{
            return BadRequest("Não encontrado");
        }
    }

    [HttpPost]
    public IActionResult Create(Filme filme)
    {
        if (_filmeService.SalvarFilme(filme)){
            return Ok();
        }
        else{
            return BadRequest("");
        }
    }

    [HttpPut]
    public IActionResult Update(Filme filme)
    {
        if (_filmeService.AlterarFilme(filme)){
            return Ok();
        }
        else{
            return BadRequest("");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete( string id){
        if (_filmeService.DeletarFilme(id)){
            return Ok();
        }
        else{
            return BadRequest("");
        }
    }

}

