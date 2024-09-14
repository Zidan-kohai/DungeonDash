using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FusionStartup : MonoBehaviour
{
    [SerializeField]
    private NetworkSceneManagerDefault _sceneManager;

    [SerializeField]
    private NetworkRunner _runner;

    [SerializeField]
    private string _sessionName = "SampleSession";


    private void Start()
    {
        StartSimulation(GameMode.AutoHostOrClient);
    }

    private async void StartSimulation(GameMode gameMode)
    {
        _runner.ProvideInput = true;

        await _runner.StartGame(new StartGameArgs()
        {
            GameMode = gameMode,
            SceneManager = _sceneManager,
            SessionName = _sessionName,
            Scene = GetScene(),
        });
    }

    private SceneRef GetScene()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        return SceneRef.FromIndex(buildIndex);
    }
}
