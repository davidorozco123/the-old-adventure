using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_ctrl : MonoBehaviour {
    private Rigidbody2D rb;
    private Transform trans;
    private Vector2 v2_Pos;
    private Vector2 v2_vel;
    private Vector2 v2_dir;
    private bool b_facing;//0 for right ; 1 for left;
    private bool b_sprinting;
    private bool b_moving;
    //private bool input_v;

    public float f_speed;
    public float f_sprintSpeed;
    public short i_xfacing;

    public GameObject HurtBox_atk_prefab;
    public Vector3 HurtBox_offset;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        v2_Pos = trans.position;
    }
	
	// Update is called once per frame
	void Update () {
        //////////////////////////// - Facing info [-1, 1] - ///////////////////////////////
        if (!b_facing)
            i_xfacing = 1;
        else
            i_xfacing = -1;

        //////////////////////////////////////////////////////////////////////////////
        //////////////////////////// - Input Manager - ///////////////////////////////
        //////////////////////////////////////////////////////////////////////////////

        //////////////////////////// - Movement manager - ///////////////////////////////

        if (Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0.1) {
            //////////////////////////// - Move up - ///////////////////////////////
            if (Input.GetKey(KeyCode.LeftShift)) {
                transform.position += Vector3.up * f_sprintSpeed * Time.deltaTime;
                b_sprinting = true;
            }
            else {
                transform.position += Vector3.up * f_speed * Time.deltaTime;
                b_sprinting = false;
            }
            ////////////////////////////////////////////////////////////////////////
        }
        if (Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < -0.1) {
            //////////////////////////// - Move down - ///////////////////////////////
            if (Input.GetKey(KeyCode.LeftShift)) {
                transform.position += Vector3.down * f_sprintSpeed * Time.deltaTime;
                b_sprinting = true;
            }
            else {
                transform.position += Vector3.down * f_speed * Time.deltaTime;
                b_sprinting = false;
            }
            //////////////////////////////////////////////////////////////////////////
        }
        if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0.1) {
            //////////////////////////// - Move right - ///////////////////////////////
            if (Input.GetKey(KeyCode.LeftShift)) {
                transform.position += Vector3.right * f_sprintSpeed * Time.deltaTime;
                b_sprinting = true;
            }
            else {
                transform.position += Vector3.right * f_speed * Time.deltaTime;
                b_sprinting = false;
            }
            b_facing = false;
            this.GetComponent<SpriteRenderer>().flipX = false;
            ////////////////////////////////////////////////////////////////////////////
        }
        if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < -0.1) {
            //////////////////////////// - Move left - ///////////////////////////////
            if (Input.GetKey(KeyCode.LeftShift)) {
                transform.position += Vector3.left * f_sprintSpeed * Time.deltaTime;
                b_sprinting = true;
            }
            else {
                transform.position += Vector3.left * f_speed * Time.deltaTime;
                b_sprinting = false;
            }
            b_facing = true;
            this.GetComponent<SpriteRenderer>().flipX = true;
            //////////////////////////////////////////////////////////////////////////
        }
        ////////////////////////// Player atk //////////////////////////
        if (!b_moving) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject clone;
                clone = Instantiate(HurtBox_atk_prefab, transform.position + (HurtBox_offset * i_xfacing), transform.rotation);
            }
        }
        

    }

}
