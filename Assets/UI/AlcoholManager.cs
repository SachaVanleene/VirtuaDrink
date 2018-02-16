using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * @author Matthieu Le Boucher <matt.leboucher@gmail.com> 
 */
public class AlcoholManager : MonoBehaviour
{
    public delegate void OnRateChangeDelegate(float newRate);
    public event OnRateChangeDelegate OnAlcoholRateChange;

    private float alcoholRate;

    private static readonly float TOLERANCE = 0.01f;

    public float AlcoholRate
    {
        get
        {
            return alcoholRate;
        }

        set
        {
            if (Math.Abs(alcoholRate - value) < TOLERANCE)
                return;

            alcoholRate = value;

            if (OnAlcoholRateChange != null)
                OnAlcoholRateChange(alcoholRate);
        }
    }

    [Tooltip("The slider reflecting a graphical representation of the alcohol rate.")]
    [SerializeField]
    private Slider slider;

    [Tooltip("The text displaying the alcohol rate.")]
    [SerializeField]
    private Text text;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        alcoholRate = 0.5f;
        OnAlcoholRateChange += UpdateUI;
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            AlcoholRate += 0.1f;
    }

    /// <summary>
    /// Updates the alcohol UI part whenever the rate is updated.
    /// </summary>
    private void UpdateUI(float newRate)
    {
        slider.value = newRate;
        text.text = newRate + " g";
    }
}
