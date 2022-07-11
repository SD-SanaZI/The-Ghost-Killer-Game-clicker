using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buffs : MonoBehaviour
{
    protected float cdValue, buffValue; // Полное время перезарядки
    private float _cdTime, _buffTime;     // Текущее время перезарядки

    void Update()
    {
	if(_cdTime > 0){
	    GetComponentInChildren<Text>(true).text = _cdTime.ToString();
            _cdTime -= Time.deltaTime;
	    if(_cdTime <= 0)
		GetComponentInChildren<Text>(true).text = name;
	}
	if(_buffTime > 0){
            _buffTime -= Time.deltaTime;
	    if(_buffTime <= 0)
		UnBuffer();
	}
    }

    public void Do()
    {
	if(_cdTime <= 0 && !GameObject.Find("Logic").GetComponent<SpawnScript>().GetArePouse())
	{
	    _cdTime = cdValue;
	    _buffTime = buffValue;
	    Buffer();
	}
    }

    protected virtual void Buffer(){}
    protected virtual void UnBuffer(){}
}
