using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSpawn : Buffs
{
    private float _freezeTime;

    void Start()
    {
        cdValue = 8f;
	_freezeTime = 3f;
    }

    protected override void Buffer()
    {
	GameObject.Find("Logic").GetComponent<SpawnScript>().AddTimeToSpawn(_freezeTime);
    }
}
