using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class RebindingDown : MonoBehaviour
{
    [SerializeField] public InputActionReference actionRebind = null;
    [SerializeField] public GameObject startRebindObj = null;
    [SerializeField] public GameObject waitingforInputObj = null;
    [SerializeField] public TextMeshProUGUI button_text;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    public void Start() {
        startRebindObj.GetComponentInChildren<TextMeshProUGUI>().text = PlayerPrefs.GetString("DownRebind");
    }
    public void startRebind() {

        startRebindObj.SetActive(false);
        waitingforInputObj.SetActive(true);

        Debug.Log(startRebindObj.name);
        var bindingIndex = actionRebind.action.bindings.IndexOf(x=>x.isPartOfComposite && x.name==startRebindObj.name);
        rebindingOperation = actionRebind.action.PerformInteractiveRebinding().WithTargetBinding(bindingIndex)
        .OnMatchWaitForAnother(0.1f).WithExpectedControlType("Button")
        .OnComplete(operation => CompleteRebind()).Start();
    }

    public void CompleteRebind() {
        int bindingIdx = actionRebind.action.bindings.IndexOf(x=>x.isPartOfComposite && x.name==startRebindObj.name);
        button_text = startRebindObj.GetComponentInChildren<TextMeshProUGUI>();

        button_text.text = InputControlPath.ToHumanReadableString(
            actionRebind.action.bindings[bindingIdx].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);

        PlayerPrefs.SetString("DownRebind", button_text.text);

        rebindingOperation.Dispose();
        startRebindObj.SetActive(true);
        waitingforInputObj.SetActive(false);


    }
    public void BacktoSettings() {
        SceneManager.LoadScene("AdjustSettings");
    }
}
