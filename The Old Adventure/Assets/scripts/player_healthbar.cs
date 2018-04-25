using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_healthbar : MonoBehaviour
{

    public int maxHealth = 100;
    public float curHealth = 100;

    public Texture2D bgImage;
    public Texture2D fgImage;

    public float f_Knockback = 1.0f;
    public float MAX_healthBarLength;
    public float healthBarLength;
    public float healthBarheight;
    public float f_hp_tick;

    // Use this for initialization
    void Start()
    {
        healthBarLength = MAX_healthBarLength;
    }

    // Update is called once per frame
    void Update()
    {
        AddjustCurrentHealth(0);
    }

    void OnGUI()
    {
        // Create one Group to contain both images
        // Adjust the first 2 coordinates to place it somewhere else on-screen
        GUI.BeginGroup(new Rect(0, 0, MAX_healthBarLength, healthBarheight));

        // Draw the background image
        GUI.Box(new Rect(0, 0, MAX_healthBarLength, healthBarheight), bgImage);

        // Create a second Group which will be clipped
        // We want to clip the image and not scale it, which is why we need the second Group
        GUI.BeginGroup(new Rect(0, 0, curHealth / maxHealth * healthBarLength, healthBarheight));

        // Draw the foreground image
        GUI.Box(new Rect(0, 0, MAX_healthBarLength, healthBarheight), fgImage);

        // End both Groups
        GUI.EndGroup();

        GUI.EndGroup();
    }

    public void AddjustCurrentHealth(int adj)
    {

        curHealth += adj;

        if (curHealth < 0)
        {
            curHealth = 0;
            //Destroy(gameObject);
        }
            

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        if (maxHealth < 1)
            maxHealth = 1;

        healthBarLength = MAX_healthBarLength * (curHealth / (float)maxHealth);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "enemy")
        {
            curHealth += -f_hp_tick;
        }
        Debug.Log(col.collider.tag);
    }
    void hit_FromEnemy(float dmg)  {
        curHealth += -dmg;
        if (GetComponent<SpriteRenderer>().flipX == false)
            transform.position += Vector3.right * f_Knockback;
        else if (GetComponent<SpriteRenderer>().flipX == true)
            transform.position += Vector3.left * f_Knockback;
        // Debug.Log("pow");
    }
}