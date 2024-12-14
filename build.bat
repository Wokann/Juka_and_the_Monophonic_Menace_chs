@echo on
setlocal enabledelayedexpansion
:: 设置指令路径、工具路径、基础文件名
    set "WorkPath=%~dp0"
    cd /d %WorkPath%

    set "armips_main=.\main.asm"
    set "tool_armips=.\tools\armips\armips.exe"
    set "Test_Date=20241214"

    set "Input_Rom_Name=Juka and the Monophonic Menace (USA) (En,Fr,Es)"
    set "Input_Rom=.\rom\%Input_Rom_Name%.gba"

    set "Output_Rom_Name=Juka and the Monophonic Menace (C)"
    set "Output_Rom=.\rom\%Output_Rom_Name%.gba"
    set "Output_Sym=.\%Output_Rom_Name%.sym"
    set "Output_Temp=.\%Output_Rom_Name%.temp"

    :: 检查原始rom是否存在
    if not exist "%Input_Rom%" (
        @echo "%Input_Rom%" is Not Exist!
	    goto :Exit
    )
    :: armips打补丁
    %tool_armips% %armips_main% ^
        -strequ Input_Rom  "%Input_Rom%" ^
        -strequ Output_Rom "%Output_Rom%" ^
        -sym    "%Output_Sym%" ^
        -temp   "%Output_Temp%" ^
        -stat ^
        -erroronwarning ^
        || (
            @echo Error^^!
            goto :Exit
            )
    @echo armips Patched^^!

    cd .\tools\Final(JuKa)
    "Final(JuKa).exe"
    cd ..\..\
    @echo Final(JuKa) Patched^^!
    del /Q "%Output_Rom%"
    goto :Exit


:Exit
    :: 3秒后自动关闭本窗口
    @echo off
    ping 127.0.0.1 -n 3 >nul

endlocal