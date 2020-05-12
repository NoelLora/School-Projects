using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightOnWally : MonoBehaviour
{
    private void Update()
    {
        destroyObj();
    }
    private void destroyObj()
    {
        Object.Destroy(gameObject, 5.0f);
    }

}
