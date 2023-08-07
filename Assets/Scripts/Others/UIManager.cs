using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public int Score = 0;
    public TextMeshProUGUI ScoreText;

    
    void Start()
    {
        instance = this;
    }

    
    void Update()
    {
        
    }
}
