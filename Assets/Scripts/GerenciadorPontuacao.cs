using TMPro;
using UnityEngine;

public class GerenciadorPontuacao : MonoBehaviour
{
    public TextMeshProUGUI textoPontuacao;
    public int pontuacaoTotal;
    public GameObject[] pinos;

    private Vector3[] posicoesIniciais;
    private Quaternion[] rotacoesIniciais;

    private void Start()
    {
        pontuacaoTotal = 0;

        posicoesIniciais = new Vector3[pinos.Length];
        rotacoesIniciais = new Quaternion[pinos.Length];

        for (int i = 0; i < pinos.Length; i++)
        {
            posicoesIniciais[i] = pinos[i].transform.position;
            rotacoesIniciais[i] = pinos[i].transform.rotation;
        }
    }

    public void ContarPinosDerrubados()
    {
        int pinosDerrubados = 0;

        foreach (GameObject pino in pinos)
        {
            Pino scriptPino = pino.GetComponent<Pino>();
            if (scriptPino.foiDerrubado)
            {
                pinosDerrubados++; 
            }
        }

        AtualizarPontuacao(pinosDerrubados);
    }

    public void AtualizarPontuacao(int pinosDerrubados)
    {
        
        pontuacaoTotal += pinosDerrubados;
       

        textoPontuacao.text = "Pontuação: " + pontuacaoTotal;
    }


}
