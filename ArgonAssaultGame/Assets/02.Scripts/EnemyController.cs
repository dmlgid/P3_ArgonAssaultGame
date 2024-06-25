using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($"{this.name} -- Collision -- {other.gameObject.name}");
        Destroy(this.gameObject);

    }
}
