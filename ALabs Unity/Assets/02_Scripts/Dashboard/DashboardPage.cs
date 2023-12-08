using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DashboardPage : MonoBehaviour
{
    GuestPlayerData guestPlayerData = new GuestPlayerData();

    [Header("Dashboard")]
    [SerializeField] GameObject DashboardCanvas;

    [Header("Lessons")]
    [SerializeField] GameObject LessonsCanvas;

    [Header("Settings")]
    [SerializeField] GameObject SettingsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenDashboardPage()
    {
        DashboardCanvas.SetActive(true);
        LessonsCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);
    }

    public void OpenSettingsPage()
    {
        DashboardCanvas.SetActive(false);
        LessonsCanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
    }

    public void OpenLessonsPage()
    {
        DashboardCanvas.SetActive(false);
        LessonsCanvas.SetActive(true);
        SettingsCanvas.SetActive(false);
    }

    public void OpenLessonOne()
    {
        SceneManager.LoadScene("Lesson1-Intro");
    }

    public void SceneLoaderButtons(string scene) 
    {
        SceneManager.LoadScene(scene);
    }
    
    public void quitButton()
    {
        Application.Quit();
    }
}
