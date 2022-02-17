using System;
using System.Text.RegularExpressions;

namespace DesafioDeProgramacaoAcademiaCapgemini2022 {

    internal class Program {

        private static void Main(string[] args) {
            int selecao = 0;

            Console.WriteLine("Qual questao voce gostaria de abir?");
            Console.WriteLine("Para abrir a primeira questao, Digite 1");
            Console.WriteLine("Para abrir a segunda questao, Digite 2");
            Console.WriteLine("Para abrir a terceira questao, Digite 3");
            selecao = Convert.ToInt32(Console.ReadLine());

            switch (selecao) {
                case 1:
                    Console.WriteLine("Digite um numero");
                    PrimeiraQuestao(Convert.ToInt32(Console.ReadLine()));
                    break;

                case 2:
                    Console.WriteLine("Digite um numero");
                    SegundaQuestao(Console.ReadLine());
                    break;

                case 3:
                    Console.WriteLine("Digite qualquer palavra");
                    TerceiraQuestao(Console.ReadLine());
                    break;
            }
        }

        //Questão 01

        public static void PrimeiraQuestao(int entrada) {
            //Contador porque vamos colocar espacos vazios na mesma quantidade
            //da entrada so que na ultima casa vamos por o asterisco
            //no decorrer do codigo, essa casa diminui, ou seja, no primeiro loop
            //o asterisco entra na ultima casa mas no segundo loop, ele entra na penultima
            // e assim por diante..

            int contador = entrada - 1;

            for (int i = 0; i < entrada; i++) {
                //Loop que print os espacos vazios e os asteriscos no final da string
                for (int j = 0; j < entrada; j++) {
                    if (j < contador) {
                        Console.Write(" ");
                    } else {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();

                //Remove a casa decimal do asteriscos, ou seja, se no primeiro loop
                //ele entrava na ultima casa, no proximo ele entra na penultima
                //e no proximo na antepenultima e assim sucessivamente...
                contador--;
            }
        }

        //Questão 02

        //Ter no minimo 6 caracter
        //Ter no minimo 1 digito (numero)
        //Ter no minimo 1 letra em minusculo
        //Ter no minimo 1 letra em maiusculo
        //Ter no minimo 1 caracter especial !@#$%^&*()-+

        public static void SegundaQuestao(string senha) {
            char[] senhaInadequada = senha.ToCharArray();

            bool val_Caracter = false;
            bool val_Digitos = false;
            bool val_Minuscula = false;
            bool val_Maiuscula = false;
            bool val_Especial = false;

            //Validacao 6 caracter
            if (senhaInadequada.Length >= 6) {
                val_Caracter = true;
            }

            //Validacao de 1 digito
            for (int i = 0; i < senhaInadequada.Length; i++) {
                if (Char.IsDigit(senhaInadequada[i])) {
                    val_Digitos = true;
                }
            }

            //Validacao de 1 minuscula
            for (int i = 0; i < senhaInadequada.Length; i++) {
                if (Char.IsLetter(senhaInadequada[i])) {
                    if (senhaInadequada[i].ToString() == senhaInadequada[i].ToString().ToLower()) {
                        val_Minuscula = true;
                    }
                }
            }

            //Validacao de 1 maiuscula
            for (int i = 0; i < senhaInadequada.Length; i++) {
                if (Char.IsLetter(senhaInadequada[i])) {
                    if (senhaInadequada[i].ToString() == senhaInadequada[i].ToString().ToUpper()) {
                        val_Maiuscula = true;
                    }
                }
            }

            //Validacao do caracter especial !@#$%^&*()-+
            for (int i = 0; i < senhaInadequada.Length; i++) {
                if (senhaInadequada[i].ToString().Contains('!') || senhaInadequada[i].ToString().Contains('@') ||
                    senhaInadequada[i].ToString().Contains('#') || senhaInadequada[i].ToString().Contains('$') ||
                    senhaInadequada[i].ToString().Contains('%') || senhaInadequada[i].ToString().Contains('^') ||
                    senhaInadequada[i].ToString().Contains('&') || senhaInadequada[i].ToString().Contains('*') ||
                    senhaInadequada[i].ToString().Contains('(') || senhaInadequada[i].ToString().Contains(')') ||
                    senhaInadequada[i].ToString().Contains('-') || senhaInadequada[i].ToString().Contains('+')) {
                    val_Especial = true;
                }
            }

            if (val_Caracter == false || val_Digitos == false || val_Minuscula == false
                || val_Maiuscula == false || val_Especial == false) {
                string validado = val_Caracter ? "Validado" : "Nao Validado";
                Console.Write($"Validacao de Caracter: {validado}");

                if (!(senha.Length >= 6)) {
                    Console.Write($" - faltam {6 - senha.Length} digitos para senha forte");
                }

                Console.WriteLine();
                validado = val_Digitos ? "Validado" : "Nao Validado";
                Console.WriteLine($"Validacao de Digitos: {validado}");

                validado = val_Minuscula ? "Validado" : "Nao Validado";
                Console.WriteLine($"Validacao de Minuscula: {validado}");

                validado = val_Maiuscula ? "Validado" : "Nao Validado";
                Console.WriteLine($"Validacao de Maiuscula: {validado}");

                validado = val_Especial ? "Validado" : "Nao Validado";
                Console.WriteLine($"Validacao de C.Especial: {validado}");
            } else {
                Console.WriteLine("Senha forte!");
            }
        }

        //Questão 03

        //Atividade incompleta por motivo insuficiente de conhecimento para resolver a problemática.
        public static void TerceiraQuestao(string palavra) {
            //Anagramas
            //Achar as letras iguais
            char[] palavraAleatoria = palavra.ToCharArray();
            char[] letrasIguais = new char[palavra.Length];
            int cont_letrasIguais = 0;

            for (int loop_1 = 1; loop_1 < palavraAleatoria.Length; loop_1++) {
                if (palavraAleatoria[loop_1] == ' ') {
                    break;
                }
                for (int loop_2 = 0; loop_2 < palavraAleatoria.Length; loop_2++) {
                    if (loop_1 != loop_2) {
                        if (palavraAleatoria[loop_1].Equals(palavraAleatoria[loop_2])) {
                            letrasIguais[cont_letrasIguais] = palavraAleatoria[loop_1];
                            cont_letrasIguais++;
                            palavraAleatoria[loop_1] = ' ';
                            palavraAleatoria[loop_2] = ' ';
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"Letras iguais: ");
            for (int i = 0; i < letrasIguais.Length; i++) {
                Console.WriteLine($"{letrasIguais[i]}");
            }
        }
    }
}