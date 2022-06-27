using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActions : MonoBehaviour
{
    private float timeToMove, timeBetweenMove;
    private float forseScale;
    private int hp;
    public GameObject soundTouch, soundDeath;

    // Start is called before the first frame update
    void Start()
    {
	Physics.IgnoreLayerCollision(6, 6);// На слое 6 находяться монстры. Монстры не сталкиваются
	timeBetweenMove = 2;
	forseScale = 100;
	hp = GameObject.Find("Logic").GetComponent<SpawnScript>().GetScore() / 5;
	GetComponent<Transform>().localScale = new Vector3(0.15f + 0.05f * hp, 0.15f + 0.05f * hp, 0.15f + 0.05f * hp);
    }

    void Move()
    {
	GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(-180,180), 0)));
	GetComponent<Rigidbody>().AddForce(new Vector3(
				(float)(Math.Sin(GetComponent<Rigidbody>().rotation.eulerAngles.y/180*Math.PI))*forseScale,
				0,
				(float)(Math.Cos(GetComponent<Rigidbody>().rotation.eulerAngles.y/180*Math.PI))*forseScale));
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToMove <= 0)
	{
	    timeToMove = 1 + timeBetweenMove / (GameObject.Find("Logic").GetComponent<SpawnScript>().GetScore() + 2);
	    Move();
	}
	else
	{
	    timeToMove -= Time.deltaTime;
	}
	if(GetComponent<Light>().intensity > 0)
	{
	    GetComponent<Light>().intensity -= 0.1f;
	}
    }

    private void TakeHit()
    {
	hp -= GameObject.Find("Logic").GetComponent<SpawnScript>().GetDamage();
	GetComponent<Transform>().localScale = new Vector3(0.15f + 0.05f * hp, 0.15f + 0.05f * hp, 0.15f + 0.05f * hp);
    }

    private void OnMouseDown()
    {
	if(!GameObject.Find("Logic").GetComponent<SpawnScript>().GetArePouse())
	{
	    TakeHit();
	    Instantiate(soundTouch, GetComponent<Transform>().localPosition, Quaternion.identity);
	    if(hp < 1)
	    {
		Instantiate(soundDeath, GetComponent<Transform>().localPosition, Quaternion.identity);
		GameObject.Find("Logic").GetComponent<SpawnScript>().DecreaseMonsterNumber(1);
		Destroy(gameObject);
	    }
	}
    }
}
