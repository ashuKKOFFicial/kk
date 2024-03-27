using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class AddressableAssetsPrefabCube : MonoBehaviour
{
    [SerializeField] private AssetReference addressableSceneName;
    [SerializeField] AsyncOperationHandle<SceneInstance> handle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadAddressableScene(AssetReference sceneName)
    {

        handle = Addressables.LoadSceneAsync(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
