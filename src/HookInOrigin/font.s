
.org 0x08006232
    ldr r5,=FontHack_3|1
    bx r5
    nop
 .pool

.org 0x08009294
    ldr r5,=FontHack_4|1
    bx r5
 .pool

.org 0x08016DE8
    ldr r0,=FontHack_2|1
    bx r0
 .pool

.org 0x0801AFC0
    ldr r3,=FontHack_1|1
    bx r3
 .pool

.org 0x0801B072
    b 0x0801B07A

.org 0x0802B8A4
    b 0x0802B8D4

.org 0x0820E128
    .word FontBig ;0x09000000       ;=old 0x08F78D00  + 0x087300
    .word FontBig_offset ;0x0913C710       ;=old 0x090B5410  + 0x087300

.org 0x0820E164
    .word FontSmall ;0x0913F034       ;=old 0x090B7D34  + 0x087300
    .word FontSmall_offset ;0x0916D7E8       ;=old 0x090E64E8  + 0x087300

.org 0x0821C440
    .byte 0x02,0x07,0x08,0x0D,0x04,0x12,0x04,0xFF
    ;小字字符串"CHINESE"
