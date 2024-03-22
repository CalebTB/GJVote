using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Vote Upgrade/Votes Per Click", fileName ="Votes Per Click")]
public class VoteUpgradePerClick : VoteUpgrade
{
    public override void ApplyUpgrade()
    {
        VoteManager.instance.VotesPerClickUpgrade += UpgradeAmount;
    }
}