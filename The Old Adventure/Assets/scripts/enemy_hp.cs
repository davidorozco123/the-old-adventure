using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hp : MonoBehaviour {
    public float f_HP = 100;
    public float f_Knockback = 5;

    private SpriteRenderer enemy_sprite;
    private BoxCollider2D enemy_2DboxCol;
    //private Rigidbody2D rb;
    //private Transform trans;
    // Use this for initialization
    void Start () {
        enemy_sprite = GetComponent<SpriteRenderer>();
        enemy_2DboxCol = GetComponent<BoxCollider2D>();
        //rb = GetComponent<Rigidbody2D>();
        //trans = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (f_HP <= 0)
        {
            Destroy(gameObject);
        }
	}
    void hit_FromPlyr(float dmg) {
        f_HP -= dmg;
        if (GetComponent<SpriteRenderer>().flipX == false)
            transform.position += Vector3.right * f_Knockback;
        else if (GetComponent<SpriteRenderer>().flipX == true)
            transform.position += Vector3.left * f_Knockback;
       // Debug.Log("pow");
    }
}
