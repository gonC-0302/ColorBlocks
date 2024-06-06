using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public void OnClickStartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("Title");

    }
}
