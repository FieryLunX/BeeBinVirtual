using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] GameObject dialogCharacter;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] TMP_Text dialogName;

    [SerializeField] int lettersPerSecond;

    public event Action OnShowDialog;
    public event Action OnHideDialog;

    public static DialogManager Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    Dialog dialog;
    int currentLine = 0;
    bool isTyping;

    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();

        this.dialog = dialog;
        dialogBox.SetActive(true);
        dialogCharacter.SetActive(true);

        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Z) && !isTyping)
        {
            ++currentLine;
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                dialogBox.SetActive(false);
                dialogCharacter.SetActive(false);
                currentLine = 0;
                OnHideDialog?.Invoke();
            }
        }
    }

    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.1f / lettersPerSecond);
        }
        isTyping = false;
    }
}