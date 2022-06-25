using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterActions : MonoBehaviour
{
    public GameObject logic;
    private Rigidbody _rb;
    private float timeToForce, timeToRotate, timeBetweenForce, timeBetweenRotate;

    // Start is called before the first frame update
    void Start()
    {
	logic = GameObject.Find("Logic");
	_rb = GetComponent<Rigidbody>();
//	_rb.AddForce(new Vector3(0,0,50));
	Physics.IgnoreLayerCollision(6, 6);
	_rb.MoveRotation(Quaternion.Euler(new Vector3(0, 100, 0)));
	timeBetweenForce = 2;
	timeBetweenRotate = 2;
	_rb.AddForce(new Vector3((float)(Math.Sin(transform.rotation.y)*50),0,(float)(Math.Cos(transform.rotation.y)*50)));
    }

    // Update is called once per frame
    void Update()
    {
/*        if(timeToRotate <= 0)
	{
	    timeToRotate = timeBetweenRotate;
	    _rb.MoveRotation(Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(-180,180), 0)));
	    Debug.Log("rotate");
	}
	else
	{
	    timeToRotate -= Time.deltaTime;
	}
        if(timeToForce <= 0)
	{
	    timeToForce = timeBetweenForce;
	    _rb.AddForce(new Vector3((float)(Math.Sin(transform.rotation.y)*50),0,(float)(Math.Cos(transform.rotation.y)*50)));
	}
	else
	{
	    timeToForce -= Time.deltaTime;
	}*/
    }

    private void OnMouseDown()
    {
	logic.GetComponent<SpawnScript>().DecreaseMonsterNumber(1);
	Destroy(gameObject);
    }
}
