using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buffs : MonoBehaviour
{
    protected float cdValue, buffValue;
    private float cdTime, buffTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	if(cdTime > 0)
	{
	    GetComponentInChildren<Text>( true ).text = cdTime.ToString();
            cdTime -= Time.deltaTime;
	    if(cdTime <= 0)
	    {
		GetComponentInChildren<Text>( true ).text = name;
	    }
	}
	if(buffTime > 0)
	{
            buffTime -= Time.deltaTime;
	    if(buffTime <= 0)
	    {
		UnBuffer();
	    }
	}
    }

    public void Do()
    {
	if(cdTime <= 0 && !GameObject.Find("Logic").GetComponent<SpawnScript>().GetArePouse())
	{
	    cdTime = cdValue;
	    buffTime = buffValue;
	    Buffer();
	}
    }

    protected virtual void Buffer()
    {
	
    }

    protected virtual void UnBuffer()
    {
	
    }


}
