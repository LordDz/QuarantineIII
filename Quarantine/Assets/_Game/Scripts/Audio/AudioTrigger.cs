using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioTrigger : MonoBehaviour
{
    void OnDestroy()
    {
        StudioEventEmitter eventEmitter = GetComponent<StudioEventEmitter>();
        eventEmitter.Stop();
    }
}
