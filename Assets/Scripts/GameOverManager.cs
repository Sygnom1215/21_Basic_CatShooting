using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private Text textHighScore = null;

    void Start()
    {
        textHighScore.text = string.Format("HIGHSCORE {0}", PlayerPrefs.GetInt("HighScore", 500));
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("Main");
    }
}
