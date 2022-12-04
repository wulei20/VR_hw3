using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_script : MonoBehaviour
{
    public char button_val;
    public GameObject display_box;
    private bool selected;
    // Start is called before the first frame update
    void Start()
    {
        button_val = transform.Find("Text").GetComponent<Text>().text[0];
        display_box = GameObject.Find("Display_box");
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            if (button_val != 'D')
                display_box.GetComponent<arithmetic_script>().arithmetic += button_val;
            else
            {
                int len = display_box.GetComponent<arithmetic_script>().arithmetic.Length;
                display_box.GetComponent<arithmetic_script>().arithmetic = display_box.GetComponent<arithmetic_script>().arithmetic.Substring(0, len-1);
            }
            if (button_val == '=')
                display_box.GetComponent<arithmetic_script>().Calculate();
        }
    }
}
