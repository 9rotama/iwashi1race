using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingControl : MonoBehaviour
{
    [SerializeField] private Sprite one,two,three,four,five,six,seven,eight,st,nd,rd,th;
    private Image rankImage;
    private Image thImage;
    private GameObject player;
    private GameObject[] cpuPlayer;
    private int ranking;
    
    void Awake()
    {
        rankImage = this.GetComponent<Image>();
        thImage = this.transform.GetChild(0).GetComponent<Image>();

        player = GameObject.FindGameObjectWithTag("Player");
        cpuPlayer = GameObject.FindGameObjectsWithTag("Enemy");
        
        ranking = 1;
    }
    
    void Update()
    {
        ranking = 0;
        for (int i = 0; i < cpuPlayer.Length; i++)
        {
            if (player.transform.position.x < cpuPlayer[i].transform.position.x)
            {
                ranking++;
            }
        }

        switch (ranking+1)
        {
            case 1:
                rankImage.sprite = one;
                thImage.sprite = st;
                break;
            case 2:
                rankImage.sprite = two;
                thImage.sprite = nd;
                break;
            case 3:
                rankImage.sprite = three;
                thImage.sprite = rd;
                break;
            case 4:
                rankImage.sprite = four;
                thImage.sprite = th;
                break;
            case 5:
                rankImage.sprite = five;
                thImage.sprite = th;
                break;
            case 6:
                rankImage.sprite = six;
                thImage.sprite = th;
                break;
            case 7:
                rankImage.sprite = seven;
                thImage.sprite = th;
                break;
            case 8:
                rankImage.sprite = eight;
                thImage.sprite = th;
                break;
        }

        
    }
}
