﻿using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LevelLoader : MonoBehaviour {

    public GameObject loadingScreen;
    public Image loadingBar;
    public TextMeshProUGUI loadPercent;
    public float progress;
    public float delay;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void LoadLevelNotAsync(string sceneIn)
    {
        SceneManager.LoadScene(sceneIn);
    }
    public void LoadLevel(string sceneIn)
    {
        StartCoroutine(LoadAsynchronously(sceneIn));
    }

    IEnumerator LoadAsynchronously(string sceneIn)
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(delay);
        AsyncOperation opereation = SceneManager.LoadSceneAsync(sceneIn);


        while (!opereation.isDone)
        {
            progress = (opereation.progress / 9f) * 10f;
            loadPercent.text = Mathf.RoundToInt((progress * 100f)).ToString() + " %";
            loadingBar.fillAmount = progress;
            yield return null;
        }
    }
}