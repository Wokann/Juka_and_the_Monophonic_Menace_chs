## gba_EEPROM_reverse

本工具用于将gba游戏的eeprom存档进行64位正反序转换。
不同模拟器、烧录卡或存档导出导入工具生成的eeprom存档格式不同，可能为正序，可能为反序，不同顺序的存档无法在相反顺序的模拟器、烧录卡或存档导出导入工具上读取或写入。
本工具用于将存档进行正反序转换，以适应存档在不同模拟器、烧录卡或存档导出导入工具间使用的需要。

以下是部分模拟器或烧录卡正反序的情况：
正序：
    no$gba, FlashManager, open_agb_firm(3ds), ……
反序：
    vba, mgba, ezo, ezode, gbarunner2, gba_backup_tool(nds), ……

使用方法：
1、将你需要转换的eeprom存档文件用鼠标选中，并拖拽至本工具exe上，即可自动生成带有后缀的转换后的文件。
2、也可使用命令行：gba_EEPROM_reverse.exe (需要转换的文件（含路径）)


本工具由卧看微尘制作。