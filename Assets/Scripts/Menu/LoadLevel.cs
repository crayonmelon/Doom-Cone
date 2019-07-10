using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string LevelName;
    public GameObject loading;

    private void Start()
    {
        Cursor.visible = true;
        Screen.lockCursor = false;
    }

    public void PlayGame()
    {
        loading.SetActive(true);
        SceneManager.LoadScene(LevelName);
    }
}
