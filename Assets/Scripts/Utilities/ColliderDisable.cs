using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDisable : MonoBehaviour
{
    public Collider punchCollider;
    public Collider kickCollider;

    public void DisablePunch()
    {
        punchCollider.enabled = false;
    }

    public void DisableKick()
    {
        kickCollider.enabled = false;
    }
}
