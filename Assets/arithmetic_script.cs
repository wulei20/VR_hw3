using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arithmetic_script : MonoBehaviour
{
    public string arithmetic;
    // Start is called before the first frame update
    void Start()
    {
        arithmetic = "0";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Calculate()
    {
        int val = 0, tmp = 0, factor = 1;
        bool error = false;
        for (int i = 0; i < arithmetic.Length; i++)
        {
            if (arithmetic[i] >= '0' && arithmetic[i] <= '9')
            {
                tmp = arithmetic[i];
                while (arithmetic[i + 1] >= '0' && arithmetic[i + 1] <= '9')
                {
                    i++;
                    tmp = tmp * 10 + arithmetic[i];
                }
            }
            else if (arithmetic[i] == '+')
                val += tmp * factor;
            else if (arithmetic[i] == '-')
                factor = -factor;
            else
            {
                Debug.Log("Calculate Error!");
                error = true;
                break;
            }
        }
        val += tmp * factor;
        arithmetic = error ? "Error" : arithmetic + val.ToString();
    }
}
