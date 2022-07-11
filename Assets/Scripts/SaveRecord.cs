using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveRecord : MonoBehaviour
{
    public InputField nameString;

    public void Save()
    {
	int i = 1;
	for(; i < 11 && PlayerPrefs.GetInt(i.ToString() + "+") >= PlayerPrefs.GetInt("Score"); i++){}
	for(int j = 9; j >= i; j--)
	{
	    PlayerPrefs.SetString((j+1).ToString(), PlayerPrefs.GetString(j.ToString()));
	    PlayerPrefs.SetInt((j+1).ToString() + "+", PlayerPrefs.GetInt(j.ToString() + "+"));
	}
	PlayerPrefs.SetString(i.ToString(), nameString.text);
	PlayerPrefs.SetInt(i.ToString() + "+", PlayerPrefs.GetInt("Score"));
        SceneManager.LoadScene("Scenes/Menu");
    }
}
