using UnityEngine;
using UnityEngine.UI;

namespace TrashBucked.Scripts
{
    public sealed class DisplayBonuses
    {
        private Text _text;
        public static int WinPoints;

        public DisplayBonuses()
        {
            _text = Object.FindObjectOfType<Text>();
            WinPoints = 0;
        }

        public void CheckPoints(int value)
        {
            WinPoints += value;
            _text.text = $"Your score: {WinPoints}";
        }
    }
}