using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordSystem : MonoBehaviour
{
    private TMP_InputField inputTextField;
    public TMP_Text text;

    private void Start()
    {
        inputTextField = GetComponent<TMP_InputField>();
    }

    public void CheckPass()
    {
        switch (inputTextField.text)
        {
            case "Password":
                text.text = "CORRECT";
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
