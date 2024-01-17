using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newsc : MonoBehaviour
{
    [SerializeField] private Image im;
    private void Awake()
    {
        im.fillAmount = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        im.fillAmount += 0.001f;
    }
}
