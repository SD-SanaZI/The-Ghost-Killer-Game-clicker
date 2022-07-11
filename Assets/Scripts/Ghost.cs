using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Monster
{
    public GameObject spawnLight;
    private float _forseScale;

    void Start()
    {
        timeBetweenMove = 2;
	_forseScale = 1000;
	hp = GameObject.Find("Logic").GetComponent<SpawnScript>().GetScore() / 5;
	GetComponent<Transform>().localScale = new Vector3(1f + 0.2f * hp, 1f + 0.02f * hp, 1f + 0.02f * hp);
	Instantiate(spawnLight, GetComponent<Transform>().position, Quaternion.identity);
    }

    protected override void Move()
    {
	GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(-180,180), 0)));
	GetComponent<Rigidbody>().AddForce(new Vector3(
				(float)(Math.Sin(GetComponent<Rigidbody>().rotation.eulerAngles.y/180*Math.PI))*_forseScale,
				0,
				(float)(Math.Cos(GetComponent<Rigidbody>().rotation.eulerAngles.y/180*Math.PI))*_forseScale));
    }
}
