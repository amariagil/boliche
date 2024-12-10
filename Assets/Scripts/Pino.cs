using UnityEngine;

public class Pino : MonoBehaviour
{
    public bool foiDerrubado = false;

    void Update()
    {
        // Verifica se o pino est� inclinado e ainda n�o foi contabilizado
        if (!foiDerrubado && transform.up.y < 0.5f)
        {
            foiDerrubado = true;
        }
    }
}
