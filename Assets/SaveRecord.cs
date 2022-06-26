using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveRecord : MonoBehaviour
{
    public InputField nameString;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
	int i = 1;
	for(; i <= 11 && PlayerPrefs.GetInt(i.ToString()) > PlayerPrefs.GetInt("Score"); i++){}
// Исправить перепись рекорда
	PlayerPrefs.SetInt(i.ToString() + "+", PlayerPrefs.GetInt("Score"));
	PlayerPrefs.SetString(i.ToString(), nameString.text);
        SceneManager.LoadScene("Scenes/Menu");
    }
}
