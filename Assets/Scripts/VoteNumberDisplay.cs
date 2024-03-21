using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VoteNumberDisplay : MonoBehaviour
{
    public void UpdateVoteText (double voteCount, TextMeshProUGUI textToChange, string optionalEndText = null) {
        string[] suffixes = {"", "k", "M", "B", "T"};
        int index = 0;

        while(voteCount >= 1000 && index < suffixes.Length - 1) {
            voteCount /= 1000;
            index++;

            if(index >= suffixes.Length - 1 && voteCount >= 1000) { break;}

            string formattedText;
            if(index == 0) { 
                formattedText = voteCount.ToString(); 
            }
            else { 
                formattedText = voteCount.ToString("F1") + suffixes[index]; 
            }

            textToChange.text = formattedText + optionalEndText;
        }
    }
}
