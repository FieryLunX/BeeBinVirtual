using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScript : MonoBehaviour
{
    public void SignUp()
    {
        SceneManager.LoadSceneAsync("SignUpMenu");
    }
    public void SignIn()
    {
        SceneManager.LoadSceneAsync("SignInMenu");
    }
    // public void About()
    // {
    //     SceneManager.LoadSceneAsync("AboutMenu");
    // }
}
