using HarmonyLib;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TestingMod.Patches;

[HarmonyPatch(typeof(MainMenuController))]
public class MainMenuControllerPatch{
    private static bool isExiting;
    
    [HarmonyPatch("ExitGame")]
    [HarmonyPrefix]
    static bool PatchExitGame(){
        ButtonController saveGameButton = MainMenuController.Instance.saveGameButton;
        if (isExiting){
            return true;
        }

        isExiting = true;
        PointerEventData data = new PointerEventData(null);
        saveGameButton.OnSelect();
        saveGameButton.OnPointerUp(data);
        saveGameButton.OnPointerClick(data);
        return false;
    }
}