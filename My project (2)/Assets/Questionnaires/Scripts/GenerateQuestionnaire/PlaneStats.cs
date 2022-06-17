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
        public static int iter = 0;
        public static int questionaire_no = 1;
        public static int firedEvent = 0;
        public static string currentQuestionnaireId = "";

        //Balanced Latin Square
        /*  p1  A   B   H   C   G   D   F   E 
            p2	B	C	A	D	H	E	G	F
            p3	C	D	B	E	A	F	H	G
            p4	D	E	C	F	B	G	A	H
            p5	E	F	D	G	C	H	B	A
            p6	F	G	E	H	D	A	C	B
            p7	G	H	F	A	E	B	D	C
            p8	H	A	G	B	F	C	E	D
        */
        public static int[] vr_scene_order_4_p1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 0 };
        public static int[] vr_scene_order_4_p2 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 0 };
        public static int[] vr_scene_order_4_p3 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 0 };
        public static int[] vr_scene_order_4_p4 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 0 };
        public static int[] vr_scene_order_4_p5 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 0 };
        public static int[] vr_scene_order_4_p6 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 0 };
        public static int[] vr_scene_order_4_p7 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 0 };
        public static int[] vr_scene_order_4_p8 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 0 };

    


        //Set corresponding array for each participant
        public static int[] plane_com = vr_scene_order_4_p1;



    }
}