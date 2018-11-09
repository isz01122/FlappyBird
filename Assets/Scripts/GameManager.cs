using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//How to Call In and Inherit an Open Source Singleton
public class GameManager : Singleton<GameManager>
{
    float score;
    public Text scoreText;
    public GameObject readyImage;

    public float spawnColumnX;
    public GameObject column;
    public float columnMinY;
    public float columnMaxY;
    public float spawnTime = 1.0f;

    public GameObject gameOverUI;
    public Vector3 gameOverUIMoveFrom;
    public float gameOverUITime = 1.0f;
    bool isGameOver = false;
    public bool isReady = true;
    public GameObject currGround;

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);
    }

    void Start () 
    {
        currGround = GetComponent<GameObject>();
        score = 0;
        readyImage.SetActive(true);
        StartCoroutine(SpawnColumn());
        column.SetActive(false);
    }

    void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
    }

    void LateUpdate () 
    {
        if (isReady)
        {
            if (Input.GetMouseButtonDown(0))
            {   
                isReady = false;
                readyImage.SetActive(false);
                column.SetActive(true);
            }
        }
       
    }

    public void GameOver()
    {
        isGameOver = true;

        gameOverUI.SetActive(true);
        iTween.MoveFrom(gameOverUI, gameOverUIMoveFrom, gameOverUITime);
    }

    public void AddScore()
    {
        ++score;
        scoreText.text = "Score : " + score;
    }

    //return time and frame!!
    IEnumerator SpawnColumn()
    {   
        while (true)
        {
            Vector3 pos = new Vector3();
            pos.x = spawnColumnX;
            pos.y = Random.Range(columnMinY, columnMaxY);
            Instantiate(column, pos, Quaternion.identity);

            yield return new WaitForSeconds(spawnTime);

        }

    }
}
