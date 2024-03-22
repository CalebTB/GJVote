using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class VoteManager : MonoBehaviour
{

    public static VoteManager instance ;
    public GameObject MainGameCanvas;

    [SerializeField] private GameObject upgradeCanvas;
    [SerializeField] private TextMeshProUGUI voteCountText;
    [SerializeField] private TextMeshProUGUI votesPerSecondText;
    [SerializeField] private GameObject voteObj;

    public GameObject votePopUpText;
    [SerializeField] private GameObject backgroundObj;

    [Space]
    public VoteUpgrade[] VoteUpgrades;
    [SerializeField] private GameObject upgradeUiToSpawn;
    [SerializeField] private Transform upgradeUiParent;
    public GameObject votesPerSecondObjToSpawn;

    public double CurrentVoteCount { get; set; }
    public double CurrentVotesPerSecond { get; set; }

    //upgrades
    public double VotesPerClickUpgrade { get; set; }
    private InitializeUpgrades initializeUpgrades;

    //AudioSource
    AudioSource upgradeAudio;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        UpdateVoteUI();
        UpdateVotesPerSecondUI();

        initializeUpgrades = GetComponent<InitializeUpgrades>();
        initializeUpgrades.Initialize(VoteUpgrades, upgradeUiToSpawn, upgradeUiParent);
    }
    
    #region On Vote Clicked

    public void OnVoteClicked () {
        IncreaseVote();

        voteObj.transform.DOBlendableScaleBy
        (new Vector3(0.05f, 0.05f, 0.05f), 0.05f).OnComplete(VoteScaleBack);

        backgroundObj.transform.DOBlendableScaleBy
        (new Vector3(0.05f, 0.05f, 0.05f), 0.05f).OnComplete(BackgroundScaleBack);
    }

    private void VoteScaleBack () {
        voteObj.transform.DOBlendableScaleBy(new Vector3(-0.05f, -0.05f, -0.05f), 0.05f);
    }

    private void BackgroundScaleBack () {
        backgroundObj.transform.DOBlendableScaleBy(new Vector3(-0.05f, -0.05f, -0.05f), 0.05f);
    }
    public void IncreaseVote () {
        CurrentVoteCount += 1 + VotesPerClickUpgrade;
        UpdateVoteUI();
    }

    #endregion

    #region UI Updates

    private void UpdateVoteUI() {
        voteCountText.text = CurrentVoteCount.ToString("F1");
    }

    private void UpdateVotesPerSecondUI() {
        votesPerSecondText.text = CurrentVotesPerSecond.ToString() + " Votes/S";
    }

    #endregion

    #region Simple Increases

    public void SimpleVoteIncrease(double amount) {
        CurrentVoteCount += amount;
        UpdateVoteUI();
    }

    public void SimpleVotesPerSecondIncrease(double amount) {
        CurrentVotesPerSecond += amount;
        UpdateVotesPerSecondUI();
    }

    #endregion

    #region ButtonEvents

    public void OnUpgradeButtonClick(VoteUpgrade upgrade, UpgradeButtonScript buttonScript) {
        if (CurrentVoteCount >= upgrade.CurrentUpgradeCost) {
            upgrade.ApplyUpgrade();
            upgradeAudio = GetComponent<AudioSource>();
            upgradeAudio.Play();

            CurrentVoteCount -= upgrade.CurrentUpgradeCost;
            UpdateVoteUI();

            upgrade.CurrentUpgradeCost = Mathf.Round((float)(upgrade.CurrentUpgradeCost * (1 + upgrade.CostIncreaseMultiplierPerPurchase)));
            buttonScript.UpgradeCostText.text = "Cost: " + upgrade.CurrentUpgradeCost;
        }
    }

    #endregion

    #region Endstate 

    public void EndGameButton() {
        if(CurrentVoteCount >= 1000000000000) {
            //Change to a win menu
            SceneManager.LoadScene(2);
        }
    }

    #endregion

}
