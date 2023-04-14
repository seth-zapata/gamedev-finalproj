using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HistoryHandler : MonoBehaviour
{
    [SerializeField] Dropdown dropdown;
    [SerializeField] List<string> dropdown_items;
    [SerializeField] public Character charScript;
    public void Start(){

        charScript = GameObject.FindObjectOfType(typeof(Character)) as Character;
        dropdown_items = new List<string>();
        Debug.Log("periodt1");
        if (System.String.Equals(PlayerPrefs.GetString("run_duration"),"false")){
            dropdown_items.Add("No games played yet!");
        } else {
            Debug.Log("periodt2");
            var tempString = "";
            for (int i = 0; i < PlayerPrefs.GetString("game_run").Length; i++) {
                //Debug.Log("periodtloop");
                var c = PlayerPrefs.GetString("game_run")[i];
                if (System.String.Equals(c.ToString(), ";")) {
                    Debug.Log(tempString);
                    dropdown_items.Add(tempString);
                    tempString = "";
                } else {
                    tempString = tempString + c.ToString();
                }
            }
            //Debug.Log("true time " + PlayerPrefs.GetString("run_duration"));
            //Debug.Log(PlayerPrefs.GetString("run_duration").Substring(3, 8));
        }
        Debug.Log("periodt3");
        foreach(var item in dropdown_items) {
            var new_option = new Dropdown.OptionData();
            new_option.text = item;

            dropdown = GameObject.Find("DropdownMenu").GetComponent<Dropdown>();
            dropdown.options.Add(new_option);
        }
        dropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(dropdown);});
    }
    public void DropdownItemSelected(Dropdown dropdown) {
        int idx = dropdown.value;


    }
    public void ReturnToMain(){
        SceneManager.LoadScene("MainMenu");
    }

}
