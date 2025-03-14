using System;
using System.Collections.Generic;

namespace JogoDaForcaGUI
{
    class JogoDaForca
    {
        public string palavraPerdida { get; private set; }
        public HashSet<char> letrasAcertadas { get; private set; }
        public HashSet<char> letrasErradas { get; private set; }
        public int tentativas { get; private set; }

        public JogoDaForca(string palavra)
        {
            palavraPerdida = palavra.ToUpper();
            letrasAcertadas = new HashSet<char>();
            letrasErradas = new HashSet<char>();
            tentativas = 6;
        }

        public bool jogoFinalizado()
        {
            if (tentativas <= 0)
                return true;

            foreach (char letra in palavraPerdida)
            {
                if (!letrasAcertadas.Contains(letra))
                    return false;
            }

            return true;
        }

        public void fazerJogada(char tentativa)
        {
            tentativa = char.ToUpper(tentativa); // Converte a tentativa para maiúscula

            // Verifica se a letra já foi tentada
            if (letrasAcertadas.Contains(tentativa) || letrasErradas.Contains(tentativa))
                return;

            // Se a letra estiver na palavra secreta
            if (palavraPerdida.Contains(tentativa))
            {
                letrasAcertadas.Add(tentativa); // Adiciona a letra ao conjunto de corretas
            }
            else
            {
                // Se a letra estiver errada
                letrasErradas.Add(tentativa); // Adiciona a letra ao conjunto de erradas
                tentativas--; // Decrementa as tentativas restantes
            }
        } 
    }
}
