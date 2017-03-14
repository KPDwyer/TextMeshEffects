using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WobblyTextEffect : BaseTextMeshEffect {

    public float Speed;
    public float Density;
    public float Magnitude;

    public bool AutoUpdate = true;

    private Text m_text;

    protected override void Start()
    {
        m_text = GetComponent<Text>();
        base.Start();
    }

    protected override List<UIVertex> ProcessCharacters(List<UIVertex> verts, int characterindex)
    {
        for (int i = 0; i < verts.Count; i++)
        {
            UIVertex c = verts[i];
            c.position = c.position + new Vector3(1, Magnitude * Mathf.Sin((Time.timeSinceLevelLoad * Speed) + (characterindex * Density)), 1);
            verts[i] = c;

        }

        return base.ProcessCharacters(verts, characterindex);
    }

    public void UpdateWobble()
    {
        m_text.SetVerticesDirty();
    }

    void Update()
    {
        if (AutoUpdate)
        {
            UpdateWobble();
        }
    }


}
