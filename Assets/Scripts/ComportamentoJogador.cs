using System;
using UnityEngine;

public class ComportamentoJogador : MonoBehaviour
{
    public Rigidbody2D meuRigidbody;
    public float aceleracao = 1.0f;
    public float velocidadeAngular = 180.0f;
    public float velocidadeMaxima = 10.0f;

    public Rigidbody2D prefabProjetil;
    public float velocidadeProjetil = 10.0f;

    private Vector3 _bounds;
    private Vector3 _spriteBounds;

    private void Start()
    {
        _spriteBounds = GetComponent<SpriteRenderer>().sprite.bounds.extents;
        _bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
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
        
        MovePlayerToTheOtherSideOfScreen();
    }

    private void MovePlayerToTheOtherSideOfScreen()
    {
        if (transform.position.x < -_bounds.x - _spriteBounds.x/2)
        {
            this.transform.position = new Vector3(_bounds.x, this.transform.position.y);
        }

        if (transform.position.x > _bounds.x + _spriteBounds.x/2)
        {
            this.transform.position = new Vector3(-_bounds.x, this.transform.position.y);
        }

        if (transform.position.y < -_bounds.y - _spriteBounds.y/2)
        {
            this.transform.position = new Vector3(this.transform.position.x, _bounds.y);
        }

        if (transform.position.y > _bounds.y + _spriteBounds.y/2)
        {
            this.transform.position = new Vector3(this.transform.position.x, -_bounds.y);
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
