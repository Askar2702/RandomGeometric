using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class Figure : MonoBehaviour
{
    [SerializeField] double rate;
    [SerializeField] private Color[] color; //for automatic color change
    [SerializeField] string ScriptableName;
    [SerializeField] int touchCount;
    #region Canvas
    [Header("CANVAS")]
    [SerializeField] GameObject panel;
    [SerializeField] Text _name;
    [SerializeField] Text _type;
    [SerializeField] Text _maxClick;
    [SerializeField] Text _minClick;
    [SerializeField] Text _colorText;
    [SerializeField] Image _color;
    [SerializeField] Slider sliderTime;
    [SerializeField] float _time;
    #endregion
    private MeshRenderer mesh;
    private IDisposable _update;
    private FigureScriptable figureScriptable;

    protected item item;
    protected virtual void Start()
    {
        LoadData();
        mesh = GetComponent<MeshRenderer>();
        _update = Observable.Interval(TimeSpan.FromSeconds(rate)).Subscribe(x => 
        {
            mesh.material.color = color[UnityEngine.Random.Range(0, color.Length)];
        });
    }

    protected void Update()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
            sliderTime.value = _time;
            if (_time <= 0)
            {
                if (touchCount > figureScriptable.MinClicksCount && touchCount < figureScriptable.MaxClicksCount)
                {
                    mesh.material.color = figureScriptable.color;
                    Debug.Log("Good");
                }
                _time = 0;
                panel.SetActive(false);
            }
        }
        
    }

    private void OnMouseDown()
    {
        _time = 4;
        touchCount++;
        if (panel.activeSelf) return;
        panel.SetActive(true);
    }
    protected void OnDestroy()
    {
        _update.Dispose();
    }
    
    private void LoadData()
    {
        figureScriptable = Resources.Load(ScriptableName) as FigureScriptable;
        _type.text = figureScriptable.ObjectType;
        _maxClick.text +=" "+ figureScriptable.MaxClicksCount.ToString();
        _minClick.text +=" "+ figureScriptable.MinClicksCount.ToString();
        _color.color = new Color(figureScriptable.color.r, figureScriptable.color.g, figureScriptable.color.b);
        _name.text = name;
    }
}
