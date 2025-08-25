using System;

class Program {
    static void Main() {
        
        string[,] tabuleiro = {
            { "1", "2", "3" },
            { "4", "5", "6" },
            { "7", "8", "9" }
        };

        string turno = "X";  
        int jogadas = 0;     
        bool fim = false;    

        while (!fim && jogadas < 9) {
            Mostrar(tabuleiro); 

            Console.WriteLine("VEZ DO " + turno + ": ");
            string jogada = Console.ReadLine() ?? "";

            bool valido = false;

            
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (tabuleiro[i, j] == jogada) {
                        tabuleiro[i, j] = turno; 
                        valido = true;
                    }
                }
            }

            
            if (!valido) {
                Console.WriteLine("JOGADA INVALIDA!");
                Console.ReadKey();
                continue;
            }

            jogadas++;

           
            if ((tabuleiro[0,0] == turno && tabuleiro[0,1] == turno && tabuleiro[0,2] == turno) ||
                (tabuleiro[1,0] == turno && tabuleiro[1,1] == turno && tabuleiro[1,2] == turno) ||
                (tabuleiro[2,0] == turno && tabuleiro[2,1] == turno && tabuleiro[2,2] == turno) ||
                (tabuleiro[0,0] == turno && tabuleiro[1,0] == turno && tabuleiro[2,0] == turno) ||
                (tabuleiro[0,1] == turno && tabuleiro[1,1] == turno && tabuleiro[2,1] == turno) ||
                (tabuleiro[0,2] == turno && tabuleiro[1,2] == turno && tabuleiro[2,2] == turno) ||
                (tabuleiro[0,0] == turno && tabuleiro[1,1] == turno && tabuleiro[2,2] == turno) ||
                (tabuleiro[0,2] == turno && tabuleiro[1,1] == turno && tabuleiro[2,0] == turno)) 
            {
                Mostrar(tabuleiro);
                Console.WriteLine("JOGADOR " + turno + " GANHOU!");
                fim = true;
            }
            else if (jogadas == 9) {
                Mostrar(tabuleiro);
                Console.WriteLine("DEU VELHA!");
                fim = true;
            }
            else {
                
                if (turno == "X") {
                    turno = "O";
                } else {
                    turno = "X";
                }
            }
        }
    }

    
    static void Mostrar(string[,] t) {
        Console.Clear();
        for (int i = 0; i < 3; i++) {
            Console.WriteLine(" " + t[i,0] + " | " + t[i,1] + " | " + t[i,2]);
            if (i < 2) Console.WriteLine("---+---+---");
        }
        Console.WriteLine();
    }
}
