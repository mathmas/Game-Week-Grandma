using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarilBehaviour : MonoBehaviour
{
    public GameObject barilExplosionPrefab;

    private void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Ground"))
        {
            GameObject barilExplosionObj = Instantiate(barilExplosionPrefab, transform.position, barilExplosionPrefab.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
