using System;

class Program {
    static void Main() {
        // CRIA O TABULEIRO 3X3
        string[,] tabuleiro = { 
            { "1", "2", "3" }, 
            { "4", "5", "6" }, 
            { "7", "8", "9" } 
        };

        string turno = "X"; // JOGADOR QUE COMEÇA
        int jogadas = 0;    // CONTADOR DE JOGADAS
        bool fim = false;   // CONTROLA SE O JOGO ACABOU

        // LOOP DO JOGO
        while (!fim && jogadas < 9) {
            Mostrar(tabuleiro); // MOSTRA O TABULEIRO
            Console.WriteLine("VEZ DO " + turno + ": ");
            string jogada = Console.ReadLine() ?? "";

            bool valido = false;

            // PROCURA NO TABULEIRO
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (tabuleiro[i, j] == jogada) {
                        tabuleiro[i, j] = turno; // MARCA X OU O
                        valido = true;
                    }
                }
            }

            // JOGADA NOT VÁLIDA
            if (!valido) {
                Console.WriteLine("JOGADA INVÁLIDA!");
                continue;
            }

            jogadas++;

            // ALGUÉM GANHOU ?
            if (Venceu(tabuleiro, turno)) {
                Mostrar(tabuleiro);
                Console.WriteLine("JOGADOR " + turno + " GANHOU!");
                fim = true;
            } else if (jogadas == 9) {
                Mostrar(tabuleiro);
                Console.WriteLine("DEU VELHA!");
            } else {
                // TROCA O JOGADOR
                turno = (turno == "X") ? "O" : "X";
            }
        }
    }

    // MOSTRA O TABULEIRO BONITINHO
    static void Mostrar(string[,] t) {
        Console.Clear();
        for (int i = 0; i < 3; i++) {
            Console.WriteLine($" {t[i,0]} | {t[i,1]} | {t[i,2]} ");
            if (i < 2) Console.WriteLine("---+---+---");
        }
        Console.WriteLine();
    }

    // VERIFICA TODAS AS POSSIBILIDADES DE VITÓRIA
    static bool Venceu(string[,] t, string p) {
        // LINHAS (i)
        for (int i = 0; i < 3; i++)
            if (t[i,0] == p && t[i,1] == p && t[i,2] == p) return true;

        // COLUNAS (j)
        for (int j = 0; j < 3; j++)
            if (t[0,j] == p && t[1,j] == p && t[2,j] == p) return true;

        // DIAGONAL E TRANSVERSAL
        if (t[0,0] == p && t[1,1] == p && t[2,2] == p) return true;
        if (t[0,2] == p && t[1,1] == p && t[2,0] == p) return true;

        return false;
    }
}
