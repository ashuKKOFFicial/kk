using UnityEngine;

[CreateAssetMenu(fileName = "Pay3Session", menuName = "ScriptableObjects/Pay3Session", order = 2)]
public class Pay3Session : ScriptableObject
{
    public bool isLoggedIn = false;
    public string address = "";
    public string jwtToken = "";
}
