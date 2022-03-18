using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public static class Eventler
{
    public static event Action engeligecti;
    public static event Action<float, float> engeleGirdi;
   

    public static event Action<YeniEngelArgs> yeniHedefYolla;
    public static event Action oyunbasla;
    public static event Action gameover;
    public static void engelGirdi(float x, float y)
    {

        engeleGirdi?.Invoke(x, y);

    }
    public static void EngelGecildi()
    {
        engeligecti?.Invoke();
    }
    public static void OnyeniHedefYolla(YeniEngelArgs args)
    {
        yeniHedefYolla?.Invoke(args);
    }
    public static void ONOyunBasla()
    {
        oyunbasla?.Invoke();
    }  
    public static void ONOyunBitti()
    {
        gameover?.Invoke();
    }
}
public class YeniEngelArgs : EventArgs
{

    public Engel hedef;
    public Vector2 boxsize;

}