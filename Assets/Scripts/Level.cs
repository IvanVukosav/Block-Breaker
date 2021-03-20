using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakableBlocks = 0;
    [SerializeField] public int balls = 0;
    //[SerializeField] SceneLoader sceneLoader;
    SceneLoader sceneLoader;
    public void CountBlocks()
    {
        breakableBlocks++;
    }
    public void CountBalls()
    {
        balls++;
    }

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();//ili prek serialize field kao sto si na ball/ paddle imao
        
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
 
    // Start is called before the first frame update
    /*Moj pokusaj, postoji puno jednostavniji nacin
     * [SerializeField] int breakableBlocks = 0;
    int Total;
      void Start()
    {
        CountBlocks();
    }

    * private void CountBlocks()
     {
       GameObject[] objects = GameObject.FindGameObjectsWithTag("blok");
       foreach(var objekt in objects){
           breakableBlocks++;
       }
      // Debug.Log("value: " + BreakableBlocks);
    }
    private void BrokenBlock()
    {
        //mogu tipa radit jos jedno brojanje i rec ako je manje ovaj se
        //smanji, ali sto dobijem od toga
    }
    void Update()
    {
       
        BrokenBlock();
    }*/
}
