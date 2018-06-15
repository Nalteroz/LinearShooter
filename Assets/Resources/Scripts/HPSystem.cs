using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSystem : MonoBehaviour
{
    public float TotalHP = 100;
    public string BulletTag = "EnemyBullet";
    public float BulletDamage = 5;
    public bool Died = false;
    public Slider HPBar;
    public Text YouDiedText;
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == BulletTag)
        {
            TotalHP -= BulletDamage;
            Destroy(collision.gameObject);
            HPBar.value = TotalHP;
            if (TotalHP < 0)
            {
                YouDiedText.gameObject.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }
}
