using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLightBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,1);
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Light>().intensity > 0)
	{
	    GetComponent<Light>().intensity -= 0.1f;
	}
    }
}
