using UnityEngine;

[CreateAssetMenu(fileName = "Pay3SDKConfig", menuName = "ScriptableObjects/Pay3SDKConfig", order = 1)]
public class Pay3SDKConfig : ScriptableObject
{
    public string androidPackageId;
    public string appNotifyApiKey;
    public string appNotifyAppId;
    public string appNotifyProjectId;
    public string appNotifyDatabaseUrl;
    public string appNotifyStorageBucket;
    public string appDeepLink;
    public string pay3ClientId;
    public string pay3HostName;
}
