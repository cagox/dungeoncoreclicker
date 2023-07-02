using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public int StoredMana;
    public bool GamePaused;

    [SerializeField] private TextMeshProUGUI ManaText;
    
    
    void Awake()
    {
        if (manager != null && manager != this)
        {
            Destroy(this);
        }
        else
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        StoredMana = 0;
        GamePaused = false;
    }

    public void IncreaseMana(int value)
    {
        StoredMana += value;
    }

    void Update()
    {
        ManaText.text = "Mana: " + StoredMana.ToString();
    }
    
    
}
