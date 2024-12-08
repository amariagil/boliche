using UnityEngine;

public class BolaControle : MonoBehaviour
{
    public Camera cameraPrincipal;
    public float alturaBola = 1f;
    public float forçaMaxima = 10f;    // Força máxima de lançamento
    public float tempoCarregamento = 2f;  // Tempo máximo para carregar a força

    private Vector3 direcao;
    private Rigidbody rb;
    private bool carregandoForça = false;
    private float tempoSegurando = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (cameraPrincipal == null)
            cameraPrincipal = Camera.main;
    }

    void Update()
    {
        // Realiza o Raycast para capturar a direção do mouse
        Ray ray = cameraPrincipal.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 direcaoMouse = hit.point - transform.position;
            direcaoMouse.y = 0;
            direcao = direcaoMouse.normalized;
        }

        // Carregar a força
        if (Input.GetMouseButtonDown(0))  // Ao pressionar o botão esquerdo do mouse
        {
            carregandoForça = true;
            tempoSegurando = 0f;  // Inicia o carregamento da força
        }

        if (Input.GetMouseButton(0) && carregandoForça)  // Enquanto o botão estiver pressionado
        {
            tempoSegurando += Time.deltaTime;  // Aumenta o tempo de pressão
        }

        if (Input.GetMouseButtonUp(0))  // Quando o botão for solto
        {
            // Calcula a força com base no tempo segurado
            float força = Mathf.Lerp(0, forçaMaxima, tempoSegurando / tempoCarregamento);
            LançarBola(força);  // Lança a bola com a força calculada
            carregandoForça = false;  // Finaliza o carregamento
        }
    }

    // Função para lançar a bola com a força
    public void LançarBola(float força)
    {
        rb.AddForce(direcao * força, ForceMode.Impulse);
    }
}
