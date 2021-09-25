using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Checkers_Board : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 scaleChange;
    private float offsetx = -4;
    private float offsetz = -4;
    [SerializeField] public float[,] position = new float[8, 8];
    void createPiece(int n, int m, int oddRow = 0, bool isBrown = true)
    {
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.position = new Vector3(0 + 2 * n + offsetx + oddRow, 0.5f, m + offsetz);
        position[(int)(m + offsetz + 4f), (int)(0 + 2 * n + offsetx + oddRow + 4f)] = 1;
        scaleChange = new Vector3(0.8f, 0.2f, 0.8f);
        cylinder.transform.localScale = scaleChange;

        if (isBrown)
            cylinder.GetComponent<Renderer>().material.color = new Color32(147, 48, 48, 255);
        else
            cylinder.GetComponent<Renderer>().material.color = Color.white;
    }
    void createBoard(int row, int col, bool isRed = false)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(row + offsetx, 0, col + offsetz);

        if (isRed)
            cube.GetComponent<Renderer>().material.color = Color.red;
        else
            cube.GetComponent<Renderer>().material.color = Color.black;
    }

    void Start()
    {
        for (int col = 0; col < 8; col++)
        {
            for (int row = 0; row < 8; row++)
            {
                if ((col + row) % 2 == 1)
                    createBoard(row, col, true);
                else
                    createBoard(row, col, false);
                position[col, row] = 0;
            }

        }

        for (int col = 0; col < 4; col++)
        {
            for (int row = 0; row < 3; row++)
            {
                if (row % 2 == 1)
                    createPiece(col, row, 1);
                else
                    createPiece(col, row);


            }

        }

        for (int col = 0; col < 4; col++)
        {
            for (int row = 5; row < 8; row++)
            {
                if (row % 2 == 1)
                    createPiece(col, row, 1, false);
                else
                    createPiece(col, row, 0, false);

            }

        }
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (count % 2 == 0)
                    //position[i, j] = 1;
                    count++;
                //print(position[i, j]);
            }
        }
        int[,] floorMapArray = new int[4, 4];

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < position.GetLength(1); i++)
        {
            for (int j = 0; j < position.GetLength(0); j++)
            {
                sb.Append(position[i, j]);
                sb.Append(' ');
            }
            sb.AppendLine();
        }
        Debug.Log(sb.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
