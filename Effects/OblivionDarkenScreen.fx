sampler uImage0 : register(s0);
sampler uImage1 : register(s1);
sampler uImage2 : register(s2);
sampler uImage3 : register(s3);
float3 uColor;
float3 uSecondaryColor;
float2 uScreenResolution;
float2 uScreenPosition;
float2 uTargetPosition;
float2 uDirection;
float uOpacity;
float uTime;
float uIntensity;
float uProgress;
float2 uImageSize1;
float2 uImageSize2;
float2 uImageSize3;
float2 uImageOffset;
float uSaturation;
float4 uSourceRect;
float2 uZoom;

float4 OblivionDarkenScreen(float2 coords : TEXCOORD0) : COLOR0
{
    // vignette effect from https://www.shadertoy.com/view/4lSXDm
    float4 color = tex2D(uImage0, coords);
    float2 coord = (coords - 0.5) * (uScreenResolution.x/uScreenResolution.y) * 2.0;

    float rf = sqrt(dot(coord, coord)) * (0.35 * uOpacity);
    float rf2_1 = rf * rf + 1;
    float e = 1 / (rf2_1 * rf2_1);

    float4 src = 1;
    float4 vig = float4(src.rgb * e, 1.0) * 0.7;
    float4 colorBackground = color * (1 - (0.7f * uOpacity)) + (color * float4(uColor, 1) * uOpacity * 4);

    return colorBackground * vig * color.a;
}

technique Technique1
{
    pass OblivionDarkenScreen
    {
        PixelShader = compile ps_2_0 OblivionDarkenScreen();
    }
}