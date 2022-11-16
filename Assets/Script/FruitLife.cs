using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitLife : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 6f);
    }
}
