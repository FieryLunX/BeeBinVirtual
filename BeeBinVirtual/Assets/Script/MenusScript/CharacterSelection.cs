using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] playerCharacter;
    private int index;

    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        playerCharacter = new GameObject[transform.childCount];
        
        for (int i = 0; i < transform.childCount; i++)
            playerCharacter[i] = transform.GetChild(i).gameObject;

        // foreach (GameObject go in playerCharacter)
        //     go.SetActive(false);
        
        // if (playerCharacter[index])
        //     playerCharacter[index].SetActive(true);
    }

    public void CharacterChooseNusa()
    {
        PlayerPrefs.SetInt("CharacterSelected", 0);
        SceneManager.LoadSceneAsync("Class-408");
    }

    public void CharacterChooseTara()
    {
        PlayerPrefs.SetInt("CharacterSelected", 1);
        SceneManager.LoadSceneAsync("Class-408");
    }
}
