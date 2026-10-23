using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BackGroundAlternade : MonoBehaviour
{
    public int nextGround=0;
    void Start()
    {
        nextGround = 0;
        AlterarFundo();
    }
        
    void Update()
    {
    }
    public void AlterarFundo() {
        ColorUtility.TryParseHtmlString(color().ToString(), out Color cor);
        Camera.main.backgroundColor = cor;
    }
    public string color()
    {
        switch (nextGround)
        {
            case 0:
                nextGround = 1;
                return "#FFFF";
            case 1:
                nextGround = 2;
                return "#BC898B";
            case 2:
                nextGround = 3;
                return "#9DE076";
            case 3:
                nextGround = 4;
                return "#75E0C8";
            default:
                nextGround = 0;
                return "#B3B284";
        }
    }
    public void resetar()
    {
        nextGround = 0;
        AlterarFundo();
    }
}
