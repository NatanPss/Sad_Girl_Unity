using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;
public class GameManage : MonoBehaviour
{

    public static GameManage Instance { get; private set; }
    public float iniciatialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }
    public PlayerScript player;
    public Spawner spawner;
    public GameObject gameOver;
    public GameObject History;
    public TextMeshProUGUI HistoryText;
    public GameObject backGround;
    public TextMeshProUGUI scoreText;
    public float score = 0;
    private bool estage = false;
    private int nextHistory= 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }

    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }


    private void Start()
    {
        player = FindAnyObjectByType<PlayerScript>();
        spawner = FindAnyObjectByType<Spawner>();
        History.gameObject.SetActive(false);
        backGround.GetComponent<BackGroundAlternade>().resetar();
        NewGame();

    }

    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsByType<Obstacle>();
        backGround.GetComponent<BackGroundAlternade>().resetar();

        foreach (Obstacle obs in obstacles)
        {
            Destroy(obs.gameObject);
        }
        gameSpeed = iniciatialGameSpeed;
        score = 0f;
        scoreText.text = score.ToString("F0");


        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        //score.reset();
        gameOver.SetActive(false);
        History.SetActive(false);

    }
    public void GameOver() {
        gameSpeed = 0f;
        enabled = false;
        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        //score.pause();
        gameOver.SetActive(true);
    }

   private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
        if (score > 50)
        {
            score = 0f;
            backGround.GetComponent<BackGroundAlternade>().AlterarFundo();

            History.gameObject.SetActive(true);
            HistoryText.text = nextHistorys().ToString();
            nextHistory++;
        }
    }
    private string nextHistorys() {
        switch(nextHistory)
        {
            case 0:
                return "Eu estou aki tão sozinha, será que mesmo correndo tanto alguém vai se lembrar de mim?";
            case 1:
                return "Por que ela foi me abandonar, eu achei q ela ia sempre ficar comigo.";
            case 2:
                return "eu não sei o que fazer, será que se eu voltar ela vai estar lá?";
            case 3:
                return "Não, ela se foi para sempre jamais saberei como é ouvir suas canções.";
            default:
                nextHistory = 0;
                return "Só me resta lembrar de suas ações e suas memórias, talvez assim ela viva eternamente.";
        }
    }
}
