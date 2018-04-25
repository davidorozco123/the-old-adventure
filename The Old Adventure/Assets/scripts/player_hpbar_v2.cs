using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_hpbar_v2 : MonoBehaviour {

    public int maxHealth = 100;
    public float curHealth = 100;

    public float f_Knockback = 1.0f;
    public Image bgImage;
    public Image fgImage;

    // Use this for initialization
    void Start () {
        curHealth = maxHealth;
	}
	public void lifeMod(float value) {
        curHealth += value;
        if (curHealth > maxHealth)
            curHealth = maxHealth;
        else if (curHealth < 0)
            curHealth = 0;
        GUI_Update();

    }
    void GUI_Update() {
        fgImage.fillAmount = (0 / maxHealth * curHealth);
    }
    // Update is called once per frame
    void Update () {
		
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
