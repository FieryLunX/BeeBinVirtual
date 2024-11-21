using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignInScript : MonoBehaviour
{
    public void SignIntoMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
