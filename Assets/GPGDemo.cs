using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public class GPGDemo : MonoBehaviour
{
    #region Public_Vars
    public string leaderboard;
    #endregion


    #region Ui_Callbacks

    /// <summary>
    /// Login In Into Your Google+ Account
    /// </summary>
    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Login Sucess");
            }
            else
            {
                Debug.Log("Login failed");
            }
        });
    }

    /// <summary>
    /// Shows All Available Leaderborad
    /// </summary>
    public void OnShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }

    /// <summary>
    /// Adds Score To leader board
    /// </summary>
    public void OnAddScoreToLeaderBorad()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(5000, leaderboard, (bool success) =>
            {
                if (success)
                {
                    ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(leaderboard);
                }
                else
                {
                    Debug.Log("Add Score Fail");
                }
            });
        }
    }

    /// <summary>
    /// On Logout of your Google+ Account
    /// </summary>
    public void OnLogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
    }



    #endregion


}
