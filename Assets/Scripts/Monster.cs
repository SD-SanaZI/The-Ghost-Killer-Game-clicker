using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private float _timeToMove;
    protected float timeBetweenMove;
    protected int hp;
    public GameObject soundTouch, soundDeath;

    void Update()
    {
        if(_timeToMove <= 0)
	{
	    _timeToMove = 1 + timeBetweenMove / (GameObject.Find("Logic").GetComponent<SpawnScript>().GetScore() + 2);
	    Move();
	}
	else
	{
	    _timeToMove -= Time.deltaTime;
	}
    }

    private void TakeHit()
    {
	hp -= GameObject.Find("Logic").GetComponent<SpawnScript>().GetDamage();
	GetComponent<Transform>().localScale = new Vector3(1f + 0.2f * hp, 1f + 0.02f * hp, 1f + 0.02f * hp);
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

    protected virtual void Move(){}
}
