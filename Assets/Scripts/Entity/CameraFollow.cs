using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform target;
    public int maxPosX=4;
    public int maxPosY=4;
    private Vector3 cameraPos;
    
    public Vector3 CameraPos 
    { 
        get { return cameraPos; } 
        set 
        { 
            if (Mathf.Abs(value.x) > maxPosX) cameraPos.x = value.x < 0 ? -maxPosX : maxPosX; else cameraPos.x = value.x;
            if (Mathf.Abs(value.y) > maxPosY) cameraPos.y = value.y < 0 ? -maxPosY : maxPosY; else cameraPos.y = value.y;
            cameraPos.z = -10;
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        CameraPos = target.position;
        transform.position = cameraPos;
    }
}
