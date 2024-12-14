
.org 0x08209EDA
.func FontHack_1
 @@CheckAddress:    ;0x08209EDA
    ldr r3,[pc,0x30];=0x0820E170
    cmp r3,r10
    beq @@CheckBytes
    ldr r3,[pc,0x30];=0x0820E178
    cmp r3,r10
    beq @@CheckBytes
    ldr r3,[pc,0x30];=0x0820E1A8
    cmp r3,r10
    beq @@CheckBytes
    b @@Origin_Back
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    .word 0x0820E170
    nop
    nop
    .word 0x0820E178
    .word 0x0820E1A8
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
 @@Origin_Back_pre:    ;0x08209F30
    nop
 @@Origin_Back:    ;0x08209F32
    ldrb r3,[r5,0]
    ldr r2,[r2,4]
    lsl r3,r3,2
    add r7,r2,r3
    ldr r3,[pc,4];=0x0801AFC8|1
    bx r3
    nop
    .word 0x0801AFC9
    nop
    nop
    nop
    nop
    nop
    nop
 @@CheckBytes:    ;0x08209F50
    ldrb r3,[r5,0]
    cmp r3,0x6B
    ble @@Origin_Back_pre
    cmp r3,0x80
    bge @@Origin_Back_pre
    cmp r3,0x6F
    ble @@ChsSmall_Back
    cmp r3,0x79
    ble @@ChsBig_Back
    b @@Origin_Back_pre
    nop
    nop
    nop
    nop
    nop
    nop
 @@ChsSmall_Back:    ;0x08209F70
    sub r3,0x6C
    lsl r3,r3,8
    add r5,1
    ldrb r2,[r5,0]
    add r3,r3,r2
    mov r2,2
    lsl r2,r2,8
    add r2,0x10
    lsl r3,r3,2
    add r3,r3,r2
    ldr r2,[r1,0]
    ldr r2,[r2,4]
    add r7,r2,r3
    ldrh r3,[r0,0x30]
    add r3,1
    strh r3,[r0,0x30]
    ldr r3,[pc,0];=0x0801AFC8|1
    bx r3
    .word 0x0801AFC9
    nop
    nop
    nop
    nop
 @@ChsBig_Back:    ;0x08209FA0
    sub r3,0x70
    lsl r3,r3,8
    add r5,1
    ldrb r2,[r5,0]
    add r3,r3,r2
    mov r2,2
    lsl r2,r2,8
    add r2,0x14
    lsl r3,r3,2
    add r3,r3,r2
    ldr r2,[r1,0]
    ldr r2,[r2,4]
    add r7,r2,r3
    ldrh r3,[r0,0x30]
    add r3,1
    strh r3,[r0,0x30]
    ldr r3,[pc,0];=0x0801AFC8|1
    bx r3
    .word 0x0801AFC9
    nop
    nop
    nop
    nop
.endfunc


.org 0x08209FD0
.func FontHack_2
 @@CheckAddress:    ;0x08209FD0
    ldr r0,[pc,0x10];=0x0820E178
    cmp r0,r11
    beq @@CheckBytes
    ldr r0,[pc,0x10];=0x0820E1A8
    cmp r0,r11
    beq @@CheckBytes
    b @@Origin_Back
    nop
    nop
    nop
    .word 0x0820E178
    .word 0x0820E1A8
    nop
    nop
 @@CheckBytes:  ;0x08209FF0
    ldr r0,[r2,0]
    ldrb r0,[r0,2]
    cmp r0,0x10
    beq @@ChsBig_Back
    cmp r0,0xD
    beq @@ChsSmall_Back
    nop
    nop
 @@Origin_Back: ;0x0820A000
    mov r0,r11
    ldr r1,[r0,0]
    ldr r0,[r2,0]
    ldr r3,[r1,0]
    ldrh r2,[r0,0]
    ldr r5,[pc,4];=0x08016DF2|1
    bx r5
    nop
    .word 0x08016DF3
    nop
    nop
    nop
    nop
    nop
    nop
 @@ChsBig_Back:   ;0x0820A020
    ldr r0,[r2,0]
    ldrh r2,[r0,0]
    lsl r2,r2,0x8
    mov r1,r11
    ldr r1,[r1,0]
    ldr r3,[r1,0]
    add r5,r2,r3
    ldr r3,[pc,8];=0x3F10
    add r5,r5,r3
    ldr r3,[pc,8];=0x08016DF4|1
    bx  r3
    nop
    .word 0x00003F10
    .word 0x08016DF5
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
 @@ChsSmall_Back:   ;0x0820A050
    ldr r0,[r2,0]
    ldrh r2,[r0,0]
    mov r1,0xB0
    mul r2,r1
    mov r1,r11
    ldr r1,[r1,0]
    ldr r3,[r1,0]
    add r5,r2,r3
    ldr r3,[pc,8];=0x2A74
    add r5,r5,r3
    ldr r3,[pc,8];=0x08016DF4|1
    bx  r3
    nop
    nop
    .word 0x00002A74
    .word 0x08016DF5
    nop
    nop
    nop
    nop
    nop
    nop
