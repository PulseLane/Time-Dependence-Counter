using BeatSaberMarkupLanguage;
using CountersPlus.Custom;
using CountersPlus.Custom.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TimeDependenceCounter
{
	public class TimeDependenceCounter : MonoBehaviour
    {
        private const string _label = "Time Dependence";
        private int _notesA;
        private int _notesB;
        private double _averageA;
        private double _averageB;

        private TextMeshProUGUI _counter;
        //private TextMeshProUGUI _label;
        void Start()
        {
            StartCoroutine(FindScoreController());
            if (Resources.FindObjectsOfTypeAll<CoreGameHUDController>()?.FirstOrDefault(x => x.isActiveAndEnabled) == null)
            {
                Logger.log.Debug("HUD disabled");
                return;
            }
            gameObject.transform.localScale = Vector3.zero;
            Canvas canvas = gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            CanvasScaler cs = gameObject.AddComponent<CanvasScaler>();
            cs.scaleFactor = 10.0f;
            cs.dynamicPixelsPerUnit = 10f;
            gameObject.AddComponent<GraphicRaycaster>();
            gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1f);
            gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1f);
            
            _counter = BeatSaberUI.CreateText(canvas.transform as RectTransform, $"", Vector2.zero);
            _counter.alignment = TextAlignmentOptions.Center;
            //_counter.transform.localScale *= .12f;
            _counter.fontSize = 3f;
            _counter.color = Color.white;
            //_counter.lineSpacing = -50f;
            _counter.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1f);
            _counter.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1f);
            _counter.enableWordWrapping = false;
            //_counter.transform.localPosition = new Vector3(-0.1f, 2.5f, 8f);

            //_label = BeatSaberUI.CreateText(canvas.transform as RectTransform, $"", Vector2.zero);
            //_label.alignment = TextAlignmentOptions.Center;
            //_label.fontSize = 3f;
            //_label.color = Color.white;

            //GameObject labelGO = new GameObject("Time Dependence Counter | Label");
            //labelGO.transform.parent = transform;
            //_label.text = "Time Dependence";

            _notesA = 0;
            _notesB = 0;
            _averageA = 0;
            _averageB = 0;
            UpdateText();
        }

        IEnumerator FindScoreController()
        {
            yield return new WaitUntil(() => Resources.FindObjectsOfTypeAll<BeatmapObjectManager>().Any());

            BeatmapObjectManager scoreController = Resources.FindObjectsOfTypeAll<BeatmapObjectManager>().First();
            Logger.log.Debug("Found score scontroller");
            scoreController.noteWasCutEvent += OnNoteHit;
        }

        public void OnNoteHit(INoteController data, NoteCutInfo info)
        {
            //Logger.log.Debug("Note hit");
            //var x = Utils.sumOfSquares(info.cutNormal);
            Logger.log.Debug(info.cutNormal.ToString());
            //Logger.log.Debug($"{x}");
            //x = Math.Pow(x, -0.5);
            UpdateText(Math.Abs(info.cutNormal.z), info.saberType);
        }

        public void UpdateText(double number, SaberType saberType)
        {
            Logger.log.Debug($"{number}");
            if (saberType == SaberType.SaberA)
            {
                var x = _averageA * _notesA + number;
                _notesA += 1;
                _averageA = x / (double)_notesA;
            }
            else
            {
                var x = _averageB * _notesB + number;
                _notesB += 1;
                _averageB = x / (double)_notesB;
            }

            UpdateText();
        }

        private void UpdateText()
        {
            if (Config.separateSaber)
            {
                var countA = _averageA.ToString($"N{Config.decimalPrecision}");
                var countB = _averageB.ToString($"N{Config.decimalPrecision}");
                _counter.text = $"{_label}\n{countA}  {countB}";
            }
            else
            {
                var average = (_averageA + _averageB) / 2;
                var count = average.ToString($"N{Config.decimalPrecision}");
                _counter.text = $"{_label}\n{count}";
            }
        }
    }
}
