using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public GameObject player;
    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text experienceText;
    public Text goldText;
    //https://youtu.be/e7VEe_qW4oE?t=505
    public void OpenQuestWindow(){
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        experienceText.text = quest.experienceReward.ToString();
        goldText.text = quest.goldReward.ToString();
    }

}
