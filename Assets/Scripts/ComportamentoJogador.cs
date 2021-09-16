using UnityEngine;

public class ComportamentoJogador : MonoBehaviour
{
    public Rigidbody2D meuRigidbody;
    public float aceleracao = 1.0f;
    public float velocidadeAngular = 180.0f;
    public float velocidadeMaxima = 10.0f;

    public Rigidbody2D prefabProjetil;
    public float velocidadeProjetil = 10.0f;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D projetil = Instantiate(
                prefabProjetil,
                meuRigidbody.position,
                Quaternion.identity
            );

            projetil.velocity = transform.up * velocidadeProjetil;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Vector3 direcao = transform.up * aceleracao;
            meuRigidbody.AddForce(direcao, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            meuRigidbody.rotation += velocidadeAngular * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            meuRigidbody.rotation -= velocidadeAngular * Time.deltaTime;
        }

        if (meuRigidbody.velocity.magnitude > velocidadeMaxima)
        {
            meuRigidbody.velocity = Vector2.ClampMagnitude(
                meuRigidbody.velocity,
                velocidadeMaxima
            );
        }
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        Destroy(gameObject);
    }
}
