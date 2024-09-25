using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordTrailTest : MonoBehaviour
{
    public void Update()
    {
        transform.Rotate(270f * Time.deltaTime, 0f, 0f);
    }
}
