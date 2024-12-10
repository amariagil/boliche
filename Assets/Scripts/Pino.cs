using UnityEngine;

public class Pino : MonoBehaviour
{
    public bool foiDerrubado = false;

    void Update()
    {
        // Verifica se o pino está inclinado e ainda não foi contabilizado
        if (!foiDerrubado && transform.up.y < 0.5f)
        {
            foiDerrubado = true;
        }
    }
}
