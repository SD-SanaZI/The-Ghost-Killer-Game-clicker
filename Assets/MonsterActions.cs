using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterActions : MonoBehaviour
{
    private GameObject logic;
    private Rigidbody _rb;
    private float timeToMove, timeBetweenMove;
    private float forseScale;

    // Start is called before the first frame update
    void Start()
    {
	logic = GameObject.Find("Logic");
	_rb = GetComponent<Rigidbody>();
	Physics.IgnoreLayerCollision(6, 6);
	timeBetweenMove = 2;
	forseScale = 100;
    }

    void Move()
    {
	_rb.MoveRotation(Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(-180,180), 0)));
	_rb.AddForce(new Vector3((float)(Math.Sin(_rb.rotation.eulerAngles.y/180*Math.PI))*forseScale,0,(float)(Math.Cos(_rb.rotation.eulerAngles.y/180*Math.PI))*forseScale));

    }

    // Update is called once per frame
    void Update()
    {
        if(timeToMove <= 0)
	{
	    timeToMove = timeBetweenMove;
	    Move();
	}
	else
	{
	    timeToMove -= Time.deltaTime;
	}
    }

    private void OnMouseDown()
    {
	if(!logic.GetComponent<SpawnScript>().GetArePouse())
	{
	    logic.GetComponent<SpawnScript>().DecreaseMonsterNumber(1);
	    Destroy(gameObject);
	}
    }
}
