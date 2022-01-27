using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameBehaviour : MonoBehaviour
{
    public string labelText;
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    private int _playerLives = 1;
    private string _state;
    private GUIStyle guiStyle = new GUIStyle();
    public Camera fpsCam;
    
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    public int Lives
    {
        get
        {
            return _playerLives;
        }
        set
        {
            _playerLives = value;
            Debug.LogFormat("Lives: {0}", _playerLives);
            if (_playerLives <= 0)
            {
                labelText = "Press R to activate cursor";
                showLossScreen = true;
                fpsCam.transform.rotation = new Quaternion(0, 0, 90, -90);
                Time.timeScale = 0;
                Destroy(GameObject.Find("Capsule").GetComponent<PlayerMovement>());
            }
            else
            {
                labelText = "Ouch...that's got hurt.";
            }
        }
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _state = "Manager initialized..";
        Debug.Log(_state);
    }

    void OnGUI()
    {
        guiStyle.fontSize = 25;
        guiStyle.normal.textColor = Color.white;
        GUI.contentColor = Color.white;
        //GUI.Label(new Rect(45, 50, 150, 250), "" + _playerLives, guiStyle);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 600, 700), labelText, guiStyle);
        if (showWinScreen)
        {
            
        }
        if (showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "D E A D"))
            {

                Utilities.RestartLevel();
            }
        }
    }
}
