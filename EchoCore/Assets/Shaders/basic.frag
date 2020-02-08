#version 460 core

out vec4 aColor;
in vec2 texCoord;

uniform sampler2D uTexture;

void main()
{
	aColor = texture(uTexture, texCoord);
}