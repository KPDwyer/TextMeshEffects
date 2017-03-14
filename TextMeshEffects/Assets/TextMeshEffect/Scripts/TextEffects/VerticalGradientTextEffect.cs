using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Text Mesh Effect for Vertical Gradients.
/// </summary>
public class VerticalGradientTextEffect : BaseTextMeshEffect {

    public Color TopColor;
    public Color BottomColor;

    protected override List<UIVertex> ProcessCharacters(List<UIVertex> verts, int characterindex)
    {
        for (int i = 0; i < 6; i++)
        {
            UIVertex c;
            c = verts[i];
            if (i == 0 ||
                i == 1 ||
                i == 5)
            {
                c.color = TopColor;
            }
            else
            {
                c.color = BottomColor;
            }
            verts[i] = c;
        }
        return base.ProcessCharacters(verts,characterindex);
    }

}
