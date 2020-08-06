using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float jumpForce;
    public bool isUp;
    public Animator anim;
    private int health = 5;
    public GameObject effect;

    private void Update() {
        if(health<=0) {
                Instantiate(effect, transform.position, transform.rotation);
                Destroy(transform.parent.gameObject);//para destruir objeto pai
        }
    }
    
    void OnCollisionEnter2D(Collision2D colisor) {
        if(isUp) { 
            anim.SetTrigger("hit");
            health--;
            colisor.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        } else {
            anim.SetTrigger("hit");
            health--;
            colisor.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse);
        }
    }
}
