using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_script : MonoBehaviour
{
    public char button_val;
    public arithmetic_script QAQ;
    public Button my_button;

    // Start is called before the first frame update
    void Start()
    {
        button_val = transform.Find("Text").GetComponent<Text>().text[0];
        QAQ = GameObject.Find("Display_box").GetComponent<arithmetic_script>();
        my_button = transform.GetComponent<Button>();
        my_button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update() {}

    
    void OnClick()
    {
        // display_box.GetComponent<arithmetic_script>().arithmetic = Random.Range(0, 100).ToString();
        QAQ.Press(button_val);
    }
}
