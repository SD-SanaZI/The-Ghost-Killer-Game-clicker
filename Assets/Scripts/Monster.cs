using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private float timeToMove;
    protected float timeBetweenMove;
    protected int hp;
    public GameObject soundTouch, soundDeath;

    // Start is called before the first frame update
    void Start()
    {

    }

    protected virtual void Move()
    {

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
/*	if(GetComponent<Light>().intensity > 0)
	{
	    GetComponent<Light>().intensity -= 0.1f;
	}*/
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
		Debug.Log("-");
		Instantiate(soundDeath, GetComponent<Transform>().localPosition, Quaternion.identity);
		GameObject.Find("Logic").GetComponent<SpawnScript>().DecreaseMonsterNumber(1);
		Destroy(gameObject);
	    }
	}
    }
}
