using System;
using System.IO;
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

            //Inicio Upload
            //Verificamos se o usuario anexou um arquivo

            if ( form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/img/Equipes" );

                if ( !Directory.Exists( folder ) )
                {
                    Directory.CreateDirectory( folder );
                }

                var path = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName );

                using ( var stream = new FileStream( path, FileMode.Create ) )
                {
                    //Salvamos o arquivo no caminho especificado

                    file.CopyTo( stream );
                }

                novaEquipe.Imagem = file.FileName;

            }

            else
            {
                novaEquipe.Imagem = "padrao.png";
            }

            //Termino Upload

            equipeModel.Create(novaEquipe);
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }

        [Route("{id}")]
        public IActionResult Excluir( int id )
        {
            equipeModel.Delete( id );

            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}