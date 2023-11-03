using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordSystem : MonoBehaviour
{
    private TMP_InputField inputTextField;
    public TMP_Text text;
    public GameObject imageBefore;
    public GameObject imageAfter;
    public GameObject inputSystem;


    private void Start()
    {
        inputTextField = GetComponent<TMP_InputField>();
        imageBefore.SetActive(true);
        imageAfter.SetActive(false);
    }

    public void CheckPass()
    {
        switch (inputTextField.text)
        {
            case "cats172":
                text.text = "CORRECT";
                imageBefore.SetActive(false);
                imageAfter.SetActive(true);
                inputSystem.SetActive(false);
                break;
            case "Richard Medan":
                text.text = "HAIL RICHARD MEDAN";
                break;
            default:
                text.text = "WRONG";
                break;
        }
    }

}
