using UnityEngine;

public class ControleJogada : MonoBehaviour
{
    public GerenciadorPontuacao gerenciadorPontuacao;
    public Rigidbody bola;

    private bool jogadaFinalizada = false; // Controla se a jogada já terminou

    void Update()
    {
        // Verifica se a bola parou de se mover
        if (!jogadaFinalizada && bola.velocity.magnitude < 0.1f)
        {
            jogadaFinalizada = true; // Marca a jogada como finalizada
            gerenciadorPontuacao.ContarPinosDerrubados();
        }
    }

    public void NovaJogada()
    {
        jogadaFinalizada = false; // Reseta o estado para a próxima jogada
    }
}
