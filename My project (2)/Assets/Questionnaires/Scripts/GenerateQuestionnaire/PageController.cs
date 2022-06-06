﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// PageController.class
/// 
/// version 1.0
/// date: July 1st, 2020
/// authors: Martin Feick & Niko Kleer
/// </summary>

namespace VRQuestionnaireToolkit
{
    public class PageController : MonoBehaviour
    {
        private GameObject _vrQuestionnaireFactory;

        private PageFactory _pageFactory;
        private GameObject _export;
        public List<GameObject> unansweredMandatoryQuestions;
        public List<MeshRenderer> renders;
        public List<GameObject> planes;

        int plane_amount = 10;

        void hideOrShowPlanes()
        {
            for (int i = 0; i <= plane_amount; i++)
                planes.Add(GameObject.FindGameObjectWithTag(string.Concat("plane", i.ToString())));

            for (int i = 0; i <= plane_amount; i++)
                renders.Add(planes[i].GetComponentInChildren<MeshRenderer>());

            for (int i = 0; i <= plane_amount; i++)
                renders[i].enabled = false;

            int q = PlaneStats.questionaire_no;
            int p = PlaneStats.plane_com[PlaneStats.plane_no];
            if (q == 2)
                renders[0].enabled = true;
            else
                renders[p].enabled = true;
            print(p);
        }

        void Start()
        {
            //init necessary relationships
            _vrQuestionnaireFactory = GameObject.FindGameObjectWithTag("QuestionnaireFactory");

            _export = GameObject.FindGameObjectWithTag("ExportToCSV");
            _pageFactory = _vrQuestionnaireFactory.GetComponent<PageFactory>();
            unansweredMandatoryQuestions = new List<GameObject>();
            hideOrShowPlanes();
        }

        public bool CheckMandatoryQuestionsAnswered()
        {
            int countMandatory = 0;
            int answeredMandatory = 0;

            for (int i = 0; i < _pageFactory.QuestionList.Count; i++)
            {
                if (_pageFactory.GetComponent<PageFactory>().QuestionList[i][0].GetComponentInParent<Radio>() != null)
                {
                    if (_pageFactory.GetComponent<PageFactory>().QuestionList[i][0].GetComponentInParent<Radio>()
                        .QMandatory)
                    {
                        countMandatory++;

                        bool isAnswered = false;
                        for (int j = 0;
                            j < _pageFactory.GetComponent<PageFactory>().QuestionList[i][0].GetComponentInParent<Radio>()
                                .RadioList.Count;
                            j++)
                        {
                            if (_pageFactory.GetComponent<PageFactory>().QuestionList[i][j].GetComponentInChildren<Toggle>().isOn)
                            {
                                isAnswered = true;
                                answeredMandatory++;
                            }
                        }
                        if (!isAnswered) // If this question is not answered yet.
                        {
                            unansweredMandatoryQuestions.Add(_pageFactory.GetComponent<PageFactory>().QuestionList[i][0].transform.parent.Find("QuestionText").gameObject);
                        }
                    }
                }
                else if (_pageFactory.GetComponent<PageFactory>().QuestionList[i][0].GetComponentInParent<RadioGrid>() != null)
                {
                    if (_pageFactory.GetComponent<PageFactory>().QuestionList[i][0].GetComponentInParent<RadioGrid>()
                        .QMandatory)
                    {
                        countMandatory++;

                        bool isAnswered = false;
                        for (int j = 0;
                            j < _pageFactory.GetComponent<PageFactory>().QuestionList[i][0]
                                .GetComponentInParent<RadioGrid>()
                                .RadioList.Count;
                            j++)
                        {
                            if (_pageFactory.GetComponent<PageFactory>().QuestionList[i][j].GetComponentInChildren<Toggle>()
                                .isOn)
                            {
                                isAnswered = true;
                                answeredMandatory++;
                            }
                        }
                        if (!isAnswered) // If this question is not answered yet.
                        {
                            unansweredMandatoryQuestions.Add(_pageFactory.GetComponent<PageFactory>().QuestionList[i][0].transform.parent.Find("ConditionName").gameObject);
                        }
                    }
                }
                else if (_pageFactory.GetComponent<PageFactory>().QuestionList[i][0].GetComponentInParent<Checkbox>() != null)
                {
                    if (_pageFactory.GetComponent<PageFactory>().QuestionList[i][0].GetComponentInParent<Checkbox>() != null)
                    {
                        if (_pageFactory.GetComponent<PageFactory>().QuestionList[i][0].GetComponentInParent<Checkbox>()
                            .QMandatory)
                        {
                            countMandatory++;

                            bool isAnswered = false;
                            for (int j = 0;
                                j < _pageFactory.GetComponent<PageFactory>().QuestionList[i][0].GetComponentInParent<Checkbox>()
                                    .CheckboxList.Count;
                                j++)
                            {
                                if (_pageFactory.GetComponent<PageFactory>().QuestionList[i][j].GetComponentInChildren<Toggle>().isOn)
                                {
                                    isAnswered = true;
                                    answeredMandatory++;
                                }
                            }
                            if (!isAnswered) // If this question is not answered yet.
                            {
                                unansweredMandatoryQuestions.Add(_pageFactory.GetComponent<PageFactory>().QuestionList[i][0].transform.parent.Find("QuestionText").gameObject);
                            }
                        }
                    }
                }
                else if (_pageFactory.GetComponent<PageFactory>().QuestionList[i][0].GetComponentInParent<LinearGrid>() != null)
                {
                    if (_pageFactory.GetComponent<PageFactory>().QuestionList[i][0].GetComponentInParent<LinearGrid>()
                        .QMandatory)
                    {
                        countMandatory++;

                        bool isAnswered = false;
                        for (int j = 0;
                            j < _pageFactory.GetComponent<PageFactory>().QuestionList[i][0].GetComponentInParent<LinearGrid>()
                                .LinearGridList.Count;
                            j++)
                        {
                            if (_pageFactory.GetComponent<PageFactory>().QuestionList[i][j].GetComponentInChildren<Toggle>().isOn)
                            {
                                isAnswered = true;
                                answeredMandatory++;
                            }
                        }
                        if (!isAnswered) // If this question is not answered yet.
                        {
                            unansweredMandatoryQuestions.Add(_pageFactory.GetComponent<PageFactory>().QuestionList[i][0].transform.parent.Find("QuestionText").gameObject);
                        }
                    }
                }
            }

            if (countMandatory - answeredMandatory == 0)
                return true;
            else
                return false;
        }

