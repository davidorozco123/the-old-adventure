using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_steerings : MonoBehaviour {

    private Rigidbody2D rb;
    private Transform trans;
    private Vector3 v3_Pos;
    //private Vector2 v2_vel;
    private Vector3 dist;
    private Vector3 v3_dir;

    public GameObject target;
    public float f_speed;
    private Vector3 v3_target;

    private Rigidbody2D t_rb;
    private Transform t_trans;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();

        t_rb = target.GetComponent<Rigidbody2D>();
        t_trans = target.GetComponent<Transform>();

        v3_Pos = trans.position;
        v3_target = t_trans.position;



    }
	
	// Update is called once per frame
	void Update () {
        trans = GetComponent<Transform>();
        t_trans = target.GetComponent<Transform>();
        v3_Pos = trans.position;
        v3_target = t_trans.position;
        v3_dir = v3_target - v3_Pos;
        v3_dir.Normalize();
        v3_dir.z = 0;
        transform.position += v3_dir * f_speed * Time.deltaTime;
        if (v3_dir.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(v3_dir.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

    }

}
