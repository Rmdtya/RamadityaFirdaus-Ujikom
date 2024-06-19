using Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;
    public float SpawnInterval;
    public CameraAnimator CameraAnimator;

    public float xMinPositionRandom;
    public float xMaxPositionRandom;

    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textTimer;
    public TextMeshProUGUI textResult;
    public GameObject panelGameOver;
    int currentScore;
    int currentTimer;
    public int defaultTimer = 60;
    public bool ismainmenu = false;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        if (ismainmenu) return;

        InvokeRepeating("SpawnManager", SpawnInterval, SpawnInterval);
        currentScore = 0;
        currentTimer = defaultTimer;

        StartCoroutine(CountDownTimer());
    }

    private void SpawnManager()
    {
        int RandomValue = Random.Range(0, 4);

        switch (RandomValue)
        {
            case 0:
                GameObject cow = EnemyPooling.instance.GetCowObject();
                SpawnObject(cow); ;
                break;
            case 1:
                GameObject deer = EnemyPooling.instance.GetDeerObject();
                SpawnObject(deer); ;
                break;
            case 2:
                GameObject dog = EnemyPooling.instance.GetDogObject();
                SpawnObject(dog); ;
                break;
            case 3:
                GameObject horse = EnemyPooling.instance.GetHorseObject();
                SpawnObject(horse); ;
                break;
        }
    }

    private void SpawnObject(GameObject enemyObject)
    {
        if (enemyObject != null)
        {
            float randomX = Random.Range(xMinPositionRandom, xMaxPositionRandom);
            Vector3 OffserPosition = new Vector3(randomX, 0, 0);

            enemyObject.transform.position = transform.position + OffserPosition;
            enemyObject.SetActive(true);
        }
    }

    private IEnumerator CountDownTimer()
    {
        float timer = currentTimer;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            textTimer.text = "Timer : " + ((int)timer).ToString();
            yield return null;
        }

        GameOver();
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        CameraAnimator.GameOver();
        textResult.text = "Score : " + currentScore.ToString();
        SoundManager.instance.PlaySoundGameOver();
        panelGameOver.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void UpdateScore(int score)
    {
        currentScore += score;
        textScore.text = "Score : " + currentScore.ToString();
    }
}
