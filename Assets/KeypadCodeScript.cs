using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class KeypadCodeScript : MonoBehaviour
{
    public Text Displaytext;
    public int maxChars=10;
    public int CorrectCode;
    public UnityEvent OnCorrectAnswer;
    private void OnEnable()
    {
        Displaytext.text = "";
    }

    public void AddNum(int num)
    {
        if (maxChars-1 >= Displaytext.text.Length)
        {
            Displaytext.text = Displaytext.text + num.ToString();
        }
    }

    public void Backspace()
    {
        if(Displaytext.text != "")
        {
            Displaytext.text = Displaytext.text.Substring(0, Displaytext.text.Length - 1);
        }
    }

    public void Enter()
    {
        if (Displaytext.text == CorrectCode.ToString())
        {
            OnCorrectAnswer.Invoke();
        }
        else
        {
            Displaytext.text = "";
        }
    }
}
