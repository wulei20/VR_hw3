using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arithmetic_script : MonoBehaviour
{
    public string arithmetic;
    private bool error;
    // Start is called before the first frame update
    void Start()
    {
        arithmetic = "";
        error = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Find("Text").GetComponent<Text>().text = error ? "Error" : arithmetic;
    }

    public void Press(char button_val)
    {
        error = false;
        if (button_val == 'D') // Del
        {
            if (arithmetic.Length > 0)
            {
                arithmetic = arithmetic.Substring(0, arithmetic.Length - 1);
            }
        }
        else if (('0' <= button_val && button_val <= '9') || button_val == '+' || button_val == '-')
        {
            arithmetic += button_val;
        }
        else if (button_val == '=')
        {
            arithmetic += "=";
            Calculate();
        }
    }

    private void Calculate()
    {
        int number = 0, result = 0;
        bool waiting_for_op = true;
        char last_op = '+';
        for (int i = 0; i < arithmetic.Length; i++)
        {
            var c = arithmetic[i];
            if (waiting_for_op)
            {
                if (c == '+' || c == '-')
                {
                    if (last_op == '+')
                    {
                        result += number;
                    }
                    else
                    {
                        result -= number;
                    }
                    number = 0;
                    last_op = c;
                    waiting_for_op = false;
                }
                else if ('0' <= c && c <= '9')
                {
                    number = number * 10 + (c - '0');
                }
                else if (c == '=')
                {
                    if (last_op == '+')
                    {
                        result += number;
                    }
                    else if (last_op == '-')
                    {
                        result -= number;
                    }
                    if (i != arithmetic.Length - 1)
                    {
                        error = true;
                        arithmetic = "";
                        return;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    error = true;
                    arithmetic = "";
                    return;
                }
            }
            else
            {
                if ('0' <= c && c <= '9')
                {
                    number = c - '0';
                    waiting_for_op = true;
                }
                else
                {
                    error = true;
                    arithmetic = "";
                    return;
                }
            }
        }
        arithmetic += result.ToString();
    }
}
