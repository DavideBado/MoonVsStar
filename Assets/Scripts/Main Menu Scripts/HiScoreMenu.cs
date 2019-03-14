using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiScoreMenu : MonoBehaviour
{
    List<int> HIscoreList = new List<int>();
    public GameObject HiScoreCanvas;
    public void OpenHiScore()
    {
        if(HIscoreList.Count > 0)
        {
            HiScoreCanvas.SetActive(true);            
        }
    }
}
