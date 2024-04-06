using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraScript : MonoBehaviour
{

    IEnumerator AuraTime()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);

    }

    private void Awake()
    {
        StartCoroutine(AuraTime());
    }
}