        /*
         * GoToNextPage method
         *
         * Disables current page and enables next page
         * If the user reaches the final page the "Next" button becomes the "Submit" button with the underlying functionality
         * to call the Save() and Export() Method
         * Verifies that all "mandatory" questions on this page have been answered
         */
        public void GoToNextPage()
        {
            if (CheckMandatoryQuestionsAnswered() || _pageFactory.CurrentPage == 0)
            {
                // _pageFactory.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
                _pageFactory.PageList[_pageFactory.CurrentPage].SetActive(false);
                ++_pageFactory.CurrentPage;
                _pageFactory.PageList[_pageFactory.CurrentPage].SetActive(true);
                if (PlaneStats.questionaire_no!=2)
                    PlaneStats.plane_no ++;
                hideOrShowPlanes();
                //reached second-last page
                if (_pageFactory.PageList.Count - 2 == _pageFactory.CurrentPage)
                {
                    GameObject q_footer = GameObject.Find("Q_Footer");
                    TextMeshProUGUI nextButton = q_footer.GetComponentInChildren<TextMeshProUGUI>();
                    nextButton.text = "Submit";
                }

                if (_pageFactory.PageList.Count - 1 == _pageFactory.CurrentPage)
                {
                    _export.GetComponent<ExportToCSV>().Save();
                }
            }
            else
            {
                foreach (GameObject obj in unansweredMandatoryQuestions) // Make each unanswered question blink in red.
                {
                    StartCoroutine(ChangeTextColor(obj));
                }
                unansweredMandatoryQuestions.Clear();
                //   _pageFactory.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(true);
            }
        }

        /*
         * GoToPreviousPage method
         *
         * Disables current page and enables previous page
         */
        public void GoToPreviousPage()
        {
            _pageFactory.PageList[_pageFactory.CurrentPage].SetActive(true);
            _pageFactory.PageList[_pageFactory.CurrentPage].SetActive(false);
            --_pageFactory.CurrentPage;
            _pageFactory.PageList[_pageFactory.CurrentPage].SetActive(true);
            if (PlaneStats.questionaire_no != 2)
                PlaneStats.plane_no --;
            hideOrShowPlanes();

        }

        IEnumerator ChangeTextColor(GameObject textObj)
        {
            float increment = 0.05f;
            float timer = 0;
            while (timer <= 1)
            {
                timer += increment;
                textObj.GetComponent<TextMeshProUGUI>().color =
                    Color.Lerp(Color.black, Color.red, Mathf.Abs(Mathf.Sin(3 * Mathf.PI * timer))); // blink 3 times from black to red.
                yield return new WaitForSeconds(increment);
            }
        }
    }
}