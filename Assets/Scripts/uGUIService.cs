using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uGUIService : SingletonMonoBehaviour<uGUIService>
{
    [SerializeField] private Text m_privateIPAddressText;
    [SerializeField] private Text m_statusText;

    public Text PrivateIPAddressText
    {
        get { return m_privateIPAddressText; }
        set { m_privateIPAddressText = value; }
    }
    public Text StatusText
    {
        get { return m_statusText; }
        set { m_statusText = value; }
    }

}
