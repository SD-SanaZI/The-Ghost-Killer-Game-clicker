using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActions : MonoBehaviour
{
    private float _timeToMove, _timeBetweenMove;
    private float _forseScale;
    private int _hp;
    public GameObject soundTouch, soundDeath;

    void Start()
    {
	Physics.IgnoreLayerCollision(6, 6);// На слое 6 находяться монстры. Монстры не сталкиваются
	_timeBetweenMove = 2;
	_forseScale = 1000;
	_hp = GameObject.Find("Logic").GetComponent<SpawnScript>().GetScore() / 5;
	GetComponent<Transform>().localScale = new Vector3(1f + 0.2f * _hp, 1f + 0.02f * _hp, 1f + 0.02f * _hp);
    }

    void Move()
    {
	GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(-180,180), 0)));
	GetComponent<Rigidbody>().AddForce(new Vector3(
				(float)(Math.Sin(GetComponent<Rigidbody>().rotation.eulerAngles.y/180*Math.PI))*_forseScale,
				0,
				(float)(Math.Cos(GetComponent<Rigidbody>().rotation.eulerAngles.y/180*Math.PI))*_forseScale));
    }

    void Update()
    {
        if(_timeToMove <= 0)
	{
	    _timeToMove = 1 + _timeBetweenMove / (GameObject.Find("Logic").GetComponent<SpawnScript>().GetScore() + 2);
	    Move();
	}
	else
	{
	    _timeToMove -= Time.deltaTime;
	}
    }

    private void TakeHit()
    {
	_hp -= GameObject.Find("Logic").GetComponent<SpawnScript>().GetDamage();
	GetComponent<Transform>().localScale = new Vector3(1f + 0.2f * _hp, 1f + 0.02f * _hp, 1f + 0.02f * _hp);
    }

    private void OnMouseDown()
    {
	if(!GameObject.Find("Logic").GetComponent<SpawnScript>().GetArePouse())
	{
	    TakeHit();
	    Instantiate(soundTouch, GetComponent<Transform>().localPosition, Quaternion.identity);
	    if(_hp < 1)
	    {
		Instantiate(soundDeath, GetComponent<Transform>().localPosition, Quaternion.identity);
		GameObject.Find("Logic").GetComponent<SpawnScript>().DecreaseMonsterNumber(1);
		Destroy(gameObject);
	    }
	}
    }
}
