using CountersPlus.Counters.Custom;
using CountersPlus.Counters.Interfaces;
using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace TimeDependenceCounter
{
    public class TimeDependenceCounter : BasicCustomCounter, INoteEventHandler
    {
        private int _notesLeft;
        private int _notesRight;

        private double _averageLeft;
        private double _averageRight;

        private TMP_Text _counterLeft;
        private TMP_Text _counterRight;

        public override void CounterInit()
        {
            string defaultValue = FormatTimeDependence(0, GetDecimals());
            var label = CanvasUtility.CreateTextFromSettings(Settings);
            label.text = "Time Dependence";
            label.fontSize = 3;

            Vector3 leftOffset = Vector3.up * -0.2f;
            TextAlignmentOptions leftAlign = TextAlignmentOptions.Top;
            if (Configuration.Instance.separateSaber)
            {
                _counterRight = CanvasUtility.CreateTextFromSettings(Settings, new Vector3(0.2f, -0.2f, 0));
                _counterRight.lineSpacing = -26;
                _counterRight.text = defaultValue;
                _counterRight.alignment = TextAlignmentOptions.TopLeft;

                leftOffset = new Vector3(-0.2f, -0.2f, 0);
                leftAlign = TextAlignmentOptions.TopRight;
            }

            _counterLeft = CanvasUtility.CreateTextFromSettings(Settings, leftOffset);
            _counterLeft.lineSpacing = -26;
            _counterLeft.text = defaultValue;
            _counterLeft.alignment = leftAlign;
        }

        public void OnNoteMiss(NoteData data) { }

        public void OnNoteCut(NoteData data, NoteCutInfo info)
        {
            if (data.colorType == ColorType.None || !info.allIsOK) return;
            UpdateText(Math.Abs(info.cutNormal.z), info.saberType);
        }

        public void UpdateText(double timeDependence, SaberType saberType)
        {
            timeDependence = Configuration.Instance.multiply ? timeDependence * 100 : timeDependence;
            if (saberType == SaberType.SaberA)
            {
                var x = _averageLeft * _notesLeft + timeDependence;
                _notesLeft += 1;
                _averageLeft = x / (double)_notesLeft;
            }
            else
            {
                var x = _averageRight * _notesRight + timeDependence;
                _notesRight += 1;
                _averageRight = x / (double)_notesRight;
            }

            UpdateText();
        }

        private void UpdateText()
        {
            if (Configuration.Instance.separateSaber)
            {
                _counterLeft.text = FormatTimeDependence(_averageLeft, GetDecimals());
                _counterRight.text = FormatTimeDependence(_averageRight, GetDecimals());
            }
            else
            {
                var average = (_averageLeft + _averageRight) / 2;
                _counterLeft.text = FormatTimeDependence(average, GetDecimals());
            }
        }

        private string FormatTimeDependence(double timeDependence, int decimals)
        {
            return timeDependence.ToString($"F{decimals}", CultureInfo.InvariantCulture);
        }

        private int GetDecimals()
        {
            return Configuration.Instance.multiply ? Math.Max(Configuration.Instance.decimalPrecision - 2, 0) : Configuration.Instance.decimalPrecision;
        }

        public override void CounterDestroy() { }
    }
}
