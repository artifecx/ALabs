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

    [Header("Lesson 1")]
    [SerializeField] GameObject Lesson1Canvas;

    [Header("Level 2")]
    [SerializeField] GameObject Level2Canvas;

    #region DASHBOARD FUNCTIONS
    public void OpenDashboardPage()
    {
        DashboardCanvas.SetActive(true);
        LessonsCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);

        Lesson1Canvas.SetActive(false);
        Level2Canvas.SetActive(false);
    }

    public void OpenSettingsPage()
    {
        DashboardCanvas.SetActive(false);
        LessonsCanvas.SetActive(false);
        SettingsCanvas.SetActive(true);

        Lesson1Canvas.SetActive(false);
        Level2Canvas.SetActive(false);
    }

    public void OpenLessonsPage()
    {
        DashboardCanvas.SetActive(false);
        LessonsCanvas.SetActive(true);
        SettingsCanvas.SetActive(false);

        Lesson1Canvas.SetActive(false);
        Level2Canvas.SetActive(false);
    }
    #endregion

    #region LESSONS BTN -> LESSONS CANVAS -> LEVEL 1 & LEVEL 2 BUTTONS
    public void OpenLessonOneIntro()
    {
        SceneManager.LoadScene("Lesson1-Intro");
    }

    public void OpenLessonOneGameImple()
    {
        SceneManager.LoadScene("Lesson1-GameImple");
    }
    public void SceneLoaderButtons(string scene) 
    {
        SceneManager.LoadScene(scene);
    }
    
    public void quitButton()
    {
        Application.Quit();
    }
    #endregion


    #region LESSONS FUNCTIONS
   public void OpenLesson1Canvas()
    {
        DashboardCanvas.SetActive(false);
        LessonsCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);

        Lesson1Canvas.SetActive(true);
        Level2Canvas.SetActive(false);
    }
    #endregion
}
