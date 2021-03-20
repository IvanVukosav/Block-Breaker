using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params?meh
    [SerializeField] AudioClip BreakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    //blockyType list
    enum BlockType {breakable, unbreakable};//stvori popis
    [SerializeField] BlockType blockType;

    //cached reference
    Level level;

    //state variable
    [SerializeField] int timesHit;//TOOD only serialiazed for debug purposes
    GameStatus gameStatus;

    private void Start()
    {
        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (blockType==BlockType.breakable)
        {
            level.CountBlocks();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (blockType == BlockType.breakable)
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (maxHits <= timesHit)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError(gameObject.name + "Block sprite is missing from array");
        }
    }

    private void DestroyBlock()
    {
        // AudioSource.PlayClipAtPoint(BreakSound, new Vector3(5, 1, 2));
        PlayBlockDestroySFX();
        TriggerSparklesVFX();
        level.BlockDestroyed();
        gameStatus.AddToScore();
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(BreakSound, Camera.main.transform.position);
        Destroy(gameObject);
       
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
