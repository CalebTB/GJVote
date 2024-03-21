using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeUpgrades : MonoBehaviour
{
    public void Initialize(VoteUpgrade[] upgrades, GameObject UIToSpawn, Transform spawnParent) {
        for(int i = 0; i < upgrades.Length; i++) {
            int currentIndex = i;
            GameObject go = Instantiate(UIToSpawn, spawnParent);

            //reset cost
            upgrades[currentIndex].CurrentUpgradeCost = upgrades[currentIndex].OriginalUpgradeCost;

            //set text
            UpgradeButtonScript buttonScript = go.GetComponent<UpgradeButtonScript>();
            buttonScript.UpgradeButtonText.text = upgrades[currentIndex].UpgradeButtonText;
            buttonScript.UpgradeDescriptionText.SetText(upgrades[currentIndex].UpgradeButtonDscription, upgrades[currentIndex].UpgradeAmount);
            buttonScript.UpgradeCostText.text = "Cost: " + upgrades[currentIndex].CurrentUpgradeCost;

            if (UIToSpawn == null)
            {
                Debug.LogError("UIToSpawn is null");
                return;
            }
            if (spawnParent == null)
            {
                Debug.LogError("spawnParent is null");
                return;
            }
            if (upgrades == null)
            {
                Debug.LogError("upgrades array is null");
                return;
            }
            if (upgrades.Length == 0)
            {
                Debug.LogError("upgrades array is empty");
                return;
            }
            // And within the loop, after instantiating 'go':
            if (buttonScript == null)
            {
                Debug.LogError("UpgradeButtonScript not found on instantiated object");
                continue; // Skip this iteration
            }

            //set onClick
            buttonScript.UpgradeButton.onClick.AddListener(delegate {VoteManager.instance.OnUpgradeButtonClick(upgrades[currentIndex], buttonScript);});
        }
    }
}
