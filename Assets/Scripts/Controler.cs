using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Controler : MonoBehaviour
{
    public abstract void Move();
    public float UseInput(ref float v, float s, KeyCode I, KeyCode D)
    {
        if (Input.GetKey(I))
        {
            v = Mathf.Lerp(v, 1, s);
        }
        else if (Input.GetKey(D))
        {
            v = Mathf.Lerp(v, -1, s);
        }
        else
        {
            v = Mathf.Lerp(v, 0, s);
        }

        return v;
    }

}
public struct KeyMap    //    I means increase   D means Decrese
{
    public KeyCode freelook;
    //move forward and backwarf
    public KeyCode moveF ;
    public KeyCode moveB ;
    public float moveV;
    //rotate alog z
    public KeyCode rotZI;
    public KeyCode rotZD;
    public float rotZV;
    //rotate alog y
    public KeyCode rotYI;
    public KeyCode rotYD;
    public float rotYV;
    //rotate alog x
    public KeyCode rotXI;
    public KeyCode rotXD;
    public float rotXV;

}