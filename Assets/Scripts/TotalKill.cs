using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalKill : Buffs
{
    void Start()
    {
        cdValue = 20f;
    }

    protected override void Buffer()
    {
	GameObject[] allMonsters = GameObject.FindGameObjectsWithTag("Monster");
	foreach(GameObject monsters in allMonsters)
	{
	    Destroy(monsters);
	    GameObject.Find("Logic").GetComponent<SpawnScript>().DecreaseMonsterNumber(1);
        }
    }
}