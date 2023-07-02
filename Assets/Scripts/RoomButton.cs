using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomButton : MonoBehaviour
{
    [SerializeField] private string RoomName;
    [SerializeField] private Image RoomIcon;
    [SerializeField] private Image ButtonImage;
    [SerializeField] private Color ButtonColor;
    [SerializeField] private Color TextColor;
    [SerializeField] private Color RoomIconColor;
    [SerializeField] private TextMeshProUGUI RoomNameText;
    [SerializeField] private TextMeshProUGUI RoomValueText;
    [SerializeField] private TextMeshProUGUI RoomLevelText;
    
    private int RoomValue;
    private int RoomLevel;

    [SerializeField] private int LevelCostMultiplier;
    [SerializeField] private int LevelValueMultiplier;
    [SerializeField] private bool LevelOneIsFree;

    [SerializeField] private Button m_RoomButton;

    [SerializeField] private float iterationTime;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Set Button Color
        ButtonColor.a = 1;
        ButtonImage.color = ButtonColor;
        //Set Text Color
        TextColor.a = 1;
        RoomNameText.color = TextColor;
        RoomValueText.color = TextColor;
        RoomLevelText.color = TextColor;
        //Set Icon Color
        RoomIconColor.a = 1;
        RoomIcon.color = RoomIconColor;

        RoomNameText.text = RoomName;

        RoomLevel = 0;
        RoomValue = 0;

        m_RoomButton.onClick.AddListener(UpgradeRoom);

        StartCoroutine(AccumulateMana());


    }

    // Update is called once per frame
    void Update()
    {
        RoomValue = RoomLevel * LevelValueMultiplier;
        RoomValueText.text = "(" + RoomValue.ToString() + ")";
        int nextCost = 0;
        if (RoomLevel != 0 || !LevelOneIsFree)
        {
            nextCost = (RoomLevel + 1) * LevelCostMultiplier;
        }

        RoomLevelText.text = "Level: " + RoomLevel.ToString() + " Next: " + nextCost.ToString();
    }
    

    void UpgradeRoom()
    {
        if (LevelOneIsFree && RoomLevel == 0)
        {
            RoomLevel++;
            return;
        }

        int targetLevel = RoomLevel + 1;
        int LevelCost = targetLevel * LevelCostMultiplier;

        if (GameManager.manager.StoredMana >= LevelCost)
        {
            RoomLevel++;
            GameManager.manager.StoredMana -= LevelCost;
        }
    }

    IEnumerator AccumulateMana()
    {
        while (true)
        {
            GameManager.manager.IncreaseMana(RoomValue);
            yield return new WaitForSeconds(iterationTime);
        }
    }
    
    
}
