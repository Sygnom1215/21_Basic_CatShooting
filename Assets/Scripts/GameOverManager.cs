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
        textHighScore.text = string.Format("가장 많이 꼬신 고양이 마리 수 {0}", PlayerPrefs.GetInt("HighScore", 500));
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("Main");
    }
}
