using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    Transform targetStartPos;
    [SerializeField]
    Transform targetEndPos;

    [Space]

    [SerializeField]
    Transform sprite;
    [SerializeField]
    Transform spriteStartPos;
    [SerializeField]
    Transform spriteEndPos;
    

    private void LateUpdate()
    {
        float value = Mathf.InverseLerp(targetStartPos.position.x, targetEndPos.position.x, target.position.x);
        
        Vector3 pos = sprite.transform.localPosition;
        pos.x = Mathf.Lerp(spriteStartPos.localPosition.x, spriteEndPos.localPosition.x, value);
        sprite.transform.localPosition = pos;
    }
}
