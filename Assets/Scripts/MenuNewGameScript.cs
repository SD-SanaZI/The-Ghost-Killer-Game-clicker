using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNewGameScript : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Scenes/Game");
    }
}
