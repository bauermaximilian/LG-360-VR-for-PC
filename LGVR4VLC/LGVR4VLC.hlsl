// This is a HLSL shader for the Direct3D9 video output module for VLC,
// which turns a normal video input into a side-by-side image for the
// LG 360 VR glasses.

// Hint: Make sure the encoding is UTF-8 without BOM, or it won't work.

#define PI 3.14159

Texture2D shaderTexture;
SamplerState SampleType;

struct PS_INPUT
{
	float4 Position   : SV_POSITION;
	float2 Texture    : TEXCOORD0;
};

float4 get_eye_view(float2 coordinates, float2 offset, float2 scale, 
	float rotationDeg)
{
	float2 pivot = float2(0.5, 0.5);

	float rotationRad = rotationDeg * PI / 180.0;

	float rotation_sin = sin(rotationRad);
	float rotation_cos = cos(rotationRad);

	float2x2 rotation = float2x2(rotation_cos, -rotation_sin, rotation_sin, 
		rotation_cos);

	float2 origin_coordinates = coordinates - pivot - (offset);
	float2 rotated_coordinates = mul(origin_coordinates, rotation);
	float2 transformed_coordinates = (rotated_coordinates / scale) + pivot;

	if (transformed_coordinates.x >= 0 && transformed_coordinates.x <= 1 &&
		transformed_coordinates.y >= 0 && transformed_coordinates.y <= 1)
		return shaderTexture.Sample(SampleType, transformed_coordinates);
	else return float4(0, 0, 0, 1);
}

float4 main(PS_INPUT In) : SV_TARGET
{
	float4 left = 
		get_eye_view(In.Texture, float2(-0.25, -0.0115), float2(0.95, 0.45), 90); 
	float4 right = 
		get_eye_view(In.Texture, float2(0.25, -0.0115), float2(0.95, 0.45), -90);

	return left + right;
}