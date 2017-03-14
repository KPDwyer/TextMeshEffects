using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorizontalGradientTextEffect : BaseTextMeshEffect {

    public Gradient ColorGrad;

    private float totalAffectedCharacters;

    public override void ModifyMesh(VertexHelper vh)
    {
        //every time the mesh gets reevaluated this is called.

        totalAffectedCharacters = EndIndex - StartIndex;

        base.ModifyMesh(vh);

    }

    protected override List<UIVertex> ProcessCharacters(List<UIVertex> verts, int characterindex)
    {
        int actualIndex = characterindex - StartIndex;

        for (int i = 0; i < 6; i++)
        {
            UIVertex c;
            c = verts[i];
            c.color = ColorGrad.Evaluate((float)actualIndex / totalAffectedCharacters);
            verts[i] = c;
        }

        return base.ProcessCharacters(verts, characterindex);
    }

}
