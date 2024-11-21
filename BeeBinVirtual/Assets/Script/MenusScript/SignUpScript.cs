using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignUpScript : MonoBehaviour
{
    public void SignUptoMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
