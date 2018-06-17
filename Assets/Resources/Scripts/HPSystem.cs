using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSystem : MonoBehaviour
{
    public float TotalHP = 100;
    public string[] CollisionTags;
    public float[] CollisionDamage;
    public bool Died = false, AllCollision = false;
    public Slider HPBar;
    public Text YouDiedText, DeathCounterText;

    DestructionAnimation dAnimation;
    PlayerControl PlayerMovment;
    PeriodicEnemyShoot Enemy;
	// Use this for initialization
	void Start ()
    {
        dAnimation = GetComponent<DestructionAnimation>();
        PlayerMovment = GetComponent<PlayerControl>();
        Enemy = GetComponent<PeriodicEnemyShoot>();
        DeathCounterText = GameObject.Find("Counter").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        int TagIdx = CheckTag(collision.gameObject.tag);
        if (AllCollision || TagIdx >= 0)
        {
            if(AllCollision) TotalHP -= CollisionDamage[0];
            else TotalHP -= CollisionDamage[TagIdx];
            if(HPBar) HPBar.value = TotalHP;
            if (TotalHP < 0)
            {
                if(YouDiedText) YouDiedText.gameObject.SetActive(true);
                if (PlayerMovment) PlayerMovment.CanMove = false;
                if (Enemy) Enemy.CanMove = false;
                if(DeathCounterText && gameObject.tag == "EnemyShip")
                {
                    DeathCounterText.text = (float.Parse(DeathCounterText.text) + 1).ToString();
                    
                }
                if (dAnimation) dAnimation.Activate = true;
                else Destroy(gameObject);
            }
        }
    }

    int CheckTag(string collidertag)
    {
        for (int i = 0; i < CollisionTags.Length; i++)
        {
            if (collidertag == CollisionTags[i]) return i;
        }
        return -1;
    }
}
