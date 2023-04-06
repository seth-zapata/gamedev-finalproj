using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreHandler : MonoBehaviour
{
    [SerializeField] private ScoreUpdate scoreUpdate;
    [SerializeField] private GameObject warningObject;
    [SerializeField] private GameObject scoreTextObject;
    [SerializeField] private GameObject speedUpgradeCountObject;
    [SerializeField] private GameObject strengthUpgradeCountObject;
    [SerializeField] private GameObject armorUpgradeCountObject;
    [SerializeField] private GameObject healthUpgradeCountObject;
    [SerializeField] private GameObject shieldUpgradeCountObject;
    [SerializeField] private GameObject reviveUpgradeCountObject;



    [SerializeField] public Text totalPoints;
    [SerializeField] public Text speedUpgrades;
    [SerializeField] public Text strengthUpgrades;
    [SerializeField] public Text armorUpgrades;
    [SerializeField] public Text healthUpgrades;
    [SerializeField] public Text shieldUpgrades;
    [SerializeField] public Text reviveUpgrades;

    [SerializeField] private List<string> skillNames;
    public void ReturnToMain(){
        SceneManager.LoadScene("MainMenu");
    }
    public void Start(){
        string[] input = {"speed_upgrades", "strength_upgrades", "armor_upgrades", "health_upgrades", "shield_upgrades", "revive_upgrades"};
        skillNames.AddRange(input);

        warningObject = GameObject.Find("Warning");
        warningObject.GetComponent<Text>().enabled = false;

        scoreTextObject = GameObject.Find("Total points");
        totalPoints = scoreTextObject.GetComponent<Text>();
        totalPoints.text = "Available points to spend: " + PlayerPrefs.GetInt("score").ToString();

        speedUpgradeCountObject = GameObject.Find("Speed Upgrade Count");
        speedUpgradeCountObject.GetComponent<Text>().text = PlayerPrefs.GetInt("speed_upgrades").ToString() + "/4";

        strengthUpgradeCountObject = GameObject.Find("Strength Upgrade Count");
        strengthUpgrades = strengthUpgradeCountObject.GetComponent<Text>();
        strengthUpgrades.text = PlayerPrefs.GetInt("strength_upgrades").ToString() + "/4";

        armorUpgradeCountObject = GameObject.Find("Armor Upgrade Count");
        armorUpgrades = armorUpgradeCountObject.GetComponent<Text>();
        armorUpgrades.text = PlayerPrefs.GetInt("armor_upgrades").ToString() + "/4";

        healthUpgradeCountObject = GameObject.Find("Health Upgrade Count");
        healthUpgrades = healthUpgradeCountObject.GetComponent<Text>();
        healthUpgrades.text = PlayerPrefs.GetInt("health_upgrades").ToString() + "/4";

        shieldUpgradeCountObject = GameObject.Find("Shield Upgrade Count");
        shieldUpgrades = shieldUpgradeCountObject.GetComponent<Text>();
        shieldUpgrades.text = PlayerPrefs.GetInt("shield_upgrades").ToString() + "/4";

        reviveUpgradeCountObject = GameObject.Find("Revive Upgrade Count");
        reviveUpgrades = reviveUpgradeCountObject.GetComponent<Text>();
        reviveUpgrades.text = PlayerPrefs.GetInt("revive_upgrades").ToString() + "/4";

    }
    public void upgradeSpeedSkill() {
        if (PlayerPrefs.GetInt("speed_upgrades") == 4) {
            warningObject.GetComponent<Text>().text = "Speed skill is maxed out!";
            warningObject.GetComponent<Text>().enabled = true;
        } else {
            if (PlayerPrefs.GetInt("score") >= 1) {
                PlayerPrefs.SetInt("speed_upgrades", PlayerPrefs.GetInt("speed_upgrades") + 1);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 1);
                totalPoints.text = "Available points to spend: " + PlayerPrefs.GetInt("score").ToString();
                speedUpgrades = speedUpgradeCountObject.GetComponent<Text>();
                speedUpgrades.text = PlayerPrefs.GetInt("speed_upgrades").ToString() + "/4";
            }
        }
    }
    public void upgradeStrengthSkill() {
        if (PlayerPrefs.GetInt("strength_upgrades") == 4) {
            warningObject.GetComponent<Text>().text = "Strength skill is maxed out!";
            warningObject.GetComponent<Text>().enabled = true;
        } else {
            if (PlayerPrefs.GetInt("score") >= 1) {
                PlayerPrefs.SetInt("strength_upgrades", PlayerPrefs.GetInt("strength_upgrades") + 1);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 1);
                totalPoints.text = "Available points to spend: " + PlayerPrefs.GetInt("score").ToString();
                strengthUpgrades = strengthUpgradeCountObject.GetComponent<Text>();
                strengthUpgrades.text = PlayerPrefs.GetInt("strength_upgrades").ToString() + "/4";
            }
        }
    }
    public void upgradeArmorSkill() {
        if (PlayerPrefs.GetInt("armor_upgrades") == 4) {
            warningObject.GetComponent<Text>().text = "Armor skill is maxed out!";
            warningObject.GetComponent<Text>().enabled = true;
        } else {
            if (PlayerPrefs.GetInt("score") >= 1) {
                PlayerPrefs.SetInt("armor_upgrades", PlayerPrefs.GetInt("armor_upgrades") + 1);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 1);
                totalPoints.text = "Available points to spend: " + PlayerPrefs.GetInt("score").ToString();
                armorUpgrades = armorUpgradeCountObject.GetComponent<Text>();
                armorUpgrades.text = PlayerPrefs.GetInt("armor_upgrades").ToString() + "/4";
            }
        }
    }
    public void upgradeHealthSkill() {
        if (PlayerPrefs.GetInt("health_upgrades") == 4) {
            warningObject.GetComponent<Text>().text = "Health skill is maxed out!";
            warningObject.GetComponent<Text>().enabled = true;
        } else {
            if (PlayerPrefs.GetInt("score") >= 1) {
                PlayerPrefs.SetInt("health_upgrades", PlayerPrefs.GetInt("health_upgrades") + 1);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 1);
                totalPoints.text = "Available points to spend: " + PlayerPrefs.GetInt("score").ToString();
                healthUpgrades = healthUpgradeCountObject.GetComponent<Text>();
                healthUpgrades.text = PlayerPrefs.GetInt("health_upgrades").ToString() + "/4";
            }
        }
    }
    public void upgradeShieldSkill() {
        if (PlayerPrefs.GetInt("shield_upgrades") == 4) {
            warningObject.GetComponent<Text>().text = "Shield skill is maxed out!";
            warningObject.GetComponent<Text>().enabled = true;
        } else {
            if (PlayerPrefs.GetInt("score") >= 1) {
                PlayerPrefs.SetInt("shield_upgrades", PlayerPrefs.GetInt("shield_upgrades") + 1);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 1);
                totalPoints.text = "Available points to spend: " + PlayerPrefs.GetInt("score").ToString();
                shieldUpgrades = shieldUpgradeCountObject.GetComponent<Text>();
                shieldUpgrades.text = PlayerPrefs.GetInt("shield_upgrades").ToString() + "/4";
            }
        }
    }
    public void upgradeReviveSkill() {
        if (PlayerPrefs.GetInt("revive_upgrades") == 4) {
            warningObject.GetComponent<Text>().text = "Revive skill is maxed out!";
            warningObject.GetComponent<Text>().enabled = true;
        } else {
            if (PlayerPrefs.GetInt("score") >= 1) {
                PlayerPrefs.SetInt("revive_upgrades", PlayerPrefs.GetInt("revive_upgrades") + 1);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 1);
                totalPoints.text = "Available points to spend: " + PlayerPrefs.GetInt("score").ToString();
                reviveUpgrades = reviveUpgradeCountObject.GetComponent<Text>();
                reviveUpgrades.text = PlayerPrefs.GetInt("revive_upgrades").ToString() + "/4";
            }
        }
    }
    public void refundSkillPoints() {
        foreach (var name in skillNames) {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + PlayerPrefs.GetInt(name));
            PlayerPrefs.SetInt(name, 0);
            totalPoints.text = "Available points to spend: " + PlayerPrefs.GetInt("score").ToString();
        }
        speedUpgradeCountObject.GetComponent<Text>().text = "0/4";
        strengthUpgradeCountObject.GetComponent<Text>().text = "0/4";
        armorUpgradeCountObject.GetComponent<Text>().text = "0/4";
        healthUpgradeCountObject.GetComponent<Text>().text = "0/4";
        shieldUpgradeCountObject.GetComponent<Text>().text = "0/4";
        reviveUpgradeCountObject.GetComponent<Text>().text = "0/4";
    }
}
