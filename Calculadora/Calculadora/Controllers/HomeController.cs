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
        public IActionResult Index(){

            //preparar os dados a serem enviados para a View na primeira interação
            ViewBag.Visor = "0";        //inicia a calculadora com 0

            return View();
        }



        /*CLASSE DE INTERFACE*/
        /*Funcao resposanvel pela interacao do browser, metedo que recebe o pedido feito pelo browser*/
       
        //recebe os dados do servidor, valor do botao

        [HttpPost] //SÓ qd o formulario for submetido em "psot" ele sera ecionado
        public IActionResult Index( string botao, string visor) {   //botao pode executar 18 acoes diferentes

            //testar valor do 'botao'
            switch (botao)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    //pressionei um algarismo
                    if(visor == "0") { visor = botao; }
                    //tipo de dados do visor e string vai contactar na string
                    else { visor = visor + botao; }
                    //desafio: fazer em modo algebrico a operacao
                    break;


                case ",":
                    //foi precionada a virgula
                    //string com ''
                    //virgula só uma vez
                    if (!visor.Contains(',')) visor += ',';

                    break;

                case "+/-":

                    //vamos inverter o valor do 'visor'
                    //StartsWith, vamos usar para verificar se o numero e negatico, ou começa com o sinal de menos ou nao começa

                    //Se o visor comecar com o sinal de menos
                    if (visor.StartsWith('-')) visor = visor.Substring(1);
                                                        //visor[1..];

                    //retornar negativo
                    else visor = '-' + visor;


                    //sugestao: fazer de forma algebrica

                    break;
            }

            //preparar dados para serem enviados à View
            //Saco para a view, contentor que transporta dados do contoler para a view 
            //dar a viewo valor do controller
            ViewBag.Visor = visor;


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