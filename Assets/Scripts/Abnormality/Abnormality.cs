using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abnormality : MonoBehaviour
{
    [SerializeField] private AbnormalityData abnormalityData;

    public AbnormalityData Data
    {
        get
        {
            return abnormalityData;
        }
    }
}