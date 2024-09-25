using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXDestroyer : MonoBehaviour
{
    [SerializeField] float lifeTime = 1;

    public void Start() => Invoke(nameof(RemoveSlashObject), lifeTime);

    public void RemoveSlashObject() => Destroy(gameObject);
}