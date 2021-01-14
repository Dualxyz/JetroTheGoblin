using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable] //Unity makes this inheritable? / displays it into the inspector
public class Quest {
    public bool isActive;
    public string title;
    public string description;
    public int experienceReward;
    public int goldReward;
}
