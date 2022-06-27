using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour
{
    public GameObject monster;
    private float timeBetweenSpawn, timeToSpawn;
    private int numberOfMonsters;
    private int score, damage;
    private bool arePouse;

    void Start()
    {
        timeBetweenSpawn = 4;
	damage = 1;
	GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
    }

    void Update()
    {
        if(timeToSpawn <= 0)
	{
	    Spawn();
	    timeToSpawn = 1 + timeBetweenSpawn  / (score + 2);
	}
	else
	{
	    timeToSpawn -= Time.deltaTime;
	}
    }

    public int GetDamage()
    {
	return damage;
    }    

    public void SetDamage(int newDamage)
    {
	damage = newDamage;
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

    public void DecreaseMonsterNumber(int addScore)
    {
	score += addScore;
	GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
	numberOfMonsters -= 1;
	GameObject.Find("MonsterNumber").GetComponent<Text>().text = numberOfMonsters.ToString();
    }

    public int GetScore()
    {
	return score;
    }

    void Spawn()
    {
	Vector3 spawnPlase = new Vector3(Random.Range(-9.8f,9.8f),0.1f,Random.Range(-9.8f,9.8f));
        Instantiate(monster, spawnPlase, Quaternion.identity);
	numberOfMonsters += 1;
	GameObject.Find("MonsterNumber").GetComponent<Text>().text = numberOfMonsters.ToString();
	if(numberOfMonsters == 10)
	{
	    PlayerPrefs.SetInt("Score", score);
	    SceneManager.LoadScene("Scenes/Recording");
	}
    }

    public void AddTimeToSpawn(float time)
    {
	timeToSpawn += time;
    }

/*    public void TotalKill()
    {
	if(!arePouse)
	{
	    GameObject[] allMonsters;
	    allMonsters = GameObject.FindGameObjectsWithTag("Monster");
	    foreach (GameObject monsters in allMonsters)
	    {
	        Destroy(monsters);
		DecreaseMonsterNumber(1);
            }
	}
    }*/
}
