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
        //A1 B2 C3 D4 E5 F6 G7 H8
        /*  p1  A1   B2   H8   C3   G7   D4   F6   E5
            p2	B	C	A	D	H	E	G	F
            p3	C	D	B	E	A	F	H	G
            p4	D	E	C	F	B	G	A	H
            p5	E	F	D	G	C	H	B	A
            p6	F	G	E	H	D	A	C	B
            p7	G	H	F	A	E	B	D	C
            p8	H	A	G	B	F	C	E	D
        */
        public static int[] vr_scene_order_4_p1 = { 0, 1, 2, 8, 3, 7, 4, 6, 5,  0 };
        public static int[] vr_scene_order_4_p2 = { 0, 2, 3, 1, 4, 8, 5, 7, 6,  0 };
        public static int[] vr_scene_order_4_p3 = { 0, 3, 4, 2, 5, 1, 6, 8, 7,  0 };
        public static int[] vr_scene_order_4_p4 = { 0, 4, 5, 3,	6, 2, 7, 1,	8,  0 };
        public static int[] vr_scene_order_4_p5 = { 0, 5, 6, 4,	7, 3, 8, 2,	1,  0 };
        public static int[] vr_scene_order_4_p6 = { 0, 6, 7, 5,	8, 4, 1, 3,	2,  0 };
        public static int[] vr_scene_order_4_p7 = { 0, 7, 8, 6,	1, 5, 2, 4,	3,  0 };
        public static int[] vr_scene_order_4_p8 = { 0, 8, 1, 7,	2, 6, 3, 5,	4,  0 };

    


        //Set corresponding array for each participant
        public static int[] plane_com = vr_scene_order_4_p8;



    }
}