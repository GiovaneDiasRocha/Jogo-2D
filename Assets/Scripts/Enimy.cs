using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enimy : MonoBehaviour
{

    private Rigidbody2D rig;
    private Animator anim;
    public float speed;
    public Transform rigthCol;
    public Transform leftCol;
    public Transform headPoint;
    private bool colliding;
    private bool PlayerDstroyed = false;
    public LayerMask layer;
    public BoxCollider2D boxCollider2;
    public CircleCollider2D circleCollider2D;

    void Start()
    {
     rig = GetComponent<Rigidbody2D>();
     anim = GetComponent<Animator>();
    }


    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y); //movimentar o inimigo/ speed representa o eixo X / rig.velocity.y não permite o inimigo movomentar no eixo y
        colliding = Physics2D.Linecast(rigthCol.position, leftCol.position, layer); //colisor invisivel para definir a area de movimentaçao do inimigo /layer é para limitar a colisão a uma layer
    
        if(colliding) {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y); //rotacionar o inimigo
            speed *= -1f; //muda a direção invertendo o valor do eixo  X
        }

    }

    void OnCollisionEnter2D(Collision2D colisor) {
        if(colisor.gameObject.tag == "Player") {
            float height = colisor.contacts[0].point.y - headPoint.position.y;

        if(height > 0 && !PlayerDstroyed) {
            colisor.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            speed = 0f;
            anim.SetTrigger("Die");
            boxCollider2.enabled = false;
            circleCollider2D.enabled = false;
            rig.bodyType = RigidbodyType2D.Kinematic;
            Destroy(gameObject, 0.5f);
        } else {
         PlayerDstroyed = true;
         Controller.instance.ShowGameOver();
         Destroy(colisor.gameObject);
        }

        }
    }
}
