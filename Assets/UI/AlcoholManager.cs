using System;
using UnityEngine;
using UnityEngine.UI;

/*
 * @author Matthieu Le Boucher <matt.leboucher@gmail.com> 
 */
namespace UI
{
    public class AlcoholManager : MonoBehaviour
    {
        /*
         * The current user's alcohol rate.
         */
        private float alcoholRate;
        
        /// <inheritdoc />
        public delegate void OnRateChangeDelegate(float newRate);
        
        /*
         * Event triggered whenever the user's alcohol rate changes.
         */
        public event OnRateChangeDelegate OnAlcoholRateChange;

        /*
         * Used for float comparison.
         */
        private const float TOLERANCE = 0.01f;

        /*
         * Encapsulation to track alcohol rate changes.
         */
        private float AlcoholRate
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
        private void Start()
        {
            alcoholRate = 0.5f;
            OnAlcoholRateChange += UpdateUI;
        }

        /// <summary>
        /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // On left click, increase the alcohol rate.
                AlcoholRate += 0.1f;
                
                // Todo: implement the logic of alcohol rate change.
            }
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
}
