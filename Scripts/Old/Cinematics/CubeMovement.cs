using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public bool isSlowMotion = false;
    public bool isEnabled = false;
    private void Update()
    {
        if(isEnabled) transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (Time.deltaTime * 400f));
        if (isSlowMotion) SlowMotion();
    }

    void SlowMotion()
    {
        isSlowMotion = false;
        Time.timeScale = 0.001f;
    }
}
