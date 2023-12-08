using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class LoginPage : MonoBehaviour
{
    GuestPlayerData guestPlayerData;
    [SerializeField] TextMeshProUGUI toptext;
    [SerializeField] TextMeshProUGUI MessageText;

    [Header("Login")]
    [SerializeField] TMP_InputField EmailLoginInput;
    [SerializeField] TMP_InputField PasswordLoginInput;
    [SerializeField] GameObject LoginPage1;

    [Header("Register")]
    [SerializeField] TMP_InputField UsernameRegisterInput;
    [SerializeField] TMP_InputField EmailRegisterInput;
    [SerializeField] TMP_InputField PasswordRegisterInput;
    [SerializeField] GameObject RegisterPage;

    [Header("Recovery")]
    [SerializeField] TMP_InputField EmailRecoveryInput;
    [SerializeField] GameObject RecoveryPage;

    [Header("Guest")]
    [SerializeField] TMP_InputField UsernameInputField;
    [SerializeField] GameObject GuestPage;


    // Start is called before the first frame update

    #region PlayFab Login & Register Functions

    // Login and Register functions

    /*public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = EmailLoginInput.text,
            Password = PasswordLoginInput.text,
        };

        //PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);

    }

    private void OnLoginSuccess(LoginResult result)
    {
        MessageText.text = "Logging in...";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    

    public void RegisterUser()
    {
        
        var request = new RegisterPlayFabUserRequest {
            DisplayName = UsernameRegisterInput.text,
            Email = EmailRegisterInput.text,
            Password = PasswordRegisterInput.text,

            RequireBothUsernameAndEmail = true
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnregisterSuccess, OnError);
    }
    public void RecoverUser()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = EmailRecoveryInput.text,
            TitleId = "7D540"
        };

        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoverySuccess, OnError);
    }

    private void OnRecoverySuccess(SendAccountRecoveryEmailResult result)
    {
        OpenLoginPage();
        MessageText.text = "Recovery Mail sent successfully!";
    }

    private void OnError(PlayFabError error)
    {
        MessageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    private void OnregisterSuccess(RegisterPlayFabUserResult result)
    {
        MessageText.text = "Account successfully created!";
        OpenLoginPage();
    }*/

    public void OpenLoginPage()
    {
        LoginPage1.SetActive(true);
        RegisterPage.SetActive(false);
        RecoveryPage.SetActive(false);
        GuestPage.SetActive(false);
        toptext.text = "Login";
    }

    public void OpenRegisterPage()
    {
        LoginPage1.SetActive(false);
        RegisterPage.SetActive(true);
        RecoveryPage.SetActive(false);
        GuestPage.SetActive(false);
        toptext.text = "Register";
    }

    public void OpenRecoveryPage()
    {
        LoginPage1.SetActive(false);
        RegisterPage.SetActive(false);
        RecoveryPage.SetActive(true);
        GuestPage.SetActive(false);
        toptext.text = "Recover Password";
    }

    public void OpenGuestPage()
    {
        LoginPage1.SetActive(false);
        RegisterPage.SetActive(false);
        RecoveryPage.SetActive(false);
        if(!PlayerPrefs.GetString("Username").Equals(""))
        {
            Debug.Log(PlayerPrefs.GetString("Username"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            GuestPage.SetActive(true);
            toptext.text = "Play as Guest";
        }
    }

    #endregion

    #region PlayerPrefs Play as Guest Functions

    public static bool RegisterAsGuestSuccess = false;
    private void OnLoginSuccessAsGuest(bool RegisterAsGuestSuccess)
    {
        if (RegisterAsGuestSuccess == true)
        {
            MessageText.text = "Logging in...";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void RegisterGuestUser() // when the user signs up as guest
    {
        guestPlayerData = new GuestPlayerData();
        if(UsernameInputField.text != null && UsernameInputField.text.Count() >= 8)
        {
            guestPlayerData.SignUpAsGuest(UsernameInputField.text);
            RegisterAsGuestSuccess = true;
            Debug.Log("Guest player successfully registered!");
            OnLoginSuccessAsGuest(RegisterAsGuestSuccess);

        }
        else if(UsernameInputField.text.Count() != 0 && UsernameInputField.text.Count() < 7)
        {
            MessageText.text = "Username must be more than 8 characters";
        } else
        {
            MessageText.text = "Username Input field must not be empty";
        }
        
    }

    

    #endregion
}
