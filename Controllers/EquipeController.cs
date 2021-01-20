using System;
using E_players.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_players.Controllers
{
    [Route("Equipe")] 
    public class EquipeController : Controller
    {
        //Criamos uma instância equipeModel com a estrutura Equipe
        Equipe equipeModel = new Equipe();

    [Route("Listar")]
        public IActionResult Index()
        {
            //Listando todas as equipes e enviando para a View, atráves da ViewBag
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

    [Route("Cadastrar")]
        public IActionResult Cadastrar( IFormCollection form )
        {
            //Criamos uma nova instância de Equipe e armazenamos os dados enviados pelo usuário atráves do formulário e salvamos no objeto novaEquipe

            Equipe novaEquipe   = new Equipe();

            novaEquipe.IdEquipe = Int32.Parse( form["IdEquipe"] );
            novaEquipe.Nome     = form["Nome"];
            novaEquipe.Imagem   = form["Imagem"];

            equipeModel.Create(novaEquipe);
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}