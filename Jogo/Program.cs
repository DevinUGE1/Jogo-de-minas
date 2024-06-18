using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Jogo
{
    internal class Program
    {
        static void Main(string[] args)
        {
        inicio:;
            //Variaveis
            string jogador;
            bool vitoria;
            string desafio;
            string[,] cenario; //matriz de 2 dimensões 
            int x, y;
            //Intruções (teclado + comando)
            ConsoleKeyInfo teclado; //comando
            string comando;
            Random aleatorio;
            int sorte1, sorte2;
            int dificuldade;

            //inicializando
            jogador = "@";
            vitoria = false;
            desafio = "*";
            //Vetor ou matriz
            cenario = new string[10, 10]
            {
                // 0  1    2   3   4   5   6   7   8   9   
                 {"#","#","#","#","#","#","#","#","#", "#" },//0
                 {"#", " ", " ", " ", " ", " ", " ", " ", " ", "#" },//1
                 {"#", " ", " ", " ", " ", " ", " ", " ", " ", "#" },//2
                 {"#", " ", " ", " ", " ", " ", " ", " ", " ", "#" },//3
                 {"#", " ", " ", " ", " ", " ", " ", " ", " ", "#" },//4
                 {"#", " ", " ", " ", " ", " ", " ", " ", " ", "#" },//5
                 {"#", " ", " ", " ", " ", " ", " ", " ", " ", "#" },//6
                 {"#", " ", " ", " ", " ", " ", " ", " ", " ", "#" },//7
                 {"#", " ", " ", " ", " ", " ", " ", " ", " ", "|" },//8
                 {"#","#","#","#","#","#","#","#","#", "#" },//9
 
            };

            x = 1;
            y = 1;

            Console.Title = "Campo Minado";


            Console.WriteLine("tecle (I) para inicio do jogo ");
            comando = Console.ReadLine();
            ExibeCena(0);


            Console.Clear();

            //dificuldade
            Console.WriteLine("Selecione a dificuldade digitando de 1 a 5 ");
            dificuldade = int.Parse(Console.ReadLine());
            if (dificuldade < 1 && dificuldade > 5)
            {
                Console.WriteLine("Dificuldade invalida \n");
                Console.WriteLine("Digite a tecla (Esc) para sair ");
                teclado = Console.ReadKey();
            }


            Console.Clear();
            Console.WriteLine("Seu Personagem é o ( @ ), percorra todo o campo sem pisar nas minas ( * ). ");
            Console.WriteLine("Para ganhar chegue até a porta de saída ( | ).");
            Console.WriteLine("Seja rápido quando mais demorar mais minas iram aparecer.");
            Console.WriteLine("\nDigite enter para continuar  ");
            Console.ReadLine();


            do
            {
                Console.Clear();
                //Processamento
                // Entrada <=> Processamento <=> Saida
                cenario[y, x] = jogador;

                //define aleatoria
                aleatorio = new Random();


                teclado = new ConsoleKeyInfo();

                if (comando.ToUpper() == "I")
                {
                    //limpar tela
                    Console.Clear();
                    //Exibe o senario ler array y e x

                    for (int linha = 0; linha < 10; linha++)
                    {
                        for (int coluna = 0; coluna < 10; coluna++)
                        {
                            //exibe a informação da linhas e colunas da matriz
                            if (cenario[linha, coluna] == "*")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(cenario[linha, coluna]);
                                Console.ResetColor();
                            }
                            else if (cenario[linha, coluna] == "@")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(cenario[linha, coluna]);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write(cenario[linha, coluna]);
                            }
                        }
                        // ir para proxima linha
                        Console.WriteLine();
                    }

                    //exibe o menu do comandos do jogo

                    Console.WriteLine("Comandos");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("(W) para cima,");
                    Console.WriteLine("(S) para Baixo,");
                    Console.WriteLine("(A) para esquerda,");
                    Console.WriteLine("(D) para Direita,");
                    Console.WriteLine("tecla (Esc) para Sair");
                    Console.ResetColor();
                    Console.WriteLine("Tecle o comando: ");
                    teclado = Console.ReadKey();

                    switch (teclado.Key)
                    {

                        case ConsoleKey.W:
                            if (cenario[y - 1, x] != "#")
                            {
                                //limpar o movimento
                                cenario[y, x] = " ";

                                if (cenario[y - 1, x] == "*")
                                {
                                    Console.Clear();
                                    ExibeCena(1);
                                    Console.WriteLine("Digite enter para continuar ");
                                    Console.ReadLine();
                                    goto perdeu;
                                }
                                else if (cenario[y - 1, x] == "|")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Você conseguiu chegar até a saida e se salvar. ");
                                    Console.WriteLine("Digite enter para continuar  ");
                                    Console.ReadLine();
                                    vitoria = true;
                                    goto ganha;
                                }
                                y--;
                            }
                            break;

                        case ConsoleKey.S:
                            if (cenario[y + 1, x] != "#")
                            {
                                //limpar o movimento
                                cenario[y, x] = " ";

                                if (cenario[y + 1, x] == "*")
                                {
                                    Console.Clear();
                                    ExibeCena(1);
                                    Console.WriteLine("Digite enter para continuar  ");
                                    Console.ReadLine();
                                    goto perdeu;
                                }
                                else if (cenario[y + 1, x] == "|")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Você conseguiu chegar até a saida e se salvar. ");
                                    Console.WriteLine("Digite enter para continuar  ");
                                    Console.ReadLine();
                                    vitoria = true;
                                    goto ganha;
                                }
                                y++;
                            }

                            break;

                        case ConsoleKey.A:
                            if (cenario[y, x - 1] != "#")
                            {
                                //limpar o movimento
                                cenario[y, x] = " ";

                                if (cenario[y, x - 1] == "*")
                                {
                                    Console.Clear();
                                    ExibeCena(1);
                                    Console.WriteLine("Digite enter para continuar  ");
                                    Console.ReadLine();
                                    goto perdeu;
                                }
                                else if (cenario[y, x - 1] == "|")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Você conseguiu chegar até a saida e se salvar. ");
                                    Console.WriteLine("Digite enter para continuar  ");
                                    Console.ReadLine();
                                    vitoria = true;
                                    goto ganha;
                                }
                                x--;
                            }
                            break;

                        case ConsoleKey.D:
                            if (cenario[y, x + 1] != "#")
                            {
                                //limpar o movimento
                                cenario[y, x] = " ";

                                if (cenario[y, x + 1] == "*")
                                {
                                    Console.Clear();
                                    ExibeCena(1);
                                    Console.WriteLine("Digite enter para continuar  ");
                                    Console.ReadLine();
                                    goto perdeu;
                                }
                                else if (cenario[y, x + 1] == "|")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Você conseguiu chegar até a saida e se salvar. ");
                                    Console.WriteLine("Digite enter para continuar  ");
                                    Console.ReadLine();
                                    vitoria = true;
                                    goto ganha;
                                }
                                x++;
                            }
                            break;


                        case ConsoleKey.Escape:

                            break;
                        default:
                            Console.WriteLine("Comando invalido, tente novamente!");
                            Console.ReadKey();
                            break;

                    }



                    //Dificudade
                    for (int n = 1; n <= dificuldade; n++)
                    {
                        sorte1 = aleatorio.Next(1, 9);
                        sorte2 = aleatorio.Next(1, 9);
                        if (cenario[sorte1, sorte2] != "@")
                        {
                            cenario[sorte1, sorte2] = "*";
                        }


                    }






                }

                else
                {
                    Console.WriteLine("Digite a telca (Esc) para sair ");
                    teclado = Console.ReadKey();

                }

                Console.ReadKey();

            } while (teclado.Key != ConsoleKey.Escape);



        perdeu:;

        ganha:;
            if (vitoria == true)
            {
                Console.Clear();
                Console.WriteLine("parabens voce conseguiu ganhar ");
                ExibeCena(3);
                Console.Clear();
                Console.WriteLine("Digite Y para jogar novamente ou N para Sair");

                comando = Console.ReadLine();
                if (comando.ToUpper() == "Y")
                {
                    Console.Clear();
                    goto inicio;
                }


            }
            else
            {
                Console.Clear();

                ExibeCena(4);
                Console.Clear();
                Console.WriteLine("Digite Y para jogar novamente ou N para Sair");
                comando = Console.ReadLine();
                if (comando.ToUpper() == "Y")
                {
                    Console.Clear();
                    goto inicio;
                }
            }

        }

        static void ExibeCena(int codigocena)
        {
            //verifica qual cena 
            switch (codigocena)
            {
                default:
                    Console.WriteLine("Cena invalido");
                    break;
                case 0://inicio
                    Console.Clear();
                    Console.WriteLine("Jogo do campo minado  ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                   ,,*.                                             \r\n                                    .   .        *////.                                             \r\n                                ...................................,,,,,                            \r\n                                ........../@*..................@@**,,,,,                            \r\n                                  .......@%@@@.,@@@@@@@@*.#@./@.,,,,,,,,                            \r\n                                .............(@@@@@@@@@@,@@@@.,,,,,,,,,,                            \r\n                                ............,@@@@@@@@@@@@@@@@@,,,,,,,,,,                            \r\n                                ............*@,...,@@@.....@@@,,,,,,.                               \r\n                 .              .............@@,.,.&@&,.,.#&&,,.,,,,,,,,                            \r\n                                .............,.@@@@,@@@@@@@*@@,,,,,,,,,,                            \r\n                                .........@@@@*,,,&@,@@/@@/,,,*@*,,,,,,,,                            \r\n                                ..,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,                            \r\n                                ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,                            \r\n                                                  ////.                                             \r\n                                                  *,,,.                                             \r\n                                                  ,,*,.                                             \r\n                                                  ,,*,.                                             \r\n                                       .          ,,,,.                                             \r\n                                                  .*,,.                ,****,                       \r\n                                                  .,,,.       */(*/****/*//******/((*.              \r\n                                                   ,,,.      */******/*/###/*/*********             \r\n                                                             #/*********************//(             \r\n                        ./*(((((((((//*                      #(###(((((//////((//((//((             \r\n                   *//********/(/********/(/                   ###(((((((((((((//((/*               \r\n                  (/**********(#(************                                                       \r\n                  ##((***/****************/((                                                       \r\n                   #//##/*(((((((((((//(///((                                                    \r\n                      (#(((((((((((((/*(/                        .,,,,.                             \r\n                                                        ,/(//****/**********/(*.                    \r\n                                                       ********/**###/*********/*                   \r\n                                                      .#/**********************/(                   \r\n                                                      .#(###(((((//////((//((//((                   \r\n                                                         ###(((((((((((((//((//                     \r\n                                                                                                    \r\n");
                    Console.ResetColor();
                    Console.WriteLine("Pressione enter");
                    Console.ReadLine();
                    break;

                case 1://bomba
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("                                               &#                                                   \r\n .  .  .. ..  .  .  .. ..  .  .  .. ..  . &.  .. ..  .  .  .. ..  .  .. .. ..  .  .. ..  .  .  .. ..\r\n .  .  .. ..  .  .  .. ..  .  . &..(..  .  .  ...//@##@*.  .. ..  .  .. .. ..  .  .. ..  .  .  .. ..\r\n  .. ..  .  .  &@@@@@@@  .  .@@@@@@@@ .. .,@@@@@@@@@@@((((# ..  @&((((((((%  @. ..  .  .  .. ..  .  \r\n  .. ..  .  . ,@@@ . @@@ .@@@@ / &@@@&((@@@@@((((@@@@@(((((,&@@((((((((((((((@. ..  .  .  .. ..  .  \r\n .  .  .. .. @&@@@@@@@ .@@@@@ .  @@@@(@@@@@(((((((@@@@///@@@@//////(((((((((((/@@ .. ..  .  .  .. ..\r\n .  .  .. ..  @@@@@@@@ /@@@,  #@@@@&(&@@@@((/((//@@@@//@@@@@@////////(((((((((((( .. ..  .  .  .. ..\r\n  .. ..  .  .@@@@ @@@@. @@@@@@@@@((((@@@@@@@&@@@@@@@/@@@@@@@/////@@/////((((((((((@ .  .  .. ..  .  \r\n  .. ..  .  .@@@@@ .  .  .  #(((((((&(@@@@@@@@@@@///@@@@@@@@@@@@@@@@@/@/((((((((((  .  .  .. ..  .  \r\n .  .  .. ..  .  @  @. @@#(((((((((((#/////////////@@@//@@@@@@@@@@@@/@//((((%(((@ .. ..  .  .  .. ..\r\n .  .  .. ..  . &.@ .@((((((((((((((////////////////////@@@%/@@@@@#//////@@@@@@.  .. ..  .  .  .. ..\r\n .  .  .. ..  .  .  .#((((((((((///////////#///////////////@@@@@@/////@@@@@@@@((((#@@@*& .  .  .. ..\r\n  .. ..  .  .  .. .%@@((((((((//////////(///////////////////%@(/////@@@@@@@@@@@@@@@@@@ %  .. ..  .  \r\n  .. ..  .  . @..@#((((((((((///////////////(////////////////////&@@@@/(@@@@@@@@@@@#&  .  .. ..  .  \r\n .  .  .. .. ,. @(((((((((((///////////////////////////////////////////(@@(((@@@@ @. ..  .  .  .. ..\r\n .  .  .. ..  .  @(((((((((((%/////////////%///////////////////////////(((#@@@@(  .. ..  .  .  .. ..\r\n  .. ..  .  . /.  ..*#(((((((@(//////////////@////////////////@///////(((((((((((.  .  .  .. ..  .  \r\n  .. ..  .  .  .. ..  .##((((((((/@%/////////////////////////////////(((((((((((..  .  .  .. ..  .  \r\n .  .  .. ..  .  .  .@  @((((((((((((/(////////////////////////////((((((((((( .  .. ..  .  .  .. ..\r\n .  .  .. ..  .  .  ..@..@@((((((((#,,.((((///////////(((((((((#(((((((((((@.  .  @. ..  .  .  .. ..\r\n                         &@%          %/(((((((((((((((((((((@. ../((((         @                   \r\n  .. ..  .  .  .. ..  .  .  .. ..  .  ..&../(((((((((((#  .& .  .. ..  .  .  .. ..  .  .  .. ..  .  \r\n  .. ..  .  .  .. ..  .  .  .. ..  .  .. ..  .  .  .. ..  .  .   . ..  .  .  .. ..  .  .  .. ..  .  \r\n");
                    Console.ResetColor();
                    Console.WriteLine("Pressione enter");
                    Console.ReadLine();

                    break;

                case 2://Saida
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Blue;

                    Console.Write("                                                                                                    \r\n                                                                                         ,@(        \r\n                                                                                      @**((####@    \r\n                                                                                 .@#*,*,*((##((@    \r\n                 ,@@@@@@@@&@@@@@@@@@@@,                                       @,*,,#*,***(##((/     \r\n            &@@*****///////////*,*,,*,/////********@@@@@                  *#,,,,..,,*,***(#((//     \r\n           @,//((//**********////,*,*******/****///************/#@@@   @,,**,,*.*,,**,***(#((/(     \r\n           @,**/*((,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*****,,*///*******((*,**,,**(,*,*,,,*,***(#((/@     \r\n           ,,/***/@                                 ,@@@@%,,,,*(**,#****,,*,#,*,,,#,*,**,(#((/@     \r\n           ,,*/**/@                                           @/,*,#***#,,*,#,*,,,#,,,**,(#(((      \r\n           &,****/@                                           @/*,.#,**#,,*,#*,*,,(,,,**,(((//      \r\n           @,****/@                                           @,*(,#,***,,*,,*,*,,,,,,*,,(((//      \r\n           @,*/***@                                           @,*(,#,**,,*,,*,,*,,,,,,*,,#((/@      \r\n           .,*/**/@                                           @,*/,(,**,,,,,,,**,/,*,,*,*#((/@      \r\n            ,,****&                                           (,*/,**,/,,*,*,***,#.*,**,,#((/,      \r\n            @.,*/*/                                           /((#,**,#,,*,#***,*/**,**,(#(//       \r\n            @,**/*/%                                          /**,,**,#,**,#,**.#///(#(((#(//       \r\n            %,****/@                                          /,,,,**,#,**,#,,*,/**#(*//(((/@       \r\n             ,***/*@                                         &/**,****(,,**,,,*,/**((*(,(((/@       \r\n             ,,//**@                                         @/**,,*,******,,,*.**/((((,#(//(       \r\n             (,//***                                         @/**,*,,*,****,,**.***((((,#(//        \r\n             (,*/***                                         @/**,**,******,,**.***#*((,#(//*,*@    \r\n             (,*/***                                         @,**,%*,*,,**%,,**.*/*#*((*((/(,,*     \r\n             *,/****,                                        **,*,#,,*,,,*#,***.,*,(*(*((//@        \r\n             (,/****.                                        /*,*,%,***,,*#,**.*/,,**(,((//&        \r\n             /,**/**                                         /*,*,/,****,*,,*,.#/*/(((,#(/(         \r\n             ,,*//**                                        @/*,*,,,*,****,,*,.*/*#(((,#(/(         \r\n             ,**/*/*                                        @/,*(*,,*#****,*,,*,,,***,,#(/@         \r\n             ,**/*/*                                        @/,*(,,,*#*,**,*,,,#,,***,((//@         \r\n             ,***///                                        **,//,,**#*,*#,*,*,#,,***,((//@         \r\n            @,***///                                        /*///,,**#*,*#,*,,,%,,***,((//          \r\n            @,***/*/                                        /**(#/,***,**(,*,*,,*,****((//          \r\n            @,***/*/                                       @/***,#,***,***,*,,***,.*,/#(/#          \r\n            @.,**/*@                                       #,***,#,***,**,,*,,,,,,,**(#(/@          \r\n            #,**//*@                                       #****,#,,/*,*,,,*,,/**,,**(#(/@          \r\n            @,**/*/@                                       /****,#,*#*,*#,,**,#,*,,**(#(/           \r\n            @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&@@@@@@@@@@@@@@@@@@@&*,*,*#*,*#,,****,*,,*((#((           \r\n                                                                    @%,,#,***,,,*,,*(##((           \r\n                                                                           @//,,,,,*(##(@           \r\n                                                                                  @*(###@           \r\n                                                                                                    \r\n  * *.*   #                                                        ,          /,  .  (              \r\n  *****  ..          .                                                        /.          *         \r\n");
                    Console.ResetColor();
                    Console.WriteLine("Pressione enter");
                    Console.ReadLine();
                    break;

                case 3://Trofeu
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                             #%%####%%%*                                            \r\n                                     %(,,,   .,,,,,,,,,,,,,,,,%                                     \r\n                                   #,,,,,,,,,,,,,,,,,,,,,,,,,,,**/                                  \r\n                              (#%#%#,,,,,,,,,,,,,%#,,,,,,,,,,,,**#%##%                              \r\n                            * ,,,,,%,.,,,,,,,,,,%*//*,,,,,,,,.,**/**,,,,#                           \r\n                           # ,*    %, ,,,,,,,%/////////#,,,,,,**/    %,,,/                          \r\n                           % ,,     , .,,,,,,,/**/**/%,,,,,,*,**#    %,,,.                          \r\n                            (,,#    %, ,,,,,,,%/%,,%#**,,,,%,**/    #,,/%                           \r\n                             %,,,%   %, ,,,,,,,,,,,,,,,,,,%,***,   (,,,,                            \r\n                               %,,,/# %, ,,,,,,,,,,,,,,,,,,**** #,,/(                               \r\n                                  *%,,,#,,,,,,,,,,,,,,,,,***#**,/#                                  \r\n                                         %,,,,,,,,,,,,,***%                                         \r\n                                            %*********/(*                                           \r\n                                            %##########%.                                           \r\n                                               (,,,,*#                                              \r\n                                              #,,,,,//                                              \r\n                                              /,,,,,,*%                                             \r\n                                             %,,,,,,,*/                                             \r\n                                          %.////////////((                                          \r\n                                        %//////////////////(%                                       \r\n                                        ///////////////////(%                                       \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n ");
                    Console.ResetColor();
                    Console.WriteLine("Pressione enter");
                    Console.ReadLine();

                    break;

                case 4://Perdeu

                    Console.WriteLine(" Você foi explodido  e perdeu  ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("                                                                                                    \r\n             .  %                                                           (.%%.                   \r\n             %   #%  (%.                                                  %     .%%.                \r\n             &% .,             .%%(                                 .%%      . .#%%%#               \r\n                  /%#%%%#%,                 ,%%%%##%%%%%##%%%%/       ,%%%      (#                  \r\n                               /%%%%%,  %        %,     (%#    .%%%                                 \r\n                                       %                              %                             \r\n                                  (%%%%/             .%*               #                            \r\n                       .%#/%..                     (  #%        #%%/(%.                             \r\n             ##%%%.      . .  .      #%%%%%,.  ,(%#//#%%/%%/%//  ..  #/                             \r\n         %#%%            . ,%%/#//%%////   /%/%%/%/////%//%///#(////     *%                         \r\n       %     ,.    *%###,    %%%%%%%%%#%  ##%%%%%%%%%%%%%%%%%%%%%%%%% %%#    %%                     \r\n      #   %%  %#                           %%%%%%%%%%%%%%%%%%%%%#%(       %%.    %#%# %             \r\n     #  %#                           %##%%     %%#%#   ,&&                   /%       &##           \r\n     %%%                                             #%%%%%%%.                  % #% % % (%         \r\n                                                      %%%%%%%                    %%/%/#%%%          \r\n                                                               ##%                    #(            \r\n                                                                                                    \r\n");
                    Console.ResetColor();
                    Console.WriteLine("Pressione enter");
                    Console.ReadLine();

                    break;

            }


        }
    }
}