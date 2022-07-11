using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLightBehaviour : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject,1);
    }

    void Update()
    {
        if(GetComponent<Light>().intensity > 0)
	{
	    GetComponent<Light>().intensity -= 0.1f;
	}
    }
}
