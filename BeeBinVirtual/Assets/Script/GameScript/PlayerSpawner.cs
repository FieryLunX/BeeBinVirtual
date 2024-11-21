using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private void Start() {
        Instantiate(GameManager.instance.currCharacter.prefab, transform.position, Quaternion.identity);
        GameManager.instance.currCharacter.prefab.transform.parent = transform;
    }
}
