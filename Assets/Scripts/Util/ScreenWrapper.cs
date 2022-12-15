using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    float colliderRadius;
    // Start is called before the first frame update
    void Start()
    {
        colliderRadius = GetComponent<CapsuleCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 location = transform.position;
        if (location.x - colliderRadius <= ScreenUtils.ScreenLeft)
        {
            location.x = ScreenUtils.ScreenLeft + colliderRadius;
        }
        else if (location.x + colliderRadius >= ScreenUtils.ScreenRight)
        {
            location.x = ScreenUtils.ScreenRight - colliderRadius;
        }
        transform.position = location;
    }
}
