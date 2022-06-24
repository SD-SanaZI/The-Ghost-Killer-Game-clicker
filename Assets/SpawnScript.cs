using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour
{
    public GameObject monster;
    private Vector3 spawnPlase;
    private float timeBetweenSpawn;
    private float timeToSpawn;
    public int numberOfMonsters;
    // Start is called before the first frame update

    void Spawn()
    {
	spawnPlase = new Vector3(Random.Range(-2.8f,2.8f),0.1f,Random.Range(-2.8f,2.8f));
        Instantiate(monster, spawnPlase, Quaternion.identity);
	numberOfMonsters += 1;
	if(numberOfMonsters == 10)
	{
	    SceneManager.LoadScene("Scenes/Recording");
	}
    }

    void Start()
    {
        timeBetweenSpawn = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToSpawn <= 0)
	{
	    Spawn();
	    timeToSpawn = timeBetweenSpawn;
	}
	else
	{
	    timeToSpawn -= Time.deltaTime;
	}
    }
}
