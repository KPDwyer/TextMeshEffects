using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// Provides functionality specific to Text Components
/// </summary>
public class BaseTextMeshEffect : BaseMeshEffect  {

    public int StartIndex;
    public int EndIndex;

    List<UIVertex> vertices = new List<UIVertex>();
    List<UIVertex> newVerts = new List<UIVertex>();



    public override void ModifyMesh(VertexHelper vh)
    {
        vertices.Clear();
        newVerts.Clear();
        vh.GetUIVertexStream(vertices);

        for (int i = 0; i < (vertices.Count / 6); i++)
        {
            if (i >= StartIndex && i < EndIndex)
            {
                newVerts.AddRange(ProcessCharacters(vertices.GetRange(i * 6, 6), i));
            }
            else
            {
                newVerts.AddRange(vertices.GetRange(i * 6, 6));
            }
        }

        vh.Clear();
        vh.AddUIVertexTriangleStream(newVerts);
    }


    /// <summary>
    /// Override this to apply style to appropriate characters
    /// </summary>
    /// <param name="verts">Oredered list of 6 verts representing a single character in the string</param>
    /// <param name="characterindex">index of character in string</param>
    /// <returns></returns>
    protected virtual List<UIVertex> ProcessCharacters(List<UIVertex> verts, int characterindex)
    {
        return verts;
    }


}
