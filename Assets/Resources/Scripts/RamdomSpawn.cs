using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomSpawn : MonoBehaviour
{
    public float SpawnTime = 5;
    public GameObject Prefab;

    float LastSpawTime;
    Camera MainCamera;
    Vector2 RandomPostion;

	void Start ()
    {
        MainCamera = FindObjectOfType<Camera>();
        LastSpawTime = -SpawnTime;
	}
	
	void Update ()
    {
		if(Time.time - LastSpawTime + (Time.time / 30f) > SpawnTime)
        {
            Spawn();
            LastSpawTime = Time.time;
        }
	}

    void Spawn()
    {
        Vector2 RandomScreenPostion = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
        RandomPostion = MainCamera.ScreenToWorldPoint(RandomScreenPostion);
        Instantiate(Prefab, RandomPostion, Prefab.transform.rotation);
    }
}
