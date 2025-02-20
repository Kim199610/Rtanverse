using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideCollier : MonoBehaviour
{
    public MapControle mapControle;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mapControle.IsInside(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mapControle.IsInside(false);
        }
    }
}
