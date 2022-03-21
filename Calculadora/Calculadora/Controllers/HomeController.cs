using Calculadora.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculadora.Controllers
{
    /*Herança da class controler*/
    public class HomeController : Controller
    {
        /*Variavel interna*/
        private readonly ILogger<HomeController> _logger;

        /*Construtor*/
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet] //este anotador e facultativo
        public IActionResult Index()
        {
            return View();
        }



        /*CLASSE DE INTERFACE*/
        /*Funcao resposanvel pela interacao do browser, metedo que recebe o pedido feito pelo browser*/
       
        //recebe os dados do servidor, valor do botao

        [HttpPost] //SÓ qd o formulario for submetido em "psot" ele sera ecionado
        public IActionResult Index( string botao)
        {


            return View();
        }




        public IActionResult Privacy(){
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}