using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CreateAssetMenu(menuName = "Vote Upgrade/Votes Per Second", fileName ="Votes Per Second")]
public class VoteUpgradePerSecond : VoteUpgrade
{
    public override void ApplyUpgrade () {
        GameObject go = Instantiate(VoteManager.instance.votesPerSecondObjToSpawn, Vector3.zero, Quaternion.identity);

        go.GetComponent<VotePerSecondTimer>().VotesPerSecond = UpgradeAmount;

        VoteManager.instance.SimpleVotesPerSecondIncrease(UpgradeAmount);
    }
}
