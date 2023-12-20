using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using PlayFab;

public class PlayfabAuth : MonoBehaviour
{
    public string TitleId;
    // Start is called before the first frame update
    void Start()
    {
        
        if (FB.IsInitialized)
            return;
        FB.Init(() => FB.ActivateApp());
    }

    public void LoginWithFacebook()
    {
        FB.LogInWithReadPermissions(new List<string> { "public_profile","email"}, Res => { LoginWithPlayfab(); });
    }

    public void LoginWithPlayfab()
    {
        PlayFabClientAPI.LoginWithFacebook(new PlayFab.ClientModels.LoginWithFacebookRequest
        {
            TitleId = TitleId,
            AccessToken = AccessToken.CurrentAccessToken.TokenString,
            CreateAccount = true
        },PlayfabLoginSuccess,playfabLoginFailed) ;
        
    }

    public void PlayfabLoginSuccess(PlayFab.ClientModels.LoginResult result)
    {
        Debug.Log("login successful");
    }
    public void playfabLoginFailed(PlayFabError error)
    {
        Debug.Log("login failed");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
