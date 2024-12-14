.arm
.org 0x09B00000
Intro_chs:
    .fill 0xBC,0x0
    ldr r1,[pc,0x44];=0x04000000
    ldr r0,[pc,0x44];=0x0403
    strt r0,[r1],0x0
    ldr r0,[pc,0x40];=0x06000000
    ldr r1,[pc,0x40];=Intro_Gfx
    ldr r3,[pc,0x40];=0x4B00
 @@Loop1:
    ldrt r2,[r1],0x4
    strt r2,[r0],0x4
    subs r3,r3,1
    bne @@Loop1
 @@Loop2:
    ldr r8,[pc,0x30];=0x04000130
    ldrt r6,[r8],0
    ands r7,r6,1
    beq 0x080000C0
    ands r7,r6,2
    beq 0x080000C0
    ands r7,r6,8
    beq 0x080000C0
    b @@Loop2
 ;.pool
    .word 0x04000000
    .word 0x0403
    .word 0x06000000
    .word Intro_Gfx;0x09B00120
    .word 0x4B00
    .word 0x04000130
.thumb
.org 0x09B00120
 Intro_Gfx:
    .incbin ".\graphic\intro\intro.bin"
