using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_atk : MonoBehaviour {
    public float dmg = 10;
    public float aliveTime = 0.17f;

    private Collision2D col2other;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (aliveTime <= 0)
        {
            Destroy(gameObject);
        }
        aliveTime += -Time.deltaTime;
	}
    void OnCollisionEnter2D(Collision2D col) {
        //SendMessage("hit_FromPlyr", dmg);
        col.otherCollider.SendMessage("hit_FromPlyr", dmg, SendMessageOptions.DontRequireReceiver);
       // SendMessage("hit_FromPlyr", dmg, SendMessageOptions.DontRequireReceiver);
    }
    void OnTriggerEnter2D(Collider2D col) {
        col.SendMessage("hit_FromPlyr", dmg, SendMessageOptions.DontRequireReceiver);
        //SendMessage("hit_FromPlyr", dmg, SendMessageOptions.DontRequireReceiver);
    }
}
