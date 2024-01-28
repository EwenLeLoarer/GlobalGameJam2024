using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    public void Play()
    {
        AudioManager.PlaySound2D("Click");
        SceneManager.LoadScene("scene Ewen");
    }

    public void Exit()
    {
        AudioManager.PlaySound2D("Click");
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
