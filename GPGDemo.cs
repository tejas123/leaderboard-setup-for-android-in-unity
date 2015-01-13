using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GPGDemo : MonoBehaviour
{
	
		public GUISkin skin;
		
	
		//leaderboard id
		public string leaderboard;
		
	
		// Use this for initialization
		void Start ()
		{
				PlayGamesPlatform.Activate ();
		}
	
		// Update is called once per frame
		public void OnGUI ()
		{
				GUI.skin = skin;
				skin.button.fixedWidth = Screen.width - 25;
				skin.textField.fixedWidth = Screen.width - 25;
				GUILayout.BeginArea (new Rect (0, 0, Screen.width, Screen.height));
		
				GUILayout.BeginVertical ("box");
		
				GUILayout.Label ("Google Play Games Services Demo By AppGuruz");
		
				GUILayout.Space (20);
		
				//Log In
				if (GUILayout.Button ("Log In")) {
						Social.localUser.Authenticate ((bool success) =>
						{
								if (success) {
										Debug.Log ("Login Sucess");
								} else {
										Debug.Log ("Login failed");
								}
						});
				}

		
				//Leaderboard
				if (GUILayout.Button ("Add Your Score to leaderboard")) {
						if (Social.localUser.authenticated) {
								Social.ReportScore (5000, leaderboard, (bool success) =>
								{
										if (success) {
												((PlayGamesPlatform)Social.Active).ShowLeaderboardUI (leaderboard);
										} else {
												Debug.Log ("Add Score Fail");
										}
								});
						}
				}
		
				GUILayout.Space (20);
		
				// Show Leaderboard
				if (GUILayout.Button ("Show Leaderboard")) {
						Social.ShowLeaderboardUI ();
				}
		
				GUILayout.Space (20);
		
				//Show Specific Leaderboard
				if (GUILayout.Button ("Show Specific Leaderboard")) {
						((PlayGamesPlatform)Social.Active).ShowLeaderboardUI (leaderboard);
				}
		
				GUILayout.Space (20);
		
	
				//Sign Out
				if (GUILayout.Button ("Sign Out")) {
						((PlayGamesPlatform)Social.Active).SignOut ();
				}
		
				GUILayout.EndVertical ();
				GUILayout.EndArea ();
		}
}