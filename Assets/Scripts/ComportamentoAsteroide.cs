using UnityEngine;

public class ComportamentoAsteroide : MonoBehaviour
{
    public Rigidbody2D meuRigidbody;
    [SerializeField] private GameObject smallAsteroidPrefab;
    public float velocidadeMaxima = 1.0f;

    void Start()
    {
        Vector2 direcao = Random.insideUnitCircle;
        direcao *= velocidadeMaxima;
        meuRigidbody.velocity = direcao;
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        Destroy(gameObject);
        Destroy(outro.gameObject);
        
        if (smallAsteroidPrefab != null && this.gameObject.CompareTag("BigAsteroid"))
        {
            float x = Random.Range(-7.0f, 7.0f);
            float y = Random.Range(-4.0f, 4.0f);
            Vector3 posicao = new Vector3(x, y, 0.0f);
            Instantiate(smallAsteroidPrefab, posicao, Quaternion.identity);
        }

    }
}
