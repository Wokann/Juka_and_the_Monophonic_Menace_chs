.gba
.create Output_Rom,0x08000000
.close
.open Input_Rom,Output_Rom,0x08000000


;字库破解部分
.include ".\src\HookInOrigin\font.s"
.include ".\src\HackFunction\font.s"
;eeprom存档功能修复
.include ".\src\HackFunction\save.s"


;末尾字节填充（eeprom存档修复的一环）
;若不填充满32MB也可，但需要注意以下使用情况
;1、SRAM盗卡烧录时，需确保32MB空间全部擦除，避免0x01FFFF00-0x01FFFFFF最后0x100字节有内容残留
;2、在ezo(de)运行时，由于auto模式读取rom头数据库确定存档类型，无法正常应用修复过的eeprom，解决方法有如下几种：
;  2-1:eeprom修复版rom，将rom头游戏代码改为铸剑3、蜡笔小新等游戏即可(ezo数据库内识别存档模式为0x23)
;  2-2:eeprom修复版rom，进入游戏前设置eeprom8K存档格式打开，且文件大小必须大于0x01200000(小于等于时不会切换为0x23存档模式)
EndHack:
   ;切换填充模式，请更改 IfFill32MB 的定义值
   IfFill32MB    equ   1
   .if (IfFill32MB == 1)
      ;填充满32MB模式
      .fill (0x0A000000 - EndHack),0x00
   .elseif (IfFill32MB == 0)
      ;不填充满32MB模式
      .if (EndHack > 0x09200000)
         .align 16
      .else
         .fill (0x09200010 - EndHack),0x00
      .endif
   .endif

.close