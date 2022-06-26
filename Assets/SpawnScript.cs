using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour
{
    public GameObject monster;
    private Vector3 spawnPlase;
    private float timeBetweenSpawn;
    private float timeToSpawn;
    public int numberOfMonsters;
    public Text scoreText;
    private int score;
    private bool arePouse;

    public void DecreaseMonsterNumber(int addScore)
    {
	score += addScore;
        scoreText.text = score.ToString();
	numberOfMonsters -= 1;
    }

    public bool GetArePouse()
    {
	return arePouse;
    }

    public void ChangePause()
    {
	Time.timeScale = (Time.timeScale + 1) % 2;
	arePouse = !arePouse;
    }

    public void FreezeSpawn()
    {
	if(!arePouse)
		timeToSpawn += 3;
    }

    public void TotalKill()
    {
	if(!arePouse)
	{
	    GameObject[] allMonsters;
	    allMonsters = GameObject.FindGameObjectsWithTag("Monster");
	    foreach (GameObject monster in allMonsters)
	    {
	        Destroy(monster);
		DecreaseMonsterNumber(1);
            }
	}
    }

    void Spawn()
    {
	spawnPlase = new Vector3(Random.Range(-2.8f,2.8f),0.1f,Random.Range(-2.8f,2.8f));
        Instantiate(monster, spawnPlase, Quaternion.identity);
	numberOfMonsters += 1;
	if(numberOfMonsters == 10)
	{
	    PlayerPrefs.SetInt("Score", score);
	    SceneManager.LoadScene("Scenes/Recording");
	}
    }

    void Start()
    {
        timeBetweenSpawn = 4;
	scoreText.text = score.ToString();
    }

    void Update()
    {
        if(timeToSpawn <= 0)
	{
	    Spawn();
	    timeToSpawn = timeBetweenSpawn  / (score + 2);
	}
	else
	{
	    timeToSpawn -= Time.deltaTime;
	}
    }
}
