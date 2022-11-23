Shader "Practica/Space"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" }
        Cull off

        Blend SrcAlpha OneMinusSrcAlpha
        Pass
        {
            ZWrite Off
            ColorMask R
            SetTexture[_Color]{combine texture}
        }
       
    }
}