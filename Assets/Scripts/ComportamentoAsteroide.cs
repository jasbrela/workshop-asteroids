using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ComportamentoAsteroide : MonoBehaviour
{
    private const int BigAsteroidScore = 150;
    
    public Rigidbody2D meuRigidbody;
    [SerializeField] private GameObject smallAsteroidPrefab;
    public float velocidadeMaxima = 1.0f;
    
    [SerializeField] private AudioClip asteroidDeath;
    [SerializeField] private AudioClip playerDeath;

    void Start()
    {
        Vector2 direcao = Random.insideUnitCircle;
        direcao *= velocidadeMaxima;
        meuRigidbody.velocity = direcao;
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Projectile"))
        {
            AudioSource.PlayClipAtPoint(asteroidDeath, transform.position);

            if (this.CompareTag("BigAsteroid"))
            {
                Score.AddScore(BigAsteroidScore);
            } else if (this.CompareTag("SmallAsteroid"))
            {
                Score.AddScore(BigAsteroidScore/2);
            }

            Destroy(gameObject);
        }

        if (outro.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(playerDeath, transform.position);           
            Destroy(outro.gameObject);
        }
        
        if (smallAsteroidPrefab != null && this.gameObject.CompareTag("BigAsteroid"))
        {
            float x = Random.Range(-7.0f, 7.0f);
            float y = Random.Range(-4.0f, 4.0f);
            Vector3 posicao = new Vector3(x, y, 0.0f);
            Instantiate(smallAsteroidPrefab, posicao, Quaternion.identity);
        }

    }
}
