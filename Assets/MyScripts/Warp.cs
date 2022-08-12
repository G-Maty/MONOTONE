using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Warp : MonoBehaviour
{
    [SerializeField] private GameObject warpFillAmount;
    [SerializeField] private GameObject warpOut;
    [SerializeField] private AudioClip warpSE;
    private AudioSource audioSource;
    private PlayerMoveMG playerMoveMG;
    private Vector3 warpOutPos = new Vector3(0f,0f,0f);

    // Start is called before the first frame update
    void Start()
    {
        warpFillAmount.transform.DOScale(0f, 1.5f).SetLoops(-1).SetLink(gameObject).Play();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMoveMG = collision.gameObject.GetComponent<PlayerMoveMG>();
            if(playerMoveMG.isWarp == false)
            {
                playerMoveMG.isWarp = true;
            }
            else
            {
                playerMoveMG.isWarp = false;
            }
        }
        audioSource.PlayOneShot(warpSE);
        if(playerMoveMG.isWarp == true)
        {
            warpOutPos = new Vector3(warpOut.transform.position.x, warpOut.transform.position.y, warpOut.transform.position.z);
            collision.transform.position = warpOutPos;
            playerMoveMG.isWarp = true;
        }
    }

}
