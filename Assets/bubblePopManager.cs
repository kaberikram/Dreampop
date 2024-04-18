using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubblePopManager : MonoBehaviour
{
    public enum SphereColor { Blue, Green, Yellow, Red };
    public SphereColor sphereColor;

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        switch (sphereColor)
        {
            case SphereColor.Blue:
                if (other.CompareTag("BlueFinger"))
                {
                    Debug.Log("blue");
                }
                break;
            case SphereColor.Green:
                if (other.CompareTag("GreenFinger"))
                {
                    Debug.Log("green");
                }
                break;
            case SphereColor.Yellow:
                if (other.CompareTag("YellowFinger"))
                {
                    Debug.Log("yellow");
                }
                break;
            case SphereColor.Red:
                if (other.CompareTag("RedFinger"))
                {
                    Debug.Log("red");
                }
                break;
        }
    }
}
