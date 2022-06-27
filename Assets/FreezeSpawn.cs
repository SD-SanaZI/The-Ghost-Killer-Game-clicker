using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSpawn : Buffs
{
    // Start is called before the first frame update
    void Start()
    {
        cdValue = 8f;
    }

    protected override void Buffer()
    {
	GameObject.Find("Logic").GetComponent<SpawnScript>().AddTimeToSpawn(3f);
    }
}
