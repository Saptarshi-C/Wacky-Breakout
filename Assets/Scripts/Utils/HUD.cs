using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    #region Fields

    [SerializeField]
    GameObject ballsLeftGameObject;
    [SerializeField]
    GameObject scoreGameObject;

    const string ballsLeftPrefix = "Balls Left: ";
    static Text ballsLeftText;
    static int ballsLeft = 0;

    const string scorePrefix = "Score: ";
    static Text scoreText;
    static int score = 0;

    LastBallLostEvent lastBallLostEvent = new LastBallLostEvent();

    #endregion

    #region Properties
    public int Score
    {
        get { return score; }
    }
    #endregion

    #region Methods

    void Start()
    {
        ballsLeft = ConfigurationUtils.BallsPerGame;
        ballsLeftText = ballsLeftGameObject.GetComponent<Text>();
        ballsLeftText.text = ballsLeftPrefix + ballsLeft.ToString();

        score = 0;
        scoreText = scoreGameObject.GetComponent<Text>();
        scoreText.text = scorePrefix + score.ToString();

        EventManager.AddBallLostListener(BallLost);
        EventManager.AddPointsAddedListener(BlockLost);

        EventManager.AddLastBallLostInvoker(this);

    }

    void Update()
    {

    }

    public void AddLastBallLostListener(UnityAction listener)
    {
        lastBallLostEvent.AddListener(listener);
    }

    /// <summary>
    /// Called on block destruction. Adds the value of the block to the score.
    /// </summary>
    void BlockLost(int blockPoints)
    {
        score += blockPoints;
        scoreText.text = scorePrefix + score.ToString();
    }

    /// <summary>
    /// Called when ball leaves the screen. Reduces balls left.
    /// </summary>
    void BallLost()
    {
        ballsLeft--;
        ballsLeftText.text = ballsLeftPrefix + ballsLeft.ToString();
        if (ballsLeft == 0)
        {
            lastBallLostEvent.Invoke();
        }
    }

    #endregion
}
