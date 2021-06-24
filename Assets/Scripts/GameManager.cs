using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Vector2 minPosition { get; private set; }
    public Vector2 maxPosition { get; private set; }

    [SerializeField]
    private GameObject enemyPrefab = null;
    [SerializeField]
    private Text lifeText = null;
    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private Text highScoreText = null;
    [SerializeField]
    private int life = 5;
    [SerializeField]
    private int highScore =0;
    [SerializeField]
    private int score = 0;

    void Start()
    {
        minPosition = new Vector2(-9f, -4.8f);
        maxPosition = new Vector2(9f, 4.8f);
        StartCoroutine(SpawnPandaCat());
        highScore = PlayerPrefs.GetInt("HighScore", 10);
        UpdateUI();
    }
    private IEnumerator SpawnPandaCat()
    {
        float delay = 0f;
        float positionY = 0f;
        while (true)
        {
            delay = Random.Range(1f, 0.1f);
            positionY = Random.Range(minPosition.y, maxPosition.y);
            for (int i = 0; i < 1; i++)
            {
                Instantiate(enemyPrefab, new Vector2(maxPosition.x, positionY), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(delay);
        }
    }
    private void UpdateUI()
    {
        lifeText.text = string.Format("LIFE {0}", life);
        scoreText.text = string.Format("SCORE {0}", score);
        highScoreText.text = string.Format("가장 많이 꼬신 고양이 수 {0}", highScore);
    }

    public void AddScore(int addscore)
    {
        score += addscore;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        UpdateUI();
    }
    public void Dead()
    {
        life--;
        if (life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        UpdateUI();
    }
    public void GameQuit()
    {
        Application.Quit();
    }

}
