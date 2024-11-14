using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinerText : MonoBehaviour
{
    public string[] Texts;
    public Text TexeNode;
    private int index;

    public void HandleClick()
    {
        index++;
        TexeNode.text = Texts[index];
    }
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        TexeNode.text = Texts[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
