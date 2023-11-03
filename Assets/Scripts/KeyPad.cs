using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public string answer;
    public string password;
    // Start is called before the first frame update
    public void ClickedButton(int num)
    {
        answer += num.ToString();
        Debug.Log(answer.Length);
        if(answer.Length==4 && answer.Contains(password))
        {
            Debug.Log(true);
            answer = "";
        }else if(answer.Length == 4 && !answer.Contains(password))
        {
            Debug.Log(false);
            answer = "";
        }
    }
}
