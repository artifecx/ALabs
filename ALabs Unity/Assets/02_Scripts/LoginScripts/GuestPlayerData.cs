using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuestPlayerData
{

    
    // Start is called before the first frame update
    // Default values
    private const string defaultUsername = "Guest";
    private const bool defaultHasFinishedLevel = false;

    // Player information
    private static string username;
    private static bool hasFinishedLevel1;
    private static bool hasFinishedLevel2;
    private static bool hasFinishedLevel3;

    // PlayerPrefs keys
    private const string usernameKey = "Username";
    private const string level1Key = "HasFinishedLevel1";
    private const string level2Key = "HasFinishedLevel2";
    private const string level3Key = "HasFinishedLevel3";

    // Initialize player data
    /*private void Start()
    {
        LoadPlayerData();
    }*/

    // Save player data to PlayerPrefs
    private void SavePlayerData()
    {
        PlayerPrefs.SetString(usernameKey, username);
        PlayerPrefs.SetInt(level1Key, hasFinishedLevel1 ? 1 : 0);
        PlayerPrefs.SetInt(level2Key, hasFinishedLevel2 ? 1 : 0);
        PlayerPrefs.SetInt(level3Key, hasFinishedLevel3 ? 1 : 0);

        PlayerPrefs.Save();
    }

    // Load player data from PlayerPrefs
    private void LoadPlayerData()
    {
        // If the key does not exist, PlayerPrefs.GetString returns an empty string.
        username = PlayerPrefs.GetString(usernameKey, defaultUsername);

        // If the key does not exist, PlayerPrefs.GetInt returns 0.
        hasFinishedLevel1 = PlayerPrefs.GetInt(level1Key, defaultHasFinishedLevel ? 1 : 0) == 1;
        hasFinishedLevel2 = PlayerPrefs.GetInt(level2Key, defaultHasFinishedLevel ? 1 : 0) == 1;
        hasFinishedLevel3 = PlayerPrefs.GetInt(level3Key, defaultHasFinishedLevel ? 1 : 0) == 1;
    }

    // Example usage in another script

    public void SignUpAsGuest(string guestUsername)
    {
        // Set the username
        username = guestUsername;

        // Save the guest data
        SavePlayerData();
    }

    // Example usage in another script (e.g., attached to a UI button)
    public void LogInAsGuestButton()
    {
        // You can call this method when the user clicks a button to log in as a guest
        string guestUsername = "Guest_" + Random.Range(1000, 9999); // Guest username with a random number
        SignUpAsGuest(guestUsername);
    }

    // Delete guest player from PlayerPrefs
    public void DeleteGuest()
    {
        // Delete the PlayerPrefs keys associated with the guest player
        //PlayerPrefs.DeleteKey(usernameKey);
        PlayerPrefs.SetString(usernameKey, "");
        PlayerPrefs.DeleteKey(level1Key);
        PlayerPrefs.DeleteKey(level2Key);
        PlayerPrefs.DeleteKey(level3Key);

        // Save the changes
        PlayerPrefs.Save();
    }
}
