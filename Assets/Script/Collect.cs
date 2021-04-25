using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    public static int TheGem = 0;
    public Text TextGem;

    void Start()
    {
        TextGem = GetComponent<Text>();
    }

    void Update()
    {
        TextGem.text = "X" + TheGem;
    }
}
