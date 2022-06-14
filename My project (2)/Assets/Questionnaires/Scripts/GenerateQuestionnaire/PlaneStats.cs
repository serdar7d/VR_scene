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
    public static class PlaneStats 
    {
        public static int[] plane_com1 = { 0, 2, 6, 1, 4, 3, 9, 8, 5, 10, 7, 0 };
        public static int[] plane_com2 = { 0, 1, 5, 2, 4, 3, 6, 8, 7, 10, 9, 0 };
        public static int[] plane_com3 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 0 };
        public static int[] plane_com = plane_com3;
        public static int plane_no = 0;
        public static int questionaire_no = 1;
        public static int firedEvent = 0;
    }
}