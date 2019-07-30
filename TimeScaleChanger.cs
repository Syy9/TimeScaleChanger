using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Syy.Tools
{
    public class TimeScaleChanger : EditorWindow
    {
        [MenuItem("Window/TimeScaleChanger")]
        public static void Open()
        {
            GetWindow<TimeScaleChanger>("TimeScaleChanger");
        }

        [SerializeField]
        float _timeScale = 1;

        static readonly float[] _presetTimeScales = {
            0.1f,
            0.5f,
            1,
            1.5f,
            2f,
            3f,
            5f,
            10f,
        };

        Vector2 _scrollPos;

        void OnGUI()
        {
            using (var scroll = new EditorGUILayout.ScrollViewScope(_scrollPos))
            {
                _scrollPos = scroll.scrollPosition;

                _timeScale = EditorGUILayout.FloatField("Time Scale", _timeScale);
                if (Application.isPlaying)
                {
                    if (Time.timeScale != _timeScale)
                    {
                        Time.timeScale = _timeScale;
                    }

                    if (GUILayout.Button(EditorApplication.isPaused ? "Resume" : "Pause"))
                    {
                        EditorApplication.isPaused = !EditorApplication.isPaused;
                    }

                    if (GUILayout.Button("Reset TimeScale"))
                    {
                        _timeScale = 1;
                    }

                    EditorGUILayout.LabelField("Preset");
                    foreach (var preset in _presetTimeScales)
                    {
                        DrawPresetButton(preset);
                    }
                }
                else
                {
                    EditorGUILayout.LabelField("Please Game Play");
                }
            }
        }

        void DrawPresetButton(float timeScale)
        {
            if (GUILayout.Button(timeScale.ToString(), GUILayout.Width(100)))
            {
                _timeScale = timeScale;
            }
        }
    }
}
