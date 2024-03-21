using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VotePerSecondTimer : MonoBehaviour
{
    public float TimerDuration = 0.5f;
    public double VotesPerSecond { get; set; }
    private float counter;

    private void Update()
    {
        counter += Time.deltaTime;
        if (counter >= TimerDuration)
        {
            VoteManager.instance.SimpleVoteIncrease(VotesPerSecond);
            counter = 0;
        }
    }
}
