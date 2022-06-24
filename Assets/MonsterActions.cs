using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActions : MonoBehaviour
{
    public GameObject logic;

    // Start is called before the first frame update
    void Start()
    {
	logic = GameObject.Find("Logic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
	logic.GetComponent<SpawnScript>().numberOfMonsters -= 1;
	Destroy(gameObject);
    }
}
