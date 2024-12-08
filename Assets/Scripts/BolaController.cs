using UnityEngine;

public class BolaControle : MonoBehaviour
{
    public Camera cameraPrincipal;
    public float alturaBola = 1f;
    public float for�aMaxima = 10f;    // For�a m�xima de lan�amento
    public float tempoCarregamento = 2f;  // Tempo m�ximo para carregar a for�a

    private Vector3 direcao;
    private Rigidbody rb;
    private bool carregandoFor�a = false;
    private float tempoSegurando = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (cameraPrincipal == null)
            cameraPrincipal = Camera.main;
    }

    void Update()
    {
        // Realiza o Raycast para capturar a dire��o do mouse
        Ray ray = cameraPrincipal.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 direcaoMouse = hit.point - transform.position;
            direcaoMouse.y = 0;
            direcao = direcaoMouse.normalized;
        }

        // Carregar a for�a
        if (Input.GetMouseButtonDown(0))  // Ao pressionar o bot�o esquerdo do mouse
        {
            carregandoFor�a = true;
            tempoSegurando = 0f;  // Inicia o carregamento da for�a
        }

        if (Input.GetMouseButton(0) && carregandoFor�a)  // Enquanto o bot�o estiver pressionado
        {
            tempoSegurando += Time.deltaTime;  // Aumenta o tempo de press�o
        }

        if (Input.GetMouseButtonUp(0))  // Quando o bot�o for solto
        {
            // Calcula a for�a com base no tempo segurado
            float for�a = Mathf.Lerp(0, for�aMaxima, tempoSegurando / tempoCarregamento);
            Lan�arBola(for�a);  // Lan�a a bola com a for�a calculada
            carregandoFor�a = false;  // Finaliza o carregamento
        }
    }

    // Fun��o para lan�ar a bola com a for�a
    public void Lan�arBola(float for�a)
    {
        rb.AddForce(direcao * for�a, ForceMode.Impulse);
    }
}