.endfunc

.org 0x0820A080
.func FontHack_3
 @@CheckAddress:    ;0x0820A080
    ldr r5,[pc,0x30];=0x0820E170
    cmp r0,r5
    beq @@CheckBytes
    ldr r5,[pc,0x30];=0x0820E178    //补充火神程序缺失的地址修复
    cmp r0,r5
    beq @@CheckBytes
    b @@Origin_Back
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    .word 0x0820E170
    .word 0x0820E178
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
 @@Origin_Back: ;0x0820A0D0
    ldr r2,[r5,0]
    ldrh r3,[r7,0]
    mov r1,0
    add r2,r2,r3
    ldr r3,[pc,0];=0x0800623E|1
    bx  r3
    .word 0x0800623F
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
 @@CheckBytes:  ;0x0820A0F0
    ldr r5,[r0,0]
    ldr r7,[r4,0]
    ldrb r3,[r7,2]
    cmp r3,0x10
    beq @@ChsBig_Back
    b @@Origin_Back
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
 @@ChsBig_Back:  ;0x0820A110
    ldr r7,[r4,0]
    ldr r2,[r5,0]
    ldrh r3,[r7,0]
    lsl r3,r3,8
    add r3,0x10
    mov r1,0x3F
    lsl r1,r1,8
    add r3,r3,r1
    add r2,r2,r3
    mov r1,0
    ldr r3,[pc,0];=0x0800623E|1
    bx r3
    .word 0x0800623F
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
.endfunc


.org 0x0820A140
.func FontHack_4
 @@CheckAddress:    ;0x0820A140
    ldr r5,[pc,0x30];=0x0820E1A8
    cmp r0,r5
    beq @@CheckBytes
    b @@Origin_Back
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    .word 0x0820E1A8
    nop
    nop
    nop
    nop
 @@Origin_Back:     ;0x0820A180
    ldr r5,[r7,0]
    ldr r0,[r0,0]
    ldrh r3,[r5,0]
    ldr r2,[r0,0]
    mov r1,0
    add r6,r2,r3
    ldr r3,[pc,0];=0x080092A0|1
    bx r3
    .word 0x080092A1
    nop
    nop
    nop
    nop
    nop
    nop
 @@CheckBytes:      ;0x0820A1A0
    ldr r5,[r1,0]
    ldrb r3,[r5,2]
    cmp r3,0xD
    beq @@ChsSmall_Back
    b @@Origin_Back
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
 @@ChsSmall_Back:    ;0x0820A1C0
    ldrh r3,[r5,0]
    ldr r2,[r0,0]
    ldr r2,[r2,0]
    mov r1,0xB0
    mul r3,r1
    add r6,r2,r3
    ldr r3,[pc,8];=0x2A74
    add r6,r6,r3
    mov r1,0
    ldr r3,[pc,8];=0x080092A0|1
    bx r3
    nop
    .word 0x00002A74
    .word 0x080092A1
    nop
    nop
    nop
    nop
    nop
    nop
    nop
    nop
.endfunc

.org 0x09000000
 FontBig:
 .incbin ".\graphic\fonts\fontBig.bin"

.org 0x0913C710
 FontBig_offset:
 .incbin ".\graphic\fonts\fontBig_offset.bin"

.org 0x0913F034
 FontSmall:
 .incbin ".\graphic\fonts\fontSmall.bin"

.org 0x0916D7E8
 FontSmall_offset:
 .incbin ".\graphic\fonts\fontSmall_offset.bin"
