using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Data : MonoBehaviour
{
    public int Time=5;
    private Vector3 vertice;//作为中间传值的顶点vector
    public  Vector3[] vertices;
    private Mesh mesh;
    [Range(0, 10)]
    public float value = 10;//设置高度值
    void Start()
    {
        vertices = GetComponent<MeshFilter>().mesh.vertices;//获取Gameobject meshfilter组件
        mesh = GetComponent<MeshFilter>().mesh;//获取meshfilter组件中mesh数组数据
    }

    void Update()
    {
        for (int i = 0; i < vertices.Length; i++)//遍历数组
        {

            if (vertices[i].y >= 0f)//判断mesh是否为顶部
            {
                vertice.x = vertices[i].x;
                vertice.z = vertices[i].z;
                DOTween.To(() => vertice, x => vertice = x, new Vector3(vertice.x, value, vertice.y), Time);//通过DoTween设置vertice值
                vertices[i]= vertice; //将vertice值传递给vertices[i]
            }
        }
        mesh.vertices = vertices;//刷新
    }
}
