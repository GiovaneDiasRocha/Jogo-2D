using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenPlatform : MonoBehaviour
{
    
    public float FallingTime;

    private TargetJoint2D target;
    private BoxCollider2D boxColl;

    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    
    void OnCollisionEnter2D(Collision2D colisor) {
        if(colisor.gameObject.tag == "Player") {
            Invoke("Falling", FallingTime); //Ativar o método Falling depois de um determinado tempo pela variável FallingTime
        }
    }

    void OnTriggerEnter2D(Collider2D colisor) { 
        if(colisor.gameObject.layer == 9) {
            Destroy(gameObject);
        }
    }

    void Falling() {
        target.enabled = false;
        boxColl.isTrigger = true;
    }
}
