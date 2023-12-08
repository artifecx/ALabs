using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    GuestPlayerData guestPlayerData;

    // Delete guest account
    public void DeleteGuestData()
    {
        GuestPlayerData guestPlayerData = new GuestPlayerData();
        guestPlayerData.DeleteGuest();
    }
}
