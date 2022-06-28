using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsUpdate : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePage()
    {
	for(int i = 1; i < 11; i++)
	{
	    GameObject.Find("Names" + i.ToString()).GetComponent<Text>().text = PlayerPrefs.GetString(i.ToString());
	    GameObject.Find("Scores" + i.ToString()).GetComponent<Text>().text = PlayerPrefs.GetInt(i.ToString() + "+").ToString();
	}
    }
}
