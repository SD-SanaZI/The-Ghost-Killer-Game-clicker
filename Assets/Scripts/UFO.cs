using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : Monster
{
    public GameObject spawnLight;

    void Start()
    {
        timeBetweenMove = 7;
	hp = GameObject.Find("Logic").GetComponent<SpawnScript>().GetScore() / 10;
	GetComponent<Transform>().localScale = new Vector3(1f + 0.2f * hp, 1f + 0.02f * hp, 1f + 0.02f * hp);
	Instantiate(spawnLight, GetComponent<Transform>().position, Quaternion.identity);        
    }

    protected override void Move()
    {
	GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(-180,180), 0)));
	GetComponent<Transform>().position = new Vector3(Random.Range(-49f,49f),0.1f,Random.Range(-49f,49f));
    }
}
