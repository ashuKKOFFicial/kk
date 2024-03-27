using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpawnObjectsAddressable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/Cube.prefab");
            asyncOperationHandle.Completed += AsyncOperationHandle_Completed;
        }
    }

    private void AsyncOperationHandle_Completed(AsyncOperationHandle<GameObject> asyncOperationHandle)
    {
        if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(asyncOperationHandle.Result);
        }

        else
        {
            Debug.Log("Failed to load");
        }
    }
}
