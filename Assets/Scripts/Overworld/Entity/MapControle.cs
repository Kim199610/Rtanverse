using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MapControle : MonoBehaviour
{
    [SerializeField]GameObject roof;

    public void IsInside(bool isInside)
    {
        roof.SetActive(!isInside);
    }
}
