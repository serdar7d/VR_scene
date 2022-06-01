using System.Collections;
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
        public GameObject _plane1, _plane2, _plane3, _plane4, _plane5, _plane6, _plane7, _plane8, _plane9, _plane10;
        public MeshRenderer render1, render2, render3, render4, render5, render6, render7, render8, render9, render10;
        private PageFactory _pageFactory;
        private GameObject _export;
        public List<GameObject> unansweredMandatoryQuestions;

        void hideOrShowPlanes()
        {

            _plane1 = GameObject.FindGameObjectWithTag("plane1");
            render1 = _plane1.GetComponentInChildren<MeshRenderer>();
            _plane2 = GameObject.FindGameObjectWithTag("plane2");
            render2 = _plane2.GetComponentInChildren<MeshRenderer>();
            _plane3 = GameObject.FindGameObjectWithTag("plane3");
            render3 = _plane3.GetComponentInChildren<MeshRenderer>();
            _plane4 = GameObject.FindGameObjectWithTag("plane4");
            render4 = _plane4.GetComponentInChildren<MeshRenderer>();
            _plane5 = GameObject.FindGameObjectWithTag("plane5");
            render5 = _plane5.GetComponentInChildren<MeshRenderer>();
            _plane6 = GameObject.FindGameObjectWithTag("plane6");
            render6 = _plane6.GetComponentInChildren<MeshRenderer>();
            _plane7 = GameObject.FindGameObjectWithTag("plane7");
            render7 = _plane7.GetComponentInChildren<MeshRenderer>();
            _plane8 = GameObject.FindGameObjectWithTag("plane8");
            render8 = _plane8.GetComponentInChildren<MeshRenderer>();
            _plane9 = GameObject.FindGameObjectWithTag("plane9");
            render9 = _plane9.GetComponentInChildren<MeshRenderer>();
            _plane10 = GameObject.FindGameObjectWithTag("plane10");
            render10 = _plane10.GetComponentInChildren<MeshRenderer>();

            int p = PlaneStats.plane_no;
            print(p);
            
            if (p == 0)
            {
                render1.enabled = false;
                render2.enabled = false;
                render3.enabled = false;
                render4.enabled = false;
                render5.enabled = false;
                render6.enabled = false;
                render7.enabled = false;
                render8.enabled = false;
                render9.enabled = false;
                render10.enabled = false;


            }
            else if (p == 1)
            {
                render1.enabled = true;
                render2.enabled = false;
                render3.enabled = false;
                render4.enabled = false;
                render5.enabled = false;
                render6.enabled = false;
                render7.enabled = false;
                render8.enabled = false;
                render9.enabled = false;
                render10.enabled = false;
            }
            else if (p == 2)
            {
                render1.enabled = false;
                render2.enabled = true;
                render3.enabled = false;
                render4.enabled = false;
                render5.enabled = false;
                render6.enabled = false;
                render7.enabled = false;
                render8.enabled = false;
                render9.enabled = false;
                render10.enabled = false;
            }
            else if (p == 3)
            {
                render1.enabled = false;
                render2.enabled = false;
                render3.enabled = true;
                render4.enabled = false;
                render5.enabled = false;
                render6.enabled = false;
                render7.enabled = false;
                render8.enabled = false;
                render9.enabled = false;
                render10.enabled = false;
            }
            else if (p == 4)
            {
                render1.enabled = false;
                render2.enabled = false;
                render3.enabled = false;
                render4.enabled = true;
                render5.enabled = false;
                render6.enabled = false;
                render7.enabled = false;
                render8.enabled = false;
                render9.enabled = false;
                render10.enabled = false;
            }
            else if (p == 5)
            {
                render1.enabled = false;
                render2.enabled = false;
                render3.enabled = false;
                render4.enabled = false;
                render5.enabled = true;
                render6.enabled = false;
                render7.enabled = false;
                render8.enabled = false;
                render9.enabled = false;
                render10.enabled = false;
            }
            else if (p == 6)
            {
                render1.enabled = false;
                render2.enabled = false;
                render3.enabled = false;
                render4.enabled = false;
                render5.enabled = false;
                render6.enabled = true;
                render7.enabled = false;
                render8.enabled = false;
                render9.enabled = false;
                render10.enabled = false;
            }
            else if (p == 7)
            {
                render1.enabled = false;
                render2.enabled = false;
                render3.enabled = false;
                render4.enabled = false;
                render5.enabled = false;
                render6.enabled = false;
                render7.enabled = true;
                render8.enabled = false;
                render9.enabled = false;
                render10.enabled = false;
            }
            else if (p == 8)
            {
                render1.enabled = false;
                render2.enabled = false;
                render3.enabled = false;
                render4.enabled = false;
                render5.enabled = false;
                render6.enabled = false;
                render7.enabled = false;
                render8.enabled = true;
                render9.enabled = false;
                render10.enabled = false;
            }
            else if (p == 9)
            {
                render1.enabled = false;
                render2.enabled = false;
                render3.enabled = false;
                render4.enabled = false;
                render5.enabled = false;
                render6.enabled = false;
                render7.enabled = false;
                render8.enabled = false;
                render9.enabled = true;
                render10.enabled = false;
            }
            else if (p == 10)
            {
                render1.enabled = false;
                render2.enabled = false;
                render3.enabled = false;
                render4.enabled = false;
                render5.enabled = false;
                render6.enabled = false;
                render7.enabled = false;
                render8.enabled = false;
                render9.enabled = false;
                render10.enabled = true;
            }
            else 
            {
                render1.enabled = false;
                render2.enabled = false;
                render3.enabled = false;
                render4.enabled = false;
                render5.enabled = false;
                render6.enabled = false;
                render7.enabled = false;
                render8.enabled = false;
                render9.enabled = false;
                render10.enabled = false;
            }

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

            PlaneStats.plane_no--;
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
                    Color.Lerp(Color.black, Color.red, Mathf.Abs(Mathf.Sin(3*Mathf.PI*timer))); // blink 3 times from black to red.
                yield return new WaitForSeconds(increment);
            }
        }
    }
}