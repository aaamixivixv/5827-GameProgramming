using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCh : MonoBehaviour
{
    public ObjectColor color;

    void Start()
    {
        if(TryGetComponent(out ColorRandom colorRandom))
        {
            color = colorRandom.color;
        }
    }
    ObjectColor Color()
    {
        return this.color;
    }

    void Settingcolor(ObjectColor color)
    {
        this.color = color;
    }

}
