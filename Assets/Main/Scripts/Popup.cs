using System.Collections.Generic;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CanvasGroup _questionGroupMain;
    [SerializeField] private CanvasGroup _questionGroup1;
    [SerializeField] private CanvasGroup _questionGroup2;
    [SerializeField] private CanvasGroup _answerGroup1;
    [SerializeField] private CanvasGroup _answerGroup2;
    [SerializeField] private RectTransform  _logo;
    [Space]
    [SerializeField] private Button _enterAnswerButton;
    [SerializeField] private List<Button> _changeAnswerButtons;
    [SerializeField] private List<Button> _backButtons;
    [Header("Settings")]
    [SerializeField] private float _animationDuration = 0.3f;
    
    private bool _isAnimating;
    private int _answerIndex;

    private void Awake()
    {
        _isAnimating = false;
        _answerIndex = 0;
    }

    private void OnEnable()
    {
        _enterAnswerButton.onClick.AddListener(EnterAnswer);
        
        foreach (Button button in _changeAnswerButtons)
        {
            button.onClick.AddListener(ChangeAnswer);
        }

        foreach (Button button in _backButtons)
        {
            button.onClick.AddListener(CloserAnswer);
        }
    }

    private void OnDisable()
    {
        foreach (Button button in _changeAnswerButtons)
        {
            button.onClick.RemoveListener(ChangeAnswer);
        }
    }

    private void ChangeAnswer()
    {
        if (_isAnimating) return;

        _isAnimating = true;
        
        switch (_answerIndex)
        {
            case 0:
                Tween.Alpha(_questionGroup1, 0, _animationDuration)
                    .OnComplete(() =>
                    {
                        _questionGroup1.interactable = false;
                        _questionGroup1.blocksRaycasts = false;

                        Tween.Alpha(_questionGroup2, 1, _animationDuration)
                            .OnComplete(() =>
                            {
                                _questionGroup2.interactable = true;
                                _questionGroup2.blocksRaycasts = true;

                                _answerIndex = 1;
                                _isAnimating = false;
                            });
                    });
                break;
            case 1:
                Tween.Alpha(_questionGroup2, 0, _animationDuration)
                    .OnComplete(() =>
                    {
                        _questionGroup2.interactable = false;
                        _questionGroup2.blocksRaycasts = false;

                        Tween.Alpha(_questionGroup1, 1, _animationDuration)
                            .OnComplete(() =>
                            {
                                _questionGroup1.interactable = true;
                                _questionGroup1.blocksRaycasts = true;
                                
                                _answerIndex = 0;
                                _isAnimating = false;
                            });
                    });
                break;
        }
    }

    private void EnterAnswer()
    {
        if (_isAnimating) return;

        _isAnimating = true;
        
        Tween.Rotation(_logo, Vector3.forward * 180, _animationDuration);
        Tween.Alpha(_questionGroupMain, 0, _animationDuration);
        
        switch (_answerIndex)
        {
            case 0:
                Tween.Alpha(_questionGroup1, 0, _animationDuration)
                    .OnComplete(() =>
                    {
                        _questionGroup1.interactable = false;
                        _questionGroup1.blocksRaycasts = false;

                        Tween.Alpha(_answerGroup1, 1, _animationDuration)
                            .OnComplete(() =>
                            {
                                _answerGroup1.interactable = true;
                                _answerGroup1.blocksRaycasts = true;
                                
                                _isAnimating = false;
                            });
                    });
                break;
            case 1:
                Tween.Alpha(_questionGroup2, 0, _animationDuration)
                    .OnComplete(() =>
                    {
                        _questionGroup2.interactable = false;
                        _questionGroup2.blocksRaycasts = false;

                        Tween.Alpha(_answerGroup2, 1, _animationDuration)
                            .OnComplete(() =>
                            {
                                _answerGroup2.interactable = true;
                                _answerGroup2.blocksRaycasts = true;
                                
                                _isAnimating = false;
                            });
                    });
                break;
        }
    }

    private void CloserAnswer()
    {
        if (_isAnimating) return;

        _isAnimating = true;
        
        Tween.Rotation(_logo, Vector3.forward * 0, _animationDuration);
        Tween.Alpha(_questionGroupMain, 1, _animationDuration);
        
        switch (_answerIndex)
        {
            case 0:
                Tween.Alpha(_answerGroup1, 0, _animationDuration)
                    .OnComplete(() =>
                    {
                        _answerGroup1.interactable = false;
                        _answerGroup1.blocksRaycasts = false;

                        Tween.Alpha(_questionGroup1, 1, _animationDuration)
                            .OnComplete(() =>
                            {
                                _questionGroup1.interactable = true;
                                _questionGroup1.blocksRaycasts = true;
                                
                                _isAnimating = false;
                            });
                    });
                break;
            case 1:
                Tween.Alpha(_answerGroup2, 0, _animationDuration)
                    .OnComplete(() =>
                    {
                        _answerGroup2.interactable = false;
                        _answerGroup2.blocksRaycasts = false;

                        Tween.Alpha(_questionGroup2, 1, _animationDuration)
                            .OnComplete(() =>
                            {
                                _questionGroup2.interactable = true;
                                _questionGroup2.blocksRaycasts = true;
                                
                                _isAnimating = false;
                            });
                    });
                break;
        }
    }
}
