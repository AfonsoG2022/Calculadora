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


        //public string primeiroOperando;         //quando passa do controller para a view a variavel e destruida 



        /*Construtor*/
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// 
        /// Prepara a calculadora para ser apresentada, pela primeira vez ao utilizador
        /// 
        /// </summary>
        /// <returns></returns>
        /// 



        [HttpGet] //este anotador e facultativo
        public IActionResult Index(){

            //preparar os dados a serem enviados para a View na primeira interação
            ViewBag.Visor = "0";        //inicia a calculadora com 0

            return View();
        }



        /*CLASSE DE INTERFACE*/
        /*Funcao resposanvel pela interacao do browser, metedo que recebe o pedido feito pelo browser*/

        //recebe os dados do servidor, valor do botao

        /// <summary>
        /// 
        /// Prepara a calculadora na segunda interação e seguintes
        /// 
        /// </summary>
        /// <param name="botao"> Valor do botão pressionado pelo utilizador, ao usar a calculadora </param>    
        /// <param name="visor"> Valor do visor da calculadora  </param>
        /// <param name="primeiroOperando"> na operação algebrica, valor do 1 operando</param>
        /// <param name="Operador"> operacao a ser executada</param>
        /// <param name="limpaEcra"> indica se o visor deve ser, ou nao reiniciado</param>
        /// <returns></returns>
        /// 




        [HttpPost] //SÓ qd o formulario for submetido em "psot" ele sera ecionado
        public IActionResult Index(
            string botao,
            string visor,
            string primeiroOperando,            //recupera no controller os dados
            string Operador,                     //recupera os dados
            string limpaEcra
            ) {   //botao pode executar 18 acoes diferentes

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
                    //    || = ou
                    if (limpaEcra == "sim" || visor == "0") { visor = botao; }
                    //tipo de dados do visor e string vai contactar na string
                    else { visor = visor + botao; }
                    limpaEcra = "não";
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


                    break;



                case "+":
                case "-":
                case "x":
                case ":":

                    //foi pressionado um operador
                    if (!string.IsNullOrEmpty(Operador))
                        
                    {   
                        //como já é, pelo menos, a mesma 
                        
                        //se o operador nao e nulo nem vazio executa as contas


                 
                        //agora, temos mesmo de fazer a operacao algebrica
                        double operandoUm = Convert.ToDouble(primeiroOperando.Replace(',','.'));  //converte os valores             //caso ouver , colocar .
                        double operandoDois = Convert.ToDouble(visor.Replace(',','.'));

                        double resultado = 0;



                        switch (Operador)
                        {      // Se o operador
                            case "+":
                                resultado = operandoUm + operandoDois;       // para o +
                                break;
                            case "-":
                                resultado = operandoUm - operandoDois;       // para o -
                                break;
                            case "*":
                                resultado = operandoUm * operandoDois;       // para o *
                                break;
                            case "/":
                                resultado = operandoUm / operandoDois;       // para o /
                                break;
                        }




                        visor = resultado + "";     //transforma tudo o que esta na adição 


                    }



                    primeiroOperando = visor;
                    Operador = botao;
                    limpaEcra = "sim";

            break;





        }




            //preparar dados para serem enviados para a VIEW
            ViewBag.Visor = visor;
            ViewBag.PrimeiroOperando = primeiroOperando;
            ViewBag.Operando = Operador;
            ViewBag.limpaEcra = limpaEcra;

            return View();



        //}

            

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