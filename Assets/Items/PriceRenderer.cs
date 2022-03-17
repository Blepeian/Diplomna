using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceRenderer : MonoBehaviour
{
    public Renderer rend;

    void Start()
    {
        rend.sortingLayerName = "Midground";
    }
}
