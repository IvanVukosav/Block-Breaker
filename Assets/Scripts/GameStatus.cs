using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameStatus : MonoBehaviour
{
    [Range(0.1f,10)][SerializeField] float gameSpeed=1f;
    [SerializeField] int pointsPerBlockDestroyed=83;
    [SerializeField] int currentScore = 0;
    [SerializeField] bool isAutoPlayEnabled;
    [SerializeField] TextMeshProUGUI scoreText;
    
     SceneLoader sceneLoader;
    // Start is called before the first frame update
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
       
        if (gameStatusCount > 1)
        {
            //gameObject.SetActive(false);//ovo radimo jer mi se ne unisti drugi objekt na vrijeme(Destroy se zove na kraj framea, ali mrvicu kasnije od awake pa budu dva) i kad se trazi gameObjekt moze mi naci taj drugi umjesto prvog koji mi treba
            //Unity je promjenio nacin rada destroya, netreba
            Destroy(gameObject);
     
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            
        }
    }
    void Start()
    {
        
        scoreText.text = currentScore.ToString();
        
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
    public void  ResetGame()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
