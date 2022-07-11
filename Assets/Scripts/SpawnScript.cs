using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] monsters;
    private float _timeBetweenSpawn, _timeToSpawn;
    private int _numberOfMonsters;
    private int _score, _damage;
    private bool _arePouse;

    void Start()
    {
        _timeBetweenSpawn = 4;
	_damage = 1;
	GameObject.Find("Score").GetComponent<Text>().text = _score.ToString();
    }

    void Update()
    {
        if(_timeToSpawn <= 0)
	{
	    Spawn();
	    _timeToSpawn = 1 + _timeBetweenSpawn  / (_score + 2);
	}
	else
	{
	    _timeToSpawn -= Time.deltaTime;
	}
    }

    public int GetDamage()
    {
	return _damage;
    }    

    public void SetDamage(int newDamage)
    {
	_damage = newDamage;
    }

    public bool GetArePouse()
    {
	return _arePouse;
    }

    public void ChangePause()
    {
	Time.timeScale = (Time.timeScale + 1) % 2;
	_arePouse = !_arePouse;
    }

    public void DecreaseMonsterNumber(int addScore)
    {
	_score += addScore;
	GameObject.Find("Score").GetComponent<Text>().text = _score.ToString();
	_numberOfMonsters -= 1;
	GameObject.Find("MonsterNumber").GetComponent<Text>().text = _numberOfMonsters.ToString();
    }

    public int GetScore()
    {
	return _score;
    }

    void Spawn()
    {
	Vector3 spawnPlase = new Vector3(Random.Range(-49f,49f),0.1f,Random.Range(-49f,49f));
	int i = Random.Range(0,monsters.Length);
	if(i == monsters.Length)
	    i--;
        Instantiate(monsters[i], spawnPlase, Quaternion.identity);
	_numberOfMonsters += 1;
	GameObject.Find("MonsterNumber").GetComponent<Text>().text = _numberOfMonsters.ToString();
	if(_numberOfMonsters == 10)
	{
	    PlayerPrefs.SetInt("Score", _score);
	    SceneManager.LoadScene("Scenes/Recording");
	}
    }

    public void AddTimeToSpawn(float time)
    {
	_timeToSpawn += time;
    }
}
